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

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Reportes.Puntaje
{
    public partial class Puntaje : BasePage  //System.Web.UI.Page
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
                //oListaEmpleado = oCruceMaterialBL.ListarEmpleadoCargo(Usuario.IdBase);

                if (Usuario.IdRol != 1  && Usuario.IdRol != 16)
                {
                    oListaEmpleado = oCruceMaterialBL.ListarEmpleadoCargo(Usuario.IdBase);
                    olObra = oObraBL.ListarObra(Usuario.IdBase);
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();
                    int IdObraIni = olObra.ElementAt(0).IdObra;
                    if (Usuario.IdRol == 18 || Usuario.IdRol == 19 || Usuario.IdRol == 15)
                    {
                        this.Responsable.Enabled = true;
                    }
                    else
                    {
                        oListaEmpleado = (List<EmpleadoDTO>)(from item in oListaEmpleado
                                                             where item.IdEmpleado == Usuario.IdEmpleado
                                                             select item).ToList();
                        IdEmpleadoIni = oListaEmpleado.ElementAt(0).IdEmpleado;
                        //this.Responsable.Enabled = true;
                    }

                    


                    //List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
                    //oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(IdObraIni, IdEmpleadoIni);
                    //this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
                    //this.StoreCruceMaterial.DataBind();
                    

                }
                else
                {
                    //oListaEmpleado = oCruceMaterialBL.ListarEmpleadoCargo3();
                    
                    olObra = oObraBL.ListarObraTodas();
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();
                    int IdObraIni = olObra.ElementAt(0).IdObra;
                    oListaEmpleado = oCruceMaterialBL.ListarEmpleadoCargo2(IdObraIni);
                }


                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();

                this.StoreEmpleado.DataSource = oListaEmpleado;
                this.StoreEmpleado.DataBind();


                //List<GenericaDTO> oListaTipoMaterial = new List<GenericaDTO>();
                //GenericaBL oGenericaBL = new GenericaBL();
                //oListaTipoMaterial = oGenericaBL.GetGenerica(DTO.Global.eTabla.TipoMaterial);
                //this.StoreTipoMaterial.DataSource = oListaTipoMaterial;
                //this.StoreTipoMaterial.DataBind();



            }

        }

        [DirectMethod]
        public void btnImprimirReportePuntaje(string DescripObra, string DescripResponsable,string OpcionReporte)
        {
            string FechaIni = Convert.ToDateTime(this.FechaIni.Text).ToString("dd-MM-yyyy");
            string FechaFin = Convert.ToDateTime(this.FechaFin.Text).ToString("dd-MM-yyyy");
            PuntajeBL oPuntajeBL = new PuntajeBL();
            List<PuntajesDTO>  olistaPuntaje = new List<PuntajesDTO>();
            olistaPuntaje = oPuntajeBL.ListarPuntajeDiario(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin,Convert.ToInt32(this.Responsable.Text),Convert.ToInt32(this.cbCuadrillaReporte.Text));    

            switch (OpcionReporte)
            {
                case "RdgSubactividad": ;
                    olistaPuntaje = oPuntajeBL.ListarPuntajeDiario(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text));    
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/Puntaje/PuntajePorDia.rpt";
                    Session["Intranet.VisorReporte.Data"] = olistaPuntaje;
                    Session["Intranet.VisorReporte.Base"] = Usuario.Base;// "Base Chorrillos";
                    Session["Intranet.VisorReporte.Obra"] = DescripObra; //this.Obra.Text; // DescripcionObra;
                    Session["Intranet.VisorReporte.Periodo"] = "Del " + Convert.ToDateTime(this.FechaIni.Text).ToString("dd/MM/yyyy") + " Al " + Convert.ToDateTime(this.FechaFin.Text).ToString("dd/MM/yyyy");
                    Session["Intranet.VisorReporte.Responsable"] = DescripResponsable; // this.Responsable.Text;
                    this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/Puntaje/RprVisorPuntajeDiario.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
                    break;
                case "Rdgfecha": ;
                    olistaPuntaje = oPuntajeBL.ListarPuntajeFecha(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text));    
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/Puntaje/PuntajeFecha.rpt";
                    Session["Intranet.VisorReporte.Data"] = olistaPuntaje;
                    Session["Intranet.VisorReporte.Base"] = Usuario.Base;// "Base Chorrillos";
                    Session["Intranet.VisorReporte.Obra"] = DescripObra; //this.Obra.Text; // DescripcionObra;
                    Session["Intranet.VisorReporte.Periodo"] = "Del " + Convert.ToDateTime(this.FechaIni.Text).ToString("dd/MM/yyyy") + " Al " + Convert.ToDateTime(this.FechaFin.Text).ToString("dd/MM/yyyy");
                    Session["Intranet.VisorReporte.Responsable"] = DescripResponsable; // this.Responsable.Text;
                    this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/Puntaje/RprVisorPuntajeDiario.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
                    break;
                case "RdgAcumulado": ;
                    olistaPuntaje = oPuntajeBL.ListarPuntajeAcumFecha(Convert.ToInt32(this.Obra.Text), FechaIni, FechaFin, Convert.ToInt32(this.Responsable.Text), Convert.ToInt32(this.cbCuadrillaReporte.Text));
                    Session["Intranet.VisorReporte.Ruta"] = "~/Sistema/Modulos/ProduccionServicios/Reportes/Puntaje/PuntajeAcumFecha.rpt";
                    Session["Intranet.VisorReporte.Data"] = olistaPuntaje;
                    Session["Intranet.VisorReporte.Base"] = Usuario.Base;// "Base Chorrillos";
                    Session["Intranet.VisorReporte.Obra"] = DescripObra; //this.Obra.Text; // DescripcionObra;
                    Session["Intranet.VisorReporte.Periodo"] = "Del " + Convert.ToDateTime(this.FechaIni.Text).ToString("dd/MM/yyyy") + " Al " + Convert.ToDateTime(this.FechaFin.Text).ToString("dd/MM/yyyy");
                    Session["Intranet.VisorReporte.Responsable"] = DescripResponsable; // this.Responsable.Text;
                    this.ResourceManager1.AddScript(Controles.MostrarPopUp("../../Reportes/Puntaje/RprVisorPuntajeDiario.aspx", "no", 900, 500, 30, 10, "no", "yes", "yes", "yes"));
                    break;
                default:
                    break;
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
        public void ListarCuadrillaResponsable()
        {
            CuadrillaBL oCuadrillaBL = new CuadrillaBL();
            List<CuadrillaDTO> oListaCuadrilla = new List<CuadrillaDTO>();
            
            oListaCuadrilla = oCuadrillaBL.ListarCuadrillaPorResponsable(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));

            CuadrillaDTO oCuadrillaDTO = new CuadrillaDTO();
            oCuadrillaDTO.IdCuadrilla = 0;
            oCuadrillaDTO.Descripcion = "TODOS";
            oCuadrillaDTO.CodigoCuadrilla = "TODOS";
            oListaCuadrilla.Add(oCuadrillaDTO);

            this.StoreCuadrillaReporte.DataSource = oListaCuadrilla;
            this.StoreCuadrillaReporte.DataBind();



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
            this.cbCuadrillaReporte.Clear();

            //List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
            //oListaCabeceraCruceMaterial = oCruceMaterialBL.ListarCabeceraCruceMaterial(Convert.ToInt32(this.Obra.Text), Convert.ToInt32(this.Responsable.Text));
            //this.StoreCruceMaterial.DataSource = oListaCabeceraCruceMaterial;
            //this.StoreCruceMaterial.DataBind();

        }

     


     

     




    }
}