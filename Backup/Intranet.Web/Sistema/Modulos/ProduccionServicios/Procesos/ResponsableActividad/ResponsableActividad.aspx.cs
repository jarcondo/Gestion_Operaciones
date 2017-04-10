using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.SGE;
using Ext.Net;
using Intranet.BL.SGE;
using Intranet.DTO.Global;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ResponsableActividad
{
    public partial class ResponsableActividad : BasePage
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
            List<ObraDTO> olObra=(List<ObraDTO>)Session["session.obraCP.intranet"];
            this.StoreObra.DataSource = olObra;
            this.StoreObra.DataBind();
            if (olObra.Count == 1)
            {
                this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                this.CargarActividades(olObra[0].IdObra);
                this.CargarGrilla(olObra[0].IdObra);
            }

            this.StoreArea.DataSource = new GenericaBL().GetGenerica(eTabla.Area);
            this.StoreArea.DataBind();

        }

        protected void CargarActividad(object sender, DirectEventArgs e)
        {
            int idObra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
            this.CargarActividades(idObra);
            this.CargarGrilla(idObra);
            
        }

        private void CargarActividades(int IdObra)
        {
            this.StoreActividad.DataSource = new ActividadBL().ListarActividad(IdObra);
            this.StoreActividad.DataBind();

            this.StoreResponsable.DataSource = new EmpleadoBL().ObtenerResponsables(IdObra);
            this.StoreResponsable.DataBind();
        }

        private void CargarGrilla(int idObra)
        {
            this.StoreAsignacion.DataSource = new ResponsableActividadBL().ObtenerResponsableActividad(idObra);
            this.StoreAsignacion.DataBind();
        }

        [DirectMethod]
        public void Eliminar(int IdRegistro)
        {
            new ResponsableActividadBL().EliminarResponsableActividad(IdRegistro, Usuario.IdUsuario);
            this.CargarGrilla(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
        }

        [DirectMethod]
        public void Editar(int IdRegistro)
        {
            ResponsableActividadDTO oResAct = new ResponsableActividadBL().ObtenerResponsableActividadPorID(IdRegistro);
            this.hdnIdRespAct.Text = oResAct.IdResponsableActividad.ToString();
            this.ddlActividad.SelectedItem.Value = oResAct.Actividad.IdActividad.ToString();
            this.ddlArea.SelectedItem.Value = oResAct.Area.IdGenerica.ToString();
            this.ddlResponsable.SelectedItem.Value = oResAct.Responsable.IdEmpleado.ToString();
        }

        protected void CancelarAsignacion(object sender, DirectEventArgs e)
        {
            this.hdnIdRespAct.Text = "";
            this.ddlActividad.SelectedItem.Value = "";
            this.ddlArea.SelectedItem.Value ="";
            this.ddlResponsable.SelectedItem.Value = "";
        }

        protected void GrabarAsignacion(object sender, DirectEventArgs e)
        {
            ResponsableActividadDTO oRes = new ResponsableActividadDTO();
            oRes.Actividad = new ActividadDTO()
            {
                IdActividad = Convert.ToInt32(this.ddlActividad.SelectedItem.Value),
            };
            oRes.Area = new GenericaDTO()
            {
                IdGenerica = Convert.ToInt32(this.ddlArea.SelectedItem.Value),
            };
            oRes.Responsable = new EmpleadoDTO()
            {
                IdEmpleado = Convert.ToInt32(this.ddlResponsable.SelectedItem.Value),
            };
            if (!String.IsNullOrEmpty(this.hdnIdRespAct.Text))
            {
                oRes.IdResponsableActividad = Convert.ToInt32(this.hdnIdRespAct.Text);
                new ResponsableActividadBL().ActualizarResponsableActividad(oRes, Usuario.IdUsuario);
            }
            else
            {
                new ResponsableActividadBL().InsertarResponsableActividad(oRes, Usuario.IdUsuario);
            }

            this.hdnIdRespAct.Text = "";
            this.ddlActividad.SelectedItem.Value = "";
            this.ddlArea.SelectedItem.Value = "";
            this.ddlResponsable.SelectedItem.Value = "";
            this.CargarGrilla(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
        }
    }
}