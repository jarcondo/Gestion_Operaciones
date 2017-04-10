using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Ext.Net;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using System.Configuration;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.Global;
using System.Data;
namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos
{
    public partial class CargaConsumo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InicializarControles();
            }
        }

        private void InicializarControles()
        {
            try
            {
                List<ObraDTO> olObra = new List<ObraDTO>();
                if (Usuario.IdRol != 1 && Usuario.IdRol != 6)
                    olObra = new ObraBL().ListarObra(Usuario.IdBase).Where(x => x.CP == true).ToList();
                else
                    olObra = new ObraBL().ListarObraTodas().Where(x => x.CP == true).ToList();

                if (olObra == null) return;
                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void Button1_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                int obra = 0;
                if (string.IsNullOrEmpty(this.ddlObra.SelectedItem.Text))
                {
                    this.Mensaje("DEBE SELECCIONAR OBRA.");
                    return;
                }
                else
                    obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);

                //List<CabeceraConsumoDTO> olCabecerasActualizar = (List<CabeceraConsumoDTO>)Session["Cabeceras.Consumo.Actualizar"];
                //List<CabeceraConsumoDTO> olCabecerasInsertar = (List<CabeceraConsumoDTO>)Session["Cabeceras.Consumo.Insertar"];
                //List<DetalleConsumoDTO> olDetallesInsertar = (List<DetalleConsumoDTO>)Session["Detalles.Consumo.Insertar"];
                DataTable cab = (DataTable)Session["Cabeceras.Consumo.Insertar"];
                DataTable det = (DataTable)Session["Detalles.Consumo.Insertar"];
                obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                new ConsumoMaterialBL().ProcesarOTs(obra, Usuario.IdUsuario);
                if (new CargaConsumoBL().CargarConsumoServidor(Convert.ToInt32(this.ddlObra.SelectedItem.Value), Usuario.IdUsuario,cab,det) == eEstadoTransaccion.Correctamente)
                {
                    this.Mensaje("Archivos importados exitosamente!.");
                }
                else
                    this.Mensaje("No se pudo importar los archivos.");


                //if (new CargaConsumoBL().CargarConsumoServidor(Convert.ToInt32(this.ddlObra.SelectedItem.Value), Usuario.IdUsuario, olCabecerasInsertar, olCabecerasActualizar, olDetallesInsertar) == eEstadoTransaccion.Correctamente)
                //{
                //    this.Mensaje("Archivos importados exitosamente!.");
                //}
                //else
                //    this.Mensaje("No se pudo importar los archivos.");
            }
            catch(Exception ex)
            {
                this.Mensaje(ex.Message);
            }
            finally
            {
                Session["Cabeceras.Consumo.Insertar"] = null;
                Session["Cabeceras.Consumo.Actualizar"] = null;
                Session["Detalles.Consumo.Insertar"] = null;
            }

        }

        protected void btnCargarArchivos_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.fupCabecera.PostedFile.FileName) && !String.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                {
                    var fileName = "SGIO_CONSUMO_C_";
                    fileName += (Usuario.IdBase + 100).ToString().Substring(1, 2);
                    fileName += (Convert.ToInt32(this.ddlObra.SelectedItem.Value) + 100).ToString().Substring(1, 2);
                    fileName += (DateTime.Now.Day + 100).ToString().Substring(1, 2);
                    fileName += (DateTime.Now.Month + 100).ToString().Substring(1, 2);
                    fileName += DateTime.Now.Year.ToString();
                    fileName += (DateTime.Now.Hour + 100).ToString().Substring(1, 2);
                    fileName += (DateTime.Now.Minute + 100).ToString().Substring(1, 2);
                    fileName += (DateTime.Now.Second + 100).ToString().Substring(1, 2);
                    fileName += ".xls";

                    var rutaTemporal = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString() + fileName;
                    this.fupCabecera.PostedFile.SaveAs(rutaTemporal);
                    this.hdRutaCabecera.Value = rutaTemporal;
                    this.hdNombreCabecera.Value = fileName;

                    var fileName2 = "SGIO_CONSUMO_D_";
                    fileName2 += (Usuario.IdBase + 100).ToString().Substring(1, 2);
                    fileName2 += (Convert.ToInt32(this.ddlObra.SelectedItem.Value) + 100).ToString().Substring(1, 2);
                    fileName2 += (DateTime.Now.Day + 100).ToString().Substring(1, 2);
                    fileName2 += (DateTime.Now.Month + 100).ToString().Substring(1, 2);
                    fileName2 += DateTime.Now.Year.ToString();
                    fileName2 += (DateTime.Now.Hour + 100).ToString().Substring(1, 2);
                    fileName2 += (DateTime.Now.Minute + 100).ToString().Substring(1, 2);
                    fileName2 += (DateTime.Now.Second + 100).ToString().Substring(1, 2);
                    fileName2 += ".xls";

                    var rutaTemporal2 = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString() + fileName2;
                    this.fupDetalle.PostedFile.SaveAs(rutaTemporal2);
                    this.hdRutaDetalle.Value = rutaTemporal2;
                    this.hdNombreDetalle.Value = fileName2;

                    List<CabeceraConsumoDTO> olCabeceras = new List<CabeceraConsumoDTO>();
                    List<CabeceraConsumoDTO> olCabecerasActualizar = new List<CabeceraConsumoDTO>();
                    List<CabeceraConsumoDTO> olCabecerasInsertar = new List<CabeceraConsumoDTO>();
                    string strMensaje = "";
                    

                    



                    //List<DetalleConsumoDTO> olDetalles = new CargaConsumoBL().CargarConsumoCliente(rutaTemporal, rutaTemporal2, ref olCabeceras,
                    //    ref strMensaje, Usuario.CentroServicio, Usuario.NroContrato, Usuario.EstadoCarga, Convert.ToInt32(this.ddlObra.SelectedItem.Value),
                    //     ref olCabecerasActualizar, ref olCabecerasInsertar);

                    DataTable cab=new DataTable();
                    DataTable det =new DataTable();
                    DataTable datosgrilla = new DataTable();

                    new CargaConsumoBL().CargarConsumoCliente(rutaTemporal, rutaTemporal2, ref datosgrilla, ref cab, ref det, ref strMensaje, Usuario.CentroServicio,
                        Usuario.NroContrato,Usuario.EstadoCarga,Convert.ToInt32(this.ddlObra.SelectedItem.Value),this.Usuario.IdUsuario);

                    if (String.IsNullOrEmpty(strMensaje))
                    {
                        //this.StoreCarga.DataSource = olCabeceras;
                        this.StoreCarga.DataSource = datosgrilla;
                        this.StoreCarga.DataBind();
                        /*
                        Session["Cabeceras.Consumo.Insertar"] = olCabecerasInsertar;
                        Session["Cabeceras.Consumo.Actualizar"] = olCabecerasActualizar;
                        Session["Detalles.Consumo.Insertar"] = olDetalles;
                        */
                        Session["Cabeceras.Consumo.Insertar"] = cab;
                        //Session["Cabeceras.Consumo.Actualizar"] = new object() ;
                        Session["Detalles.Consumo.Insertar"] = det;

                    }
                    else
                    {
                        this.Mensaje(strMensaje.ToUpper());
                    }
                }
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }
    }
}