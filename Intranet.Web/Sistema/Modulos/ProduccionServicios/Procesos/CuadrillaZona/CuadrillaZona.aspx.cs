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

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.CuadrillaZona
{
    public partial class CuadrillaZona : BasePage //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                List<ObraDTO> olObra = new List<ObraDTO>();
                //List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito();
                List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito2(6);

                this.Store1.DataSource = olistaCuadrillaDistritoDTO;
                this.Store1.DataBind();
                List<ObraDistritoDTO> olistaObraDistritoDTO = new ObraDistritoBL().ListarObraDistrito(6);
                this.StoreCombo.DataSource = olistaObraDistritoDTO;
                this.StoreCombo.DataBind();

                List<CuadrillaDistritoDTO> olistaCuadrillaProduccionDTO = new CuadrillaDistritoBL().ListarCuadrillaProduccion(6);
                this.StoreCuadrilla.DataSource = olistaCuadrillaProduccionDTO;
                this.StoreCuadrilla.DataBind();


                List<ZonaDTO> olistaZonaDTO = new ZonaBL().ListarZona2();
                this.ZonaStore.DataSource = olistaZonaDTO;
                this.ZonaStore.DataBind();
                //this.IdCuadrilla.Hide();
                this.IdObra.Hide();
                this.BtnCancelar.Hide();
                this.BtnEliminar.Hide();
                this.BtnGrabar.Hide();
                this.Cuadrilla.Hide();
                this.IdCuadrillaDistrito.Hide();
                this.AccionRegistro.Hide();
                //this.Cuadrilla.Disabled = true;


                ObraBL oObraBL = new ObraBL();


                if (Usuario.IdRol != 1)
                {
                    olObra = oObraBL.ListarObra(Usuario.IdBase);


                }
                else
                {
                    olObra = oObraBL.ListarObraTodas();
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();

                }
                int IdObraIni = olObra.ElementAt(0).IdObra;

                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();
            }
        }

        [DirectMethod]
        public void RefreshZonaAll()
        {
            List<ZonaDTO> olistaZonaDTO = new ZonaBL().ListarZona2();
            Session["zona"] = olistaZonaDTO;
            this.ZonaStore.DataSource = olistaZonaDTO;
            this.ZonaStore.DataBind();
            Ext.Net.X.Msg.Alert("Actualizar Registro", "ggg");
        }

        [DirectMethod]
        public void RefreshZona()
        {
            string v = this.Distrito.SelectedItem.Value;
            List<ZonaDTO> olistaZonaDTO = new ZonaBL().ListarZona(Convert.ToInt32(v));
            Session["zona"] = olistaZonaDTO;
            this.ZonaStore.DataSource = olistaZonaDTO;
            this.ZonaStore.DataBind();
        }

        protected void ZonaRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            string v = this.Distrito.SelectedItem.Value;
            List<ZonaDTO> olistaZonaDTO = new ZonaBL().ListarZona(Convert.ToInt32(v));
            Session["zona"] = olistaZonaDTO;
            this.ZonaStore.DataSource = olistaZonaDTO;
            this.ZonaStore.DataBind();
        }

        [DirectMethod]
        public void Actualizar(string cDistrito, string cZona, string cCodigoCuadrilla, int IdCuadrillaDistrito, int IdDistrito, int IdZona, int IdCuadrilla)
        {
            CuadrillaDistritoDTO oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
            oCuadrillaDistritoDTO.CodigoCuadrilla = CodigoCuadrillaField.Text;
            oCuadrillaDistritoDTO.DescripcionCuadrilla = DescripcionCuadrillaField.Text;
            oCuadrillaDistritoDTO.DescripcionDistrito = cDistrito;
            oCuadrillaDistritoDTO.DescripcionZona = cZona;
            oCuadrillaDistritoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            oCuadrillaDistritoDTO.IdDistrito = IdDistrito; // Convert.ToInt32(this.Distrito.SelectedItem.Value);
            oCuadrillaDistritoDTO.IdZona = IdZona;
            oCuadrillaDistritoDTO.IdCuadrilla = IdCuadrilla;
            oCuadrillaDistritoDTO.IdCuadrillaDistrito = IdCuadrillaDistrito;
            // Convert.ToInt32(this.Zona.SelectedItem.Value);
            //oCuadrillaDistritoDTO.IdCuadrilla = Convert.ToInt32(IdCuadrilla.Text);
            //Ext.Net.X.Msg.Alert("Actualizar Registro", Distrito.DisplayField).Show();
            if (oCuadrillaDistritoDTO.DescripcionDistrito.Length != 0)
            {
                CuadrillaDistritoBL oCuadrillaDistritoBL = new CuadrillaDistritoBL();
                oCuadrillaDistritoBL.CuadrillaDistritoActualizar(oCuadrillaDistritoDTO);

                List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito2(oCuadrillaDistritoDTO.IdObra);
                this.Store1.DataSource = olistaCuadrillaDistritoDTO;
                this.Store1.DataBind();


                Ext.Net.X.Msg.Alert("Actualizar Zona por Cuadrilla", "Registro Actualizado").Show();
            }

        }

        [DirectMethod]
        public void Insertar(string cDistrito, string cZona, string cDescripcionCuadrilla, int IdDistrito, int IdZona, int IdCuadrilla)
        {
            CuadrillaDistritoDTO oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();

            oCuadrillaDistritoDTO.DescripcionCuadrilla = cDescripcionCuadrilla;
            oCuadrillaDistritoDTO.DescripcionDistrito = cDistrito;
            oCuadrillaDistritoDTO.DescripcionZona = cZona;
            oCuadrillaDistritoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            oCuadrillaDistritoDTO.IdDistrito = IdDistrito; // Convert.ToInt32(this.Distrito.SelectedItem.Value);
            oCuadrillaDistritoDTO.IdZona = IdZona;
            oCuadrillaDistritoDTO.IdCuadrilla = IdCuadrilla;
            oCuadrillaDistritoDTO.IdCuadrillaDistrito = 0;


            if (oCuadrillaDistritoDTO.DescripcionDistrito.Length != 0)
            {
                CuadrillaDistritoBL oCuadrillaDistritoBL = new CuadrillaDistritoBL();
                oCuadrillaDistritoBL.CuadrillaDistritoInsert(oCuadrillaDistritoDTO);

                List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito2(oCuadrillaDistritoDTO.IdObra);
                this.Store1.DataSource = olistaCuadrillaDistritoDTO;
                this.Store1.DataBind();
                Ext.Net.X.Msg.Alert("Actualizar Zona por Cuadrilla", "Se agrego el registro").Show();
            }

        }




        [DirectMethod]
        public void Eliminar(int pIdCuadrilla, int pIdObra)
        {
            CuadrillaDistritoDTO oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
            //oCuadrillaDistritoDTO.IdCuadrilla = Convert.ToInt32(this.IdCuadrilla.Text);
            oCuadrillaDistritoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            CuadrillaDistritoBL oCuadrillaDistritoBL = new CuadrillaDistritoBL();
            oCuadrillaDistritoBL.CuadrillaDistritoEliminar(pIdCuadrilla, Convert.ToInt32(this.Obra.Text), pIdCuadrilla);

            List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito2(Convert.ToInt32(this.Obra.Text));
            this.Store1.DataSource = olistaCuadrillaDistritoDTO;
            this.Store1.DataBind();

            X.Msg.Notify("Actualizar Zona por Cuadrilla", "Registro Eliminado").Show();
        }

        [DirectMethod]
        public void ActualizarObraDistrito(int idregistro)
        {

            ObraDistritoDTO oZonaDTO = new ObraDistritoDTO();
            oZonaDTO.IdObra = Convert.ToInt32(this.Obra.Text);

            List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito2(oZonaDTO.IdObra);
            this.Store1.DataSource = olistaCuadrillaDistritoDTO;
            this.Store1.DataBind();

            List<ObraDistritoDTO> olistaObraDistritoDTO = new ObraDistritoBL().ListarObraDistrito(oZonaDTO.IdObra);
            this.StoreCombo.DataSource = olistaObraDistritoDTO;
            this.StoreCombo.DataBind();

            List<CuadrillaDistritoDTO> olistaCuadrillaProduccionDTO = new CuadrillaDistritoBL().ListarCuadrillaProduccion(Convert.ToInt32(this.Obra.Text));
            this.StoreCuadrilla.DataSource = olistaCuadrillaProduccionDTO;
            this.StoreCuadrilla.DataBind();
            Session["olCuadrillaObra"] = olistaCuadrillaProduccionDTO;
        }


    }
}