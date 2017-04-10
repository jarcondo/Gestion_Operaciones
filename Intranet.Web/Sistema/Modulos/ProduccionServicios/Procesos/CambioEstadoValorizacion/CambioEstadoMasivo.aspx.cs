using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.BL.ProduccionServicios.Maestra;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.BL.ProduccionServicios.Proceso;
using System.Configuration;
using System.IO;
using System.Data;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos
{
    public partial class CambioEstadoMasivo : BasePage
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
            this.CargarCombos();
            
        }

        private void CargarCombos()
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
                if (olObra.Count == 1)
                {
                    this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                    this.CargarValorizacion();
                }

                List<EstadoOTDTO> olEstado = new EstadoOTBL().ListarEstadoOT();
                olEstado = olEstado.Where(x => x.DescripcionEstado == "RESUELTO" || x.DescripcionEstado == "FACTURADO").ToList();
                if (olEstado == null) return;
                if (olEstado.Count == 0) return;
                this.StoreEstado.DataSource = olEstado;
                this.StoreEstado.DataBind();
                this.ddlEstadoOT.SelectedItem.Value = "101";
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
            }
        }

        protected void CargaValorizacionObra(object sender, DirectEventArgs e)
        {
            this.CargarValorizacion();
        }

        [DirectMethod]
        public void btnIngresaValorizacion_Click()
        {
            try
            {
                ValorizacionDTO oVal = new ValorizacionDTO();
                oVal.IdObra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                oVal.CodigoValorizacion = "";
                oVal.Descripcion = this.txtDescripcion.Text.ToUpper();
                oVal.FechaInicio = this.DateField1.Text;
                oVal.FechaFin = this.DateField2.Text;
                oVal.FechaValorizacion = this.DateField3.Text;

                new ValorizacionBL().InsertarValorizacion(oVal, Usuario.IdUsuario);
                this.CargarValorizacion();
                this.Window1.Hide();
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
            }
        }

        private void CargarValorizacion()
        {
            try
            {
                List<ValorizacionDTO> olVal = new ValorizacionBL().ObtenerValorizacion(Convert.ToInt32(this.ddlObra.SelectedItem.Value));

                this.StoreValor.DataSource = olVal;
                this.StoreValor.DataBind();

                this.StoreValorizacion.DataSource = olVal;
                this.StoreValorizacion.DataBind();

            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
            }
        }


        protected void btnCargar_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    if (!string.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                    {
                        string RutaTemp = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                        string nomArchivo = DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
                        this.fupDetalle.PostedFile.SaveAs(RutaTemp + nomArchivo);
                        this.hdnArchivo.Text = RutaTemp + nomArchivo;
                        int indicador = 0;

                        List<CargaSGIs> olCarg = new List<CargaSGIs>();
                        foreach (var line in File.ReadAllLines(RutaTemp + nomArchivo))
                        {
                            string des = this.ValidarSGI(line);
                            if (!string.IsNullOrEmpty(des)) indicador = 1;
                            try
                            {
                                olCarg.Add(new CargaSGIs() { sgi = line, descripcion = "<span style='color:red;'>" + des + "</span>" });
                            }
                            catch (Exception)
                            {
                                
                                
                            }
                            
                        }

                        this.StoreCarga.DataSource = olCarg;
                        this.StoreCarga.DataBind();

                        //if (indicador == 1)
                        //    this.Button2.Disabled = true;
                        //else
                        //    this.Button2.Disabled = false;
                    }
                    else
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE SELECCIONAR EL ARCHIVO DE TEXTO A IMPORTAR", Buttons = Ext.Net.MessageBox.Button.OK });
                }
                else
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE SELECCIONAR LA OBRA", Buttons = Ext.Net.MessageBox.Button.OK });
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
            }
        }

        private string ValidarSGI(string sgi)
        {
            string mensaje="";
            DataRow f = new ValorizacionBL().ValidarSGI(Convert.ToInt32(this.ddlObra.SelectedItem.Value), sgi);

            if (f != null)
            {


                switch (f["IDESTADOOT"].ToString())
                {
                    case "45":
                        mensaje = "Estado: ATENDIDO , ";
                        break;

                    case "101":
                        mensaje = "Estado: FACTURADO , ";
                        break;

                    default:
                        mensaje = "";
                        break;
                }

                switch (f["IDVALORIZACION"].ToString())
                {
                    case "":
                        mensaje += "";
                        break;

                    default:
                        mensaje += "ya fue valorizado.";
                        break;
                }
            }
            return mensaje;
        }

        protected void btnCambiarEstado_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ddlValorizacion.SelectedItem.Value))
                {
                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                    string archivo = this.hdnArchivo.Text;
                    int estado = Convert.ToInt32(this.ddlEstadoOT.SelectedItem.Value);
                    int valorizacion = Convert.ToInt32(this.ddlValorizacion.SelectedItem.Value);
                    foreach (var line in File.ReadAllLines(archivo))
                    {
                        new ValorizacionBL().ActualizarCabeceraValorizacion(obra, line, valorizacion, estado, Usuario.IdUsuario);
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "Se completó el Cambio de Estado!.", Buttons = Ext.Net.MessageBox.Button.OK });
                    }
                }
                else
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = "DEBE SELECCIONAR LA VALORIZACIÓN", Buttons = Ext.Net.MessageBox.Button.OK });
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
            }
        }
    }

    
    class CargaSGIs
    {
        public string sgi { get; set; }
        public string descripcion { get; set; }
    }
}