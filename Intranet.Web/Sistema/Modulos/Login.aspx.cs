using System;
using System.Collections.Generic;
using System.Linq;
using Ext.Net;
using Intranet.BL.SGE;
using System.Web.Security;
using Intranet.DTO.CFG;
using Intranet.BL.CFG;
using Intranet.BL.Maestra;
using Intranet.Web.AppCode;
using System.Web;
using Intranet.DTO.SGE;
using Intranet.BL.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private List<MenuCFG> oListamenu;
        private UsuarioLoginCFG oUsuarioLoginCFG = new UsuarioLoginCFG();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["Ext.Net.Theme"] = Ext.Net.Theme.Slate;
                InicializarControles();
            }
        }

        private void InicializarControles()
        {
            this.ltrAnho.Text = DateTime.Now.Year.ToString();
        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            UsuarioCFG oUsuario = new UsuarioCFG() { Usuario = txtUsername.Text, Password = txtPassword.Text };
            if (new CFG_AccesoBL().ValidaIngreso(ref oListamenu, oUsuario) == eResultadoCFG.Correcto)
            {
                oListamenu = (from ol in oListamenu where ol.DireccionURL != "" select ol).ToList();
                Session["session.menu.intranet"] = oListamenu;

                oUsuarioLoginCFG = new UsuarioBL().UsuarioBuscar(Convert.ToInt32(AuditoriaCFG.IdUsuario.ToString()));

                //CARGA DE MAESTRAS EN SESSION

                /******** MAESTRAS DE SGE ********/
                List<ObraDTO> olObra = new List<ObraDTO>();
                if (AuditoriaCFG.Rol.IdRol != 1 && AuditoriaCFG.Rol.IdRol != 6)
                    olObra = new ObraBL().ListarObra(oUsuarioLoginCFG.IdBase);
                else
                    olObra = new ObraBL().ListarObraTodas();
                Session["session.obra.intranet"] = olObra;
                Session["session.obraCP.intranet"] = olObra.Where(x => x.CP == true).ToList();

                Session["session.proveedor.intranet"] = new ProveedorBL().GetProveedor();
                Session["session.proveedorCP.intranet"] = new ProveedorBL().GetProveedor().Where(x => x.CP == true).ToList();
                //Session["session.producto.intranet"] = new ProductoBL().ListarProducto();
                Session["session.empleado.intranet"] = new EmpleadoBL().CargaEmpleado(oUsuarioLoginCFG.IdBase);

                /******** MAESTRAS DE PRODUCCION ********/
                List<EstadoOTDTO> olEstado = new List<EstadoOTDTO>();
                List<EstadoOTDTO> olEstadoTodos = new List<EstadoOTDTO>();
                olEstado = new EstadoOTBL().ListarEstadoOT();
                olEstadoTodos = new EstadoOTBL().ListarEstadoOTTodos();
                //switch (AuditoriaCFG.Rol.IdRol)
                //{ 
                //    case 17:
                        //olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 5 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();
                        olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 6 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();
                //        break;
                //    case 20:
                //        olEstado = olEstado.Where(x => Convert.ToInt32(x.CodigoEstadoOT) < 5 || Convert.ToInt32(x.CodigoEstadoOT) == 8).ToList();
                //        break;
                //    case 1:
                //        break;
                //}
                Session["session.estadoOT.intranet"] = olEstado;
                Session["session.estadoTodos.intranet"] = olEstadoTodos;

                //FIN CARGA DE MAESTRAS EN SESSION
                
                Session["session.user.intranet"] = oUsuarioLoginCFG;
                Session.Timeout = 1440;

                //DateTime expirationDate = DateTime.Now;
                //expirationDate = expirationDate.AddHours(10);
                //string strNickName = txtUsername.Text;
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, strNickName, DateTime.Now, expirationDate, false, oUsuarioLoginCFG.IdUsuario.ToString(), FormsAuthentication.FormsCookiePath);

                //string hash = FormsAuthentication.Encrypt(ticket);
                //HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                //Response.Cookies.Add(Cookie);

                Response.Redirect("~/Sistema/Default.aspx");
            }
            else
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                X.Msg.Notify("SMC GESTION DE OPERACIONES", "Usuario y/o Password Incorrecto!").Show();
            }
        }
    }
}