using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI;
using System.IO;
using Ext.Net;
namespace Intranet.Web.AppCode
{
    public class ControlHelper
    {
        public static void SetStoreDataSource(ref Store Store, IList DataSource)
        {
            Store.DataSource = DataSource;
            Store.DataBind();
        }

        public static string GetHtmlControl(Control Control)
        {
            string mResultValue = null;

            StringWriter mStringWriter = new StringWriter();
            HtmlTextWriter mHtmlWriter = new HtmlTextWriter(mStringWriter);

            Control.RenderControl(mHtmlWriter);

            mHtmlWriter.Flush();
            mResultValue = mStringWriter.ToString();

            mHtmlWriter.Close();
            mStringWriter.Close();

            mHtmlWriter.Dispose();
            mStringWriter.Dispose();

            return mResultValue;

        }

        public static string GetHtmlComboExt(Ext.Net.ComboBox cb)
        {
            string mResultValue = null;

            StringWriter mStringWriter = new StringWriter();
            HtmlTextWriter mHtmlWriter = new HtmlTextWriter(mStringWriter);

            cb.RenderControl(mHtmlWriter);

            mHtmlWriter.Flush();
            mResultValue = mStringWriter.ToString();

            mHtmlWriter.Close();
            mStringWriter.Close();

            mHtmlWriter.Dispose();
            mStringWriter.Dispose();

            return mResultValue;

        }

        public static void SetListDataSource(ref DropDownList Control, IList DataSource, bool AddEmptyItem = false, string EmptyText = "", string EmptyValue = "")
        {
            Control.DataSource = DataSource;
            Control.DataBind();

            if (AddEmptyItem)
            {
                Control.Items.Insert(0, new System.Web.UI.WebControls.ListItem(EmptyText, EmptyValue));
            }
        }
        //public static void SetRadioListDataSource(ref RadioButtonList Control, IList DataSource)
        //{
        //    Control.DataSource = DataSource;
        //    Control.DataBind();
        //}
        //public static void SetDataListDataSource(ref DataList Control, IList DataSource)
        //{
        //    Control.DataSource = DataSource;
        //    Control.DataBind();
        //}
        //public static void SetGridDataSource(ref GridView Control, IList DataSource, bool AddEmptyItem = false, string EmptyText = "")
        //{
        //    Control.DataSource = DataSource;
        //    Control.DataBind();
        //}
        
        //public static void ComboBoxResize(ref DropDownList control, int rows)
        //{
        //    int mHeight = 243;
        //    control.value = 0;
        //    if (rows > 10)
        //    {
        //        control.Height = mHeight;
        //    }
        //}
    }
}