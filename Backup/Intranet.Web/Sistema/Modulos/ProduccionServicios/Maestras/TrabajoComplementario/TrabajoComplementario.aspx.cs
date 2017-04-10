using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.BL.ProduccionServicios;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.Web.AppCode;
using Intranet.BL.ProduccionServicios.Maestra;
using Ext.Net;
using Intranet.DTO.Global;

namespace Intranet.Web.Modulos.ProduccionServicios.Maestras.TrabajoComplementario
{
    public partial class TrabajoComplementario : BasePage
    {

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            {
                CargarDatos();
                List<ObraDTO> olistaObraDTO = new ObraBL().ListarObraCPxBase(Usuario.IdBase);
                Store2.DataSource = olistaObraDTO;
                Store2.DataBind();
                List<GenericaDTO> olistaGenericaDTO = new GenericaBL().GetGenerica(DTO.Global.eTabla.Unidad);
                Store3.DataSource = olistaGenericaDTO;
                Store3.DataBind();
            }
        }


        void CargarDatos()
        {
            List<TrabajoComplementarioDTO> olistaTrabajoComplementarioDTO = new TrabajoComplementarioBL().GetTrabajoComplementarioPorBase(Usuario.IdBase);
            this.Store1.DataSource = olistaTrabajoComplementarioDTO;
            this.Store1.DataBind();
        }

        protected void btnnuevo_Click(object sender, DirectEventArgs e)
        {
            FormPanel1.Reset();
            FormPanel1.Title = "Mantenimiento - " + btnnuevo.ToolTip.ToString();
            GridPanel1.Enabled = false;
        }

        protected void btneliminar_Click(object sender, DirectEventArgs e)
        {
            if (IdTrabajoComplementario.Text.Length > 0)
            {
                if (new TrabajoComplementarioBL().ElimnarTrabajoComplementario(Convert.ToInt32(IdTrabajoComplementario.Text),Usuario.IdUsuario) == eResultado.Correcto)
                {
                    GridPanel1.Enabled = true;
                    FormPanel1.Reset();
                    CargarDatos();
                }
            }

           
        }
       
        protected void btnguardar_Click(object sender, DirectEventArgs e)
        {
            if (IdTrabajoComplementario.Text.Length==0)
            {
                TrabajoComplementarioDTO oTrabajoComplementarioDTO = new TrabajoComplementarioDTO();
                oTrabajoComplementarioDTO.CodigoTrabajoComplementario = CodigoTrabajoComplementario.Text;
                oTrabajoComplementarioDTO.CodMap = CodMap.Text;
                oTrabajoComplementarioDTO.CostoProgramado = Convert.ToDecimal(CostoProgramado.Text);
                oTrabajoComplementarioDTO.Descripcion = Descripcion.Text;
                oTrabajoComplementarioDTO.IdTrabajoComplementario = (IdTrabajoComplementario.Text.Length == 0 ? 0 : Convert.ToInt32(IdTrabajoComplementario.Text));
                oTrabajoComplementarioDTO.Obra = new ObraDTO() { IdObra = Convert.ToInt32(Obra.Value.ToString()) };
                oTrabajoComplementarioDTO.Observacion = Observacion.Text;
                oTrabajoComplementarioDTO.Unidad = Unidad.Text;
                TrabajoComplementarioBL oTrabajoComplementarioBL = new TrabajoComplementarioBL();
                if (oTrabajoComplementarioBL.InsertarTrabajoComplementario(oTrabajoComplementarioDTO, Usuario.IdUsuario) == DTO.Global.eResultado.Correcto)
                {
                    CargarDatos();
                    GridPanel1.Enabled = true;
                }
            }

            if (IdTrabajoComplementario.Text.Length > 0)
            {
                TrabajoComplementarioDTO oTrabajoComplementarioDTO = new TrabajoComplementarioDTO();
                oTrabajoComplementarioDTO.IdTrabajoComplementario = Convert.ToInt32(IdTrabajoComplementario.Text);
                oTrabajoComplementarioDTO.CodigoTrabajoComplementario = CodigoTrabajoComplementario.Text;
                oTrabajoComplementarioDTO.CodMap = CodMap.Text;
                oTrabajoComplementarioDTO.CostoProgramado = Convert.ToDecimal(CostoProgramado.Text);
                oTrabajoComplementarioDTO.Descripcion = Descripcion.Text;
                oTrabajoComplementarioDTO.IdTrabajoComplementario = (IdTrabajoComplementario.Text.Length == 0 ? 0 : Convert.ToInt32(IdTrabajoComplementario.Text));
                oTrabajoComplementarioDTO.Obra = new ObraDTO() { IdObra = Convert.ToInt32(Obra.Value.ToString()) };
                oTrabajoComplementarioDTO.Observacion = Observacion.Text;
                oTrabajoComplementarioDTO.Unidad = Unidad.Text;
                TrabajoComplementarioBL oTrabajoComplementarioBL = new TrabajoComplementarioBL();
                if (oTrabajoComplementarioBL.UpdateTrabajoComplementario(oTrabajoComplementarioDTO, Usuario.IdUsuario) == DTO.Global.eResultado.Correcto)
                {
                    CargarDatos();
                    GridPanel1.Enabled = true;
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}