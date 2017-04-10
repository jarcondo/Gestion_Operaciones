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
using Intranet.DTO.Global;
using Intranet.BL.SGE;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Maestras.Zona
{
    public partial class Zona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                List<ObraDTO> olObra = new List<ObraDTO>();
                List<ZonaDTO> olistaZona = new ZonaBL().ListarZona3(20);//obra inicial
                this.Store1.DataSource = olistaZona;
                this.Store1.DataBind();
                this.BtnGrabar.Hide();
                this.btnCancelar.Hide();
                this.IdZonaField.Disabled = true;
                List<ObraDistritoDTO> olistaObraDistritoDTO = new ObraDistritoBL().ListarObraDistrito(20);
                this.StoreCombo.DataSource = olistaObraDistritoDTO;
                //List<DistritoDTO> olistaDistritoDTO = new DistritoBL().ListarDistrito();
                //this.StoreCombo.DataSource = olistaDistritoDTO;
                this.StoreCombo.DataBind();
                this.IdZonaField.Hide();

                ObraBL oObraBL = new ObraBL();
                olObra = oObraBL.ListarObraTodas();
                //Session["olObraDistrito"] = olistaObraDistritoDTO;
                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();
            }
        }


        protected void btnGrabar_Click(object sender, Ext.Net.DirectEventArgs e)
        {

            ZonaDTO oZonaDTO = new ZonaDTO();
            oZonaDTO.DescripcionZona = DescripcionZonaField.Text;
            oZonaDTO.IdDistrito = Convert.ToInt32(DistritoField.Text);
            oZonaDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            if (oZonaDTO.DescripcionZona.Length != 0)
            {
                ZonaBL oZonaBL = new ZonaBL();
                oZonaBL.Insert(oZonaDTO.DescripcionZona, oZonaDTO.IdDistrito,oZonaDTO.IdObra);
                List<ZonaDTO> olistaZona = new ZonaBL().ListarZona3(oZonaDTO.IdObra);
                this.Store1.DataSource = olistaZona;
                this.Store1.DataBind();
                Ext.Net.X.Msg.Alert("Nuevo Registro", "Registro Grabado").Show();
                this.DescripcionZonaField.Text = "";
                this.DistritoField.Text = "";
                this.btnNuevo.Show();
                this.BtnGrabar.Hide();
                this.Button1.Show();
                this.btnCancelar.Hide();
                this.GridPanel1.Disabled = false;
                this.FormPanel1.Title = "Detalle";
            }

        }


        [DirectMethod]
        public void Actualizar(int idregistro)
        {
            ZonaDTO oZonaDTO = new ZonaDTO();
            oZonaDTO.IdDistrito = Convert.ToInt32(DistritoField.Text);
            oZonaDTO.DescripcionZona = DescripcionZonaField.Text;
            oZonaDTO.IdZona = Convert.ToInt32(idregistro);
            oZonaDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            if (oZonaDTO.DescripcionZona.Length != 0)
            {
                ZonaBL oZonaBL = new ZonaBL();
                oZonaBL.Update(oZonaDTO.DescripcionZona, oZonaDTO.IdDistrito, oZonaDTO.IdZona, oZonaDTO.IdObra);
                List<ZonaDTO> olistaZona = new ZonaBL().ListarZona3(oZonaDTO.IdObra);
                this.Store1.DataSource = olistaZona;
                this.Store1.DataBind();
                this.FormPanel1.Title = "Detalle";
                Ext.Net.X.Msg.Alert("Actualizar Registro", "Registro Actualizado").Show();
            }

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
                X.Msg.Notify("Actualizar Zona", "Registro eliminado").Show();
            }
            else if (CommandName == "Edit")
            {
                Ext.Net.X.Msg.Alert("Editar", ID).Show();
            }
        }

        [DirectMethod]
        public void Eliminar(string ID)
        {
            ZonaBL oZonaBL = new ZonaBL();
            eResultado oeResultado = oZonaBL.Delete(Convert.ToInt32(ID), Convert.ToInt32(this.Obra.Text));
             if (oeResultado == eResultado.Error)
             {
                 X.Msg.Notify("Actualizar Zona", "El Registro se esta usando actualmente.No se pudo eliminar").Show();
             }
             else
             {
                 List<ZonaDTO> olistaZona = new ZonaBL().ListarZona3(Convert.ToInt32(this.Obra.Text));
                 this.Store1.DataSource = olistaZona;
                 this.Store1.DataBind();
                 X.Msg.Notify("Actualizar Zona", "El registro fue eliminado").Show();
             }
        }

        [DirectMethod]
        public void ActualizarDistrito(int idregistro)
        {
            ObraDistritoDTO oZonaDTO = new ObraDistritoDTO();
            oZonaDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            List<ZonaDTO> olistaZona = new ZonaBL().ListarZona3(oZonaDTO.IdObra);//obra inicial
            this.Store1.DataSource = olistaZona;
            this.Store1.DataBind();
            List<ObraDistritoDTO> olistaObraDistritoDTO = new ObraDistritoBL().ListarObraDistrito(oZonaDTO.IdObra);
            this.StoreCombo.DataSource = olistaObraDistritoDTO;
            this.StoreCombo.DataBind();

        }

    }
}