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
    public class DetalleLimpiezaDAO
    {
        public List<DetalleLimpiezaDTO> ConsultaLimpieza(int cab)
        {
            try
            {
                List<DetalleLimpiezaDTO> oDetalleLimpieza = new List<DetalleLimpiezaDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_SelectLimpieza", new object[]
                {
                    cab,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DetalleLimpiezaDTO oDeLimp = new DetalleLimpiezaDTO();

                        oDeLimp.idCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDeLimp.idLimpieza = Convert.ToInt32(dataReader["IdLimpieza"].ToString());
                        oDeLimp.idCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                        oDeLimp.arena = Convert.ToBoolean(dataReader["arena"].ToString());
                        oDeLimp.cascajo = Convert.ToBoolean(dataReader["cascajos"].ToString());
                        oDeLimp.diametro = dataReader["diametro"].ToString();
                        oDeLimp.fecha = dataReader["fecha"].ToString();
                        oDeLimp.horaFin = dataReader["horaFin"].ToString();
                        oDeLimp.horaInicio = dataReader["horaInicio"].ToString();
                        oDeLimp.longitud = Convert.ToDouble(dataReader["longitud"].ToString());
                        oDeLimp.materialTubo = dataReader["materialTubo"].ToString();
                        oDeLimp.otros = Convert.ToBoolean(dataReader["otros"].ToString());
                        oDeLimp.otrosDesc = dataReader["otrosDescripcion"].ToString();
                        oDeLimp.piedra = Convert.ToBoolean(dataReader["piedras"].ToString());
                        oDeLimp.tiranteFlujo = Convert.ToDouble(dataReader["tiranteFlujo"].ToString());
                        oDeLimp.volumenExtraido = Convert.ToDouble(dataReader["volumenExtraido"].ToString());


                        oDetalleLimpieza.Add(oDeLimp);
                    }
                }
                return oDetalleLimpieza;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DetalleLimpiezaDTO>();
            }
        }

        public eResultado ActualizaLimpieza(DetalleLimpiezaDTO detaLimpia)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ActualizarLimpieza",
                    new object[]
                {
                      detaLimpia.idLimpieza,
                      detaLimpia.longitud,
                      detaLimpia.volumenExtraido,
                      detaLimpia.diametro,
                      detaLimpia.fecha,
                      detaLimpia.horaInicio,
                      detaLimpia.horaFin,
                      detaLimpia.idCuadrilla,
                      detaLimpia.materialTubo,
                      detaLimpia.tiranteFlujo,
                      detaLimpia.arena,
                      detaLimpia.piedra,
                      detaLimpia.cascajo,                                  
                      detaLimpia.otros,
                      detaLimpia.otrosDesc,                      
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

        public eResultado InsertLimpiezaVacio(int cab)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_InsertDetalleLimpiezaVacio",
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

        public List<LimpiezaColectoresMaqBaldesDTO> LimpiezaColectorMaqBalde(int Idobra, string fecDesde, string fecHasta)
        {
            try
            {
                List<LimpiezaColectoresMaqBaldesDTO> olLimpColMaqBalde = new List<LimpiezaColectoresMaqBaldesDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("LimpColectorMaqBalde", new object[]
                {
                    Idobra, fecDesde, fecHasta
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        LimpiezaColectoresMaqBaldesDTO oLCMB = new LimpiezaColectoresMaqBaldesDTO();

                        oLCMB.NumeroOrden = dataReader["NumeroOrden"].ToString();
                        oLCMB.fechaInicio = dataReader["FechaInicio"].ToString();
                        oLCMB.sgi = dataReader["Sgi"].ToString();
                        oLCMB.suministro = dataReader["Suministro"].ToString();
                        oLCMB.Direccion = dataReader["Direccion"].ToString();
                        oLCMB.Urbanizacion =dataReader["Urbanizacion"].ToString();
                        oLCMB.Distrito = (dataReader["Distrito"].ToString());
                        oLCMB.Diametro =dataReader["diametro"].ToString();
                        oLCMB.Arena = dataReader["Arena"].ToString();
                        oLCMB.Cascajos = dataReader["Cascajos"].ToString();
                        oLCMB.Piedras = dataReader["Piedras"].ToString();
                        oLCMB.Otros = dataReader["Otros"].ToString();
                        oLCMB.OtrosDesc =dataReader["OtrosDesc"].ToString();
                        oLCMB.MaterialTubo = dataReader["MaterialTubo"].ToString();
                        oLCMB.estado = dataReader["estado"].ToString();
                        oLCMB.VolumenExt = Convert.ToDouble(dataReader["volumenExtraido"].ToString());
                        oLCMB.Longitud = Convert.ToDouble(dataReader["longitud"].ToString());
                        olLimpColMaqBalde.Add(oLCMB);
                    }
                }

                return olLimpColMaqBalde;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<LimpiezaColectoresMaqBaldesDTO>();
            }
        }

        public List<LimpiezaColectoresMaqBaldesDTO> OrdLimpColectCambioTapaBuz(int Idobra, string fecDesde, string fecHasta)
        {
            try
            {
                List<LimpiezaColectoresMaqBaldesDTO> olLimpColMaqBalde = new List<LimpiezaColectoresMaqBaldesDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("OrdLimpColectCambioTapaBuz", new object[]
                {
                    Idobra, fecDesde, fecHasta
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        LimpiezaColectoresMaqBaldesDTO oLCMB = new LimpiezaColectoresMaqBaldesDTO();

                        oLCMB.NumeroOrden = dataReader["NumeroOrden"].ToString();
                        oLCMB.fechaInicio = dataReader["FechaInicio"].ToString();
                        oLCMB.sgi = dataReader["Sgi"].ToString();
                        oLCMB.suministro = dataReader["Suministro"].ToString();
                        oLCMB.Direccion = dataReader["Direccion"].ToString();
                        oLCMB.Urbanizacion = dataReader["Urbanizacion"].ToString();
                        oLCMB.Distrito = dataReader["Distrito"].ToString();
                        oLCMB.material = dataReader["Material"].ToString();
                        oLCMB.cantidad = Convert.ToDouble(dataReader["Cantidad"].ToString());
                        olLimpColMaqBalde.Add(oLCMB);
                    }
                }

                return olLimpColMaqBalde;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<LimpiezaColectoresMaqBaldesDTO>();
            }
        }

        public List<LimpiezaColectoresMaqBaldesDTO> LimpiezaColBaldeHidro(int Idobra, string fecDesde, string fecHasta)
        {
            try
            {
                List<LimpiezaColectoresMaqBaldesDTO> olLimpColMaqBalde = new List<LimpiezaColectoresMaqBaldesDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("LimpiezaColBaldeHidro", new object[]
                {
                    Idobra, fecDesde, fecHasta
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        LimpiezaColectoresMaqBaldesDTO oLCMB = new LimpiezaColectoresMaqBaldesDTO();

                        oLCMB.NumeroOrden = dataReader["NumeroOrden"].ToString();
                        oLCMB.fechaInicio = dataReader["FechaInicio"].ToString();
                        oLCMB.sgi = dataReader["Sgi"].ToString();
                        oLCMB.DescripcionSubActividad1 = dataReader["SubActividad"].ToString();
                        oLCMB.suministro = dataReader["Suministro"].ToString();
                        oLCMB.Direccion = dataReader["Direccion"].ToString();
                        oLCMB.Urbanizacion = dataReader["Urbanizacion"].ToString();
                        oLCMB.Distrito = dataReader["Distrito"].ToString();
                        oLCMB.material = dataReader["MaterialTubo"].ToString();
                        oLCMB.estado = dataReader["EstadoTramo"].ToString();
                        oLCMB.Longitud = Convert.ToDouble(dataReader["longitud"].ToString());
                        oLCMB.Diametro = dataReader["diametro"].ToString();
                        oLCMB.CuadrillaLimpieza = dataReader["CuadrillaLimpieza"].ToString();
                        oLCMB.CuadrillaTelevisada = dataReader["CuadrillaTelevisada"].ToString();
                        oLCMB.Cuadrilla = dataReader["Cuadrilla"].ToString();
                        oLCMB.NroConexiones = Convert.ToInt32(dataReader["NroConexiones"].ToString());
                        olLimpColMaqBalde.Add(oLCMB);
                    }
                }

                return olLimpColMaqBalde;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<LimpiezaColectoresMaqBaldesDTO>();
            }
        }
    }
}
