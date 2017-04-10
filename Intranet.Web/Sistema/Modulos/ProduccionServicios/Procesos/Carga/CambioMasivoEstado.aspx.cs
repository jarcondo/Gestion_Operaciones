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
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.Web.Modulos.ProduccionServicios.Procesos
{
    public partial class CambioMasivoEstado : BasePage
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
            //Combo Obra
            List<ObraDTO> olObra = (List<ObraDTO>)Session["session.obraCP.intranet"];
            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            if (olObra.Count == 1)
                this.Obra.SelectedItem.Value = olObra[0].IdObra.ToString();

            EstadoOTBL oEstadoOTBL = new EstadoOTBL();
            
            List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();

            olistaEstadoOT = (List<EstadoOTDTO>)(from item in olistaEstadoOT
                                     where item.IdEstadoOT <= 45 && item.IdEstadoOT>=2
                                     select item).ToList();

            olistaEstadoOT.Add((EstadoOTDTO)(from item in new EstadoOTBL().ListarEstadoOT()
                                     where item.IdEstadoOT == 148 
                                     select item).Single());

            olistaEstadoOT.Add((EstadoOTDTO)(from item in new EstadoOTBL().ListarEstadoOT()
                                             where item.IdEstadoOT == 100
                                             select item).Single());

            this.StoreEstado.DataSource = olistaEstadoOT;
            this.StoreEstado.DataBind();
            this.cbEstadoOT.SelectedItem.Value = (45).ToString();

            this.btnImportar.Hide();
        }

        protected void btnCargar_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {


                var fileName = "SGIO.TXT";

                var de = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString();

                var rutaTemporal = ConfigurationManager.AppSettings["RutaArchivosTemporales"].ToString() + fileName;

                fupSGIO.SaveAs(rutaTemporal);
                hdNomArchivoTemp.Text = fileName;
                hdArchivoTemp.Text = rutaTemporal;

                List<DatosSGIEstadoDTO> oListaSgiArchivoTxt = new List<DatosSGIEstadoDTO>();
                CambioMasivoEstadoBL oCambioMasivoEstadoBL = new CambioMasivoEstadoBL();
                oListaSgiArchivoTxt=oCambioMasivoEstadoBL.ListarSgiArchivoTexto(Convert.ToInt32(this.Obra.Text),Convert.ToInt32(this.cbEstadoOT.Text));
                this.StoreCarga.DataSource = oListaSgiArchivoTxt;
                this.StoreCarga.DataBind();

                this.btnImportar.Show();
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message.ToUpper());
            }
     
        }

        [DirectMethod]
        public void btnCambiarMasivoEstado_DirectClick()
        {
    
            CambioMasivoEstadoBL oCambioMasivoEstadoBL = new CambioMasivoEstadoBL();
            eEstadoTransaccion emEstadoTransaccion;
            emEstadoTransaccion = oCambioMasivoEstadoBL.CambioMasivoEstadoUpdate(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.cbEstadoOT.Text),Usuario.IdUsuario);
            if (emEstadoTransaccion == eEstadoTransaccion.Correctamente)
            {
                X.Msg.Notify("Actualizacion masiva","Los registros fueron actualizados correctamente").Show();
            }
            else {
                X.Msg.Notify("Actualizacion masiva","No se pudo actualizar los registros....intente nuevamente" ).Show();
            }
        }

        private void Limpiar()
        {
      
        }
    }
}