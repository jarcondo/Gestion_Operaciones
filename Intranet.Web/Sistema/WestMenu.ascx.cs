using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.DTO.CFG;
using Ext.Net;
namespace Intranet.Web.Sistema
{
    public partial class WestMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarMenu();
        }

        private void CargarMenu()
        {
            List<MenuCFG> olMenu = (List<MenuCFG>)Session["session.menu.intranet"];
            olMenu = olMenu.Where(x => x.Modulo == "PRODUCCION SERVICIOS").ToList();
            var lista1 = (from ol in olMenu select ol.Proceso).Distinct().ToList();
            foreach (var item in lista1)
            {
                var menuPanel = new MenuPanel
                {
                    Title = item,
                    SaveSelection = true,
                    Header = true
                };
                switch (item)
                {
                    case "Maestras":
                        menuPanel.Icon = Icon.Layout;break;
                    case "Procesos":
                        menuPanel.Icon = Icon.HourglassGo; break;
                    case "Reportes":
                        menuPanel.Icon = Icon.Report; break;

                }
                var lista2 = (from ol in olMenu where ol.Proceso==item select ol).Distinct().ToList();

                foreach (var item2 in lista2)
                {
                    var menuItem = new Ext.Net.MenuItem(item2.Menu);
                    
                    switch (item)
                    {
                        case "Maestras":
                            menuItem.Icon = Icon.LayoutEdit; break;
                        case "Procesos":
                            menuItem.Icon = Icon.PagePortrait; break;
                        case "Reportes":
                            menuItem.Icon = Icon.ReportUser; break;

                    }
                    menuItem.Listeners.Click.Handler = "addTab(#{tpMain},'mnuItem" + item2.IdMenu + "','" + item2.DireccionURL + "','" + item2.Menu + "');";
                    menuPanel.Menu.Items.Add(menuItem);
                }
                this.mnuAcordion.Items.Add(menuPanel);
                
            }
        }
    }
}