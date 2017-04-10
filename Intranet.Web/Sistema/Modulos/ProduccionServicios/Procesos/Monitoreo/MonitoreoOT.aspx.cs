using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Xml;
using System.Xml.Xsl;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.Web.AppCode;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.Monitoreo
{
    public partial class MonitoreoOT : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                this.CargarGrilla();
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
            }

        }

        protected void RowDblClick_Event(object sender, DirectEventArgs e)
        {
        }


        protected void actualizardata(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        protected void StoreEjecucionOT_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
           this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                string sFecha = DateTime.Now.Date.ToShortDateString();
                string sFechaD = DateTime.Now.Date.ToShortDateString();


                string cliente = "";

                if (Usuario.IdRol==25)
                {
                    cliente = Usuario.EMPRESA;
                }
                else
                {
                    cliente="";
                }
             

                //List<EjecucionOTGridDTO> olEjecucion = new List<EjecucionOTGridDTO>();
                //olEjecucion = new EjecucionOTBL().GetEjecucionOTGridPorObra(20, "0", estado, "0", "", 0, sFechaD, sFecha, "0", cuadrilla, 0);


                List<EjecucionOTGridDTO> olOTProgramacion = new List<EjecucionOTGridDTO>();
                olOTProgramacion = new EjecucionOTBL().MonitoreoOperacion(20, 0, 0, "1,2,3,45,100,154", sFecha, sFechaD, 0, "INICIO", "0",cliente);

               
                this.StoreEjecucionOT.DataSource = olOTProgramacion;
                this.StoreEjecucionOT.DataBind();

            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
               
            }
        }

       

        protected void StoreEjecucionOT_RecordUpdated(object sender, AfterRecordUpdatedEventArgs e)
        {
            // This event is fired once for each Record that is Updated.

            //var company = new
            //{
            //    Name = e.NewValues["company"],
            //    Price = e.NewValues["price"],
            //    LastChange = e.NewValues["lastChange"]
            //};

            //string tpl = "Name: {0}, Price: {1}, LastChange: {2}<br />";
            //this.Label1.Html += string.Format(tpl, company.Name, company.Price, company.LastChange);
        }

    }
}