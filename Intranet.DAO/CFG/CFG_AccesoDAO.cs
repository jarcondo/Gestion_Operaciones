using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Intranet.DTO;
using System.Data.Common;
using System.Data;
using Intranet.DTO.CFG;
using Intranet.DTO.Global;

namespace Intranet.DAO.CFG
{
    public class CFG_AccesoDAO
    {
        public eResultadoCFG ValidaIngreso(ref List<MenuCFG> oListamenu, UsuarioCFG oUsuarioCFG)
        {
            try
            {


                oListamenu = new List<MenuCFG>();
                MenuCFG oMenuCFG = new MenuCFG();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("CFG_Acceso_Valida", new object[] { oUsuarioCFG.Usuario, oUsuarioCFG.Password });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oMenuCFG = new MenuCFG();
                        oMenuCFG.Descripcion = dataReader["Descripcion"].ToString();
                        oMenuCFG.IdMenu = Convert.ToInt32(dataReader["IdMenu"].ToString());
                        oMenuCFG.Menu = dataReader["Menu"].ToString();
                        oMenuCFG.Modulo = dataReader["Modulo"].ToString();
                        oMenuCFG.Objeto = dataReader["Objeto"].ToString();
                        oMenuCFG.Proceso = dataReader["Proceso"].ToString();
                        oMenuCFG.Parametro = dataReader["Parametro"].ToString();
                        oMenuCFG.Parametro2 = dataReader["Parametro2"].ToString();
                        oMenuCFG.Parametro3 = dataReader["Parametro3"].ToString();
                        oMenuCFG.Parametro4 = dataReader["Parametro4"].ToString();
                        oMenuCFG.DireccionURL = dataReader["DireccionURL"].ToString() == null ? "" : dataReader["DireccionURL"].ToString();
                        AuditoriaCFG.IdUsuario = dataReader["IdUsuario"].ToString();
                        AuditoriaCFG.Password = oUsuarioCFG.Password;
                        AuditoriaCFG.PorcentajeIGV = Convert.ToDecimal(dataReader["IGV"].ToString());
                        AuditoriaCFG.Rol = new RolCFG()
                        {
                            TipoRol = dataReader["TipoRol"].ToString(),
                            IdRol = Convert.ToInt32(dataReader["IdRol"].ToString())
                        };
                        AuditoriaCFG.Usuario = oUsuarioCFG.Usuario;
                        AuditoriaCFG.PeriodoAno = oUsuarioCFG.PeriodoAno;
                        AuditoriaCFG.PeriodoMes = oUsuarioCFG.PeriodoMes;
                        oListamenu.Add(oMenuCFG);
                    }

                }

                if (oListamenu.Count == 0)
                {
                    return eResultadoCFG.Error;
                }
                else
                {
                    return eResultadoCFG.Correcto;
                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultadoCFG.Error;
            }
        }

        public eResultado CambiarPassword(int Usuario, string pass, string nuevapass)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("MA_Usuario_CambiarPassword",
                    new object[]
                {
                    Usuario,
                    pass,
                    nuevapass
                });

                int nresultado = db.ExecuteNonQuery(dbCommand);
                if (nresultado > 0)
                {
                    return eResultado.Correcto;

                }
                else
                {
                    return eResultado.Error;
                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return eResultado.Error;
            }
        }
    }
}
