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
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetalleBuzonDAO
    {
        public List<DetalleBuzonDTO> ConsultaBuzon(int cab)
        {
            try
            {
                List<DetalleBuzonDTO> oDetalleBuzon = new List<DetalleBuzonDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectBuzon", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetalleBuzonDTO oDetBuz = new DetalleBuzonDTO();

                        oDetBuz.buzon = dataReader["Buzon"].ToString();
                        oDetBuz.profundidad = Convert.ToDouble(dataReader["profundidad"].ToString());
                        oDetBuz.idBuzon = Convert.ToInt32(dataReader["IdBuzon"]);
                        oDetBuz.idCabecera = Convert.ToInt32(dataReader["IdCabecera"]);
                        oDetBuz.marcoMaterial = dataReader["marcoMaterial"].ToString();
                        oDetBuz.marcoEstado = Convert.ToBoolean(dataReader["marcoEstado"].ToString());
                        oDetBuz.tapaMaterial = dataReader["tapaMaterial"].ToString();
                        oDetBuz.tapaEstado = dataReader["tapaEstado"].ToString();
                        oDetBuz.solado = Convert.ToBoolean(dataReader["solado"].ToString());
                        oDetBuz.media = Convert.ToBoolean(dataReader["media"].ToString());
                        oDetBuz.cuerpo = Convert.ToBoolean(dataReader["cuerpo"].ToString());
                        oDetBuz.techo = Convert.ToBoolean(dataReader["techo"].ToString());
                        oDetBuz.emboquillado = Convert.ToBoolean(dataReader["emboquilladoTubo"].ToString());
                        oDetBuz.sellado = Convert.ToBoolean(dataReader["selladoBoca"].ToString());
                        oDetBuz.marcoNivelado = Convert.ToBoolean(dataReader["marcoNivelado"].ToString());

                        oDetalleBuzon.Add(oDetBuz);
                    }
                }
                return oDetalleBuzon;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetalleBuzonDTO>();
            }
        }

        public eResultado ActualizaBuzon(DetalleBuzonDTO detaBuzon)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizarBuzon",
                    new object[]
                {
                      detaBuzon.idBuzon,
                      detaBuzon.profundidad,
                      detaBuzon.marcoMaterial,
                      detaBuzon.marcoEstado,
                      detaBuzon.tapaMaterial,
                      detaBuzon.tapaEstado,
                      detaBuzon.solado,
                      detaBuzon.media,
                      detaBuzon.cuerpo,
                      detaBuzon.techo,
                      detaBuzon.emboquillado,
                      detaBuzon.sellado,
                      detaBuzon.marcoNivelado,
                });
              int resultado=  db.ExecuteNonQuery(dbCommand);
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

        public eResultado InsertDetalleBuzonVacio(int cab)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleBuzonVacio",
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

        public List<BuzonesLimpMaqBaldeDTO> BuzonesLimpMaqBalde(int Idobra, string fecDesde, string fecHasta)
        {
            try
            {
                List<BuzonesLimpMaqBaldeDTO> olBuzonLimpMaqBalde = new List<BuzonesLimpMaqBaldeDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("BuzonLimpMaqBalde", new object[]
                {
                    Idobra, fecDesde, fecHasta
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        BuzonesLimpMaqBaldeDTO oBLMB = new BuzonesLimpMaqBaldeDTO();

                        oBLMB.NumeroOrden = dataReader["NumeroOrden"].ToString();
                        oBLMB.FechaInicio = dataReader["FechaInicio"].ToString();
                        oBLMB.sgi = dataReader["Sgi"].ToString();
                        oBLMB.Suministro = dataReader["Suministro"].ToString();
                        oBLMB.Direccion = dataReader["Direccion"].ToString();
                        oBLMB.Urbanizacion = dataReader["Urbanizacion"].ToString();
                        oBLMB.Distrito = dataReader["Distrito"].ToString();
                        oBLMB.Profundidad = Double.Parse(dataReader["profundidad"].ToString());
                        oBLMB.Buzon = dataReader["Buzon"].ToString();
                        oBLMB.marcoMaterial = dataReader["marcoMaterial"].ToString();
                        oBLMB.marcoEstado = dataReader["marcoEstado"].ToString();
                        oBLMB.tapaMaterial = dataReader["tapaMaterial"].ToString();
                        oBLMB.TapaEstado = dataReader["TapaEstado"].ToString();
                        oBLMB.Media = dataReader["Media"].ToString();
                        oBLMB.Cuerpo = dataReader["Cuerpo"].ToString();
                        oBLMB.Techo = dataReader["Techo"].ToString();
                        oBLMB.Emboquillado = dataReader["Emboquillado"].ToString();
                        oBLMB.MarcoNivelado = dataReader["MarcoNivelado"].ToString();
                        olBuzonLimpMaqBalde.Add(oBLMB);
                    }
                }

                return olBuzonLimpMaqBalde;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<BuzonesLimpMaqBaldeDTO>();
            }
        }
    }
}
