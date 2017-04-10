using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DTO.Global;

namespace Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleConexionesDAO
    {
        public List<DetalleConexionesDTO> ConsultaConexiones(int cab)
        {
            try
            {
                List<DetalleConexionesDTO> oDetalleConex = new List<DetalleConexionesDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectConexion", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetalleConexionesDTO oDetCon = new DetalleConexionesDTO();
                        oDetCon.IdConexiones = Convert.ToInt32(dataReader["IdConexiones"].ToString());
                        oDetCon.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDetCon.distancia = Convert.ToDouble(dataReader["distancia"].ToString());
                        oDetCon.izqDer = dataReader["izqDer"].ToString();
                        oDetCon.pulgadas = Convert.ToDouble(dataReader["pulgadas"].ToString());
                        oDetCon.tipoMaterial = dataReader["tipoMaterial"].ToString();
                        oDetalleConex.Add(oDetCon);
                    }
                }
                return oDetalleConex;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetalleConexionesDTO>();
            }
        }

        public eResultado InsertarConexiones(DetalleConexionesDTO deta)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertConexiones",
                    new object[]
                {
                   deta.IdCabecera,
                   deta.pulgadas,
                   deta.distancia,
                   deta.izqDer,
                   deta.tipoMaterial,
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

        public eResultado ActualizaConexiones(DetalleConexionesDTO detaCone)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizarConexiones",
                    new object[]
                {
                      detaCone.IdConexiones,
                      detaCone.pulgadas,
                      detaCone.distancia,
                      detaCone.izqDer,
                      detaCone.tipoMaterial,            
                });
               int resultado= db.ExecuteNonQuery(dbCommand);
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

        public eResultado EliminarConexiones(int IdConexiones)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EliminarConexion",
                    new object[]
                {
                   IdConexiones,
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

        public eResultado InsertDetalleConexionesVacio(int cab)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleConexionesVacio",
                    new object[]
                {
                    cab,
                });
                int resultado=db.ExecuteNonQuery(dbCommand);
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
    }
}
