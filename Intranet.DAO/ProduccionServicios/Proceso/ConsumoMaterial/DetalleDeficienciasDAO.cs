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
    public class DetalleDeficienciasDAO
    {
        public List<DetalleDeficienciasDTO> ConsultaDeficiencias(int cab)
        {
            try
            {
                List<DetalleDeficienciasDTO> oDetalleDef = new List<DetalleDeficienciasDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectDeficiencias", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetalleDeficienciasDTO oDetDef = new DetalleDeficienciasDTO();
                        oDetDef.IdDeficiencias = Convert.ToInt32(dataReader["IdDeficiencias"].ToString());
                        oDetDef.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDetDef.codigo = Convert.ToInt32(dataReader["codigo"].ToString());
                        oDetDef.distancia = Convert.ToDouble(dataReader["distancia"].ToString());
                        oDetDef.puntual = Convert.ToBoolean(dataReader["puntual"].ToString());
                        oDetDef.extendida = Convert.ToDouble(dataReader["extendida"].ToString());
                        oDetalleDef.Add(oDetDef);
                    }
                }
                return oDetalleDef;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetalleDeficienciasDTO>();
            }
        }

        public eResultado InsertarDeficiencias(DetalleDeficienciasDTO deta)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDeficiencas",
                    new object[]
                {
                   deta.IdCabecera,
                   deta.codigo,
                   deta.distancia,
                   deta.puntual,
                   deta.extendida,
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

        public eResultado ActualizaDeficiencias(DetalleDeficienciasDTO DetaDef)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizarDeficiencias",
                    new object[]
                {
                      DetaDef.IdDeficiencias,
                      DetaDef.codigo,
                      DetaDef.distancia,
                      DetaDef.puntual,
                      DetaDef.extendida,            
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

        public eResultado EliminarDeficiencias(int IdDef)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EliminarDeficiencia",
                    new object[]
                {
                   IdDef,
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

        public eResultado InsertDeficienciasVacio(int cab)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleDeficienciasVacio",
                    new object[]
                {
                    cab,
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
    }
}
