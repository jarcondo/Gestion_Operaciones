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
using System.Xml;
using System.Xml.Xsl;
using Intranet.BL.ProduccionServicios.Proceso.ConsumoMaterial;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.Global;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.AlcantarilladoD
{
    public partial class rptCargoOTChorrillos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarControles();
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
        public void ObtenerDatosGrilla()
        {
            try
            {
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

                area = this.ddlArea.SelectedItem.Text;

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

                List<CargoOTChorrillosDTO> olCargo = new ConsumoMaterialBL().CargoOTChorrillos(Usuario.IdUsuario, obra, orden, cargo);
                if (olCargo != null)
                {
                    this.StoreCargoSGI.DataSource = olCargo;
                    this.StoreCargoSGI.DataBind();
                }

            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }

        }

        protected void DObtenerDatosGrilla(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
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

                area = this.ddlArea.SelectedItem.Text;

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

                List<CargoOTChorrillosDTO> olCargo = new ConsumoMaterialBL().CargoOTChorrillos(Usuario.IdUsuario, obra, orden, cargo);
                if (olCargo != null)
                {
                    this.StoreCargoSGI.DataSource = olCargo;
                    this.StoreCargoSGI.DataBind();
                }

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

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=CargoOTChorrillos.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }
    }
}