using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.UI;
using Intranet.Web.AppCode;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Ext.Net;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.BL.ProduccionServicios.Proceso;
using Intranet.DTO.Global;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.EjecucionOT
{
    public partial class MantMasivoEjecucionOT : BasePage
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
                List<ObraDTO> olObra = (List<ObraDTO>)Session["session.obraCP.intranet"];
                if (olObra != null)
                {
                    this.StoreObra.DataSource = olObra;
                    this.StoreObra.DataBind();
                    if (olObra.Count == 1)
                    {
                        this.ddlObra.SelectedItem.Value = olObra[0].IdObra.ToString();
                        this.CargarCuadrillaFiltro();
                    }
                }

                List<EstadoOTDTO> olestado = (List<EstadoOTDTO>)Session["session.estadoOT.intranet"];
                if (olestado != null)
                {
                    this.StoreEstado.DataSource = olestado;
                    this.StoreEstado.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }

        }

        protected void CargarCuadrillasFiltro(object sender, DirectEventArgs e)
        {
            this.CargarCuadrillaFiltro();
        }

        private void CargarCuadrillaFiltro()
        {
            try
            {
                List<CuadrillaDTO> olCuadrillaFiltro = new List<CuadrillaDTO>();
                olCuadrillaFiltro = new CuadrillaBL().GetCuadrillasMantenimiento(Convert.ToInt32(this.ddlObra.SelectedItem.Value));
                //olCuadrillaFiltro.Insert(0, new CuadrillaDTO() { IdCuadrilla = 0, Descripcion = "TODOS" });
                if (olCuadrillaFiltro != null)
                {
                    this.StoreCuadrillaFiltro.DataSource = olCuadrillaFiltro;
                    this.StoreCuadrillaFiltro.DataBind();
                    //this.ddlCuadrillaFiltro.SelectedItem.Value = "0";
                }
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void btnBuscarTodos_Click(object sender, DirectEventArgs e)
        {
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                string fDesde = this.txtFDesde.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFDesde.Text).ToShortDateString();
                string fHasta = this.txtFHasta.Text.Contains("0001") ? null : Convert.ToDateTime(this.txtFHasta.Text).ToShortDateString();
           
                if (fDesde == null || fHasta == null)
                {
                    this.Mensaje("DEBE SELECCIONAR LAS FECHAS DE INICIO Y FIN PARA LA ACCION");
                    return;
                }
           
                List<EjecucionOTMasivaGridDTO> olEjecucion = new List<EjecucionOTMasivaGridDTO>();
                int obra = Convert.ToInt32(this.ddlObra.SelectedItem.Value);
                olEjecucion = new EjecucionOTBL().GetEjecucionOTPorObra(obra, "0", 0, "0", "0", 0, fDesde, fHasta, "0", 0);
                

                if (olEjecucion != null)
                {
                    Session["Session.Data.Masiva"] = olEjecucion;
                    this.StoreEjecucionOT.DataSource = olEjecucion;
                    this.StoreEjecucionOT.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void btnAsignar_Click(object sender, DirectEventArgs e)
        {
            try
            {
                List<EjecucionOTMasivaGridDTO> data = (List<EjecucionOTMasivaGridDTO>)Session["Session.Filtro.Masiva"];
                int cuadrilla = Convert.ToInt32(this.ddlCuadrillaFiltro.SelectedItem.Value);
                int estado = Convert.ToInt32(this.ddlPEstado.SelectedItem.Value);
                if (new EjecucionOTBL().AsignarMasivoCuadrillaEstado(data, cuadrilla, estado, Usuario.IdUsuario) == eResultado.Correcto)
                    this.Mensaje("ASIGNACIÓN REALIZADA.");
                else
                    this.Mensaje("NO SE PUDO REALIZAR LA ASIGNACIÓN.");
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            try
            {
                List<EjecucionOTMasivaGridDTO> data = (List<EjecucionOTMasivaGridDTO>)Session["Session.Data.Masiva"];

                string s = e.Parameters[this.GridFilters1.ParamPrefix];


                //-- start filtering ------------------------------------------------------------
                if (!string.IsNullOrEmpty(s))
                {
                    FilterConditions fc = new FilterConditions(s);

                    foreach (FilterCondition condition in fc.Conditions)
                    {
                        Comparison comparison = condition.Comparison;
                        string field = condition.Name;
                        FilterType type = condition.FilterType;

                        object value;
                        switch (condition.FilterType)
                        {
                            case FilterType.Boolean:
                                value = condition.ValueAsBoolean;
                                break;
                            case FilterType.Date:
                                value = condition.ValueAsDate;
                                break;
                            case FilterType.List:
                                value = condition.ValuesList;
                                break;
                            case FilterType.Numeric:
                                if (data.Count > 0 && data[0].GetType().GetProperty(field).PropertyType == typeof(int))
                                {
                                    value = condition.ValueAsInt;
                                }
                                else
                                {
                                    value = condition.ValueAsDouble;
                                }

                                break;
                            case FilterType.String:
                                value = condition.Value.ToUpper();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        data.RemoveAll(
                            item =>
                            {
                                object oValue = item.GetType().GetProperty(field).GetValue(item, null);
                                IComparable cItem = oValue as IComparable;

                                switch (comparison)
                                {
                                    case Comparison.Eq:

                                        switch (type)
                                        {
                                            case FilterType.List:
                                                return !(value as ReadOnlyCollection<string>).Contains(oValue.ToString());
                                            case FilterType.String:
                                                return !oValue.ToString().ToUpper().StartsWith(value.ToString());
                                            default:
                                                return !cItem.Equals(value);
                                        }

                                    case Comparison.Gt:
                                        return cItem.CompareTo(value) < 1;
                                    case Comparison.Lt:
                                        return cItem.CompareTo(value) > -1;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        );
                    }
                }
                //-- end filtering ------------------------------------------------------------

                if (data != null)
                {
                    Session["Session.Filtro.Masiva"] = data;
                    this.GridPanel1.GetStore().DataSource = data;
                }
            }
            catch (Exception ex)
            {
                this.Mensaje(ex.Message);
            }
        }
    }
}