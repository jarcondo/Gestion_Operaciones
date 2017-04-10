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
using System.Xml;
using System.Xml.Xsl;

namespace Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsultaTeorico
{
    public partial class ConsultaTeorico : BasePage //System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                List<ObraDTO> olObra = new List<ObraDTO>();
                ObraBL oObraBL = new ObraBL();
                if (Usuario.IdRol != 1)
                {
                    olObra = oObraBL.ListarObra(Usuario.IdBase);
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();
                    //olObra = oObraBL.ListarObra(Usuario.IdBase);
                }
                else
                {
                    olObra = oObraBL.ListarObraTodas();
                    olObra = (List<ObraDTO>)(from item in olObra
                                             where item.CP == true
                                             select item).ToList();
                    //olObra = oObraBL.ListarObraTodas(); 

                }
                int IdObraIni = olObra.ElementAt(0).IdObra;
                this.StoreObra.DataSource = olObra;
                this.StoreObra.DataBind();

                List<CruceMaterialDTO> olistaTeorico = new ConsultaTeoricoBL().ListarTablaTeorico(IdObraIni);
                this.StoreTeorico.DataSource = olistaTeorico;
                this.StoreTeorico.DataBind();


                //List<AuxiliarCatalogoDTO> olistaAuxiliarCatalogoDTO = new AuxiliarCatalogoBL().ListarAuxiliarCatalogo(IdObraIni);
                //this.Store1.DataSource = olistaAuxiliarCatalogoDTO;
                //this.Store1.DataBind();
                //Session["olCatalogo"] = olistaAuxiliarCatalogoDTO;

                //List<AuxiliarDTO> olistaAuxiliarDTO = new AuxiliarBL().ListarAuxiliar(21);
                //this.StoreCombo.DataSource = olistaAuxiliarDTO;
                //this.StoreCombo.DataBind();

                //this.IdObra.Hide();
                //this.IdActividad.Hide();
                //this.CodigoActividad.Hide();
                //this.FormPanel1.Hide();
            }


        }


        [DirectMethod]
        public void Eliminar(int idobra, int idactividad, int idcatalogo)
        {
            AuxiliarCatalogoDTO oAuxiliarCatalogoDTO = new AuxiliarCatalogoDTO();
            oAuxiliarCatalogoDTO.IdActividad = idactividad;
            //oAuxiliarCatalogoDTO.IdAuxiliar = Convert.ToInt32(this.ComboBox1.Text);
            oAuxiliarCatalogoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            oAuxiliarCatalogoDTO.IdProCatalogo = idcatalogo;
            AuxiliarCatalogoBL oAuxiliarCatalogoBL = new AuxiliarCatalogoBL();
            oAuxiliarCatalogoBL.Eliminar(oAuxiliarCatalogoDTO);

            //List<CuadrillaDistritoDTO> olistaCuadrillaDistritoDTO = new CuadrillaDistritoBL().ListarCuadrillaDistrito2(Convert.ToInt32(this.Obra.Text));
            //this.Store1.DataSource = olistaCuadrillaDistritoDTO;
            //this.Store1.DataBind();

            List<AuxiliarCatalogoDTO> olistaAuxiliarCatalogoDTO = new List<AuxiliarCatalogoDTO>();
            olistaAuxiliarCatalogoDTO = (List<AuxiliarCatalogoDTO>)Session["olCatalogo"];

            var result2 = (from item in olistaAuxiliarCatalogoDTO where item.IdProCatalogo == oAuxiliarCatalogoDTO.IdProCatalogo select item).First();
            result2.IdAuxiliar = 0;
            result2.DescripcionAuxiliar = "No Asignado";
            this.Store1.DataSource = olistaAuxiliarCatalogoDTO;
            this.Store1.DataBind();

            X.Msg.Notify("Actualizar Registro", "Registro Actualizado").Show();
        }
        protected void ZonaRefresh(object sender, StoreRefreshDataEventArgs e)
        {
        }

        [DirectMethod]
        public void Actualizar(string DescripcionAuxiliar)
        {
            AuxiliarCatalogoDTO oAuxiliarCatalogoDTO = new AuxiliarCatalogoDTO();
            //oAuxiliarCatalogoDTO.IdAuxiliar = Convert.ToInt32(this.ComboBox1.SelectedItem.Value);
            oAuxiliarCatalogoDTO.IdObra = Convert.ToInt32(this.Obra.Text);
            //oAuxiliarCatalogoDTO.IdProCatalogo = Convert.ToInt32(this.IdProCatalogoField.Text);
            //oAuxiliarCatalogoDTO.IdActividad = Convert.ToInt32(this.IdActividad.Text);

            AuxiliarCatalogoBL oAuxiliarCatalogoBL = new AuxiliarCatalogoBL();
            oAuxiliarCatalogoBL.Insert(oAuxiliarCatalogoDTO);

            List<AuxiliarCatalogoDTO> olistaAuxiliarCatalogoDTO = new List<AuxiliarCatalogoDTO>();
            olistaAuxiliarCatalogoDTO = (List<AuxiliarCatalogoDTO>)Session["olCatalogo"];

            var result2 = (from item in olistaAuxiliarCatalogoDTO where item.IdProCatalogo == oAuxiliarCatalogoDTO.IdProCatalogo select item).First();
            result2.IdAuxiliar = oAuxiliarCatalogoDTO.IdAuxiliar;
            result2.DescripcionAuxiliar = DescripcionAuxiliar;
            this.Store1.DataSource = olistaAuxiliarCatalogoDTO;
            this.Store1.DataBind();


            Ext.Net.X.Msg.Alert("Actualizar Registro", "Registro Actualizado").Show();


        }

        [DirectMethod]
        public void ActualizarFactor(int IdTeorico , decimal Factor)
        {
            ConsultaTeoricoBL oConsultaTeoricoBL = new ConsultaTeoricoBL();
            oConsultaTeoricoBL.TeoricoUpdate(IdTeorico , Factor);
            Ext.Net.X.Msg.Alert("Actualizar Factor", "Registro Actualizado").Show();
        }



        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.Store1.DataSource = (List<AuxiliarCatalogoDTO>)Session["olCatalogo"];
            this.Store1.DataBind();
        }

        [DirectMethod]
        public void GetCatalogo()
        {

            List<CruceMaterialDTO> olistaTeorico = new ConsultaTeoricoBL().ListarTablaTeorico(Convert.ToInt32(this.Obra.Text));
            this.StoreTeorico.DataSource = olistaTeorico;
            this.StoreTeorico.DataBind();

            //List<AuxiliarCatalogoDTO> olistaAuxiliarCatalogoDTO = new AuxiliarCatalogoBL().ListarAuxiliarCatalogo(Convert.ToInt32(this.Obra.Text));
            //this.Store1.DataSource = olistaAuxiliarCatalogoDTO;
            //this.Store1.DataBind();
            //Session["olCatalogo"] = olistaAuxiliarCatalogoDTO;

            //List<AuxiliarDTO> olistaAuxiliarDTO = new AuxiliarBL().ListarAuxiliar(Convert.ToInt32(this.Obra.Text));
            //this.StoreCombo.DataSource = olistaAuxiliarDTO;
            //this.StoreCombo.DataBind();


        }

        protected void ToExcel(object sender, EventArgs e)
        {
            string json = GridData.Value.ToString();
            StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(json, null);
            XmlNode xml = eSubmit.Xml;

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=SEP.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, this.Response.OutputStream);
            this.Response.End();
        }

    }
}