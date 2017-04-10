using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using System.Data.OleDb;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.SGE;


namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class CruceMaterialDAO
    {

        public List<CruceMaterialDTO> ListarCruceMaterial(int IdObra, string FechaIni, string FechaFin,int IdCruceMaterial,int IdResponsable)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CruceMateriales",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdCruceMaterial,IdResponsable,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["CantidadEjecutada"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Diferencia"].ToString());
                        oCruceMaterialDTO.EnProceso = Convert.ToDecimal(dataReader["EnProceso"].ToString());
                        oCruceMaterialDTO.Justificado = Convert.ToDecimal(dataReader["Justificado"].ToString());
                        oCruceMaterialDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString() + "  " + dataReader["NombresApellidos"].ToString();
                        oCruceMaterialDTO.Observacionproceso = dataReader["Observacion"].ToString();                       
                        oCruceMaterialDTO.Observacionjustificacion = dataReader["ObservacionJustificado"].ToString();
                        oCruceMaterialDTO.OrdenTrabajo = dataReader["OrdenTrabajo"].ToString();
                        oCruceMaterialDTO.Teorico = Convert.ToDecimal(dataReader["Teorico"].ToString());
                        oCruceMaterialDTO.Observacion = dataReader["Observacion"].ToString() +"  "+ dataReader["ObservacionJustificado"].ToString(); ; 
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }


        public List<CruceMaterialDTO> ListarCruceMaterialNoValorizable(int IdObra, string FechaIni, string FechaFin, int IdCruceMaterial, int IdResponsable)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CruceMaterialesNoValorizable",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdCruceMaterial,IdResponsable,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["CantidadEjecutada"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Diferencia"].ToString());
                        oCruceMaterialDTO.EnProceso = Convert.ToDecimal(dataReader["EnProceso"].ToString());
                        oCruceMaterialDTO.Justificado = Convert.ToDecimal(dataReader["Justificado"].ToString());
                        oCruceMaterialDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Observacionproceso = dataReader["Observacion"].ToString();
                        oCruceMaterialDTO.Observacion = dataReader["Observacion"].ToString() +"  "+ dataReader["ObservacionJustificado"].ToString(); 
                        oCruceMaterialDTO.Observacionjustificacion = dataReader["ObservacionJustificado"].ToString();
                        oCruceMaterialDTO.OrdenTrabajo = dataReader["OrdenTrabajo"].ToString();
                        oCruceMaterialDTO.Teorico = Convert.ToDecimal(dataReader["Teorico"].ToString());
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }

        public List<CruceMaterialDTO> ListarCruceMaterialPorCuadrilla(int IdObra, string FechaIni, string FechaFin, int IdCruceMaterial, int IdResponsable,int IdCuadrilla)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CruceMaterialesPorCuadrilla",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdCruceMaterial,IdResponsable,IdCuadrilla,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["CantidadEjecutada"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Diferencia"].ToString());
                        oCruceMaterialDTO.EnProceso = Convert.ToDecimal(dataReader["EnProceso"].ToString());
                        oCruceMaterialDTO.Justificado = Convert.ToDecimal(dataReader["Justificado"].ToString());
                        //oCruceMaterialDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Observacion = dataReader["Observacion"].ToString();
                        oCruceMaterialDTO.Observacionjustificacion = dataReader["ObservacionJustificado"].ToString();
                        oCruceMaterialDTO.OrdenTrabajo = dataReader["OrdenTrabajo"].ToString();
                        oCruceMaterialDTO.Teorico = Convert.ToDecimal(dataReader["Teorico"].ToString());

                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }



        public List<CruceMaterialDTO> ListarCruceMaterialPorCuadrillaNoValorizable(int IdObra, string FechaIni, string FechaFin, int IdCruceMaterial, int IdResponsable, int IdCuadrilla)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CruceMaterialesPorCuadrillaNoValorizable",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdCruceMaterial,IdResponsable,IdCuadrilla,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["CantidadEjecutada"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Diferencia"].ToString());
                        oCruceMaterialDTO.EnProceso = Convert.ToDecimal(dataReader["EnProceso"].ToString());
                        oCruceMaterialDTO.Justificado = Convert.ToDecimal(dataReader["Justificado"].ToString());
                        //oCruceMaterialDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Observacion = dataReader["Observacion"].ToString();
                        oCruceMaterialDTO.Observacionjustificacion = dataReader["ObservacionJustificado"].ToString();
                        oCruceMaterialDTO.OrdenTrabajo = dataReader["OrdenTrabajo"].ToString();
                        oCruceMaterialDTO.Teorico = Convert.ToDecimal(dataReader["Teorico"].ToString());
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }







        public List<CabeceraCruceMaterialDTO> ListarCabeceraCruceMaterial(int IdObra ,int IdResponsable)
        {
            try
            {


                List<CabeceraCruceMaterialDTO> oListaCabeceraCruceMaterial = new List<CabeceraCruceMaterialDTO>();
                CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO = new CabeceraCruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CabeceraCruceMaterialListar",
                    new object[]
                {
                    IdObra,IdResponsable,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCabeceraCruceMaterialDTO = new CabeceraCruceMaterialDTO();

                        oCabeceraCruceMaterialDTO.FechaFinal = Convert.ToDateTime(dataReader["FechaFinal"].ToString());
                        oCabeceraCruceMaterialDTO.IdCabeceraCruceMaterial = Convert.ToInt32(dataReader["IdCabeceraCruceMaterial"].ToString());
                        oCabeceraCruceMaterialDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                        oCabeceraCruceMaterialDTO.IdResponsable = Convert.ToInt32(dataReader["IdResponsable"].ToString());
                        oCabeceraCruceMaterialDTO.TipoMaterial = Convert.ToInt32(dataReader["TipoMaterial"].ToString());
                        oCabeceraCruceMaterialDTO.Activo = Convert.ToBoolean(dataReader["Activo"].ToString());
                        oCabeceraCruceMaterialDTO.cActivo = Convert.ToBoolean(dataReader["Activo"]) == false ? "Pendiente" : "Revisado";
                        oCabeceraCruceMaterialDTO.cFechaInicial = Convert.ToDateTime(dataReader["FechaInicial"]).ToString("dd/MM/yyyy");
                        oCabeceraCruceMaterialDTO.cFechaFinal = Convert.ToDateTime(dataReader["FechaFinal"]).ToString("dd/MM/yyyy");
                        oCabeceraCruceMaterialDTO.DescripcionValorizable = dataReader["DescripcionTipoMaterial"].ToString();
                        oListaCabeceraCruceMaterial.Add(oCabeceraCruceMaterialDTO);

                    }
                }
                return oListaCabeceraCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CabeceraCruceMaterialDTO>();
            }
        }

        public List< EmpleadoDTO> ListarEmpleadoCargo(int IdBase)
        {
            try
            {


                List<EmpleadoDTO> oListaEmpleadoCargo = new List<EmpleadoDTO>();
                EmpleadoDTO oEmpleadolDTO = new EmpleadoDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableCargoListar",
                    new object[]
                {
                    IdBase,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oEmpleadolDTO = new EmpleadoDTO();
                        oEmpleadolDTO.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                        oEmpleadolDTO.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oEmpleadolDTO.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                        oListaEmpleadoCargo.Add(oEmpleadolDTO);
                    }
                }
                return oListaEmpleadoCargo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<EmpleadoDTO>();
            }
        }

        public List<EmpleadoDTO> ListarEmpleadoCargo2(int IdObra)
        {
            try
            {


                List<EmpleadoDTO> oListaEmpleadoCargo = new List<EmpleadoDTO>();
                EmpleadoDTO oEmpleadolDTO = new EmpleadoDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableCargoListar2",
                    new object[]
                {
                    IdObra,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oEmpleadolDTO = new EmpleadoDTO();
                        oEmpleadolDTO.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                        oEmpleadolDTO.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oEmpleadolDTO.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                        oListaEmpleadoCargo.Add(oEmpleadolDTO);
                    }
                }
                return oListaEmpleadoCargo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<EmpleadoDTO>();
            }
        }

        public List<EmpleadoDTO> ListarEmpleadoCargo3()
        {
            try
            {


                List<EmpleadoDTO> oListaEmpleadoCargo = new List<EmpleadoDTO>();
                EmpleadoDTO oEmpleadolDTO = new EmpleadoDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableCargoListar3");
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oEmpleadolDTO = new EmpleadoDTO();
                        oEmpleadolDTO.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                        oEmpleadolDTO.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oEmpleadolDTO.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                        oListaEmpleadoCargo.Add(oEmpleadolDTO);
                    }
                }
                return oListaEmpleadoCargo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<EmpleadoDTO>();
            }
        }



        public eResultado CabeceraCruceMaterialInsert(CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CabeceraCrucematerialInsert",
                    new object[]
                {
                      oCabeceraCruceMaterialDTO.IdObra,
                      oCabeceraCruceMaterialDTO.IdResponsable,
                      oCabeceraCruceMaterialDTO.FechaInicial,
                      oCabeceraCruceMaterialDTO.FechaFinal,
                   oCabeceraCruceMaterialDTO.TipoMaterial,
                   1,
                   
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }



        public eResultado CruceMaterialObservacionInsert(ObservacionCrucematerialDTO oObservacionCruceMaterialDTO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CrucematerialObservacionInsert",
                    new object[]
                {
                      oObservacionCruceMaterialDTO.IdCabeceraCruceMaterial,
                      oObservacionCruceMaterialDTO.IdTipoObservacion,
                      oObservacionCruceMaterialDTO.IdAuxiliar,
                      oObservacionCruceMaterialDTO.Cantidad,
                      oObservacionCruceMaterialDTO.OrdenTrabajo,
                      oObservacionCruceMaterialDTO.Observacion,
                      oObservacionCruceMaterialDTO.CodigoCuadrilla,
                   1,
                   
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }


        public eResultado CabeceraCruceMaterialUpdate(CabeceraCruceMaterialDTO oCabeceraCruceMaterialDTO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CabeceraCrucematerialUpdate",
                    new object[]
                {
                      oCabeceraCruceMaterialDTO.IdCabeceraCruceMaterial,
          
                   
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }


        public eResultado CruceMaterialObservacionJustificacionInsert(ObservacionCrucematerialDTO oObservacionCruceMaterialDTO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CrucematerialObservacionJustificacionInsert",
                    new object[]
                {
                      oObservacionCruceMaterialDTO.IdCabeceraCruceMaterial,
                      oObservacionCruceMaterialDTO.IdTipoObservacion,
                      oObservacionCruceMaterialDTO.IdAuxiliar,
                      oObservacionCruceMaterialDTO.Cantidad,
                      oObservacionCruceMaterialDTO.OrdenTrabajo,
                      oObservacionCruceMaterialDTO.Observacion,
                      oObservacionCruceMaterialDTO.CodigoCuadrilla,
                   1,
                   
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }



        public eResultado CruceMaterialDelete(int IdCruceMaterial)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CabeceraCruceMaterialDelete",
                    new object[]
                {
                     IdCruceMaterial,
                   
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }


        public List<CruceMaterialDTO> ListarRptCruceMaterialDetalle(int IdObra, string FechaIni, string FechaFin, int IdResponsable ,int IdCuadrilla , string TipoMaterial)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_RptCruceMaterialDetallado",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdResponsable,IdCuadrilla ,TipoMaterial,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["CantidadEjecutada"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Diferencia"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.DESCRIPCIONPRODUCTO = dataReader["DESCRIPCIONPRODUCTO"].ToString();
                        oCruceMaterialDTO.fecha = Convert.ToDateTime(dataReader["fecha"].ToString());
                        oCruceMaterialDTO.FUENTE = dataReader["FUENTE"].ToString();
                        oCruceMaterialDTO.NumeroOT = dataReader["NumeroOT"].ToString();
                        oCruceMaterialDTO.NumeroVale =Convert.ToInt32(dataReader["NumeroVale"].ToString());
                        oCruceMaterialDTO.sgi = dataReader["sgi"].ToString();
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }


        public List<CruceMaterialDTO> ListarRptCruceMaterialDetalleTeorico(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla, string TipoMaterial)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_RptCruceMaterialDetallado2",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdResponsable,IdCuadrilla ,TipoMaterial,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["Cantsub"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Factor"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.DESCRIPCIONPRODUCTO = dataReader["DESCRIPCIONPRODUCTO"].ToString();
                        oCruceMaterialDTO.fecha = Convert.ToDateTime(dataReader["fecha"].ToString());
                        oCruceMaterialDTO.FUENTE = dataReader["FUENTE"].ToString();
                        oCruceMaterialDTO.NumeroOT = dataReader["NumeroOT"].ToString();
                        oCruceMaterialDTO.NumeroVale = Convert.ToInt32(dataReader["NumeroVale"].ToString());
                        oCruceMaterialDTO.sgi = dataReader["sgi"].ToString();
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }


        public List<CruceMaterialDTO> ListarRptCruceMaterialDetalleProducto(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla, string TipoMaterial , int IdAuxiliar)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_RptCruceMaterialDetallado3",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdResponsable,IdCuadrilla ,TipoMaterial,IdAuxiliar,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.CantidadAlmacen = Convert.ToDecimal(dataReader["CantidadAlmacen"].ToString());
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CantidadEjecutada = Convert.ToDecimal(dataReader["CantidadEjecutada"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                        oCruceMaterialDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.Diferencia = Convert.ToDecimal(dataReader["Diferencia"].ToString());
                        oCruceMaterialDTO.MontoAuxiliar = Convert.ToDecimal(dataReader["MontoAuxiliar"].ToString());
                        oCruceMaterialDTO.PrecioAuxiliar = Convert.ToDecimal(dataReader["PrecioAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoCuadrilla2 = dataReader["CodigoCuadrilla"].ToString() + ' ' + dataReader["DescripcionCuadrilla"].ToString();
                        oCruceMaterialDTO.DESCRIPCIONPRODUCTO = dataReader["DESCRIPCIONPRODUCTO"].ToString();
                        oCruceMaterialDTO.fecha = Convert.ToDateTime(dataReader["fecha"].ToString());
                        oCruceMaterialDTO.FUENTE = dataReader["FUENTE"].ToString();
                        oCruceMaterialDTO.NumeroOT = dataReader["NumeroOT"].ToString();
                        oCruceMaterialDTO.NumeroVale = Convert.ToInt32(dataReader["NumeroVale"].ToString());
                        oCruceMaterialDTO.sgi = dataReader["sgi"].ToString();
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }






    }
}
