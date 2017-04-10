using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleOtrosDAO
    {
        public DetalleOtrosDTO SelectDetalleOtros(int cab)
        {
            try
            {
                //List<DetalleOtrosDTO> oDetalleOtros = new List<DetalleOtrosDTO>();

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectOtros", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    DetalleOtrosDTO oDetOtros = new DetalleOtrosDTO();

                    while (dataReader.Read())
                    {
                        oDetOtros.IdOtros = Convert.ToInt32(dataReader["IdOtros"].ToString());
                        oDetOtros.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"]);
                        oDetOtros.DUnoAlturaAguaRet = Convert.ToDouble(dataReader["DUnoAlturaAguaRet"].ToString());
                        oDetOtros.DUnoAlturaSolBuzon = Convert.ToDouble(dataReader["DUnoAlturaSolBuzon"]);
                        oDetOtros.DUnoAlturaTotalBuzon = Convert.ToDouble(dataReader["DUnoAlturaTotalBuzon"].ToString());
                        oDetOtros.DUnoDiametroColector = Convert.ToInt32(dataReader["DUnoDiametroColector"].ToString());
                        oDetOtros.DUnoOtros = dataReader["DUnoOtros"].ToString();
                        oDetOtros.DUnoPulgIntBuzon = Convert.ToDouble(dataReader["DUnoPulgIntBuzon"].ToString());
                        oDetOtros.DUnoTiranteHidBuzon = Convert.ToDouble(dataReader["DUnoTiranteHidBuzon"].ToString());
                        oDetOtros.DUnoVolExtSol = Convert.ToDouble(dataReader["DUnoVolExtSol"].ToString());
                        oDetOtros.ADdvd = Convert.ToInt32(dataReader["ADdvd"].ToString());
                        oDetOtros.Desmonte = Convert.ToBoolean(dataReader["Desmonte"].ToString());
                        oDetOtros.ConAgua = Convert.ToBoolean(dataReader["ConAgua"].ToString());
                        return oDetOtros;
                    }

                    oDetOtros.IdOtros = 0;
                    oDetOtros.IdCabecera = 0;
                    oDetOtros.DUnoAlturaAguaRet = 0;
                    oDetOtros.DUnoAlturaSolBuzon = 0;
                    oDetOtros.DUnoAlturaTotalBuzon = 0;
                    oDetOtros.DUnoDiametroColector = 0;
                    oDetOtros.DUnoOtros = "";
                    oDetOtros.DUnoPulgIntBuzon = 0;
                    oDetOtros.DUnoTiranteHidBuzon = 0;
                    oDetOtros.DUnoVolExtSol = 0;
                    oDetOtros.ADdvd = 0;
                    oDetOtros.Desmonte = false;
                    oDetOtros.ConAgua = false;
                    return oDetOtros;
                }
               
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new DetalleOtrosDTO();
            }
        }
        /*
        public eResultado ActualizaDetalleOtrosDVD(DetalleOtrosDTO detaOtros)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleOtrosDVD",
                        new object[]
                {
                      detaOtros.IdOtros,
                      detaOtros.IdCabecera,
                      detaOtros.ADdvd
                });
                    int resultado = db.ExecuteNonQuery(dbCommand);
                    if (resultado > 0)
                    {
                        return eResultado.Correcto;
                    }
                    else
                    {
                        return eResultado.Error;
                    }
                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new eResultado();
            }
        }
        */
        public eResultado ActualizaDetalleOtros(DetalleOtrosDTO detaOtros)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleOtros",
                        new object[]
                {
                      detaOtros.IdOtros,
                      detaOtros.IdCabecera,
                      detaOtros.DUnoAlturaSolBuzon,
                      detaOtros.DUnoVolExtSol,
                      detaOtros.DUnoPulgIntBuzon,
                      detaOtros.DUnoTiranteHidBuzon,
                      detaOtros.DUnoDiametroColector,
                      detaOtros.DUnoAlturaAguaRet,
                      detaOtros.DUnoAlturaTotalBuzon,
                      detaOtros.DUnoOtros,
                      detaOtros.ADdvd,
                      detaOtros.Desmonte,
                      detaOtros.ConAgua,
                });
                    int resultado = db.ExecuteNonQuery(dbCommand);
                    if (resultado > 0)
                    {
                        return eResultado.Correcto;
                    }
                    else
                    {
                        return eResultado.Error;
                    }
                }
            }
            catch(Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new eResultado();
            }
        }

        public eResultado InsertDetalleOtrosDUno(DetalleOtrosDTO detaOtros)
        {
            try
            {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleOtros",
                    new object[]
                {
                      detaOtros.IdOtros,
                      detaOtros.IdCabecera,
                      detaOtros.DUnoAlturaSolBuzon,
                      detaOtros.DUnoVolExtSol,
                      detaOtros.DUnoPulgIntBuzon,
                      detaOtros.DUnoTiranteHidBuzon,
                      detaOtros.DUnoDiametroColector,
                      detaOtros.DUnoAlturaAguaRet,
                      detaOtros.DUnoAlturaTotalBuzon,
                      detaOtros.DUnoOtros,
                      detaOtros.ADdvd,
                      detaOtros.Desmonte,
                      detaOtros.ConAgua
                });
                int resultado = db.ExecuteNonQuery(dbCommand);
                if (resultado > 0)
                {
                    return eResultado.Correcto;
                }
                else
                {
                    return eResultado.Error;
                }
            }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new eResultado();
            }
        }

        public List<LimpBuzonRetSolidosDTO> LimpBuzonRetSolidos(int Idobra, string fecDesde, string fecHasta)
        {
            try
            {
                List<LimpBuzonRetSolidosDTO> olLimpBuzRetSol = new List<LimpBuzonRetSolidosDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("LimpBuzonRetSolidos", new object[]
                {
                    Idobra, fecDesde, fecHasta
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        LimpBuzonRetSolidosDTO oLBRS = new LimpBuzonRetSolidosDTO();

                        oLBRS.NumeroOrden = dataReader["NumeroOrden"].ToString();
                        oLBRS.FechaInicio = dataReader["FechaInicio"].ToString();
                        oLBRS.sgi = dataReader["Sgi"].ToString();
                        oLBRS.Suministro = dataReader["Suministro"].ToString();
                        oLBRS.Direccion = dataReader["Direccion"].ToString();
                        oLBRS.Urbanizacion = dataReader["Urbanizacion"].ToString();
                        oLBRS.Distrito = dataReader["Distrito"].ToString();
                        oLBRS.Cantidad = Convert.ToInt32(dataReader["Cantidad"].ToString());
                        oLBRS.AlturaSolBuzon = Double.Parse(dataReader["AlturaSolidos"].ToString());
                        oLBRS.PulgIntBuzon = Double.Parse(dataReader["DiametroInterno"].ToString());
                        oLBRS.TiranteHidBuzon = Double.Parse(dataReader["TiranteHidraulico"].ToString());
                        oLBRS.DiametroColector = Double.Parse(dataReader["DiametroColector"].ToString());
                        oLBRS.AlturaTotalBuzon = Double.Parse(dataReader["AlturaTotalBuzon"].ToString());
                        olLimpBuzRetSol.Add(oLBRS);
                    }
                }

                return olLimpBuzRetSol;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<LimpBuzonRetSolidosDTO>();
            }
        }
    }

}
