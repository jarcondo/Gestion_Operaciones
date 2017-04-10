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
    public class DetalleCaracteristicasDAO
    {
        public List<DetalleCaracteristicasDTO> SelectCaracteristicas(int cab)
        {
            try
            {
                List<DetalleCaracteristicasDTO> oDetalleCarac = new List<DetalleCaracteristicasDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectCaracteristicas", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetalleCaracteristicasDTO oDetCar = new DetalleCaracteristicasDTO();
                        oDetCar.IdCaracteristicas = Convert.ToInt32(dataReader["IdCaracteristicas"].ToString());
                        oDetCar.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDetCar.ValNroVueltas = Convert.ToInt32(dataReader["ValNroVueltas"].ToString());
                        oDetCar.ValIzqDer = Convert.ToBoolean(dataReader["ValIzqDer"].ToString());
                        oDetCar.ValNivelAp = Convert.ToInt32(dataReader["ValNivelAp"].ToString());
                        oDetCar.ValEstado = dataReader["ValEstado"].ToString();
                        oDetCar.ValMarca = dataReader["ValMarca"].ToString();
                        oDetCar.GrifoDiametro = dataReader["GrifoDiametro"].ToString();
                        oDetCar.GrifoMarca = dataReader["GrifoMarca"].ToString();
                        oDetCar.GrifoSector = Convert.ToInt32(dataReader["GrifoSector"].ToString());
                        oDetCar.GrifoNroBocas = Convert.ToInt32(dataReader["GrifoNroBocas"].ToString());
                        oDetCar.GrifoNroVueltas = Convert.ToInt32(dataReader["GrifoNroVueltas"].ToString());
                        oDetCar.GrifoNroVueltasAb = Convert.ToInt32(dataReader["GrifoNroVueltasAb"].ToString());
                        oDetCar.OtrosSituacion = Convert.ToBoolean(dataReader["OtrosSituacion"].ToString());
                        oDetCar.OtrosNroTapas = Convert.ToInt32(dataReader["OtrosNroTapas"].ToString());
                        oDetCar.OtrosCuerpo = Convert.ToBoolean(dataReader["OtrosCuerpo"].ToString());
                        oDetCar.OtrosUbica = dataReader["OtrosUbica"].ToString();
                        oDetCar.OtrosUbicaValvula = dataReader["OtrosUbicaValvula"].ToString();
                        oDetalleCarac.Add(oDetCar);
                    }
                }
                return oDetalleCarac;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetalleCaracteristicasDTO>();
            }
        }

        public eResultado ActualizaCaracteristicas(DetalleCaracteristicasDTO detaCar)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizarCaracteristicas",
                    new object[]
                {
                      detaCar.IdCaracteristicas,
                      detaCar.ValNroVueltas,
                      detaCar.ValIzqDer,
                      detaCar.ValNivelAp,
                      detaCar.ValEstado,
                      detaCar.ValMarca,
                      detaCar.GrifoDiametro,
                      detaCar.GrifoMarca,
                      detaCar.GrifoSector,
                      detaCar.GrifoNroBocas,
                      detaCar.GrifoNroVueltas,
                      detaCar.GrifoNroVueltasAb,
                      detaCar.OtrosSituacion,
                      detaCar.OtrosNroTapas,
                      detaCar.OtrosCuerpo,
                      detaCar.OtrosUbica,
                      detaCar.OtrosUbicaValvula,
                });
               int resultado= db.ExecuteNonQuery(dbCommand);
               if (resultado>0)
               {
                   return eResultado.Correcto;
               }
               else
               {
                   return eResultado.Error;
               }
               
            }
        }

        public eResultado InsertDetalleCaracteristicasVacio(int cab)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleCaracteristicasVacio",
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
