using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.Utilities;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.Web.AppCode;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Stock
{
    public partial class rptStock : BasePage
    {
        MovimientoAlmacenBL oMovimientoAlmacenBL = new MovimientoAlmacenBL();
        
        List<StockDTO> olistStockDTO2 = new List<StockDTO>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarDatos();
            }
        }

        void CargarDatos()
        {
            olistStockDTO2 = oMovimientoAlmacenBL.ReporteStock();
            Session["Intranet.VisorReporte.Data"] = olistStockDTO2;
            StoreStock.DataSource = olistStockDTO2;
            StoreStock.DataBind();
        }
        protected void MostrarReporte(object sender, DirectEventArgs e)
        {

            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/Stock/rptStockCrystal.rpt";
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }

        protected void BuscarxCodoDes(object sender, DirectEventArgs e)
        {
            List<StockDTO> olistStockDTO = new List<StockDTO>();
            if (tfCodoDes.Text.Trim().Length == 0)
            {
                CargarDatos();
                
            }
            else
            {
                
                StoreStock.DataSource = olistStockDTO;
                olistStockDTO = (List<StockDTO>)(from item in oMovimientoAlmacenBL.ReporteStock() where (item.CodigoProducto.ToString().StartsWith(tfCodoDes.Text.ToUpper()) | item.Descripcion1.ToUpper().Contains(tfCodoDes.Text.ToUpper())) select item).ToList();
                Session["Intranet.VisorReporte.Data"] = olistStockDTO;
                StoreStock.DataSource = olistStockDTO;
                StoreStock.DataBind();
            }
        }
    }
}