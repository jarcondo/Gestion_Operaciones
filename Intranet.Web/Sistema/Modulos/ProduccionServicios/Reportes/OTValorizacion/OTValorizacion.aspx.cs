using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.Web.AppCode;
using System.Configuration;
using System.Data;
using System.IO;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.Utilities;

//using System.Configuration;
//using System.Data;



namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.OTValorizacion
{
    public partial class OTValorizacion : BasePage
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
                this.CargarCombos();
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
            }
        }

        private void CargarCombos()
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
            }
        }

        protected void ReporteOTxValo(object sender, DirectEventArgs e)
        {
            this.ReporteOTxValo();
            GridPanel1.ColumnModel.Columns[10].Hidden = true;
            GridPanel1.ColumnModel.Columns[11].Hidden = true;
            GridPanel1.ColumnModel.Columns[12].Hidden = true;
            GridPanel1.ColumnModel.Columns[13].Hidden = true;
            GridPanel1.ColumnModel.Columns[14].Hidden = true;
            GridPanel1.ColumnModel.Columns[15].Hidden = true;
            GridPanel1.ColumnModel.Columns[16].Hidden = true;
            GridPanel1.ColumnModel.Columns[17].Hidden = true;
            GridPanel1.ColumnModel.Columns[18].Hidden = true;
            GridPanel1.ColumnModel.Columns[19].Hidden = true;
            GridPanel1.ColumnModel.Columns[20].Hidden = true;
            GridPanel1.Render();
            
        }

        protected void ReporteOTxDist(object sender, DirectEventArgs e)
        {
            this.ReporteOTxDist();
            GridPanel1.ColumnModel.Columns[0].Hidden = true;
            GridPanel1.ColumnModel.Columns[1].Hidden = true;
            GridPanel1.ColumnModel.Columns[3].Hidden = true;
            GridPanel1.ColumnModel.Columns[4].Hidden = true;
            GridPanel1.ColumnModel.Columns[5].Hidden = true;
            GridPanel1.ColumnModel.Columns[6].Hidden = true;
            GridPanel1.ColumnModel.Columns[7].Hidden = true;
            GridPanel1.ColumnModel.Columns[8].Hidden = true;
            GridPanel1.Render();
        }

        protected void CargarReporte(object sender, DirectEventArgs e)
        {
            //Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/OTValorizacion/OTxValorizacion.rpt";
            //Session["Intranet.VisorReporte.Data"] = StoreOT.DataSource;
            //this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }

        private void ReporteOTxValo()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            List<OTValorizacionDTO> olEjec = new List<OTValorizacionDTO>();

            if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                if (!string.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                {
                    string RutaTemp = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                    string nomArchivo = DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
                    this.fupDetalle.PostedFile.SaveAs(RutaTemp + nomArchivo);
                    DataTable _dt;
                    _dt = new DataTable("ListaSGI");
                    _dt.Columns.Add("SGI", typeof(String));
                    _dt.Columns.Add("MONTO", typeof(Double));

                    foreach (var line in File.ReadAllLines(RutaTemp + nomArchivo))
                    {
                        try
                        {
                            string[] campos = line.Split('\t');
                            if (campos[0].ToString() == "")
                            {
                                break;
                            }
                            _dt.Rows.Add(campos[0], campos[1]);
                        }
                        catch (Exception ex)
                        {
                            new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });

                        }
                    }

                    olEjec = new ConsumoMaterialBL().OTxValorizacion(obra, _dt);

                }
            }

            StoreOT.DataSource = olEjec;
            StoreOT.DataBind();

            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/OTValorizacion/rptOTxValorizacion.rpt";
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));

            
        }

        private void ReporteOTxDist()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            List<OTValorizacionDTO> olEjec = new List<OTValorizacionDTO>();

            if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                if (!string.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                {
                    string RutaTemp = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                    string nomArchivo = DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
                    this.fupDetalle.PostedFile.SaveAs(RutaTemp + nomArchivo);
                    DataTable _dt;
                    _dt = new DataTable("ListaSGI");
                    _dt.Columns.Add("SGI", typeof(String));
                    _dt.Columns.Add("MONTO", typeof(Double));

                    foreach (var line in File.ReadAllLines(RutaTemp + nomArchivo))
                    {
                        try
                        {
                            string[] campos = line.Split('\t');
                            if (campos[0].ToString() == "")
                            {
                                break;
                            }
                            _dt.Rows.Add(campos[0], campos[1]);
                        }
                        catch (Exception ex)
                        {
                            new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });

                        }
                    }

                    olEjec = new ConsumoMaterialBL().OTxDistrito(obra, _dt);

                }
            }

            StoreOT.DataSource = olEjec;
            StoreOT.DataBind();

            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/OTValorizacion/rptOTxDistrito.rpt";
            Session["Intranet.VisorReporte.Data"] = olEjec;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            
        }
    }
}