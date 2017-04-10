using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.DTO.SGE;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;
using Ext.Net;


namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.EstadoOT
{
    public partial class EstadoOT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {

                List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();
                this.Store1.DataSource = olistaEstadoOT;
                this.Store1.DataBind();
                this.BtnGrabar.Hide();
                this.btnCancelar.Hide();
                this.CodigoEstadoOTField.Disabled = true;


            }
        }

        
        protected void btnGrabar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            EstadoOTDTO oEstadoOTDTO = new EstadoOTDTO();
            oEstadoOTDTO.CodigoEstadoOT = CodigoEstadoOTField.Text;
            oEstadoOTDTO.DescripcionEstado = DescripcionEstadoField.Text;
            if (oEstadoOTDTO.CodigoEstadoOT.Length != 0)
            {

                EstadoOTBL oEstadoOTBL = new EstadoOTBL();
                oEstadoOTBL.Insert(oEstadoOTDTO.CodigoEstadoOT, oEstadoOTDTO.DescripcionEstado, 1);
                Ext.Net.X.Msg.Alert("Nuevo Registro", "Registro Grabado").Show();
                List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();
                this.Store1.DataSource = olistaEstadoOT;
                this.Store1.DataBind();
                this.CodigoEstadoOTField.Text = "";
                this.DescripcionEstadoField.Text = "";
                this.btnNuevo.Show();
                this.BtnGrabar.Hide();
                this.Button1.Show();
                //this.BtnCancelar.Hide();
                this.CodigoEstadoOTField.Disabled = false;
                this.GridPanel1.Disabled = false;
                this.FormPanel1.Title = "Detalle";
            }
        }

        //protected void btnActualizar_Click(object sender, Ext.Net.DirectEventArgs e)
        [DirectMethod] 
        public void Actualizar(string idregistro)
        {
            EstadoOTDTO oEstadoOTDTO = new EstadoOTDTO();
            oEstadoOTDTO.CodigoEstadoOT = CodigoEstadoOTField.Text;
            oEstadoOTDTO.DescripcionEstado = DescripcionEstadoField.Text;
            if (oEstadoOTDTO.DescripcionEstado.Length != 0)
            {
            EstadoOTBL oEstadoOTBL = new EstadoOTBL();
            oEstadoOTBL.Update(oEstadoOTDTO.CodigoEstadoOT, oEstadoOTDTO.DescripcionEstado, 1);
            Ext.Net.X.Msg.Alert("Actualizar Registro", "Registro Actualizado").Show();
            List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();
            this.Store1.DataSource = olistaEstadoOT;
            this.Store1.DataBind();
            this.FormPanel1.Title = "Detalle";
            }

        }

       


        
        protected void gridCommand(object sender, Ext.Net.DirectEventArgs e)
        {
            string CommandName = e.ExtraParams["cmdName"];
            string ID = e.ExtraParams["Id"];
            if (CommandName == "Delete")
            {
                EstadoOTBL oEstadoOTBL = new EstadoOTBL();
                oEstadoOTBL.Delete(ID);
                List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();
                this.Store1.DataSource = olistaEstadoOT;
                this.Store1.DataBind();
                X.Msg.Notify("Actualizar EstadoOT", "Registro eliminado").Show();  
                //Ext.Net.X.Msg.Alert("Actualizar datos", "Registro Elminado").Show();
            }
            else if (CommandName == "Edit")
            {
                Ext.Net.X.Msg.Alert("Editar", ID).Show();
            }
        }

        [DirectMethod] 
        public void Eliminar(string ID)
        {
                EstadoOTBL oEstadoOTBL = new EstadoOTBL();
                oEstadoOTBL.Delete(ID);
                List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();
                this.Store1.DataSource = olistaEstadoOT;
                this.Store1.DataBind();
                X.Msg.Notify("Actualizar EstadoOT", "Registro eliminado").Show();

        }

        [DirectMethod] 
        public void UpdateMsg() 
            //public void UpdateMsg(object sender, DirectEventArgs e) 
        { X.Msg.Notify("Current Server Time: ", DateTime.Now.ToLongTimeString()).Show(); } 
    }
}