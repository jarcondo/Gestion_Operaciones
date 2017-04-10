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
    public class DetalleInspeccionDAO
    {
        public List<DetalleInspeccionDTO> ConsultaInspeccion(int cab)
        {
            try
            {
                List<DetalleInspeccionDTO> oDetalleIns = new List<DetalleInspeccionDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectInspecion", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetalleInspeccionDTO oDetIns = new DetalleInspeccionDTO();
                        oDetIns.idInspeccion = Convert.ToInt32(dataReader["IdInspeccion"].ToString());
                        oDetIns.idCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDetIns.estado = dataReader["estado"].ToString();
                        oDetIns.horaInicio = dataReader["horaInicio"].ToString();
                        oDetIns.horaFin = dataReader["horaFin"].ToString();
                        oDetIns.fecha = dataReader["fecha"].ToString();
                        oDetIns.idCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                        oDetalleIns.Add(oDetIns);
                    }
                }
                return oDetalleIns;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetalleInspeccionDTO>();
            }
        }

        public eResultado ActualizaInspeccion(DetalleInspeccionDTO DetaIns)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizarInspeccion",
                    new object[]
                {
                      DetaIns.idInspeccion,
                      DetaIns.estado ,
                      DetaIns.fecha,
                      DetaIns.horaInicio,
                      DetaIns.horaFin,
                      DetaIns.idCuadrilla,            
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

        public eResultado InsertInspeccionVacio(int cab)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleInspeccionVacio",
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
