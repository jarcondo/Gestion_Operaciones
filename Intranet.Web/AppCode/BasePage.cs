using System;
using Intranet.DTO.CFG;
using System.Web.UI;
using System.Web;
using Ext.Net;
using System.Collections.Generic;
using System.Reflection;
namespace Intranet.Web.AppCode
{
    public class BasePage : System.Web.UI.Page, ICallbackEventHandler
    {
        List<string> m_resultCallback = new List<string>();

        protected override void OnLoad(EventArgs e)
        {
            Session["Ext.Net.Theme"] = Ext.Net.Theme.Slate;

            //if (!Request.IsAuthenticated)
            //    Response.Redirect("~/Sistema/Login.aspx");
            if(Usuario==null)
                Response.Redirect("~/Sistema/Login.aspx");
            //Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Expires = 0;
            //Response.Cache.SetNoStore();
            //Response.AppendHeader("Pragma", "no-cache");

            base.OnLoad(e);
        }
        
        public UsuarioLoginCFG Usuario
        {
            get { return (UsuarioLoginCFG)Session["session.user.intranet"]; }
        }

        public void Mensaje(string msg)
        {
            X.Msg.Notify("SMC GESTION DE OPERACIONES", msg).Show();
        }

        public void NotificarPermanencia(string msg)
        {
            NotificationConfig oConfig = new NotificationConfig();
            oConfig.AutoHide = false;
            oConfig.PinEvent = "click";
            oConfig.Title = "SMC GESTION DE OPERACIONES";
            oConfig.Icon = Icon.Information;
            oConfig.Html = msg;
            Notification.Show(oConfig);
        }

        public void ManejarError(Exception ex)
        {
            Session["MsgError"] = ex;
            Response.Redirect("~/Sistema/ErrorPage.aspx");
        }

        //CALLBACK
        public void AddCallbackValue(string Value){
            m_resultCallback.Add(Value);
        }

        public void AddCallbackControl(Control Control)
        {
            if (IsCallback)
                m_resultCallback.Add(ControlHelper.GetHtmlControl(Control));
        }

		public void RemoveCallBackValueAt(Int32 index){
			m_resultCallback.RemoveAt(index);
		}

		public void ClearCallBackValues(){
            m_resultCallback.Clear();
		}

        private void Page_Init(object sender, System.EventArgs e)
        {
            string mScript = ClientScript.GetCallbackEventReference("", "", "", "", "", false);
            if (this.Page.IsCallback)
            {
                if (string.IsNullOrEmpty(Request["__FORMCALLBACK"]))
                {
                    try
                    {
                        this.Controls.Clear();

                    }
                    catch
                    {
                    }
                }
            }
        }

        string ICallbackEventHandler.GetCallbackResult()
        {
            string mReturnValue = null;
            mReturnValue = string.Join(":::", m_resultCallback.ToArray());
            return mReturnValue;
        }
        void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
        {
            string[] mArguments = eventArgument.Split('|');
            MethodInfo mMethodInfo = default(MethodInfo);
            string[] mParameters = null;

            if (mArguments.Length > 1)
            {
                if (string.IsNullOrEmpty(mArguments[1]))
                {
                    mParameters = null;
                }
                else
                {
                    mParameters = mArguments[1].Split(':');

                    for (int i = 0; i <= mParameters.Length - 1; i++)
                    {
                        mParameters[i] = HttpUtility.UrlDecode(mParameters[i]);
                    }
                }

            }
            else
            {
                mParameters = null;
            }

            mMethodInfo = this.GetType().GetMethod(mArguments[0]);
            try
            {
                mMethodInfo.Invoke(this, mParameters);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
