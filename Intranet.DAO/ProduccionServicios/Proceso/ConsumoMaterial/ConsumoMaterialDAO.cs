using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios.Reportes;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class ConsumoMaterialDAO
    {

        public List<DatosValorizacionDTO> ObtenerVerificarMontos(int IdObra, DataTable ListaSgi)
        {
            try
            {
                List<DatosValorizacionDTO> olEjecucionOT = new List<DatosValorizacionDTO>();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Gestion"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PRO_ObtenerVerificarMontos";
                sqlCommand.Connection = connection;
                sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                sqlCommand.Parameters.Add("ListaSGI", SqlDbType.Structured).Value = ListaSgi;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection.Open();


                using (IDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DatosValorizacionDTO oEjec = new DatosValorizacionDTO();
                        //oEjec.ENLACE = dataReader["ENLACE"].ToString();
                        //oEjec.CODIGO = dataReader["CODIGO"].ToString();
                        oEjec.DESCRIP = dataReader["DESCRIP"].ToString();
                        //oEjec.SumaDeCANTIDAD = Convert.ToDecimal(dataReader["SumaDeCANTIDAD"].ToString());
                        //oEjec.PRECIO_UNI = Convert.ToDecimal(dataReader["PRECIO_UNI"].ToString());
                        //oEjec.Tipo = dataReader["Tipo"].ToString();
                        //oEjec.NOMACTIVID = dataReader["NOMACTIVID"].ToString();
                        //oEjec.SGI = dataReader["SGI"].ToString();
                        //oEjec.UNIDAD = dataReader["UNIDAD"].ToString();
                        olEjecucionOT.Add(oEjec);
                    }
                }
                sqlCommand.Connection.Close();


                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DatosValorizacionDTO>();
            }
        }

        public List<DatosValorizacionDTO> ObtenerDatosExistenciaOT(int IdObra, DataTable ListaSgi)
        {
            try
            {
                List<DatosValorizacionDTO> olEjecucionOT = new List<DatosValorizacionDTO>();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Gestion"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PRO_mDObtenerExistenciaOT";
                sqlCommand.Connection = connection;
                sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                sqlCommand.Parameters.Add("ListaSGI", SqlDbType.Structured).Value = ListaSgi;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection.Open();



                using (IDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DatosValorizacionDTO oEjec = new DatosValorizacionDTO();
                        //oEjec.ENLACE = dataReader["ENLACE"].ToString();
                        //oEjec.CODIGO = dataReader["CODIGO"].ToString();
                        oEjec.DESCRIP = dataReader["DESCRIP"].ToString();
                        //oEjec.SumaDeCANTIDAD = Convert.ToDecimal(dataReader["SumaDeCANTIDAD"].ToString());
                        //oEjec.PRECIO_UNI = Convert.ToDecimal(dataReader["PRECIO_UNI"].ToString());
                        //oEjec.Tipo = dataReader["Tipo"].ToString();
                        //oEjec.NOMACTIVID = dataReader["NOMACTIVID"].ToString();
                        //oEjec.SGI = dataReader["SGI"].ToString();
                        //oEjec.UNIDAD = dataReader["UNIDAD"].ToString();
                        olEjecucionOT.Add(oEjec);
                    }
                }
                sqlCommand.Connection.Close();


                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DatosValorizacionDTO>();
            }
        }

        public eResultado ColocarSGIaOTmanuales(Int32 mSGI, Int32 midcabecera)
        {
            try
            {
                string resultado = "";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("ColocarSGIaOTmanuales", new object[]
                {
                    mSGI,midcabecera
                });
                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    
                    while (dataReader.Read())
                    {
                        resultado = dataReader["Resultado"].ToString();
                    }
                }

                if (resultado.ToUpper() == "NINGUNO") return eResultado.Correcto;



                if (resultado.Contains("Al correlativo"))
                {
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message =resultado, Buttons = Ext.Net.MessageBox.Button.OK });
                    return eResultado.Correcto;
                }
                else
                {
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = resultado, Buttons = Ext.Net.MessageBox.Button.OK });
                    return eResultado.Error;
                }

                
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }

        public List<CabeceraDTO> ObtenerCabeceraConsumo(int IdObra,int usuario, string sgi,int correlativo,string nroOT)
        {
            try
            {
                List<CabeceraDTO> olCabecera = new List<CabeceraDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_Obtener", new object[]
                {
                    IdObra,
                    usuario,
                    sgi,
                    correlativo,
                    nroOT
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        CabeceraDTO oCabecera = new CabeceraDTO();
                        oCabecera.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oCabecera.Obra = new ObraDTO()
                        {
                            IdObra = Convert.ToInt32(dataReader["IdObra"].ToString()),
                            DescripcionCorta = dataReader["DescripcionCorta"].ToString(),
                        };
                        oCabecera.Distrito = new DistritoDTO()
                        {
                            IdDistrito = Convert.ToInt32(dataReader["IdDistrito"].ToString()),
                            Distrito = dataReader["Distrito"].ToString(),
                        };
                        oCabecera.Observacion = dataReader["ObservacionC"].ToString();
                        oCabecera.Urbanizacion = dataReader["Urbanizacion"].ToString();
                        oCabecera.Direccion = dataReader["Direccion"].ToString();
                        oCabecera.Cliente = dataReader["Cliente"].ToString();
                        oCabecera.Sgi = dataReader["Sgi"].ToString();
                        oCabecera.Suministro = dataReader["Suministro"].ToString();
                        oCabecera.NumeroOrden = dataReader["NumeroOrden"].ToString();
                        oCabecera.FechaOrden = dataReader["FechaOrden"].ToString();
                        oCabecera.Actividad = new ActividadDTO()
                        {
                            IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString()),
                            Descripcion1 = dataReader["Descripcion1"].ToString(),
                            Descripcion2 = dataReader["Descripcion2"].ToString(),
                        };
                        oCabecera.FechaDigitacion = dataReader["FechaDigitacion"].ToString();
                        oCabecera.FechaProgramacion = dataReader["FechaProgramacion"].ToString();
                        oCabecera.FechaInicio = dataReader["FechaInicio"].ToString();
                        oCabecera.HoraInicio = dataReader["HoraInicio"].ToString();
                        oCabecera.FechaTermino = dataReader["FechaTermino"].ToString();
                        oCabecera.Horatermino = dataReader["HoraTermino"].ToString();
                        oCabecera.HorasTrabajadas = Convert.ToDecimal(dataReader["HorasTrabajadas"].ToString() == "" ? "0" : dataReader["HorasTrabajadas"].ToString());
                        oCabecera.NumeroTrabajadores = Convert.ToInt32(dataReader["NumeroTrabajadores"].ToString() == "" ? "0" : dataReader["NumeroTrabajadores"].ToString());
                        if (dataReader["IdCuadrilla"].ToString() != "")
                            oCabecera.Cuadrilla = new CuadrillaDTO()
                            {
                                IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString()),
                                //Descripcion = dataReader["Descripcion"].ToString(),
                            };
                        else
                            oCabecera.Cuadrilla = new CuadrillaDTO()
                            {
                                IdCuadrilla = 0,
                            };
                        oCabecera.IdZona = dataReader["IdZona"].ToString();

                        oCabecera.EstadoOT = new EstadoOTDTO()
                        {
                            IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"].ToString()),
                            DescripcionEstado = dataReader["DescripcionEstado"].ToString(),
                        };
                        //oCabecera.NroRegistro = Convert.ToInt32("1");//Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oCabecera.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oCabecera.CostoOPEN = Convert.ToDecimal(dataReader["ncosto_ot"].ToString() == "" ? "0" : dataReader["ncosto_ot"].ToString());
                        oCabecera.EstadoOTRO = new EstadoOTDTO()
                        {
                            IdEstadoOT = Convert.ToInt32(dataReader["EstadoRO"].ToString()),
                        };
                        oCabecera.NroCargo = dataReader["NroCargo"].ToString();
                        olCabecera.Add(oCabecera);
                    }
                }
                return olCabecera;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CabeceraDTO>();
            }
        }

        public List<ConsumoMaterialDTO> ObtenerDetalleConsumo(int IdCabecera)
        {
            try
            {
                List<ConsumoMaterialDTO> olConsumo = new List<ConsumoMaterialDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Detalle_ListarDetalles", new object[]
                {
                    IdCabecera,
                });
                
                dbCommand.CommandTimeout = 0;
                
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    int cont = 1;
                    while (dataReader.Read())
                    {
                        ConsumoMaterialDTO oConsumo = new ConsumoMaterialDTO();
                        oConsumo.Item = cont;
                        oConsumo.IdTipo = Convert.ToInt32(dataReader["IdTipo"].ToString());
                        oConsumo.Tipo = dataReader["Tipo"].ToString();
                        oConsumo.ID = Convert.ToInt32(dataReader["ID"].ToString());
                        oConsumo.Descripcion = dataReader["Descripcion"].ToString();
                        oConsumo.Unidad = dataReader["Unidad"].ToString();
                        oConsumo.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                        oConsumo.Precio = Convert.ToDecimal(dataReader["Costo"].ToString());
                        oConsumo.SubTotal = Convert.ToDecimal(dataReader["SubTotal"].ToString());
                        oConsumo.SGIO = Convert.ToBoolean(dataReader["SGIO"].ToString());
                        oConsumo.Observacion = dataReader["Observacion"].ToString();
                        olConsumo.Add(oConsumo);
                        cont++;
                    }
                }

                return olConsumo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<ConsumoMaterialDTO>();  
            }
        }

        public DetalleDTO ObtenerDetallePorID(int IdDetalle)
        {
            try
            {


                DetalleDTO oDetalle = new DetalleDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Detalle_ObtenerPorID", new object[]
                {
                    IdDetalle,
                });
                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oDetalle = new DetalleDTO();
                        oDetalle.IdDetalle = Convert.ToInt32(dataReader["IdDetalle"].ToString());
                        oDetalle.Cabecera = new CabeceraDTO()
                        {
                            IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString()),
                        };

                        oDetalle.Catalogo = new CatalogoDTO()
                        {
                            IdProCatalogo = Convert.ToInt32(dataReader["IdCatalogo"].ToString()),
                        };
                        oDetalle.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                        oDetalle.Costo = Convert.ToDecimal(dataReader["Costo"].ToString());
                        oDetalle.SGIO = Convert.ToBoolean(dataReader["SGIO"].ToString());
                        oDetalle.Observacion = dataReader["Observacion"].ToString();
                    }
                }

                return oDetalle;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new DetalleDTO();  
            }
        }

        public DetalleSubActividadDTO ObtenerDetalleSubActividadPorID(int IdDetalleSubAct)
        {
            try
            {


                DetalleSubActividadDTO oDetalle = new DetalleSubActividadDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_DetalleSubActividad_ObtenerPorID", new object[]
                {
                    IdDetalleSubAct,
                });
                dbCommand.CommandTimeout = 0;

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oDetalle = new DetalleSubActividadDTO();
                        oDetalle.IdDetalleSubAct = Convert.ToInt32(dataReader["IdDetalleSubAct"].ToString());
                        oDetalle.IdCabecera = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        oDetalle.IdSubActividad = Convert.ToInt32(dataReader["IdSubActividad"].ToString());
                        oDetalle.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                        oDetalle.Costo = Convert.ToDecimal(dataReader["Costo"].ToString());
                        oDetalle.SGIO = Convert.ToBoolean(dataReader["SGIO"].ToString());
                        oDetalle.IdCuadrilla = Convert.ToInt32(string.IsNullOrEmpty(dataReader["IdCuadrilla"].ToString()) ? "0" : dataReader["IdCuadrilla"].ToString());
                        oDetalle.IdProveedor = Convert.ToInt32(string.IsNullOrEmpty(dataReader["IdProveedor"].ToString()) ? "0" : dataReader["IdProveedor"].ToString());
                        oDetalle.Observacion = dataReader["Observacion"].ToString();
                    }
                }

                return oDetalle;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new DetalleSubActividadDTO();
            }
        }

        public eResultado InsertarDetalleSubActividad(DetalleSubActividadDTO oDetSub, int IdCuadrilla, int IdProveedor, int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_DetalleSubActividad_Insertar",
                    new object[]
                {
                   oDetSub.IdCabecera,
                   oDetSub.IdSubActividad,
                   oDetSub.Cantidad,
                   oDetSub.Costo,
                   false,
                   Usuario,
                   DateTime.Now,
                   IdCuadrilla,
                   IdProveedor,oDetSub.Observacion
                });
                dbCommand.CommandTimeout = 0;
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

        public eResultado InsertarDetalleMaterial(DetalleDTO oDet, int Usuario)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_DetalleMaterial_Insertar",
                    new object[]
                {
                   oDet.Cabecera.IdCabecera,
                   oDet.Catalogo.IdProCatalogo,
                   oDet.Cantidad,
                   oDet.Costo,
                   false,
                   Usuario,
                   DateTime.Now,oDet.Observacion
                });
                dbCommand.CommandTimeout = 0;
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

        public int InsertarNuevaCabecera(CabeceraDTO oCabecera, int Usuario,ref int correlativo)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_InsertarSinSGI",
                    new object[]
                {
                    oCabecera.Obra.IdObra
                    ,oCabecera.Distrito.IdDistrito
                    ,oCabecera.Urbanizacion
                    ,oCabecera.Direccion
                    ,oCabecera.Sgi
                    ,oCabecera.Suministro
                    ,oCabecera.NumeroOrden
                    ,oCabecera.Actividad.IdActividad
                    ,oCabecera.FechaDigitacion
                    ,oCabecera.FechaInicio
                    ,oCabecera.HoraInicio
                    ,oCabecera.FechaTermino
                    ,oCabecera.Horatermino
                    ,oCabecera.HorasTrabajadas
                    ,oCabecera.NumeroTrabajadores
                    ,oCabecera.Cuadrilla.IdCuadrilla
                    ,oCabecera.EstadoOT.IdEstadoOT
                    ,Usuario,oCabecera.Cliente,oCabecera.Observacion
                });

                int codigo = 0;
                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        codigo = Convert.ToInt32(dataReader["IdCabecera"].ToString());
                        correlativo = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                    }
                }
                return codigo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return 0;
            }
        }

        public eResultado ActualizarCabecera(CabeceraDTO oCabecera, int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_ActualizarCabecera",
                    new object[]
                {
                    oCabecera.IdCabecera
                    ,oCabecera.NumeroOrden
                    ,oCabecera.FechaOrden
                    ,oCabecera.FechaDigitacion
                    ,oCabecera.FechaProgramacion
                    ,oCabecera.FechaInicio
                    ,oCabecera.HoraInicio
                    ,oCabecera.FechaTermino
                    ,oCabecera.Horatermino
                    ,oCabecera.HorasTrabajadas
                    ,oCabecera.NumeroTrabajadores
                    ,oCabecera.Cuadrilla.IdCuadrilla
                    ,oCabecera.EstadoOT.IdEstadoOT
                    ,Usuario
                    ,DateTime.Now,oCabecera.Cliente,oCabecera.Direccion,oCabecera.Urbanizacion,oCabecera.Observacion
                });

                dbCommand.CommandTimeout = 0;

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

        public eResultado ActualizarDetalle(DetalleDTO oDetalle, int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Detalle_Actualizar",
                    new object[]
                {
                    oDetalle.IdDetalle
                    ,oDetalle.Catalogo.IdProCatalogo
                    ,oDetalle.Cantidad
                    ,oDetalle.Costo
                    ,Usuario
                    ,DateTime.Now,oDetalle.Observacion
                });
                dbCommand.CommandTimeout = 0;
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

        public eResultado ActualizarDetalleSubActividad(DetalleSubActividadDTO oDetalle, int IdCuadrilla,int IdProveedor, int Usuario)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_DetalleSubActividad_Actualizar",
                    new object[]
                {
                    oDetalle.IdDetalleSubAct
                    ,oDetalle.IdSubActividad
                    ,oDetalle.Cantidad
                    ,oDetalle.Costo
                    ,Usuario
                    ,DateTime.Now
                    ,IdCuadrilla
                    ,IdProveedor,oDetalle.Observacion
                });
                dbCommand.CommandTimeout = 0;
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

        public eResultado EliminarDetalle(int IdDetalle, int Usuario)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Detalle_Eliminar",
                    new object[]
                {
                    IdDetalle
                    ,Usuario
                    ,DateTime.Now
                });
                dbCommand.CommandTimeout = 0;
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

        public eResultado EliminarDetalleSubActividad(int IdDetalleSubAct, int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_DetalleSubActividad_Eliminar",
                    new object[]
                {
                    IdDetalleSubAct
                    ,Usuario
                    ,DateTime.Now
                });
                dbCommand.CommandTimeout = 0;
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

        public List<ConsumoMaterialDTO> ObtenerCargoSGIs(int IdCargoEntrega)
        {
            try
            {
                List<ConsumoMaterialDTO> olCargo = new List<ConsumoMaterialDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoSGI_Obtener", new object[]
                {
                    IdCargoEntrega,
                });
                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ConsumoMaterialDTO oCargo = new ConsumoMaterialDTO();
                        oCargo.Descripcion = dataReader["SGI"].ToString();
                        oCargo.Tipo = dataReader["FechaCrea"].ToString();
                        olCargo.Add(oCargo);
                    }
                }

                return olCargo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<ConsumoMaterialDTO>();
            }
        }

        public eResultado InsertarCargoSGI(int IdCargoEntrega, int IdObra, string IdCabecera, int Usuario)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoSGI_Insertar",
                    new object[]
                {

                   IdCargoEntrega,
                   IdObra,
                   Convert.ToInt32(IdCabecera),
                   Usuario
                });

                dbCommand.CommandTimeout = 0;

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

        public eResultado EliminarCargoSGI(int Usuario)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoSGI_Eliminar",
                    new object[]
                {
                   Usuario
                });
                dbCommand.CommandTimeout = 0;

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

        public List<CargoEntregaDTO> ObtenerCargoEntrega(int Usuario, int IdObra,string Ordenacion,int idcargo)
        {
            try
            {
                List<CargoEntregaDTO> olCargos = new List<CargoEntregaDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoSGI_ObtenerCargoEntrega", new object[]
                //DbCommand dbCommand = db.GetStoredProcCommand("PRO_ObtenerCargoEntrega", new object[]
                {
                    Usuario,IdObra,Ordenacion,idcargo
                });

                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    int cont = 1;
                    while (dataReader.Read())
                    {
                        CargoEntregaDTO cargo = new CargoEntregaDTO();
                        cargo.Item = cont;
                        cargo.NroCargo = dataReader["NroCargo"].ToString();
                        cargo.Area = dataReader["Area"].ToString();
                        cargo.Residente = dataReader["Responsable"].ToString();
                        cargo.SGI = dataReader["SGI"].ToString();
                        cargo.NIS = dataReader["NIS"].ToString();
                        cargo.ACTIVIDAD = dataReader["ACTIVIDAD"].ToString();
                        cargo.SUBACTIVIDAD = dataReader["SUBACTIVIDAD"].ToString();
                        cargo.ORDEN = dataReader["ORDEN"].ToString();
                        cargo.FechaEjecucion = dataReader["FechaEjecucion"].ToString();
                        cargo.MUNICIPIO = dataReader["MUNICIPIO"].ToString();
                        cargo.LOCALIDAD = dataReader["LOCALIDAD"].ToString();
                        cargo.DIRECCION = dataReader["DIRECCION"].ToString();
                        cargo.CUADRILLA = dataReader["CUADRILLA"].ToString();
                        cargo.DISTRITO = dataReader["DISTRITO"].ToString();
                        cargo.DESDISTRITO = dataReader["DESDISTRITO"].ToString();
                        cargo.FechaEmision = dataReader["FechaEmision"].ToString();
                        cargo.ESTADO = dataReader["ESTADO"].ToString();
                        cargo.COSTO_SEDAPRO = Convert.ToDecimal(dataReader["COSTO_SEDAPRO"].ToString());
                        cargo.COSTO_OPEN = Convert.ToDecimal(dataReader["COSTO_OPEN"].ToString());
                        cargo.DIFERENCIA = Convert.ToDecimal(dataReader["DIFERENCIA"].ToString());
                        olCargos.Add(cargo);
                        cont++;
                    }
                }

                return olCargos;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CargoEntregaDTO>();
            }
        }

        public List<CargoSIODTO> ObtenerCargo(int IdObra,int Usuario)
        {
            try
            {
                List<CargoSIODTO> olCargos = new List<CargoSIODTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoEntrega_Obtener",
                    new object[]
                {
                   IdObra,Usuario
                });
                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        CargoSIODTO cargo = new CargoSIODTO();
                        cargo.IdCargoEntrega = Convert.ToInt32(dataReader["IdCargoEntrega"].ToString());
                        cargo.NombreCargo = dataReader["NombreCargo"].ToString();
                        olCargos.Add(cargo);
                    }
                }

                return olCargos;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CargoSIODTO>();
            }
        }

        public int ValidarExistenciaCargo(string SGI)
        {
            try
            {
                int resultado;
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoSGI_ValidarExistencia",
                    new object[]
                {
                   SGI
                });

                dbCommand.CommandTimeout = 0;

                resultado = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                return resultado;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return 2;
            }
        }

        public eResultado InsertarCargoEntrada(int IdObra, string NombreCargo, int Usuario)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoEntrega_Insertar",
                    new object[]
                {
                   IdObra,
                   NombreCargo,
                   Usuario
                });
                dbCommand.CommandTimeout = 0;
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

         public eResultado EliminarSGICargo(int IdObra, string sgi, int Usuario)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CargoSGI_EliminarSGI",
                    new object[]
                {
                   IdObra,
                   sgi,
                   Usuario,
                });
                dbCommand.CommandTimeout = 0;
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

         public eResultado ProcesarOTs(int idObra, int usuario)
         {
             try
             {
                 Database db = DatabaseFactory.CreateDatabase();
                 
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_ProcesarOTs",
                     new object[]
                {
                    idObra,usuario
                });
                 dbCommand.CommandTimeout = 0;
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

         public List<EjecucionOTFechaDTO> ObtenerEjecucionOTFecha(int IdObra, string fecDesde,string fecHasta)
         {
             try
             {
                 List<EjecucionOTFechaDTO> olEjecucionOT = new List<EjecucionOTFechaDTO>();
                 Database db = DatabaseFactory.CreateDatabase();
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_ObtenerEjecucionOTFecha", new object[]
                {
                    IdObra,fecDesde, fecHasta
                });
                 dbCommand.CommandTimeout = 0;

                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         EjecucionOTFechaDTO oEjec = new EjecucionOTFechaDTO();

                         oEjec.Sgi = dataReader["Sgi"].ToString();
                         oEjec.NumeroOrden = dataReader["NumeroOrden"].ToString();
                         oEjec.Suministro = dataReader["Suministro"].ToString();
                         oEjec.Estado = dataReader["Estado"].ToString();
                         oEjec.Direccion = dataReader["Direccion"].ToString();
                         oEjec.Urbanizacion = dataReader["Urbanizacion"].ToString();
                         oEjec.Distrito = dataReader["Distrito"].ToString();
                         
                         oEjec.FechaInicio = dataReader["FechaInicio"].ToString();
                         oEjec.HoraInicio = dataReader["HoraInicio"].ToString();
                         oEjec.FechaTermino = dataReader["FechaTermino"].ToString();
                         oEjec.Horatermino = dataReader["Horatermino"].ToString();
                         oEjec.SubActividad = dataReader["SubActividad"].ToString();
                         oEjec.Cuadrilla = dataReader["CuadPrincipal"].ToString();
                         oEjec.PuntajePrincipal = Convert.ToDecimal(dataReader["PuntajePrincipal"].ToString() == DBNull.Value.ToString() ? "0.0" : dataReader["PuntajePrincipal"].ToString());
                         oEjec.CuadReposicion = (dataReader["CuadReposicion"].ToString() == null ? "" : dataReader["CuadReposicion"].ToString());
                         oEjec.PuntajeReposicion = Convert.ToDecimal(dataReader["PuntajeReposicion"].ToString() == DBNull.Value.ToString() ? "0.0" : dataReader["PuntajeReposicion"].ToString());
                         oEjec.PuntajeTotal = oEjec.PuntajePrincipal + oEjec.PuntajeReposicion;
                         oEjec.Diametro = Convert.ToDecimal(dataReader["Diametro"].ToString());
                         oEjec.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                         oEjec.Total = Convert.ToDecimal(dataReader["Total"].ToString());
                         olEjecucionOT.Add(oEjec);
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<EjecucionOTFechaDTO>();
             }
         }

         public List<EjecucionOTCuadrillaDTO> ObtenerEjecucionOTCuadrilla(int IdObra, string fecDesde, string fecHasta)
         {
             try
             {
                 List<EjecucionOTCuadrillaDTO> olEjecucionOT = new List<EjecucionOTCuadrillaDTO>();
                 Database db = DatabaseFactory.CreateDatabase();
                 
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_ObtenerEjecucionOTCuadrilla", new object[]
                {
                    IdObra,fecDesde, fecHasta
                });

                 
                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         EjecucionOTCuadrillaDTO oEjec = new EjecucionOTCuadrillaDTO();

                         oEjec.Base = dataReader["Base"].ToString();
                         oEjec.Obra = dataReader["Obra"].ToString();
                         oEjec.FDesde = dataReader["FechaDesde"].ToString();
                         oEjec.FHasta = dataReader["FechaHasta"].ToString();
                         oEjec.Cuadrilla = dataReader["CUADRILLA"].ToString();
                         oEjec.TotalSubAct = Convert.ToDecimal(dataReader["SUBACTIVIDAD"].ToString());
                         oEjec.TotalMat = Convert.ToDecimal(dataReader["MATERIAL"].ToString());
                         oEjec.TotalRes = Convert.ToDecimal(dataReader["RESANE"].ToString());
                         oEjec.Total = Convert.ToDecimal(dataReader["TOTAL"].ToString());
                         
                         olEjecucionOT.Add(oEjec);
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<EjecucionOTCuadrillaDTO>();
             }
         }

         public List<EjecucionOTCuadrillaDTO> ObtenerEjecucionOTCuadrillaDet(int IdObra, string fecDesde, string fecHasta)
         {
             try
             {
                 List<EjecucionOTCuadrillaDTO> olEjecucionOT = new List<EjecucionOTCuadrillaDTO>();
                 Database db = DatabaseFactory.CreateDatabase();

                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_ObtenerEjecucionOTCuadrillaDetallado", new object[]
                {
                    IdObra,fecDesde, fecHasta
                });


                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         EjecucionOTCuadrillaDTO oEjec = new EjecucionOTCuadrillaDTO();
                         oEjec.Base = dataReader["Base"].ToString();
                         oEjec.Obra = dataReader["Obra"].ToString();
                         oEjec.FDesde = dataReader["FechaDesde"].ToString();
                         oEjec.FHasta = dataReader["FechaHasta"].ToString();
                         oEjec.TotalSubAct = Decimal.Parse(dataReader["TotalSubAct"].ToString());
                         oEjec.TotalMat = Decimal.Parse(dataReader["TotalMat"].ToString());
                         oEjec.TotalRes = Decimal.Parse(dataReader["TotalRes"].ToString());
                         oEjec.Total = Decimal.Parse(dataReader["Total"].ToString());
                         oEjec.Tipo = dataReader["TIPO"].ToString();
                         oEjec.Actividad = dataReader["ACTIVIDAD"].ToString();
                         oEjec.Unidad = dataReader["Unidad"].ToString();
                         oEjec.Codigo = dataReader["Codigo"].ToString();
                         oEjec.SubActividad = dataReader["SUBACTIVIDAD"].ToString();
                         oEjec.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                         oEjec.CuadrillaDesc = dataReader["Descripcion"].ToString();
                         oEjec.Cuadrilla = dataReader["CUADRILLA"].ToString();
                         olEjecucionOT.Add(oEjec);
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<EjecucionOTCuadrillaDTO>();
             }
         }

         public List<DatosValorizacionDTO> ObtenerDatosArchivoValidacion(int IdObra, DataTable ListaSgi)
         {
             try
             {
                 List<DatosValorizacionDTO> olEjecucionOT = new List<DatosValorizacionDTO>();
                  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Gestion"].ConnectionString);
                  SqlCommand sqlCommand = new SqlCommand();
                 sqlCommand.CommandType=CommandType.StoredProcedure;
                 sqlCommand.CommandText="PRO_VALORIZACION_ObtenerDatosValidacion_INTRANET_SEDAPRO";
                 sqlCommand.Connection=connection;
                  sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                  sqlCommand.Parameters.Add("ListaSGI", SqlDbType.Structured).Value = ListaSgi;

                  sqlCommand.Connection.Open();

                  sqlCommand.CommandTimeout = 0;
                  using (IDataReader dataReader = sqlCommand.ExecuteReader())
                  {
                      while (dataReader.Read())
                      {
                          DatosValorizacionDTO oEjec = new DatosValorizacionDTO();
                          oEjec.ENLACE = dataReader["ENLACE"].ToString();
                          oEjec.CODIGO = dataReader["CODIGO"].ToString();
                          oEjec.DESCRIP = dataReader["DESCRIP"].ToString();
                          oEjec.SumaDeCANTIDAD = Convert.ToDecimal(dataReader["SumaDeCANTIDAD"].ToString());
                          oEjec.PRECIO_UNI = Convert.ToDecimal(dataReader["PRECIO_UNI"].ToString());
                          oEjec.Tipo = dataReader["Tipo"].ToString();
                          oEjec.NOMACTIVID = dataReader["NOMACTIVID"].ToString();
                          oEjec.SGI = dataReader["SGI"].ToString();
                          //oEjec.UNIDAD = dataReader["UNIDAD"].ToString();
                          olEjecucionOT.Add(oEjec);
                      }
                  }
                  sqlCommand.Connection.Close();

                
                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<DatosValorizacionDTO>();
             }
         }

         public List<DatosValorizacionDTO> ObtenerDatosArchivoValidacion(int IdObra, int IdValorizacion)
         {
             try
             {
                 List<DatosValorizacionDTO> olEjecucionOT = new List<DatosValorizacionDTO>();
                 Database db = DatabaseFactory.CreateDatabase();
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_VALORIZACION_ObtenerDatosValidacion", new object[]
                {
                    IdObra,IdValorizacion
                });
                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         DatosValorizacionDTO oEjec = new DatosValorizacionDTO();

                         oEjec.ENLACE = dataReader["ENLACE"].ToString();
                         oEjec.CODIGO = dataReader["CODIGO"].ToString();
                         oEjec.DESCRIP = dataReader["DESCRIP"].ToString();
                         oEjec.SumaDeCANTIDAD = Convert.ToDecimal(dataReader["SumaDeCANTIDAD"].ToString());
                         oEjec.PRECIO_UNI = Convert.ToDecimal(dataReader["PRECIO_UNI"].ToString());
                         oEjec.Tipo = dataReader["Tipo"].ToString();
                         oEjec.NOMACTIVID = dataReader["NOMACTIVID"].ToString();
                         oEjec.UNIDAD = dataReader["UNIDAD"].ToString();
                         olEjecucionOT.Add(oEjec);
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<DatosValorizacionDTO>();
             }
         }

         public List<RadioProduccionDTO> ObtenerCruceRadioProduccion(int IdObra, string fecDesde, string fecHasta)
         {
             try
             {
                 List<RadioProduccionDTO> olEjecucionOT = new List<RadioProduccionDTO>();
                 int cont = 0;
                 Database db = DatabaseFactory.CreateDatabase();
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_CruceRadioSEDAPRO", new object[]
                {
                    IdObra,fecDesde,fecHasta
                });
                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         RadioProduccionDTO oEjec = new RadioProduccionDTO();
                         oEjec.Item = (cont + 1).ToString();
                         oEjec.Base = dataReader["Base"].ToString();
                         oEjec.Obra = dataReader["Obra"].ToString();
                         oEjec.FDesde = dataReader["FDesde"].ToString();
                         oEjec.FHasta = dataReader["FHasta"].ToString();
                         oEjec.SGI = dataReader["SGI"].ToString();
                         oEjec.Radio = dataReader["Radio"].ToString();
                         oEjec.Produccion = dataReader["Produccion"].ToString();
                         olEjecucionOT.Add(oEjec);
                         cont++;
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<RadioProduccionDTO>();
             }
         }

         public List<CruceOTsDTO> ObtenerCruceOTsProduccion(int IdObra)
         {
             try
             {
                 List<CruceOTsDTO> olEjecucionOT = new List<CruceOTsDTO>();
                 Database db = DatabaseFactory.CreateDatabase();
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_CruceOT_Produccion", new object[]
                {
                    IdObra
                });
                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     string antCuadrilla = "";
                     while (dataReader.Read())
                     {
                         
                         if (antCuadrilla == dataReader["laCUADRILLA"].ToString())
                         {
                             switch (dataReader["NOM_ACTIVIDAD"].ToString())
                             {
                                 case "A":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioA = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionA = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "B":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioB = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionB = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "C":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioC = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionC = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "D":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioD = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionD = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "E":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioE = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionE = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "E1":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioE1 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionE1 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "E2":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioE2 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionE2 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "F":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioF = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionF = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "G1":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioG1 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionG1 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "G2":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioG2 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionG2 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "GA":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioGA = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionGA = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "GD":
                                     olEjecucionOT[olEjecucionOT.Count - 1].RadioGD = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     olEjecucionOT[olEjecucionOT.Count - 1].ProduccionGD = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                             }
                             
                         }
                         else
                         {
                             CruceOTsDTO oEjec = new CruceOTsDTO();
                             oEjec.Cuadrilla = dataReader["CUADRILLA"].ToString();
                             switch (dataReader["NOM_ACTIVIDAD"].ToString())
                             {
                                 case "A":
                                     oEjec.RadioA = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionA = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "B":
                                     oEjec.RadioB = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionB = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "C":
                                     oEjec.RadioC = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionC = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "D":
                                     oEjec.RadioD = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionD = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "E":
                                     oEjec.RadioE = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionE = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "E1":
                                     oEjec.RadioE1 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionE1 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "E2":
                                     oEjec.RadioE2 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionE2 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "F":
                                     oEjec.RadioF = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionF = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "G1":
                                     oEjec.RadioG1 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionG1 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "G2":
                                     oEjec.RadioG2 = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionG2 = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "GA":
                                     oEjec.RadioGA = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionGA = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                                 case "GD":
                                     oEjec.RadioGD = Convert.ToInt32(dataReader["RADIO"].ToString());
                                     oEjec.ProduccionGD = Convert.ToInt32(dataReader["PRODUCCION"].ToString());
                                     break;
                             }
                             olEjecucionOT.Add(oEjec);
                         }
                         antCuadrilla = dataReader["laCUADRILLA"].ToString(); 
                         
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<CruceOTsDTO>();
             }
         }

         public List<EjecucionOTFechaDTO> GenerarSEPC(int IdObra, string fecDesde, string fecHasta)
         {
             try
             {
                 List<EjecucionOTFechaDTO> olEjecucionOT = new List<EjecucionOTFechaDTO>();
                 Database db = DatabaseFactory.CreateDatabase();
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_GenerarSEPC", new object[]
                {
                    IdObra,fecDesde,fecHasta
                });
                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         EjecucionOTFechaDTO oEjec = new EjecucionOTFechaDTO();
                         oEjec.Sgi = dataReader["ITEM"].ToString();
                         oEjec.SubActividad = dataReader["TIPO"].ToString();
                         oEjec.NumeroOrden = dataReader["N_ORDEN"].ToString();
                         oEjec.FechaInicio = dataReader["FE_ORDEN"].ToString();
                         oEjec.Direccion = dataReader["DIRECC"].ToString();
                         oEjec.Cuadrilla = dataReader["CUADRILLA"].ToString();
                         oEjec.Distrito = dataReader["COD_DIST"].ToString();
                         oEjec.Suministro = dataReader["CONTRATO"].ToString();

                         olEjecucionOT.Add(oEjec);
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<EjecucionOTFechaDTO>();
             }
         }

         public List<EjecucionOTFechaDTO> GenerarSEPI(int IdObra, string fecDesde, string fecHasta)
         {
             try
             {
                 List<EjecucionOTFechaDTO> olEjecucionOT = new List<EjecucionOTFechaDTO>();
                 Database db = DatabaseFactory.CreateDatabase();
                 DbCommand dbCommand = db.GetStoredProcCommand("PRO_Cabecera_GenerarSEPI", new object[]
                {
                    IdObra,fecDesde,fecHasta
                });
                 dbCommand.CommandTimeout = 0;
                 using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                 {
                     while (dataReader.Read())
                     {
                         EjecucionOTFechaDTO oEjec = new EjecucionOTFechaDTO();
                         oEjec.NumeroOrden = dataReader["NumeroOrden"].ToString();
                         oEjec.SubActividad = dataReader["Codigo"].ToString();
                         oEjec.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                         oEjec.Cuadrilla = dataReader["Cuadrilla"].ToString();

                         olEjecucionOT.Add(oEjec);
                     }
                 }

                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<EjecucionOTFechaDTO>();
             }
         }

         public List<OTValorizacionDTO> OTxValorizacion(int IdObra, DataTable ListaSgi)
         {
             try
             {
                 List<OTValorizacionDTO> olEjecucionOT = new List<OTValorizacionDTO>();
                 SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gestion"].ConnectionString);
                 SqlCommand sqlCommand = new SqlCommand();
                 sqlCommand.CommandType = CommandType.StoredProcedure;
                 sqlCommand.CommandText = "OTxValorizacion";
                 sqlCommand.Connection = connection;
                 sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                 sqlCommand.Parameters.Add("ListaSGI2", SqlDbType.Structured).Value = ListaSgi;
                 sqlCommand.CommandTimeout = 0;
                 sqlCommand.Connection.Open();

                 using (IDataReader dataReader = sqlCommand.ExecuteReader())
                 {
                     while (dataReader.Read())
                     {
                         OTValorizacionDTO oEjec = new OTValorizacionDTO();
                         oEjec.Actividad = dataReader["Actividad"].ToString();
                         oEjec.NumeroOrden = dataReader["NumeroOrden"].ToString();
                         oEjec.FechaInicio = dataReader["FechaInicio"].ToString();
                         oEjec.SGI = dataReader["Sgi"].ToString();
                         oEjec.Suministro = dataReader["Suministro"].ToString();
                         oEjec.Direccion = dataReader["Direccion"].ToString();
                         oEjec.Urbanizacion = dataReader["Urbanizacion"].ToString();
                         oEjec.CodigoDistrito = dataReader["CodigoDistrito"].ToString();
                         oEjec.DescSubAct = dataReader["DescripcionSubActividad1"].ToString();
                         oEjec.monto = Convert.ToDouble(dataReader["ncosto_ot"].ToString());
                         oEjec.tipo = "";
                         oEjec.Barranco = 0.0;
                         oEjec.Chorrillos=0.0;
                         oEjec.Lince=0.0;
                         oEjec.Miraflores = 0.0;
                         oEjec.SanIsidro = 0.0;
                         oEjec.Surco = 0.0;
                         oEjec.Total = 0.0;
                         oEjec.Unidad = "";
                         olEjecucionOT.Add(oEjec);
                     }
                 }
                 sqlCommand.Connection.Close();


                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<OTValorizacionDTO>();
             }
         }

        public List<OTValorizacionDTO> OTxDistrito(int IdObra, DataTable ListaSgi)
         {
             try
             {
                 List<OTValorizacionDTO> olEjecucionOT = new List<OTValorizacionDTO>();
                 SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gestion"].ConnectionString);
                 SqlCommand sqlCommand = new SqlCommand();
                 sqlCommand.CommandType = CommandType.StoredProcedure;
                 sqlCommand.CommandText = "OTxDistrito";
                 sqlCommand.Connection = connection;
                 sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                 sqlCommand.Parameters.Add("ListaSGI2", SqlDbType.Structured).Value = ListaSgi;
                 sqlCommand.CommandTimeout = 0;
                 sqlCommand.Connection.Open();

                 using (IDataReader dataReader = sqlCommand.ExecuteReader())
                 {
                     while (dataReader.Read())
                     {
                         OTValorizacionDTO oEjec = new OTValorizacionDTO();
                         oEjec.Actividad = dataReader["Actividad"].ToString();
                         oEjec.NumeroOrden = "";
                         oEjec.FechaInicio = "";
                         oEjec.SGI = "";
                         oEjec.Suministro = "";
                         oEjec.Direccion = "";
                         oEjec.Urbanizacion = "";
                         oEjec.CodigoDistrito = "";
                         oEjec.DescSubAct = dataReader["SubActividad"].ToString();
                         oEjec.monto = 0.0;
                         oEjec.tipo = dataReader["tipo"].ToString();
                         oEjec.Chorrillos = Convert.ToDouble(dataReader["Chorrillos"].ToString());
                         oEjec.Miraflores = Convert.ToDouble(dataReader["MIRAFLORES"].ToString());
                         oEjec.Surco = Convert.ToDouble(dataReader["SURCO"].ToString());
                         oEjec.Surquillo = Convert.ToDouble(dataReader["SURQUILLO"].ToString());
                         oEjec.SanBorja = Convert.ToDouble(dataReader["SAN BORJA"].ToString());
                         oEjec.Barranco = Convert.ToDouble(dataReader["BARRANCO"].ToString());
                         oEjec.Lince = Convert.ToDouble(dataReader["LINCE"].ToString());
                         oEjec.SanIsidro = Convert.ToDouble(dataReader["SAN ISIDRO"].ToString());
                         oEjec.SurcoViejo = Convert.ToDouble(dataReader["SURCO VIEJO"].ToString());
                         oEjec.Total = Convert.ToDouble(dataReader["Total"].ToString());
                         oEjec.Unidad = dataReader["UND"].ToString();
                         olEjecucionOT.Add(oEjec);
                     }
                 }
                 sqlCommand.Connection.Close();


                 return olEjecucionOT;
             }
             catch (Exception ex)
             {
                 new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                 return new List<OTValorizacionDTO>();
             }
         }

        public List<CargoOTChorrillosDTO> CargoOTChorrillos(int Usuario, int IdObra, string Ordenacion, int idcargo)
        {
            try
            {
                List<CargoOTChorrillosDTO> olEjecucionOT = new List<CargoOTChorrillosDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("CargoOTChorrillos1", new object[]
                {
                    Usuario,IdObra,Ordenacion,idcargo
                });
                dbCommand.CommandTimeout = 0;
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        CargoOTChorrillosDTO oEjec = new CargoOTChorrillosDTO();
                        oEjec.sgi = dataReader["Sgi"].ToString();
                        oEjec.Suministro = dataReader["Suministro"].ToString();
                        oEjec.FechaDigitacion = dataReader["FechaDigitacion"].ToString();
                        oEjec.DescEstado = dataReader["DescripcionEstado"].ToString();
                        oEjec.Actividad = dataReader["ACTIVIDAD"].ToString();
                        oEjec.SubActividad = dataReader["SUBACTIVIDAD"].ToString();
                        oEjec.Direccion = dataReader["DIRECCION"].ToString();
                        oEjec.Distrito = dataReader["DISTRITO"].ToString();
                        oEjec.Cserv = dataReader["C_SERV"].ToString();
                        oEjec.NroOrden = dataReader["ORDEN"].ToString();
                        oEjec.FechaInicio = dataReader["FechaInicio"].ToString();
                        oEjec.Sca = Double.Parse(dataReader["COSTO_SEDAPRO"].ToString());
                        oEjec.CostoOT = Double.Parse(dataReader["COSTO_OPEN"].ToString());
                        oEjec.Diferencia = Double.Parse(dataReader["DIFERENCIA"].ToString());
                        olEjecucionOT.Add(oEjec);
                    }
                }

                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CargoOTChorrillosDTO>();
            }
        }
    }
}
