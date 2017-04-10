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
using Intranet.BL.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Ext.Net;
using Intranet.DTO.Global;
using System.Text;
using Intranet.Web.AppCode;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ObraDistrito
{
    public partial class ObraDistrito :BasePage // System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                List<ObraDTO> olObra = new List<ObraDTO>();//(List<ObraDTO>)Session["olObra"];
                List<ObraDistritoDTO> olistaObraDistrito = new ObraDistritoBL().ListarObraDistrito(20);//obra inicial
                this.Store1.DataSource = olistaObraDistrito;
                this.Store1.DataBind();
                this.BtnGrabar.Hide();
                this.Button1.Hide();
                this.btnCancelar.Hide();
                //this.IdZonaField.Disabled = true;
                List<DistritoDTO> olistaDistritoDTO = new DistritoBL().ListarDistrito();
                this.StoreCombo.DataSource = olistaDistritoDTO;
                this.StoreCombo.DataBind();
                //this.IdZonaField.Hide();
                
               
                ObraBL oObraBL = new ObraBL();
                olObra = oObraBL.ListarObra(Usuario.IdBase);//.ListarObraTodas();
                //Session["olObraDistrito"] = olistaObraDistritoDTO;
                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();
               
            }
        }

        [DirectMethod]
        public void GrabarDistrito()
        {

            ObraDistritoDTO oObraDistritoDTO = new ObraDistritoDTO();
            //oZonaDTO.DescripcionZona = DescripcionZonaField.Text;
            oObraDistritoDTO.IdDistrito = Convert.ToInt32(DistritoField.Text);
            oObraDistritoDTO.IdObra = Convert.ToInt32(this.Obra.Text);

            if (oObraDistritoDTO.IdDistrito != 0)
            {
                ObraDistritoBL oObraDistritoBL = new ObraDistritoBL();
                eResultado oeResultado = oObraDistritoBL.Insert(oObraDistritoDTO.IdObra, oObraDistritoDTO.IdDistrito);
                if (oeResultado == eResultado.Error)
                {
                    X.Msg.Notify("Actualizar Obra Distrito", "El Registro ya existe.No se Grabó el registro").Show();
                }else
                {
                    List<ObraDistritoDTO> olistaObraDistrito = new ObraDistritoBL().ListarObraDistrito(oObraDistritoDTO.IdObra);
                    this.Store1.DataSource = olistaObraDistrito;
                    this.Store1.DataBind();
                    Ext.Net.X.Msg.Alert("Nuevo Registro", "Registro Grabado").Show();
                    //this.DescripcionZonaField.Text = "";
                    //this.DistritoField.Text = "";
                    this.btnNuevo.Show();
                    this.BtnGrabar.Hide();
                    this.Button1.Hide();
                    this.btnCancelar.Hide();
                    this.GridPanel1.Disabled = false;
                    this.FormPanel1.Title = "Detalle";
                }
            }

        }


        [DirectMethod]
        public void Actualizar(int idregistro)
        {
            //ZonaDTO oZonaDTO = new ZonaDTO();
            //oZonaDTO.IdDistrito = Convert.ToInt32(DistritoField.Text);
            ////oZonaDTO.DescripcionZona = DescripcionZonaField.Text;
            //oZonaDTO.IdZona = Convert.ToInt32(idregistro);
            //if (oZonaDTO.DescripcionZona.Length != 0)
            //{
            //    ZonaBL oZonaBL = new ZonaBL();
            //    oZonaBL.Update(oZonaDTO.DescripcionZona, oZonaDTO.IdDistrito, oZonaDTO.IdZona);
            //    List<ZonaDTO> olistaZona = new ZonaBL().ListarZona3(6);
            //    this.Store1.DataSource = olistaZona;
            //    this.Store1.DataBind();
            //    this.FormPanel1.Title = "Detalle";
            //    Ext.Net.X.Msg.Alert("Actualizar Registro", "Registro Actualizado").Show();
            //}

        }

        [DirectMethod]
        public void ActualizarDistrito(int idregistro)
        {
            ObraDistritoDTO oZonaDTO = new ObraDistritoDTO();
            oZonaDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            List<ObraDistritoDTO> olistaObraDistrito = new ObraDistritoBL().ListarObraDistrito(oZonaDTO.IdObra);
            this.Store1.DataSource = olistaObraDistrito;
            this.Store1.DataBind();


        }



        protected void gridCommand(object sender, Ext.Net.DirectEventArgs e)
        {
            string CommandName = e.ExtraParams["cmdName"];
            string ID = e.ExtraParams["Id"];
            if (CommandName == "Delete")
            {
                EstadoOTBL oEstadoOTBL = new EstadoOTBL();
                oEstadoOTBL.Delete(ID);
                List<EstadoOTDTO> olistaEstadoOT = new EstadoOTBL().ListarEstadoOT();
                this.Store1.DataSource = olistaEstadoOT;
                this.Store1.DataBind();
                X.Msg.Notify("Actualizar EstadoOT", "Registro eliminado").Show();
            }
            else if (CommandName == "Edit")
            {
                Ext.Net.X.Msg.Alert("Editar", ID).Show();
            }
        }

        [DirectMethod]
        public void Eliminar(string ID , string idobra)
        {
            ObraDistritoBL oObraDistritoBL = new ObraDistritoBL();
            eResultado oeResultado = oObraDistritoBL.Delete(Convert.ToInt32(ID), Convert.ToInt32(idobra));
            if (oeResultado == eResultado.Error)
            {
                X.Msg.Notify("Actualizar EstadoOT", "El Registro se esta usando actualmente.No se pudo eliminar").Show();
            }
            else
            {
                List<ObraDistritoDTO> olistaObraDistrito = new ObraDistritoBL().ListarObraDistrito(Convert.ToInt32(idobra));
                this.Store1.DataSource = olistaObraDistrito;
                this.Store1.DataBind();
                X.Msg.Notify("Actualizar EstadoOT", "El registro fue eliminado").Show();
            }
        }
    }
}