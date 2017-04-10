using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
namespace Intranet.Utilities
{
    public class Controles
    {
        public static void LlenarComboBox(DropDownList DropDown, object DataSource, string ValueField, string TextField, bool IncludeDummy)
        {
            DropDown.DataSource = DataSource;
            DropDown.DataValueField = ValueField;
            DropDown.DataTextField = TextField;
            DropDown.DataBind();
            if (IncludeDummy)
            {
                DropDown.Items.Insert(0, new ListItem("--Seleccione--"));
                DropDown.Items[0].Value = "0";
            }
        }

        public static string MostrarPopUp(string strDireccion, string strAleatorio, int intAncho, int intAlto, 
        int intPosicionX, int intPosicionY, string strMenuBar, string strResizable, 
        string strStatus, string strScrollbar) {
            return //"<script language='javascript'>" +
                       "window.open('" + strDireccion + "', " +
                  "'" + strAleatorio + "', " +
                  "'width=" + intAncho.ToString() + ", " +
                  " height=" + intAlto.ToString() + ", " +
                  " top=" + intPosicionX.ToString() + ", " +
                  " left=" + intPosicionY.ToString() + ", " +
                  " menubar=" + strMenuBar + ", " +
                  " resizable=" + strResizable + ", " +
                  " status=" + strStatus + ", " +
                  " scrollbars=" + strScrollbar + "' );";/* +
                 "</script>"*/
        }
    }
}
