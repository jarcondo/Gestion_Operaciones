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

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ProductoAuxiliar
{
    public partial class ProductoAuxiliar : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                List<ObraDTO> olObra = new List<ObraDTO>();
                ObraBL oObraBL = new ObraBL();
                if (Usuario.IdRol != 1)
                {
                    this.Button1.Hide();
                    this.Button2.Hide();
                }
                else
                {
                }
                List<AuxiliarDTO> olistaAuxiliarDTO = new AuxiliarBL().ListarAuxiliar(21);
                this.StoreCombo.DataSource = olistaAuxiliarDTO;
                this.StoreCombo.DataBind();
                Session["olAuxiliar"] = olistaAuxiliarDTO;
                List<ProductoDTO> olistaProductoDTO = new ProductoBL().ListarProducto();
                this.StoreProducto.DataSource = olistaProductoDTO;
                this.StoreProducto.DataBind();
                List<AuxiliarProductoDTO> olistaAuxiliarProductoDTO = new AuxiliarProductoBL().ListarAuxiliarProducto(21);
                this.StoreAuxiliarProducto.DataSource = olistaAuxiliarProductoDTO;
                this.StoreAuxiliarProducto.DataBind();
                this.IdObra.Hide();
                this.FormPanel1.Hide();
                this.ComboBox1.Hide();
                this.cbStates.Hide();
                this.Button3.Hide();
                this.Button4.Hide();
                this.IdAuxiliar.Hide();
                this.IdProducto.Hide();
                this.IdProductoAuxiliar.Hide();
            }

        }

        [DirectMethod]
        public void Eliminar(int IdProductoAuxiliar)
        {
            AuxiliarProductoBL oAuxiliarProductoBL = new AuxiliarProductoBL();
            oAuxiliarProductoBL.Eliminar(IdProductoAuxiliar);
            //List<AuxiliarProductoDTO> olistaAuxiliarProductoDTO = new AuxiliarProductoBL().ListarAuxiliarProducto(21);
            //this.StoreAuxiliarProducto.DataSource = olistaAuxiliarProductoDTO;
            //this.StoreAuxiliarProducto.DataBind();
            X.Msg.Notify("Actualizar Registro", "Registro Eliminado").Show();
        }
        protected void ZonaRefresh(object sender, StoreRefreshDataEventArgs e)
        {
        }

        [DirectMethod]
        public void Actualizar(string DescripcionAuxiliar)
        {
            AuxiliarProductoDTO oAuxiliarProductoDTO = new AuxiliarProductoDTO();
            
            oAuxiliarProductoDTO.IdAuxiliar = Convert.ToInt32(this.ComboBox1.SelectedItem.Value);
            oAuxiliarProductoDTO.IdObra = 21;
            oAuxiliarProductoDTO.IdProducto = Convert.ToInt32(this.cbStates.SelectedItem.Value);

            AuxiliarProductoBL oAuxiliarProductoBL = new AuxiliarProductoBL();
            oAuxiliarProductoBL.Insert(oAuxiliarProductoDTO);

            List<AuxiliarProductoDTO> olistaAuxiliarProductoDTO = new AuxiliarProductoBL().ListarAuxiliarProducto(21);
            this.StoreAuxiliarProducto.DataSource = olistaAuxiliarProductoDTO;
            this.StoreAuxiliarProducto.DataBind();


            Ext.Net.X.Msg.Alert("Actualizar Registro", "Registro Actualizado").Show();


        }

        [DirectMethod]
        public void InsertarAuxiliar(string DescripcionAuxiliar)
        {
            List<AuxiliarDTO>  olistaAuxiliarDTO2 = (List<AuxiliarDTO>)Session["olAuxiliar"];

            var result = (from item in olistaAuxiliarDTO2
                          where item.Descripcion.ToUpper() == DescripcionAuxiliar.ToUpper()
                          select item).Count();
            if (result > 0) {

                Ext.Net.X.Msg.Alert("Nuevo registro", "La Descripcion ya existe").Show();
                return;
            }
            //resultado = result.Count();

            AuxiliarDTO oAuxiliarDTO = new AuxiliarDTO();
            oAuxiliarDTO.IdObra = 21;
            oAuxiliarDTO.Descripcion = DescripcionAuxiliar;

            AuxiliarBL oAuxiliarBL = new AuxiliarBL();
            oAuxiliarBL.Insert(oAuxiliarDTO);
            
            List<AuxiliarDTO> olistaAuxiliarDTO = new AuxiliarBL().ListarAuxiliar(21);
            this.StoreCombo.DataSource = olistaAuxiliarDTO;
            this.StoreCombo.DataBind();
            Session["olAuxiliar"] = olistaAuxiliarDTO;
            X.Msg.Notify("Nuevo Registro", "Se agrego registro auxiliar").Show();

        }


        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.Store1.DataSource = (List<AuxiliarCatalogoDTO>)Session["olCatalogo"];
            this.Store1.DataBind();
        }


      
        [DirectMethod]
        public void GetCatalogo()
        {

            List<AuxiliarCatalogoDTO> olistaAuxiliarCatalogoDTO = new AuxiliarCatalogoBL().ListarAuxiliarCatalogo(21);
            this.Store1.DataSource = olistaAuxiliarCatalogoDTO;
            this.Store1.DataBind();
            Session["olCatalogo"] = olistaAuxiliarCatalogoDTO;

            List<AuxiliarProductoDTO> olistaAuxiliarProductoDTO = new AuxiliarProductoBL().ListarAuxiliarProducto(21);
            this.StoreAuxiliarProducto.DataSource = olistaAuxiliarProductoDTO;
            this.StoreAuxiliarProducto.DataBind();

            List<AuxiliarDTO> olistaAuxiliarDTO = new AuxiliarBL().ListarAuxiliar(21);
            this.StoreCombo.DataSource = olistaAuxiliarDTO;
            this.StoreCombo.DataBind();
            Session["olAuxiliar"] = olistaAuxiliarDTO;
            this.ComboBox1.Clear();

        }
    }
}