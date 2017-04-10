using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Ext.Net;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.Actividad
{
    public partial class SubActividad : BasePage
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
            this.BtnGrabar.Hide();
            this.btnCancelar.Hide();
            this.CodigoSubActividadField.Disabled = true;
        }

        private void CargarCombos()
        {
            List<ObraDTO> olObra = (List<ObraDTO>)Session["session.obraCP.intranet"];
            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            if (olObra.Count == 1)
            {
                this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                this.StoreActividad.DataSource = new ActividadBL().ListarActividad(olObra[0].IdObra);
                this.StoreActividad.DataBind();
            }
        }

        protected void CargarActividad(object sender, DirectEventArgs e)
        {
            this.StoreActividad.DataSource = new ActividadBL().ListarActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
            this.StoreActividad.DataBind();
        }

        protected void CargarSubActividad(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            this.StoreSubActividad.DataSource = new SubActividadBL().ObtenerSubActividad(Convert.ToInt32(this.ddlObra.SelectedItem.Value),Convert.ToInt32(this.ddlActividad.SelectedItem.Value));
            this.StoreSubActividad.DataBind();
        }

        [DirectMethod]
        public void Eliminar(int IdRegistro)
        {
            new SubActividadBL().EliminarSubActividad(IdRegistro, Usuario.IdUsuario);
            this.CargarGrilla();
        }


        [DirectMethod]
        public void ActualizarActividad(int IdRegistro)
        {
            try
            {
                SubActividadDTO oSubAct = new SubActividadBL().ListarSubActividadPorID(IdRegistro);
                oSubAct.CodMap =Convert.ToInt32( this.CodMapField.Text);
                oSubAct.DescripcionSubActividad1 = this.DescripcionSubActividad1Field.Text.ToUpper();
                oSubAct.DescripcionSubActividad2 = this.DescripcionSubActividad2Field.Text.ToUpper();
                oSubAct.Unidad = this.UnidadField.Text.ToUpper();
                oSubAct.CostoProgramado = Convert.ToDecimal(this.CostoProgramadoField.Text);
                oSubAct.Puntaje = Convert.ToDecimal(this.PuntajeField.Text);
                oSubAct.Observacion = this.ObservacionField.Text.ToUpper();
                oSubAct.TrabajoComplementario = this.TrabajoComplementarioField.Checked;
                oSubAct.Resane = this.ResaneField.Checked;
                oSubAct.TTeorico = tteoricold.Text == "" ? 0 : Convert.ToDecimal(this.tteoricold.Text);

                new SubActividadBL().ActualizarSubActividad(oSubAct, Usuario.IdUsuario);
                this.CargarGrilla();
                this.CodigoSubActividadField.Text = "";
                this.CodMapField.Text = "";
                this.DescripcionSubActividad1Field.Text = "";
                this.DescripcionSubActividad2Field.Text = "";
                this.UnidadField.Text = "";
                this.CostoProgramadoField.Text = "";
                this.PuntajeField.Text = "";
                this.ObservacionField.Text = "";
                this.TrabajoComplementarioField.Checked = false;
                this.ResaneField.Checked = false;
                this.btnNuevo.Show();
                this.BtnGrabar.Hide();
                this.Button1.Show();
                //this.BtnCancelar.Hide();
                this.CodigoSubActividadField.Disabled = false;
                this.GridPanel1.Disabled = false;
                this.FormPanel1.Title = "Detalle";
            }
            catch
            {
                this.Mensaje("No se pudo actualizar el registro.");
            }
        }

        protected void btnGrabar_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            SubActividadDTO oSubAct = new SubActividadDTO();
            oSubAct.CodigoSubActividad = this.CodigoSubActividadField.Text.ToUpper();
            oSubAct.CodMap = Convert.ToInt32(this.CodMapField.Text);
            oSubAct.Actividad = new ActividadDTO()
            {
                IdActividad = Convert.ToInt32(this.ddlActividad.SelectedItem.Value),
            };
            oSubAct.DescripcionSubActividad1 = this.DescripcionSubActividad1Field.Text.ToUpper();
            oSubAct.DescripcionSubActividad2 = this.DescripcionSubActividad2Field.Text.ToUpper();
            oSubAct.Unidad = this.UnidadField.Text.ToUpper();
            oSubAct.CostoProgramado = Convert.ToDecimal(this.CostoProgramadoField.Text);
            oSubAct.Puntaje = Convert.ToDecimal(this.PuntajeField.Text);
            oSubAct.Observacion = this.ObservacionField.Text.ToUpper();
            oSubAct.TrabajoComplementario = this.TrabajoComplementarioField.Checked;
            oSubAct.Resane = this.ResaneField.Checked;
            oSubAct.TTeorico = tteoricold.Text=="" ? 0 : Convert.ToDecimal(this.tteoricold.Text);


            if (oSubAct.CodigoSubActividad.Length != 0)
            {

                new SubActividadBL().InsertarSubActividad(oSubAct, Usuario.IdUsuario);
                Ext.Net.X.Msg.Alert("Nuevo Registro", "Registro Grabado").Show();
                this.CargarGrilla();
                this.CodigoSubActividadField.Text = "";
                this.CodMapField.Text = "";
                this.ddlActividad.SelectedItem.Value = "";
                this.DescripcionSubActividad1Field.Text = "";
                this.DescripcionSubActividad2Field.Text = "";
                this.UnidadField.Text = "";
                this.CostoProgramadoField.Text = "";
                this.PuntajeField.Text = "";
                this.ObservacionField.Text = "";
                this.TrabajoComplementarioField.Checked = false;
                this.ResaneField.Checked = false;
                this.btnNuevo.Show();
                this.BtnGrabar.Hide();
                this.Button1.Show();
                //this.BtnCancelar.Hide();
                this.CodigoSubActividadField.Disabled = false;
                this.GridPanel1.Disabled = false;
                this.FormPanel1.Title = "Detalle";
            }
            else
                this.Mensaje("DEBE INGRESAR EL CÓDIGO DE LA ACTIVIDAD");
        }
    }
}