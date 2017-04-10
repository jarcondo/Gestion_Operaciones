using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Web.AppCode;
using Ext.Net;
using Intranet.BL.CFG;
using Intranet.DTO.Global;

namespace Intranet.Web.Sistema
{
    public partial class CambioPassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void CambiarPassword(object sender, DirectEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtPassActual.Text))
            {
                this.Mensaje("Ingrese su contraseña actual.");
                return;
            }

            if (String.IsNullOrEmpty(this.txtPassNueva.Text))
            {
                this.Mensaje("Ingrese su nueva contraseña.");
                return;
            }

            if (String.IsNullOrEmpty(this.txtPassNueva2.Text))
            {
                this.Mensaje("Ingrese confirmación de su nueva contraseña.");
                return;
            }

            string actual = this.txtPassActual.Text;
            string nueva = this.txtPassNueva.Text;
            string confirmacion = this.txtPassNueva2.Text;

            if (actual == nueva)
            {
                this.Mensaje("La nueva contraseña no puede ser igual a su contraseña actual.");
                return;
            }

            if (nueva != confirmacion)
            {
                this.Mensaje("La nueva contraseña y su confirmación deben ser iguales.");
                return;
            }

            if (nueva.Length > 20)
            {
                this.Mensaje("La nueva contraseña excede al límite de dígitos permitidos.");
                return;
            }

            if (new CFG_AccesoBL().CambiarPassword(Usuario.IdUsuario, actual, nueva) == eResultado.Correcto)
                this.Mensaje("Su password ha sido cambiada.");
            else
                this.Mensaje("No se pudo actualizar su password. Inténtelo nuevamente");

        }
        
    }
}