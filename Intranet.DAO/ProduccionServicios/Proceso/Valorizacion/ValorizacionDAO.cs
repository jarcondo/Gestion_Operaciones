using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Procesos;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Intranet.DTO.Global;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class ValorizacionDAO
    {
        public List<ValorizacionDTO> ObtenerValorizacion(int IdObra)
        {
            try
            {
                List<ValorizacionDTO> olVal = new List<ValorizacionDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Valorizacion_ObtenerValorizacion", new object[]
                {
                    IdObra,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ValorizacionDTO oVal = new ValorizacionDTO();
                        oVal.IdValorizacion = Convert.ToInt32(dataReader["IdValorizacion"].ToString());
                        oVal.CodigoValorizacion = dataReader["CodigoValorizacion"].ToString();
                        oVal.Descripcion = dataReader["Descripcion"].ToString();
                        oVal.FechaInicio = dataReader["FechaInicio"].ToString();
                        oVal.FechaFin = dataReader["FechaFin"].ToString();
                        oVal.FechaValorizacion = dataReader["FechaValorizacion"].ToString();
                        olVal.Add(oVal);
                    }
                }

                return olVal;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<ValorizacionDTO>();
            }
        }

        public eResultado InsertarValorizacion(ValorizacionDTO oVal,int Usuario)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Valorizacion_Insertar",
                    new object[]
                {
                    oVal.IdObra 
                    ,oVal.CodigoValorizacion
                    ,oVal.Descripcion
                    ,oVal.FechaInicio
                    ,oVal.FechaFin
                    ,oVal.FechaValorizacion
                    ,Usuario
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }

        public eResultado ActualizarCabeceraValorizacion(int IdObra,string sgi,int idValorizacion,int estado,int usuario)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_ActualizarValorizacion",
                    new object[]
                {
                    IdObra,sgi,idValorizacion,estado,usuario
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }
        
        public DataRow ValidarSGI(int IdObra,string sgi)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Valorizacion_ValidarSGI",
                    new object[]
                {
                    IdObra,sgi
                });

                DataRow dsr = null;
                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dsr = ds.Tables[0].Rows[0];
                    }
                }
                return dsr;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                DataRow dr = null;
                return dr;
            }
        }

        
    }
}
