using System;
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
using Intranet.BL.SGE;
using Intranet.Web.AppCode;
using Intranet.Utilities;
using Intranet.DTO.Global;


namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CruceMaterial
{
    public partial class RegistroCruceMaterial : BasePage //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                List<ObraDTO> olObra = new List<ObraDTO>();
                ObraBL oObraBL = new ObraBL();
                List<EmpleadoDTO> oListaEmpleado = new List<EmpleadoDTO>();
                CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
                int IdEmpleadoIni = 0;
                oListaEmpleado = oCruceMaterialBL.ListarEmpleadoCargo(Usuario.IdBase);

                if (Usuario.IdRol != 1)
                { 
                    
                    olObra = oObraBL.ListarObra(Usuario.IdBase);
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();
                    int IdObraIni = olObra.ElementAt(0).IdObra;
                    if (Usuario.IdRol == 18 || Usuario.IdRol == 19 || Usuario.IdRol == 15 || Usuario.IdRol == 16 )
                    {
                    
                    }
                    else
                    {
                        oListaEmpleado = (List<EmpleadoDTO>)(from item in oListaEmpleado
                                                             where item.IdEmpleado == Usuario.IdEmpleado
                                                             select item).ToList();
                    }

                             IdEmpleadoIni = oListaEmpleado.ElementAt(0).IdEmpleado;

                    
                     List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
                     oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(IdObraIni, IdEmpleadoIni);
                     this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
                     this.StoreCruceMaterial.DataBind();
                     this.Responsable.Enabled = false;
                
                }
                else { 
                    
                    olObra = oObraBL.ListarObraTodas();
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();
                    int IdObraIni = olObra.ElementAt(0).IdObra;
                
                }


               

               
             
                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();

                this.StoreEmpleado.DataSource = oListaEmpleado;
                this.StoreEmpleado.DataBind();

            

               

               

                List<GenericaDTO> oListaTipoMaterial = new List<GenericaDTO>();
                GenericaBL oGenericaBL = new GenericaBL();
                oListaTipoMaterial = oGenericaBL.GetGenerica(DTO.Global.eTabla.TipoMaterial);
                this.StoreTipoMaterial.DataSource = oListaTipoMaterial;
                this.StoreTipoMaterial.DataBind();

                //List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
                //oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(IdObraIni,0);
                //this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
                //this.StoreCruceMaterial.DataBind();
                this.FormPanel1.Hide();
                this.BtnCancelar.Hide();
                this.BtnGrabar.Hide();
                this.FechaIni.Hide();
                this.FechaFin.Hide();
                this.CbTipoMaterial.Hide();

                this.StoreReporte.DataSource = new object[]
                    {
                        new object[]{1, "Cruce de Materiales"},            
                        new object[]{2, "Detalle Almacen y Produccion"}, 
                        new object[]{3, "Detalle Almacen y Teorico"} 

                    };

                this.StoreReporte.DataBind();


            }

        }

        [DirectMethod]
        public void Eliminar(int IdCruceMaterial)
        {
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            oCruceMaterialBL.CruceMaterialDelete(IdCruceMaterial);
            List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
            oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
            this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
            this.StoreCruceMaterial.DataBind();

            X.Msg.Notify("Actualizar Registro", "Registro Eliminado").Show();


            //AuxiliarProductoDTO oAuxiliarProductoDTO = new AuxiliarProductoDTO();       
            //oAuxiliarProductoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            //AuxiliarProductoBL oAuxiliarProductoBL = new AuxiliarProductoBL();
            //oAuxiliarProductoBL.Eliminar(oAuxiliarProductoDTO);
            //List<AuxiliarProductoDTO> olistaAuxiliarProductoDTO = new AuxiliarProductoBL().ListarAuxiliarProducto(Convert.ToInt32(this.Obra.Text));
            //X.Msg.Notify("Actualizar Registro", "Registro Eliminado").Show();
        }



        [DirectMethod]
        public void MostrarCrucematerial(string cFecIni, string cFecFin, int ID ,string cTipoMaterial)
        {

            string FechaIni = Convert.ToDateTime(cFecIni).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(cFecFin).ToString("dd-MM-yyyy");



            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            CuadrillaBL oCuadrillaBL = new CuadrillaBL();
            List<CuadrillaDTO> oListaCuadrilla = new List<CuadrillaDTO>();
            List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();

            if (cTipoMaterial == "Valorizable")
            {
                oListaCruceMaterial = oCruceMaterialBL.ListarCruceMaterial(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, ID, Convert.ToInt32(this.Responsable.Text));
                this.StoreDetalleCruceMaterial.DataSource = oListaCruceMaterial;
            }
            else {
                oListaCruceMaterial = oCruceMaterialBL.ListarCruceMaterialNoValorizable(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, ID, Convert.ToInt32(this.Responsable.Text));
                this.StoreDetalleCruceMaterial.DataSource = oListaCruceMaterial;
            }
            Session["ListaCruceMaterial"] = oListaCruceMaterial;
            this.StoreDetalleCruceMaterial.DataBind();

            oListaCuadrilla = oCuadrillaBL.ListarCuadrillaPorResponsable(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));

            CuadrillaDTO oCuadrillaDTO = new CuadrillaDTO();
            oCuadrillaDTO.IdCuadrilla = 0;
            oCuadrillaDTO.Descripcion = "TODOS";
            oCuadrillaDTO.CodigoCuadrilla = "TODOS";
            oListaCuadrilla.Add(oCuadrillaDTO);

            this.StoreCuadrilla.DataSource=oListaCuadrilla;
            this.StoreCuadrilla.DataBind();


            this.StoreCuadrillaReporte.DataSource=oListaCuadrilla;
            this.StoreCuadrillaReporte.DataBind();

            
        }
        protected void Command_Handler(object sender, DirectEventArgs e)
        {
            //X.Msg.Alert("Server", "Hello!").Show();
        }


        protected void Store_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            
        }

        //protected void RefreshZona(object sender, StoreRefreshDataEventArgs e)
        //{
        //    this.Window1.Show();
        //}

        [DirectMethod]
        public void Actualizar(string DescripcionAuxiliar)
        {
            AuxiliarProductoDTO oAuxiliarProductoDTO = new AuxiliarProductoDTO();
            oAuxiliarProductoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            AuxiliarProductoBL oAuxiliarProductoBL = new AuxiliarProductoBL();
            oAuxiliarProductoBL.Insert(oAuxiliarProductoDTO);
            List<AuxiliarProductoDTO> olistaAuxiliarProductoDTO = new AuxiliarProductoBL().ListarAuxiliarProducto(Convert.ToInt32(this.Obra.Text));
            Ext.Net.X.Msg.Alert("Actualizar Registro", "Registro Actualizado").Show();
        }

        [DirectMethod]
        public void Grabar()
        {
            CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO = new CabeceraCruceMaterialDTO();

            oCabeceraCruceMaterialDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            oCabeceraCruceMaterialDTO.IdResponsable = Convert.ToInt32(this.Responsable.Text);
            oCabeceraCruceMaterialDTO.TipoMaterial = Convert.ToInt32(this.CbTipoMaterial.Text);
            oCabeceraCruceMaterialDTO.FechaInicial = Convert.ToDateTime(this.FechaIni.Text);
            oCabeceraCruceMaterialDTO.FechaFinal = Convert.ToDateTime(this.FechaFin.Text);

            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            eResultado Resultado =  oCruceMaterialBL.CabeceraCruceMaterialInsert(oCabeceraCruceMaterialDTO);
            if (Resultado == eResultado.Error)
            {

                Ext.Net.X.Msg.Alert("Nuevo Cruce", "Las Fechas de Inicio y Fin ya existen").Show();
                return;
            }
            else
            {

                List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
                oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
                this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
                this.StoreCruceMaterial.DataBind();

                Ext.Net.X.Msg.Alert("Actualizar Registro", "El registro se grabó correctamente").Show();
            }
        }


        protected void BtnBuscarCruceMatResponsable(object sender, DirectEventArgs e)
        {

            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
            oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
            this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
            this.StoreCruceMaterial.DataBind();

            //try
            //{
            //    this.CargarGrilla();
            //}
            //catch (Exception ex)
            //{
            //    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
            //}

        }

        [DirectMethod]
        public void GrabarEnProceso()
        {
            ObservacionCrucematerialDTO oObservacionCrucematerialDTO = new ObservacionCrucematerialDTO();

            oObservacionCrucematerialDTO.Cantidad = Convert.ToDecimal(this.CantidadEnProceso.Text);
            oObservacionCrucematerialDTO.IdAuxiliar = Convert.ToInt32(this.IdAuxiliarEnProceso.Text);
            oObservacionCrucematerialDTO.IdCabeceraCruceMaterial = Convert.ToInt32(this.IdCruceField.Text);
            oObservacionCrucematerialDTO.IdTipoObservacion = 1;
            oObservacionCrucematerialDTO.Observacion = this.ObservacionEnProceso.Text;
            oObservacionCrucematerialDTO.OrdenTrabajo = this.OTEnProceso.Text;
            oObservacionCrucematerialDTO.CodigoCuadrilla = this.CodigoCuadrillaEnProceso.Text;

            //this.ItemEnProceso.Text;

            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            oCruceMaterialBL.CruceMaterialObservacionInsert(oObservacionCrucematerialDTO);
            List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
            oListaCruceMaterial = (List<CruceMaterialDTO>)Session["ListaCruceMaterial"];
            var result2 = (from item in oListaCruceMaterial where item.Item ==Convert.ToInt32(this.ItemEnProceso.Text) select item).First();
            result2.EnProceso = Convert.ToDecimal(this.CantidadEnProceso.Text);
            result2.Observacion = this.ObservacionEnProceso.Text;
            result2.OrdenTrabajo = this.OTEnProceso.Text;

            if (this.TipoMaterialField.Text == "Valorizable")
            {
                result2.Diferencia = result2.CantidadAlmacen - result2.CantidadEjecutada - result2.EnProceso - result2.Justificado;
                result2.MontoAuxiliar = result2.Diferencia * result2.PrecioAuxiliar;
            }
            else {
                result2.Diferencia = result2.CantidadAlmacen - result2.Teorico - result2.EnProceso - result2.Justificado;
                result2.MontoAuxiliar = result2.Diferencia * result2.PrecioAuxiliar;
            }
            //result2.Justificado = Convert.ToInt32(this.CantidadJustificacion.Text);
            //result2.Observacionjustificacion = this.ObservacionJustificacion.Text;
            //oListaCruceMaterial = (List<CruceMaterialDTO>)result2..ToList();

            this.VentanaEnProceso.Hide();

            //string FechaIni = Convert.ToDateTime(this.FechaIncialField.Text).ToString("yyyy-MM-dd");
            //string FechaFin = Convert.ToDateTime(this.FechaFinalField.Text).ToString("yyyy-MM-dd");
            //CruceMaterialBL oCruceMaterialBL2 = new CruceMaterialBL();






            //if (this.TipoMaterialField.Text == "Valorizable")
            //{

            //    this.StoreDetalleCruceMaterial.DataSource = oListaCruceMaterial; //oCruceMaterialBL2.ListarCruceMaterial(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.IdCruceField.Text), Convert.ToInt32(this.Responsable.Text));
            //}
            //else {

            //    this.StoreDetalleCruceMaterial.DataSource = oListaCruceMaterial;  //oCruceMaterialBL2.ListarCruceMaterialNoValorizable(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.IdCruceField.Text), Convert.ToInt32(this.Responsable.Text));
            //}
            //this.StoreDetalleCruceMaterial.DataBind();



            Session["ListaCruceMaterial"] = oListaCruceMaterial;
            Ext.Net.X.Msg.Alert("Material en Proceso", "Se Actualizo el registro correctamente").Show();
            

        }



        [DirectMethod]
        public void GrabarJustificacion()
        {
            ObservacionCrucematerialDTO oObservacionCrucematerialDTO = new ObservacionCrucematerialDTO();

            oObservacionCrucematerialDTO.Cantidad = Convert.ToDecimal(this.CantidadJustificacion.Text);
            oObservacionCrucematerialDTO.IdAuxiliar = Convert.ToInt32(this.IdAuxiliarJustificacion.Text);
            oObservacionCrucematerialDTO.IdCabeceraCruceMaterial = Convert.ToInt32(this.IdCruceField.Text);
            oObservacionCrucematerialDTO.IdTipoObservacion = 2;
            oObservacionCrucematerialDTO.Observacion = this.ObservacionJustificacion.Text;
            oObservacionCrucematerialDTO.OrdenTrabajo = " ";
            oObservacionCrucematerialDTO.CodigoCuadrilla = this.CodigoCuadrillaJustificacion.Text;


            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            oCruceMaterialBL.CruceMaterialObservacionJustificacionInsert(oObservacionCrucematerialDTO);


            this.VentanaJustificacion.Hide();

            string FechaIni = Convert.ToDateTime(this.FechaIncialField.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFinalField.Text).ToString("dd-MM-yyyy");
            CruceMaterialBL oCruceMaterialBL2 = new CruceMaterialBL();

            List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
            oListaCruceMaterial = (List<CruceMaterialDTO>)Session["ListaCruceMaterial"];
            var result2 = (from item in oListaCruceMaterial where item.Item == Convert.ToInt32(this.ItemJustificacion.Text) select item).First();
          
            result2.Justificado = Convert.ToDecimal(this.CantidadJustificacion.Text);
            result2.Observacionjustificacion = this.ObservacionJustificacion.Text;

            if (this.TipoMaterialField.Text == "Valorizable")
            {
                result2.Diferencia = result2.CantidadAlmacen - result2.CantidadEjecutada - result2.EnProceso - result2.Justificado;
                result2.MontoAuxiliar = result2.Diferencia * result2.PrecioAuxiliar;
            }
            else
            {
                result2.Diferencia = result2.CantidadAlmacen - result2.Teorico - result2.EnProceso - result2.Justificado;
                result2.MontoAuxiliar = result2.Diferencia * result2.PrecioAuxiliar;
            }


            //if (this.TipoMaterialField.Text == "Valorizable")
            //{
            //    this.StoreDetalleCruceMaterial.DataSource = oListaCruceMaterial; //oCruceMaterialBL2.ListarCruceMaterial(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.IdCruceField.Text), Convert.ToInt32(this.Responsable.Text));
            //}
            //else {
            //    this.StoreDetalleCruceMaterial.DataSource = oListaCruceMaterial;  //oCruceMaterialBL2.ListarCruceMaterialNoValorizable(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.IdCruceField.Text), Convert.ToInt32(this.Responsable.Text));
            //}
            //this.StoreDetalleCruceMaterial.DataBind();


            Session["ListaCruceMaterial"] = oListaCruceMaterial;
            Ext.Net.X.Msg.Alert("Material Justificado", "Se Actualizo el registro correctamente").Show();


        }



        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            //this.Store1.DataSource = (List<AuxiliarCatalogoDTO>)Session["olCatalogo"];
            //this.Store1.DataBind();
        }

        [DirectMethod]
        public void btnImprimir(string DescripcionObra, string CheckDiferencia)
        {
            string FechaIni = Convert.ToDateTime(this.FechaIncialField.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFinalField.Text).ToString("dd-MM-yyyy");
            int OpcionCuadrilla =Convert.ToInt32(this.cbCuadrillaReporte.Text);
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CruceMaterialDTO> olistaCruceMaterial = new List<CruceMaterialDTO>();
            
            olistaCruceMaterial = (List<CruceMaterialDTO>)Session["ListaCruceMaterial"];
            if (CheckDiferencia == "true")
            {
                olistaCruceMaterial = (List<CruceMaterialDTO>)(from item in olistaCruceMaterial
                                                               where item.Diferencia >= 0 || item.Observacion.Trim().Length !=0
                                                               select item).ToList();
            }

            if (OpcionCuadrilla == 0) { }
            else
            {
                olistaCruceMaterial = (List<CruceMaterialDTO>)(from item in olistaCruceMaterial
                                                      where item.IdCuadrilla == OpcionCuadrilla
                                                      select item).ToList();
            }

            foreach (CruceMaterialDTO item in olistaCruceMaterial)
            {
                if (item.Diferencia >= 0)
                {

                    item.MontoAuxiliar2 = item.MontoAuxiliar;

                }
                else {
                    item.MontoAuxiliar2 = 0;
                }


            }


           // olistaCruceMaterial = oCruceMaterialBL.ListarCruceMaterial(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.IdCruceField.Text),Convert.ToInt32(this.Responsable.Text));

            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceMaterial/CruceMaterial.rpt";
            Session["Intranet.VisorReporte.Data"] = olistaCruceMaterial;
            Session["Intranet.VisorReporte.Base"] = Usuario.Base;// "Base Chorrillos";
            Session["Intranet.VisorReporte.Obra"] = DescripcionObra;
            Session["Intranet.VisorReporte.Periodo"] = "Del " + this.FechaIncialField.Text+ " Al " + this.FechaFinalField.Text;
            Session["Intranet.VisorReporte.Responsable"] = this.DescripcionResposableField.Text; // "jorge diaz aguilar";
            Session["Intranet.VisorReporte.TipoMaterial"] = this.TipoMaterialField.Text;
            Session["Intranet.VisorReporte.IdCruce"]=Convert.ToInt32(this.IdCruceField.Text).ToString();
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/CruceMaterial/RptVisorCruceMaterial.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }



        [DirectMethod]
        public void btnImprimirCruceDetalle(string DescripcionObra)
        {
            string FechaIni = Convert.ToDateTime(this.FechaIncialField.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFinalField.Text).ToString("dd-MM-yyyy");
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CruceMaterialDTO> olistaCruceMaterial = new List<CruceMaterialDTO>();
            //olistaCruceMaterial = (List<CruceMaterialDTO>)Session["ListaCruceMaterial"];
            if (this.TipoMaterialField.Text == "Valorizable")
            {
                olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetallado(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text), "S");
            }
            else {
                olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetallado(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text), "N");
            }
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceMaterial/CruceMaterialDetallado.rpt";
            Session["Intranet.VisorReporte.Data"] = olistaCruceMaterial;
            Session["Intranet.VisorReporte.Base"] = Usuario.Base;
            Session["Intranet.VisorReporte.Obra"] = DescripcionObra;
            Session["Intranet.VisorReporte.Periodo"] = "Del " + this.FechaIncialField.Text + " Al " + this.FechaFinalField.Text;
            Session["Intranet.VisorReporte.Responsable"] = this.DescripcionResposableField.Text;
            Session["Intranet.VisorReporte.TipoMaterial"] = this.TipoMaterialField.Text;
            Session["Intranet.VisorReporte.IdCruce"] = Convert.ToInt32(this.IdCruceField.Text).ToString();

            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/CruceMaterial/RptVisorCruceMaterialDetallado.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }


        
        [DirectMethod]
        public void ReporteCruceProducto(int idProducto,int IdCuadrilla ,string DescripcionObra)
        {
            string FechaIni = Convert.ToDateTime(this.FechaIncialField.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFinalField.Text).ToString("dd-MM-yyyy");
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CruceMaterialDTO> olistaCruceMaterial = new List<CruceMaterialDTO>();
            if (this.TipoMaterialField.Text == "Valorizable")
            {
                olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetalladoProducto(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text),IdCuadrilla ,"S" ,idProducto);
            }
            else {
                olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetalladoProducto(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), IdCuadrilla, "N", idProducto);
                //olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetallado(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text), "N");
            }
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceMaterial/CruceMaterialDetallado.rpt";
            Session["Intranet.VisorReporte.Data"] = olistaCruceMaterial;
            Session["Intranet.VisorReporte.Base"] = Usuario.Base;// "Base Chorrillos";
            Session["Intranet.VisorReporte.Obra"] = DescripcionObra;
            Session["Intranet.VisorReporte.Periodo"] = "Del " + this.FechaIncialField.Text + " Al " + this.FechaFinalField.Text;
            Session["Intranet.VisorReporte.Responsable"] = this.DescripcionResposableField.Text;
            Session["Intranet.VisorReporte.TipoMaterial"] = this.TipoMaterialField.Text;
            Session["Intranet.VisorReporte.IdCruce"] = Convert.ToInt32(this.IdCruceField.Text).ToString();
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/CruceMaterial/RptVisorCruceMaterialDetallado.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
        }


        [DirectMethod]
        public void btnImprimirCruceDetalleTeorico(string DescripcionObra)
        {
            string FechaIni = Convert.ToDateTime(this.FechaIncialField.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFinalField.Text).ToString("dd-MM-yyyy");
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CruceMaterialDTO> olistaCruceMaterial = new List<CruceMaterialDTO>();
            if (this.TipoMaterialField.Text == "Valorizable")
            {
                Ext.Net.X.Msg.Alert("Reporte Cruce de Materiales", "Este reporte solo aplica para NO VALORIZABLES").Show();

                //olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetallado(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text), "S");
            }
            else
            {
                olistaCruceMaterial = oCruceMaterialBL.ListarRptCruceMaterialDetalladoTeorico(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text), "N");
          
            Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/CruceMaterial/CruceMaterialDetallado2.rpt";
            Session["Intranet.VisorReporte.Data"] = olistaCruceMaterial;
            Session["Intranet.VisorReporte.Base"] = Usuario.Base;
            Session["Intranet.VisorReporte.Obra"] = DescripcionObra;
            Session["Intranet.VisorReporte.Periodo"] = "Del " + this.FechaIncialField.Text + " Al " + this.FechaFinalField.Text;
            Session["Intranet.VisorReporte.Responsable"] = this.DescripcionResposableField.Text;
            Session["Intranet.VisorReporte.TipoMaterial"] = this.TipoMaterialField.Text;
            this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/CruceMaterial/RptVisorCruceMaterialDetallado.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
            }
        }

        [DirectMethod]
        public void ListarCabeceraCruceResponsable()
        {
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
            oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
            this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
            this.StoreCruceMaterial.DataBind();

        }

        [DirectMethod]
        public void ListarResponsableBase()
        {
            List<EmpleadoDTO> oListaEmpleado = new List<EmpleadoDTO>();
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            oListaEmpleado = oCruceMaterialBL.ListarEmpleadoCargo2(Convert.ToInt32(this.Obra.Text));
            this.StoreEmpleado.DataSource = oListaEmpleado;
            this.StoreEmpleado.DataBind();
            this.Responsable.Clear();

            //List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
            //oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
            //this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
            //this.StoreCruceMaterial.DataBind();

        }
        
        [DirectMethod]
        public void ListarCrucePorCuadrilla(string cFecIni, string cFecFin, int ID)
        {

            string FechaIni = Convert.ToDateTime(cFecIni).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(cFecFin).ToString("dd-MM-yyyy");
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();   

            this.StoreDetalleCruceMaterial.DataSource = oCruceMaterialBL.ListarCruceMaterialPorCuadrilla(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, ID, Convert.ToInt32(this.Responsable.Text),Convert.ToInt32(this.cbCuadrilla.Text));
            this.StoreDetalleCruceMaterial.DataBind();

        }


        [DirectMethod]
        public void RevisarCruce(int IdCruce)
        {
            CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO = new CabeceraCruceMaterialDTO();

            oCabeceraCruceMaterialDTO.IdCabeceraCruceMaterial = IdCruce;

            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();
            oCruceMaterialBL.CabeceraCruceMaterialUpdate(oCabeceraCruceMaterialDTO);

            Window1.Hide();

            List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
            oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
            this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
            this.StoreCruceMaterial.DataBind();

            Ext.Net.X.Msg.Alert("Actualizar Registro Cruce Material", "El Registro se actualizo correctamente").Show();

        }


        [DirectMethod]
        public void ListarCrucePorCuadrillaNoValorizable(string cFecIni, string cFecFin, int ID)
        {

            string FechaIni = Convert.ToDateTime(cFecIni).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(cFecFin).ToString("dd-MM-yyyy");
            CruceMaterialBL oCruceMaterialBL = new CruceMaterialBL();

            this.StoreDetalleCruceMaterial.DataSource = oCruceMaterialBL.ListarCruceMaterialPorCuadrillaNoValorizable(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, ID, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrilla.Text));
            this.StoreDetalleCruceMaterial.DataBind();

        }





    }
}