using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.Utilities;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.SGE;
using Intranet.DTO.Global;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.CargoEntrega
{
    public partial class VerCargoSGI : BasePage
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
            List<ObraDTO> olObra = (List<ObraDTO>)Session["session.obraCP.intranet"];
            if (olObra != null)
            {
                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();
                if (olObra.Count == 1)
                {
                    this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                    List<CargoSIODTO> olCargo = new ConsumoMaterialBL().ObtenerCargo(Convert.ToInt32(this.ddlObra.SelectedItem.Value),Usuario.IdUsuario);
                    if (olCargo == null) return;
                    if (olCargo.Count == 0) return;
                    this.StoreCargo.DataSource = olCargo;
                    this.StoreCargo.DataBind();
                    this.ddlCargo.SelectedItem.Value = olCargo[0].IdCargoEntrega.ToString();
                }
            }
            this.ddlArea.SelectedItem.Value = "";
            this.StoreArea.DataSource = new GenericaBL().GetGenerica(eTabla.Area);
            this.StoreArea.DataBind();

            
        }

        protected void CargosPorObra(object sender, DirectEventArgs e)
        {
            List<CargoSIODTO> olCargo = new ConsumoMaterialBL().ObtenerCargo(Convert.ToInt32(this.ddlObra.SelectedItem.Value),Usuario.IdUsuario);
            if (olCargo == null) return;
            if (olCargo.Count == 0) return;
            this.StoreCargo.DataSource = olCargo;
            this.StoreCargo.DataBind();
            this.ddlCargo.SelectedItem.Value = olCargo[0].IdCargoEntrega.ToString();
        }

        
        
        [DirectMethod]
        public void CargarCargoEntrega(object sender, DirectEventArgs e)
        {
            try
            {
                this.hplRutaTxt.Text = "";
                int obra = 0;
                string area = "";
                string responsable = "";

                if (String.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
                    return;
                }
                else
                    obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);

                //if (String.IsNullOrEmpty(this.ddlArea.SelectedItem.Value))
                //{
                //    this.Mensaje("DEBE SELECCIONAR EL AREA.");
                //    return;
                //}
                //else
                area = this.ddlArea.SelectedItem.Text;


                //if (String.IsNullOrEmpty(this.ddlResponsable.SelectedItem.Value))
                //{
                //    this.Mensaje("DEBE SELECCIONAR EL RESPONSABLE.");
                //    return;
                //}
                //else
                responsable = this.ddlResponsable.SelectedItem.Text;

                string orden = "";
                if (this.rCuadrilla.Checked == false && this.rIngreso.Checked == false)
                {
                    this.Mensaje("DEBE SELECCIONAR EL ORDEN DE LOS DATOS.");
                    return;
                }
                else
                {
                    if (this.rIngreso.Checked == true) orden = "INGRESO";
                    if (this.rCuadrilla.Checked == true) orden = "CUADRILLA";
                }

                int cargo = Convert.ToInt32(this.ddlCargo.SelectedItem.Value);

                List<CargoEntregaDTO> olCargo = new ConsumoMaterialBL().ObtenerCargoEntrega(Usuario.IdUsuario, obra,orden,cargo);
                if (olCargo != null)
                {
                    foreach (var item in olCargo)
                    {
                        item.Area = area;
                        item.Residente = responsable;
                    }

                    this.StoreCargoSGI.DataSource = olCargo;
                    this.StoreCargoSGI.DataBind();
                }
              
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void ImprimirCargoEntrega(object sender, DirectEventArgs e)
        {
            try
            {
                this.hplRutaTxt.Text = "";

                int obra = 0;
                string area = "";
                string responsable = "";

                if (String.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
                    return;
                }
                else
                    obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);

                //if (String.IsNullOrEmpty(this.ddlArea.SelectedItem.Value))
                //{
                //    this.Mensaje("DEBE SELECCIONAR EL AREA.");
                //    return;
                //}
                //else
                area = this.ddlArea.SelectedItem.Text;


                //if (String.IsNullOrEmpty(this.ddlResponsable.SelectedItem.Value))
                //{
                //    this.Mensaje("DEBE SELECCIONAR EL RESPONSABLE.");
                //    return;
                //}
                //else
                responsable = this.ddlResponsable.SelectedItem.Text;

                string orden = "";
                if (this.rCuadrilla.Checked == false && this.rIngreso.Checked == false)
                {
                    this.Mensaje("DEBE SELECCIONAR EL ORDEN DE LOS DATOS.");
                    return;
                }
                else
                {
                    if (this.rIngreso.Checked == true) orden = "INGRESO";
                    if (this.rCuadrilla.Checked == true) orden = "CUADRILLA";
                }

                int cargo = Convert.ToInt32(this.ddlCargo.SelectedItem.Value);

                List<CargoEntregaDTO> olCargo = new ConsumoMaterialBL().ObtenerCargoEntrega(Usuario.IdUsuario, obra,orden,cargo);
                foreach (var item in olCargo)
                {
                    item.Area = area;
                    item.Residente = responsable;
                }

                if(Usuario.IdBase==6)
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CargoEntrega/rptCargoEntregaCallao.rpt";
                else
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CargoEntrega/rptCargoEntrega.rpt";

                Session["Intranet.VisorReporte.Data"] = null;
                Session["Intranet.VisorReporte.Data"] = olCargo;
                this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarResponsablePorArea(object sender, DirectEventArgs e)
        {
            this.CargarResponsable();
        }

        private void CargarResponsable()
        {
            List<ResponsableActividadDTO> oResAct = new ResponsableActividadBL().ObtenerResponsableActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).Where(x => x.Area.IdGenerica == Convert.ToInt32(this.ddlArea.SelectedItem.Value)).ToList();
            List<EmpleadoDTO> oRes = new List<EmpleadoDTO>();
            foreach (var item in oResAct)
            {
                oRes.Add(item.Responsable);
            }
            this.ddlResponsable.SelectedItem.Value = "";
            this.StoreResponsable.DataSource = oRes;
            this.StoreResponsable.DataBind();
        }

        protected void GenerarTXTCargoEntrega(object sender, DirectEventArgs e)
        {
            try
            {
                int obra = 0;
                //int area = 0;
                //int responsable = 0;

                if (String.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
                {
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
                    return;
                }
                else
                    obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);

                //if (String.IsNullOrEmpty(this.ddlArea.SelectedItem.Value))
                //{
                //    this.Mensaje("DEBE SELECCIONAR EL AREA.");
                //    return;
                //}
                //else
                //    area = Convert.ToInt32(this.ddlArea.SelectedItem.Value);


                //if (String.IsNullOrEmpty(this.ddlResponsable.SelectedItem.Value))
                //{
                //    this.Mensaje("DEBE SELECCIONAR EL RESPONSABLE.");
                //    return;
                //}
                //else
                //    responsable = Convert.ToInt32(this.ddlResponsable.SelectedItem.Value);

                string orden="";
                if (this.rCuadrilla.Checked == false && this.rIngreso.Checked == false)
                {
                    this.Mensaje("DEBE SELECCIONAR EL ORDEN DE LOS DATOS.");
                    return;
                }
                else
                {
                    if (this.rIngreso.Checked == true) orden = "INGRESO";
                    if (this.rCuadrilla.Checked == true) orden = "CUADRILLA";
                }

                int cargo = Convert.ToInt32(this.ddlCargo.SelectedItem.Value);

                List<CargoEntregaDTO> olCargo = new ConsumoMaterialBL().ObtenerCargoEntrega(Usuario.IdUsuario, obra, orden,cargo);

                if (olCargo == null)
                {
                    this.Mensaje("NO EXISTEN DATOS!.");
                    return;
                }
                string ruta = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                string nombreFichero = this.ddlCargo.SelectedItem.Text;
                string fic = ruta + nombreFichero + ".txt";

                StreamWriter sw = new StreamWriter(Server.MapPath("TextFiles/" + nombreFichero + ".txt"), false);
                foreach (var item in olCargo)
                {
                    sw.WriteLine(item.SGI);
                }
                sw.Close();

                //string sFileName = "listadoSGI";// System.IO.Path.GetRandomFileName();
                //string sGenName = "Friendly.txt";

                //using (System.IO.StreamWriter SW = new System.IO.StreamWriter(
                //       Server.MapPath("TextFiles/" + sFileName + ".txt")))
                //{
                //    SW.WriteLine("tu may");
                //    SW.Close();
                //}
                //System.IO.FileStream fs = null;
                //fs = System.IO.File.Open(Server.MapPath("TextFiles/" +
                //         sFileName + ".txt"), System.IO.FileMode.Open);
                //byte[] btFile = new byte[fs.Length];
                //fs.Read(btFile, 0, Convert.ToInt32(fs.Length));
                //fs.Close();

                string sHtml = "ARCHIVO GENERADO EXITOSAMENTE. HAGA CLICK <a href='TextFiles/" + nombreFichero + ".txt' target='_blank'>AQUÍ</a> PARA DESCARGAR.";
                Ext.Net.Notification.Show(new NotificationConfig() { Pinned = true, ShowPin = true, Html = sHtml, Title = "SMC GESTION DE OPERACIONES" });

                
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void btnProcesar_click(object sender, DirectEventArgs e)
        {
            //try
            //{
            //    int obra=0;
            //    if(string.IsNullOrEmpty(this.ddlObra.SelectedItem.Text)){
            //        this.Mensaje("DEBE SELECCIONAR OBRA.");
            //        return;
            //    }
            //    else
            //        obra=Convert.ToInt32(this.ddlObra.SelectedItem.Value);

            //    int cargo=Convert.ToInt32(this.ddlCargo.SelectedItem.Value);

            //    new ConsumoMaterialBL().ProcesarOTs(obra, Usuario.IdUsuario);
            //    this.Mensaje("PROCESO EJECUTADO EXITOSAMENTE!.");
            //}
            //catch (Exception ex)
            //{
            //    this.Mensaje(ex.Message);
            //}
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=DATOS_CARGO.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }
    }
}