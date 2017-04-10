using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Ext.Net;
using System.Web.Security;
using Intranet.DTO.CFG;
using Intranet.BL.CFG;
using Intranet.BL.Maestra;
using Intranet.DTO.SGE;
using Intranet.BL.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.BL.ProduccionServicios.Maestra;

namespace Intranet.Web
{
    public partial class Default : BasePage
    {
        System.Timers.Timer OnRecuperaSession;
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!X.IsAjaxRequest)
            {
                this.InicializarControles();
                OnRecuperaSession = new System.Timers.Timer(60000);
                OnRecuperaSession.Elapsed += new System.Timers.ElapsedEventHandler(OnRecuperaSession_Elapsed);
              //  OnRecuperaSession.Start();
            }
        }
        #region prueba de la session de recuperaion 

        void OnRecuperaSession_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            OnRecuperaSession.Stop();
            List<MenuCFG> oListamenu = new List<MenuCFG>() ;
            UsuarioLoginCFG oUsuarioLoginCFG = new UsuarioLoginCFG();

            UsuarioCFG oUsuario = new UsuarioCFG() { Usuario = Usuario.Usuario, Password = Usuario.Password };
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
                Session.Timeout = 60000;

                /*
                 DateTime expirationDate = DateTime.Now;
                 expirationDate = expirationDate.AddHours(10);
                 string strNickName = Usuario.Usuario;
                 FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, strNickName, DateTime.Now, expirationDate, false, oUsuarioLoginCFG.IdUsuario.ToString(), FormsAuthentication.FormsCookiePath);
                 string hash = FormsAuthentication.Encrypt(ticket);
                 HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                 Response.Cookies.Add(Cookie);

                 Response.Redirect("~/Sistema/Default.aspx");
                 * */
            }

            OnRecuperaSession.Start();
        }

        #endregion
        private void InicializarControles()
        {
            this.Label2.Html = " Bienvenido(a), <b>" + Usuario.NombresApellidos.ToUpper() + " (" + Usuario.Usuario.ToUpper() + ")</b> ";
            this.Label3.Html = " Base : <b>" + Usuario.Base.ToUpper() + "</b> ";

            string mbase = System.Configuration.ConfigurationManager.ConnectionStrings["Gestion"].ToString();
            char[] r = { ';' };
            string[] arr = mbase.Split(r);
            if (arr[0].ToString().ToUpper().Contains("DESARROLLO"))
            {
                this.Label4.Html = " Entorno : <b>DESARROLLO</b> ";
            }
            else
            {
                this.Label4.Html = " Entorno : <b>PRODUCCION</b> ";
            }
            pnlWest.Title = "PRODUCCIÓN SERVICIOS";
        }
        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            Session.Abandon();
            //Session.Clear();
            //Cache.Remove(Session.SessionID);
            //FormsAuthentication.SignOut();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

            Response.Redirect("~/Sistema/Login.aspx");
        }

    }
}