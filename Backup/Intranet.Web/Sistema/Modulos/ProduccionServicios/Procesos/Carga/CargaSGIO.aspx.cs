using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.BL.SGE;
using Intranet.DTO.SGE;
using Ext.Net;
using Intranet.Web.AppCode;
using Intranet.BL.ProduccionServicios.Maestra;
using System.Configuration;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.ProduccionServicios.Proceso;
using System.IO;
using Intranet.DTO.Global;

namespace Intranet.Web.Modulos.ProduccionServicios.Procesos
{
    
    public partial class CargaSGIO : BasePage
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializarControles();
            }
        }

        private void InicializarControles()
        {
            List<ObraDTO> olObra = new List<ObraDTO>();
            if (Usuario.IdRol != 1 && Usuario.IdRol != 6)
                olObra = new ObraBL().ListarObra(Usuario.IdBase).Where(x => x.CP == true).ToList();
            else
                olObra = new ObraBL().ListarObraTodas().Where(x => x.CP == true).ToList();

            if (olObra == null) return;
            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            if (olObra.Count == 1)
                this.Obra.SelectedItem.Value = olObra[0].IdObra.ToString();
        }

        protected void btnCargar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                var fileName = "SGIO";
                fileName += (Usuario.IdBase + 100).ToString().Substring(1, 2);
                fileName += (Convert.ToInt32(Obra.SelectedItem.Value) + 100).ToString().Substring(1, 2);
                fileName += (DateTime.Now.Day + 100).ToString().Substring(1, 2);
                fileName += (DateTime.Now.Month + 100).ToString().Substring(1, 2);
                fileName += DateTime.Now.Year.ToString();
                fileName += (DateTime.Now.Hour + 100).ToString().Substring(1, 2);
                fileName += (DateTime.Now.Minute + 100).ToString().Substring(1, 2);
                fileName += (DateTime.Now.Second + 100).ToString().Substring(1, 2);
                fileName += ".xls";

                var rutaTemporal = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString() + fileName;
                fupSGIO.SaveAs(rutaTemporal);
                hdNomArchivoTemp.Text = fileName;
                hdArchivoTemp.Text = rutaTemporal;

                string resultado = "";
                List<OrdenTrabajoDTO> olOrden = new OrdenTrabajoBL().CargarOrdenTrabajoCliente(rutaTemporal, ref resultado, Convert.ToInt32(Obra.SelectedItem.Value), Usuario.CentroServicio, Usuario.NroContrato,Usuario.IdUsuario);
                if (resultado != "CORRECTO")
                {
                    olOrden = new List<OrdenTrabajoDTO>();
                    if (resultado != "CORRECTO")
                    {
                        this.Mensaje("EXISTEN INCONSISTENCIAS EN EL ARCHIVO CARGADO. LA INFORMACIÓN NO CORRESPONDE AL CENTRO DE COSTO NI AL CONTRATO REQUERIDO.");
                    }
                    else
                    {
                        this.Mensaje(resultado.ToUpper());
                    }
                }
                this.StoreCarga.DataSource = olOrden;
                this.StoreCarga.DataBind();
                Session["DatosCargados"] = olOrden;
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message.ToUpper());
            }
        }

        protected void btnImportar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                if (Session["DatosCargados"] != null)
                {
                    string archivoTemp = hdArchivoTemp.Text;
                    string archivoDestino = ConfigurationManager.AppSettings["RutaArchivoSGIO"].ToString() + hdNomArchivoTemp.Text;

                    ArchivoCargaOTDTO oArchivoCarga = new ArchivoCargaOTDTO()
                    {
                        IdArchivoCargaOT = 0,
                        ArchivoRuta = archivoDestino,
                        DescripcionCarga = archivoDestino,
                        FechaCarga = DateTime.Now,
                        UsuarioCarga = Usuario.IdUsuario,
                        Obra = new ObraDTO()
                        {
                            IdObra = Convert.ToInt32(Obra.SelectedItem.Value),
                        }
                    };

                    List<OrdenTrabajoDTO> olOrdenTrabajo = (List<OrdenTrabajoDTO>)Session["DatosCargados"];
                    olOrdenTrabajo = (from ol in olOrdenTrabajo where ol.Existe == false select ol).ToList();
                    //List<OrdenTrabajoDTO> olOrdenTrabajoExistentes = (from ol in olOrdenTrabajo where ol.Existe == true select ol).ToList();
                    if (olOrdenTrabajo.Count > 0)
                    {
                        if (new OrdenTrabajoBL().InsertarOrdenTrabajo(oArchivoCarga, olOrdenTrabajo) == eEstadoTransaccion.Correctamente)
                        {
                            File.Copy(archivoTemp, archivoDestino, true);
                            this.Mensaje("Su archivo fue importado exitosamente.");
                        }
                        else
                        {
                            this.Mensaje("No se pudo cargar el archivo. Inténtelo nuevamente.");
                        }
                    }
                    else
                    {
                        this.Mensaje("No existen registros nuevos en el archivo seleccionado.");
                    }
                    this.Limpiar();
                }
                else
                {
                    this.Mensaje("NO EXISTEN DATOS A IMPORTAR!.");
                }
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        private void Limpiar()
        {
            try
            {
                Session["DatosCargados"] = null;

                this.hdArchivoTemp.Text = "";
                this.hdNomArchivoTemp.Text = "";

                List<OrdenTrabajoDTO> olOrden = new List<OrdenTrabajoDTO>();
                this.StoreCarga.DataSource = olOrden;
                this.StoreCarga.DataBind();
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }
    }
}