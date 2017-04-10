﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Intranet.BL.SGE;
using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Reportes;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.Utilities;
using Intranet.Web.AppCode;
using Intranet.BL.ProduccionServicios.Maestra;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.PermisoMunicipal
{
    public partial class PermisosMunicipales : BasePage
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
        }

        private void CargarCombos()
        {
            try
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
                    this.CargaCuadrilla();
                }

                List<GenericaDTO> olGenerica = new GenericaBL().GetGenerica(eTabla.TipoTrabajo);
                olGenerica.Insert(0, new GenericaDTO() { IdGenerica = 0, A2 = "TODOS" });
                this.StoreTipoTrabajo.DataSource = olGenerica;
                this.StoreTipoTrabajo.DataBind();
                this.ddlTipoTrabajo.SelectedItem.Value = "0";

                List<EstadoOTDTO> olEstado = new List<EstadoOTDTO>();
                olEstado = new EstadoOTBL().ListarEstadoOT();
                olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 6 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();

                if (olEstado == null) return;
                this.StoreEstadoOT1.DataSource = olEstado;
                this.StoreEstadoOT1.DataBind();

                //olEstado.Insert(0, new EstadoOTDTO() { IdEstadoOT = 0, DescripcionEstado = "TODOS" });
                //this.StoreEstadoOT.DataSource = olEstado;
                //this.StoreEstadoOT.DataBind();
                //this.ddlEstado.SelectedItem.Value = "0";
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarCuadrilla(object sender, DirectEventArgs e)
        {
            this.CargaCuadrilla();
        }

        private void CargaCuadrilla()
        {
            try
            {

                List<CuadrillaDTO> olCuadrilla = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value)).OrderBy(x => x.Descripcion).ToList();
                olCuadrilla.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                this.StoreCuadrilla.DataSource = olCuadrilla;
                this.StoreCuadrilla.DataBind();
                this.ddlCuadrilla.SelectedItem.Value = "0";
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void CargarReporte(object sender, DirectEventArgs e)
        {
            try
            {
                if (this.ddlObra.SelectedIndex >= 0)
                {
                    int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                    int cuadrilla = Convert.ToInt32(this.ddlCuadrilla.SelectedItem.Value);
                    int tipo = Convert.ToInt32(this.ddlTipoTrabajo.SelectedItem.Value);

                    string estado = "";
                    if (this.mslEstado.SelectedItems.Count > 0)
                    {
                        foreach (SelectedListItem item in this.mslEstado.SelectedItems)
                        {
                            estado += item.Value + ",";
                        }
                        estado = estado.Substring(0, estado.Length - 1);
                    }
                    else
                    {
                        this.Mensaje("DEBE SELECCIONAR POR LO MENOS UN ESTADO");
                        return;
                    }

                    string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
                    string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();

                    if (fDesde == null || fHasta == null)
                    {
                        this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA SU REPORTE");
                        return;
                    }

                    bool permiso = this.chkPermisoMunicipal.Checked;
                    List<PermisoMunicipalDTO> olOTProgramacion = new EjecucionOTBL().ObtenerProgramacionPermisoMunicipal(obra, cuadrilla, tipo, estado, permiso, fDesde, fHasta);

                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/PermisoMunicipal/rptPermisoMuni.rpt";
                    Session["Intranet.VisorReporte.Data"] = olOTProgramacion;
                    this.ResourceManager1.AddScript(Controles.MostrarPopUp("../VisorReporte.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
                }
                else
                    this.Mensaje("DEBE SELECCIONAR LA OBRA.");
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }
    }
}