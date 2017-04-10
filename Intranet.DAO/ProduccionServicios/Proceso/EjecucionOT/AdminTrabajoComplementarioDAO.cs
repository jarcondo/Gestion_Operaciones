using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DAO.SGE;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class AdminTrabajoComplementarioDAO
    {

        public List<AdminTrabajoComplementarioDTO> ListarAdminTrabajoComplementario()
        {
            try
            {
                List<AdminTrabajoComplementarioDTO> olistaAdminTrabajo = new List<AdminTrabajoComplementarioDTO>();
                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_AdminTrabajoComplementarioListar");
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        AdminTrabajoComplementarioDTO oAdminTrabajo = new AdminTrabajoComplementarioDTO();
                        oAdminTrabajo.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                        oAdminTrabajo.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                        oAdminTrabajo.DesignadoA = dataReader["DesignadoA"].ToString();
                        oAdminTrabajo.EjecucionOT = new EjecucionOTDTO()
                        {
                            OrdenTrabajo = new OrdenTrabajoDTO()
                            {
                                //IdOrdenTrabajo=Convert.ToInt32(dataReader["IdOrdenTrabajo"].ToString()),
                                IdOrdenTrabajo = Convert.ToInt32(dataReader["SGI"].ToString()),
                            }
                        };
                        //oAdminTrabajo.EjecucionOT.OrdenTrabajo.IdOrdenTrabajo = Convert.ToInt32(dataReader["IdOrdenTrabajo"].ToString());
                        oAdminTrabajo.EstadoOT = new EstadoOTDTO()
                        {
                            DescripcionEstado = dataReader["DescripcionEstado"].ToString(),
                        };
                        //oAdminTrabajo.EstadoOT.DescripcionEstado = dataReader["DescripcionEstado"].ToString();
                        //oAdminTrabajo.FechaFin = dataReader["FechaFin"].ToString();
                        //oAdminTrabajo.FechaInicio = dataReader["FechaInicio"].ToString();
                        //oAdminTrabajo.HoraFin = dataReader["HoraFin"].ToString();
                        //oAdminTrabajo.HoraInicio = dataReader["HoraInicio"].ToString();
                        oAdminTrabajo.IdAdmTraCom = Convert.ToInt32(dataReader["IdAdmTraCom"].ToString());
                        oAdminTrabajo.Total = Convert.ToDecimal(dataReader["Total"].ToString());
                        oAdminTrabajo.TrabajoComplementario = new TrabajoComplementarioDTO()
                        {
                            Descripcion = dataReader["descripcioncomplementario"].ToString(),
                        };
                        //oAdminTrabajo.TrabajoComplementario.Descripcion = dataReader["descripcioncomplementario"].ToString();
                        oAdminTrabajo.Cuadrilla = new CuadrillaDTO()
                        {
                            Descripcion = dataReader["descripcioncuadrilla"].ToString(),
                        };
                        //oAdminTrabajo.Cuadrilla.Descripcion = dataReader["descripcioncuadrilla"].ToString();
                        olistaAdminTrabajo.Add(oAdminTrabajo);
                    }
                }

                return olistaAdminTrabajo;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<AdminTrabajoComplementarioDTO>();
            }
        }

        //JRM
        public List<AdminTrabajoComplementarioDTO> ListarAdminTrabajoComplementarioPorEjecucion(int IdEjecucionOT)
        {
            try
            {
                List<AdminTrabajoComplementarioDTO> olAdminTC = new List<AdminTrabajoComplementarioDTO>();
                AdminTrabajoComplementarioDTO oAdminTC = new AdminTrabajoComplementarioDTO();
                int posicion = 0;

                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_AdminTrabajoComplementarioListarPorEjecucion", new object[]
                                {
                                    IdEjecucionOT
                                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oAdminTC = new AdminTrabajoComplementarioDTO();
                        oAdminTC.IdAdmTraCom = Convert.ToInt32(dataReader["IdAdmTraCom"].ToString());
                        oAdminTC.Item = posicion + 1;
                        oAdminTC.TrabajoComplementario = new TrabajoComplementarioDTO()
                        {
                            IdTrabajoComplementario = Convert.ToInt32(dataReader["IdTrabajoComplementario"].ToString()),
                            CodigoTrabajoComplementario = dataReader["CodigoTrabajoComplementario"].ToString(),
                            Descripcion = dataReader["Descripcion"].ToString(),
                            Unidad = dataReader["Unidad"].ToString()
                        };
                        oAdminTC.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                        oAdminTC.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                        oAdminTC.Total = Convert.ToDecimal(dataReader["Total"].ToString());
                        oAdminTC.EjecucionOT = new EjecucionOTDTO()
                        {
                            IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString()),
                        };
                        oAdminTC.DesignadoA = dataReader["DesignadoA"].ToString();
                        oAdminTC.Usuario = dataReader["Usuario"].ToString();
                        switch (oAdminTC.DesignadoA)
                        {
                            case "CUADRILLA":
                                oAdminTC.Cuadrilla = new CuadrillaDTO()
                                {
                                    IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString()),
                                    Descripcion = dataReader["NomEjecutor"].ToString(),
                                };
                                oAdminTC.Proveedor = new ProveedorDTO()
                                {
                                    IdProveedor = 0,
                                };
                                break;
                            case "PROVEEDOR":
                                oAdminTC.Proveedor = new ProveedorDTO()
                                {
                                    IdProveedor = Convert.ToInt32(dataReader["IdProveedor"].ToString()),
                                    Proveedor = dataReader["NomEjecutor"].ToString(),
                                };
                                oAdminTC.Cuadrilla = new CuadrillaDTO()
                                {
                                    IdCuadrilla = 0,
                                };
                                break;
                        }

                        oAdminTC.EstadoOT = new EstadoOTDTO()
                        {
                            IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"].ToString()),
                            DescripcionEstado = dataReader["DescripcionEstado"].ToString(),
                        };
                        oAdminTC.FechaProgramada = dataReader["FechaProgramada"].ToString();
                        oAdminTC.FecInicio = dataReader["FechaInicio"].ToString();
                        oAdminTC.FecFin = dataReader["FechaFin"].ToString();
                        oAdminTC.HoraInicio = dataReader["HoraInicio"].ToString();
                        oAdminTC.HoraFin = dataReader["HoraFin"].ToString();

                        oAdminTC.Observacion = dataReader["Observa"].ToString();
                        olAdminTC.Add(oAdminTC);
                        posicion++;
                    }
                }

                return olAdminTC;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<AdminTrabajoComplementarioDTO>();
            }
        }

        public AdminTrabajoComplementarioDTO ListarAdminTrabajoComplementarioPorID(int IdAdminTC)
        {
            try
            {


                AdminTrabajoComplementarioDTO oAdminTC = new AdminTrabajoComplementarioDTO();
                int posicion = 0;

                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_AdminTrabajoComplementarioListarPorId", new object[]
                                {
                                    IdAdminTC
                                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oAdminTC = new AdminTrabajoComplementarioDTO();
                        oAdminTC.IdAdmTraCom = Convert.ToInt32(dataReader["IdAdmTraCom"].ToString());
                        oAdminTC.Item = posicion + 1;
                        oAdminTC.TrabajoComplementario = new TrabajoComplementarioDTO()
                        {
                            IdTrabajoComplementario = Convert.ToInt32(dataReader["IdTrabajoComplementario"].ToString()),
                            CodigoTrabajoComplementario = dataReader["CodigoTrabajoComplementario"].ToString(),
                            Descripcion = dataReader["Descripcion"].ToString(),
                            Unidad = dataReader["Unidad"].ToString()
                        };
                        oAdminTC.Cantidad = Convert.ToDecimal(dataReader["Cantidad"].ToString());
                        oAdminTC.DetalleCantidad = dataReader["DetalleCantidad"].ToString();
                        oAdminTC.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                        oAdminTC.Relleno = Convert.ToDecimal(dataReader["Relleno"].ToString());
                        oAdminTC.Total = Convert.ToDecimal(dataReader["Total"].ToString());
                        oAdminTC.EjecucionOT = new EjecucionOTDTO()
                        {
                            IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString()),
                        };
                        oAdminTC.DesignadoA = dataReader["DesignadoA"].ToString();
                        switch (oAdminTC.DesignadoA)
                        {
                            case "CUADRILLA":
                                oAdminTC.Cuadrilla = new CuadrillaDTO()
                                {
                                    IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString()),
                                };
                                oAdminTC.Proveedor = new ProveedorDTO()
                                {
                                    IdProveedor = 0,
                                }; break;
                            case "PROVEEDOR":
                                oAdminTC.Proveedor = new ProveedorDTO()
                                {
                                    IdProveedor = Convert.ToInt32(dataReader["IdProveedor"].ToString()),
                                };
                                oAdminTC.Cuadrilla = new CuadrillaDTO()
                                {
                                    IdCuadrilla = 0,
                                }; break;
                        }

                        oAdminTC.EstadoOT = new EstadoOTDTO()
                        {
                            IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"].ToString()),
                            DescripcionEstado = dataReader["DescripcionEstado"].ToString(),
                        };
                        oAdminTC.FechaProgramada = dataReader["FechaProgramada"].ToString();
                        oAdminTC.FecInicio = dataReader["FechaInicio"].ToString();
                        oAdminTC.FecFin = dataReader["FechaFin"].ToString();
                        oAdminTC.HoraInicio = dataReader["HoraInicio"].ToString();
                        oAdminTC.HoraFin = dataReader["HoraFin"].ToString();
                        oAdminTC.Observacion = dataReader["Observa"].ToString();
                    }
                }

                return oAdminTC;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new AdminTrabajoComplementarioDTO();
            }
        }

        public int InsertarAdminTrabajoComplementario(AdminTrabajoComplementarioDTO oAdminTC)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    try
                    {
                        DbCommand oCommand = db.GetStoredProcCommand("PRO_AdminTrabajoComplementarioInsertar",
                                new object[]
                        {
                            oAdminTC.EjecucionOT.IdEjecucionOT
                            ,oAdminTC.TrabajoComplementario.IdTrabajoComplementario
                            ,oAdminTC.DesignadoA
                            ,oAdminTC.Cuadrilla.IdCuadrilla
                            ,oAdminTC.Proveedor.IdProveedor
                            ,oAdminTC.Cantidad
                            ,oAdminTC.DetalleCantidad
                            ,oAdminTC.CostoProgramado  
                            ,oAdminTC.Total
                            ,oAdminTC.FechaProgramada
                            ,oAdminTC.FecInicio
                            ,oAdminTC.FecFin
                            ,oAdminTC.EstadoOT.IdEstadoOT
                            ,oAdminTC.UsuarioCrea
                            ,oAdminTC.FechaCrea
                            ,oAdminTC.Observacion
                            ,oAdminTC.Relleno
                            ,oAdminTC.HoraInicio
                            ,oAdminTC.HoraFin
                        });

                        oAdminTC.IdAdmTraCom = Convert.ToInt32(db.ExecuteScalar(oCommand));

                        return oAdminTC.IdAdmTraCom;
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return 0;
            }
        }

        public eResultado ActualizarAdminTrabajoComplementario(AdminTrabajoComplementarioDTO oAdminTC)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    try
                    {
                        DbCommand oCommand = db.GetStoredProcCommand("PRO_AdminTrabajoComplementarioActualizar",
                                new object[]
                        {
                            oAdminTC.IdAdmTraCom
                            ,oAdminTC.TrabajoComplementario.IdTrabajoComplementario
                            ,oAdminTC.DesignadoA
                            ,oAdminTC.Cuadrilla.IdCuadrilla
                            ,oAdminTC.Proveedor.IdProveedor
                            ,oAdminTC.Cantidad
                            ,oAdminTC.DetalleCantidad
                            ,oAdminTC.CostoProgramado  
                            ,oAdminTC.Total
                            ,oAdminTC.FechaProgramada
                            ,oAdminTC.FecInicio
                            ,oAdminTC.FecFin
                            ,oAdminTC.EstadoOT.IdEstadoOT
                            ,oAdminTC.UsuarioModi
                            ,oAdminTC.FechaModi
                            ,oAdminTC.Observacion
                            ,oAdminTC.Relleno
                            ,oAdminTC.HoraInicio
                            ,oAdminTC.HoraFin
                        });

                        db.ExecuteNonQuery(oCommand);

                        return eResultado.Correcto;
                    }
                    catch
                    {
                        return eResultado.Error;
                    }
                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }

        public eResultado EliminarAdminTrabajoComplementario(int IdAdmTraCom,int idusuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    try
                    {
                        DbCommand oCommand = db.GetStoredProcCommand("PRO_AdminTrabajoComplementarioEliminar",
                                new object[]
                        {
                            IdAdmTraCom,idusuario
                        });

                        db.ExecuteNonQuery(oCommand);

                        return eResultado.Correcto;
                    }
                    catch
                    {
                        return eResultado.Error;
                    }
                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }
    }
}
