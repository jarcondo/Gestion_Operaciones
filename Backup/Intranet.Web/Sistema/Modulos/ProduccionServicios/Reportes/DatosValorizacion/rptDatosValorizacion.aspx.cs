using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using System.Xml.Xsl;
using System.Xml;
using Intranet.DTO.ProduccionServicios.Procesos;
using System.Configuration;
using System.IO;
using System.Data;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.DatosValorizacion
{
    public partial class rptDatosValorizacion : BasePage
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
                this.CargarValorizacion();
            }
        }

        protected void CargarDatosValorizacion(object sender, DirectEventArgs e)
        {
            this.CargarValorizacion();
        }

        protected void DObtenerDatosGrilla(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }



        protected void DObtenerExistenciaOT(object sender, DirectEventArgs e)
        {
            this.mDObtenerExistenciaOT();
        }

        protected void DObtenerVerificarMontos(object sender, DirectEventArgs e)
        {
            this.mDObtenerVerificarMontos();
        }

        private void mDObtenerExistenciaOT()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            List<DatosValorizacionDTO> olEjec = new List<DatosValorizacionDTO>();

            if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                if (!string.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                {
                    string RutaTemp = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                    string nomArchivo = DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
                    this.fupDetalle.PostedFile.SaveAs(RutaTemp + nomArchivo);
                    DataTable _dt;
                    _dt = new DataTable("ListaSGI");
                    _dt.Columns.Add("SGI", typeof(Int32));
                    _dt.Columns.Add("MONTO", typeof(Decimal));

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


                    olEjec = new ConsumoMaterialBL().ObtenerDatosExistenciaOT(obra, _dt);

                }
            }

            this.StoreEjecucionOT.DataSource = olEjec;
            this.StoreEjecucionOT.DataBind();
        }

        private void mDObtenerVerificarMontos()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            int valorizacion = Convert.ToInt32(this.ddlValorizacion.SelectedItem.Value);
            List<DatosValorizacionDTO> olEjec = new List<DatosValorizacionDTO>();

            if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                if (!string.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                {
                    string RutaTemp = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                    string nomArchivo = DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
                    this.fupDetalle.PostedFile.SaveAs(RutaTemp + nomArchivo);
                    DataTable _dt;
                    _dt = new DataTable("ListaSGI");
                    _dt.Columns.Add("SGI", typeof(Int32));
                    _dt.Columns.Add("MONTO", typeof(Decimal));

                    foreach (var line in File.ReadAllLines(RutaTemp + nomArchivo))
                    {
                        string[] campos = line.Split('\t');
                        if (campos[0].ToString() == "")
                        {
                            break;
                        }
                        _dt.Rows.Add(campos[0], campos[1]);
                    }


                    olEjec = new ConsumoMaterialBL().ObtenerVerificarMontos(obra, _dt);

                }
                else
                {
                    olEjec = new ConsumoMaterialBL().ObtenerDatosArchivoValidacion(obra, valorizacion);
                    if (olEjec == null) return;
                    if (olEjec.Count == 0)
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                        return;
                    }
                }
            }

            this.StoreEjecucionOT.DataSource = olEjec;
            this.StoreEjecucionOT.DataBind();
        }






        private void CargarGrilla()
        {
            int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            int valorizacion = Convert.ToInt32(this.ddlValorizacion.SelectedItem.Value);
            List<DatosValorizacionDTO> olEjec=new List<DatosValorizacionDTO>();

            if (!string.IsNullOrEmpty(this.ddlObra.SelectedItem.Value))
            {
                if (!string.IsNullOrEmpty(this.fupDetalle.PostedFile.FileName))
                {
                    string RutaTemp = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();
                    string nomArchivo = DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt";
                    this.fupDetalle.PostedFile.SaveAs(RutaTemp + nomArchivo);
                    DataTable _dt;
                    _dt = new DataTable("ListaSGI");
                    _dt.Columns.Add("SGI", typeof(Int32));
                    foreach (var line in File.ReadAllLines(RutaTemp + nomArchivo))
                    {
                        string[] campos = line.Split('\t');
                        if (campos[0].ToString() == "")
                        {
                            break;
                        }

                        _dt.Rows.Add(campos[0]);
                    }


                    olEjec = new ConsumoMaterialBL().ObtenerDatosArchivoValidacion(obra, _dt);

                }
                else
                {
                    olEjec = new ConsumoMaterialBL().ObtenerDatosArchivoValidacion(obra, valorizacion);
                    if (olEjec == null) return;
                    if (olEjec.Count == 0)
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = "No existen datos para las fechas solicitadas.", Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                        return;
                    }
                }
            }
            
            this.StoreEjecucionOT.DataSource = olEjec;
            this.StoreEjecucionOT.DataBind();
        }


        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=DatosValorizacion.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }

        private void CargarValorizacion()
        {
            try
            {
                List<ValorizacionDTO> olVal = new ValorizacionBL().ObtenerValorizacion(Convert.ToInt32(this.ddlObra.SelectedItem.Value));

                this.StoreValor.DataSource = olVal;
                this.StoreValor.DataBind();

            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
            }
        }
    }
}