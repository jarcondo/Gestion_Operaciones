using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.Common;
using Intranet.DTO.ProduccionServicios.Procesos.ConsumoMaterial;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.DAO.ProduccionServicios.Proceso.ConsumoMaterial
{
    public class DetallePurgaDAO
    {
        public List<DetallePurgaDTO> ConsultaPurga(int IdCabcera)
        {
            try
            {
                List<DetallePurgaDTO> oDetallePurga = new List<DetallePurgaDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectPurga", new object[]
                {
                    IdCabcera,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetallePurgaDTO oDetPurga = new DetallePurgaDTO();

                        oDetPurga.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDetPurga.IdPurga = Convert.ToInt32(dataReader["IdPurga"].ToString());
                        oDetPurga.ANF = Convert.ToDouble(dataReader["ANF"].ToString());
                        oDetPurga.caracteristicaAgua = dataReader["CaracteristicaAgua"].ToString();
                        oDetPurga.CGI = dataReader["CGI"].ToString();
                        oDetPurga.cloro = Convert.ToDouble(dataReader["Cloro"].ToString());
                        oDetPurga.colorAgua = dataReader["ColorAgua"].ToString();
                        oDetPurga.descargaEn = dataReader["DescargaEn"].ToString();
                        oDetPurga.distanciaDescarga = Convert.ToDouble(dataReader["DistanciaDescarga"].ToString());
                        oDetPurga.InopCambio = Convert.ToBoolean(dataReader["InopCambio"].ToString());
                        oDetPurga.InopCorrectivo = Convert.ToBoolean(dataReader["InopCorrectivo"].ToString());
                        oDetPurga.losaDeteriorada = Convert.ToBoolean(dataReader["LosaDeteriorada"].ToString());
                        oDetPurga.mantenimiento = Convert.ToBoolean(dataReader["Mantenimiento"].ToString());
                        oDetPurga.marca = dataReader["Marca"].ToString();
                        oDetPurga.nroBocas = Convert.ToInt32(dataReader["NroBocas"].ToString());
                        oDetPurga.nroTapas = Convert.ToInt32(dataReader["NroTapas"].ToString());
                        oDetPurga.observacion = dataReader["Observacion"].ToString();
                        oDetPurga.opPrevMayor = Convert.ToBoolean(dataReader["OpPrevMayor"].ToString());
                        oDetPurga.opPrevMenor = Convert.ToBoolean(dataReader["OpPrevMenor"].ToString());
                        oDetPurga.presion = Convert.ToDouble(dataReader["Presion"].ToString());
                        oDetPurga.sector = Convert.ToInt32(dataReader["Sector"].ToString());
                        oDetPurga.sinMyT = Convert.ToBoolean(dataReader["SinMyT"].ToString());
                        oDetPurga.tiempoPurga = Convert.ToDouble(dataReader["TiempoPurga"].ToString());
                        oDetPurga.ubica = Convert.ToBoolean(dataReader["Ubica"].ToString());

                        oDetallePurga.Add(oDetPurga);
                    }
                }
                return oDetallePurga;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetallePurgaDTO>();
            }
        }

        public eResultado ActualizaPurga(DetallePurgaDTO detaPurga)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizaPurga",
                    new object[]
                {
                      detaPurga.IdPurga,
                      detaPurga.sector,
                      detaPurga.tiempoPurga,
                      detaPurga.presion,
                      detaPurga.cloro,
                      detaPurga.ANF,
                      detaPurga.caracteristicaAgua,
                      detaPurga.opPrevMayor,
                      detaPurga.opPrevMenor,
                      detaPurga.InopCorrectivo,
                      detaPurga.InopCambio,
                      detaPurga.marca,
                      detaPurga.nroBocas,                                  
                      detaPurga.nroTapas,
                      detaPurga.CGI,                      
                      detaPurga.ubica,
                      detaPurga.sinMyT,
                      detaPurga.losaDeteriorada,
                      detaPurga.mantenimiento,
                      detaPurga.colorAgua,
                      detaPurga.descargaEn,
                      detaPurga.distanciaDescarga,
                      detaPurga.observacion,
                });

                int resul=db.ExecuteNonQuery(dbCommand);
                if (resul > 0)
                {
                    return eResultado.Correcto;
                }
                else
                {
                    return eResultado.Error;
                }
            }
           
        }

        public eResultado InsertPurgaVacio(int IdCabecera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertPurgaVacio",
                    new object[]
                {
                    IdCabecera,        
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

        public List<PurgaDTO> ReportePurga(int Idobra, string fecDesde, string fecHasta)
        {
            try
            {
                List<PurgaDTO> lPurga = new List<PurgaDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("ReportePurga", new object[]
                {
                    Idobra, fecDesde, fecHasta
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        PurgaDTO oPurga = new PurgaDTO();

                        oPurga.Direccion = dataReader["Direccion"].ToString();
                        oPurga.Urbanizacion = dataReader["Urbanizacion"].ToString();
                        oPurga.Distrito = dataReader["Distrito"].ToString();
                        oPurga.sgi = dataReader["Sgi"].ToString();
                        oPurga.Suministro = dataReader["Suministro"].ToString();
                        oPurga.Sector = Convert.ToInt32(dataReader["Sector"].ToString());
                        oPurga.FechaInicio = dataReader["FechaInicio"].ToString();
                        oPurga.TiempoPurga = Double.Parse(dataReader["TiempoPurga"].ToString());
                        oPurga.Presion = Double.Parse(dataReader["Presion"].ToString());
                        oPurga.Cloro = Double.Parse(dataReader["Cloro"].ToString());
                        oPurga.ANF = Double.Parse(dataReader["ANF"].ToString());
                        oPurga.OpPrevMayor = dataReader["OpPrevMayor"].ToString();
                        oPurga.OpPrevMenor = dataReader["OpPrevMenor"].ToString();
                        oPurga.InopCorrectivo = dataReader["InopCorrectivo"].ToString();
                        oPurga.InopCambio = dataReader["InopCambio"].ToString();
                        oPurga.Marca = dataReader["Marca"].ToString();
                        oPurga.NroBocas = Convert.ToInt32(dataReader["NroBocas"].ToString());
                        oPurga.NroTapas = Convert.ToInt32(dataReader["NroTapas"].ToString());
                        oPurga.Ubica = dataReader["Ubica"].ToString();
                        oPurga.SinMyT = dataReader["SinMyT"].ToString();
                        oPurga.LosaDeteriorada = dataReader["LosaDeteriorada"].ToString();
                        oPurga.MantSi = dataReader["MantSi"].ToString();
                        oPurga.MantNo = dataReader["MantNo"].ToString();
                        oPurga.CaracteristicaAgua = dataReader["CaracteristicaAgua"].ToString();
                        oPurga.ColorAgua = dataReader["ColorAgua"].ToString();
                        oPurga.DescargaEn = dataReader["DescargaEn"].ToString();
                        oPurga.DistanciaDescarga = dataReader["DistanciaDescarga"].ToString();
                        oPurga.Observacion = dataReader["Observacion"].ToString();
                        lPurga.Add(oPurga);
                    }
                }

                return lPurga;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<PurgaDTO>();
            }
        }
    }
}
