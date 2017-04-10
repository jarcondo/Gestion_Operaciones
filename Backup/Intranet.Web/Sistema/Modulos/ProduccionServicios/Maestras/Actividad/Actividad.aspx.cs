using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.ProduccionServicios.Maestra;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.Actividad
{
    public partial class Actividad : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.InicializarControles();
        }

        private void InicializarControles()
        {
            this.CargarCombos();
            this.BtnGrabar.Hide();
            this.btnCancelar.Hide();
            this.CodigoActividadField.Disabled = true;
        }

        private void CargarGrilla()
        {
            this.StoreActividad.DataSource = new ActividadBL().ListarActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
            this.StoreActividad.DataBind();
        }

        private void CargarCombos()
        {
            List<ObraDTO> olObra = (List<ObraDTO>)Session["session.obraCP.intranet"];
            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            if (olObra.Count == 1)
                this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
        }

        protected void MostrarActividad(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        [DirectMethod]
        public void Eliminar(int IdRegistro)
        {
            new ActividadBL().EliminarActividad(IdRegistro,Usuario.IdUsuario);
            this.CargarGrilla();
        }


        [DirectMethod]
        public void ActualizarActividad(int IdRegistro)
        {
            try
            {
                ActividadDTO oAct = new ActividadBL().ListarActividadPorID(IdRegistro);
                oAct.CodMap = this.CodMapField.Text;
                oAct.Descripcion1 = this.Descripcion1Field.Text.ToUpper();
                oAct.Descripcion2 = this.Descripcion2Field.Text.ToUpper();
                new ActividadBL().ActualizarActividad(oAct, Usuario.IdUsuario);
                this.CargarGrilla();
            }
            catch
            {
                this.Mensaje("No se pudo actualizar el registro.");
            }
        }

        protected void btnGrabar_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            ActividadDTO oAct = new ActividadDTO();
            oAct.CodigoActividad = this.CodigoActividadField.Text.ToUpper();
            oAct.CodMap = this.CodMapField.Text;
            oAct.Obra = new ObraDTO()
            {
                IdObra = Convert.ToInt32(this.ddlObra.SelectedItem.Value),
            };
            oAct.Descripcion1 = this.Descripcion1Field.Text.ToUpper();
            oAct.Descripcion2 = this.Descripcion2Field.Text.ToUpper();
            if (oAct.CodigoActividad.Length != 0)
            {

                new ActividadBL().InsertarActividad(oAct, Usuario.IdUsuario);
                Ext.Net.X.Msg.Alert("Nuevo Registro", "Registro Grabado").Show();
                this.CargarGrilla();
                this.CodigoActividadField.Text = "";
                this.CodMapField.Text = "";
                this.Descripcion1Field.Text = "";
                this.Descripcion2Field.Text = "";
                this.btnNuevo.Show();
                this.BtnGrabar.Hide();
                this.Button1.Show();
                //this.BtnCancelar.Hide();
                this.CodigoActividadField.Disabled = false;
                this.GridPanel1.Disabled = false;
                this.FormPanel1.Title = "Detalle";
            }
            else
                this.Mensaje("DEBE INGRESAR EL CÓDIGO DE LA ACTIVIDAD");
        }
        
    }
}