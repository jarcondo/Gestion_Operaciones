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
using Intranet.DAO.ProduccionServicios.Maestra;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Reportes;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class EjecucionOTDAO
    {
        List<EjecucionOTDTO> olEjecucionOT = new List<EjecucionOTDTO>();

        public List<EjecucionOTMasivaGridDTO> GetEjecucionOTPorObra
            (int IdObra, string SGI, int IdEstado, string NIS, string direccion, 
            int NroRegistro, string fdesde, string fhasta, string NroOrden, int IdCuadrilla)
        {
            try
            {


                List<EjecucionOTMasivaGridDTO> olEjecucionOT = new List<EjecucionOTMasivaGridDTO>();
                int posicion = 0;
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTListarPorObra", new object[]
                {
                    IdObra,SGI,IdEstado,NIS,direccion,NroRegistro,fdesde,fhasta,NroOrden,IdCuadrilla,0
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        EjecucionOTMasivaGridDTO oEjecucionOT = new EjecucionOTMasivaGridDTO();
                        //oEjecucionOT.Item = posicion;
                        oEjecucionOT.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        //oEjecucionOT.NroOT = dataReader["nro_ot"].ToString();
                        //oEjecucionOT.NIS = dataReader["nis_rad"].ToString();
                        //oEjecucionOT.Distrito = dataReader["municipio"].ToString();
                        oEjecucionOT.Direccion = dataReader["direccion"].ToString() + " - " + dataReader["localidad"].ToString();
                        //oEjecucionOT.Cliente = dataReader["cliente"].ToString();
                        //oEjecucionOT.Actividad = dataReader["desc_actividad"].ToString();
                        //oEjecucionOT.Descripcion = dataReader["vdescripcion"].ToString();
                        //oEjecucionOT.FechaAlta = dataReader["f_alta"].ToString();
                        oEjecucionOT.Estado = dataReader["DescripcionEstado"].ToString();
                        oEjecucionOT.DesCuadrilla = dataReader["DesCuadrilla"].ToString();
                        oEjecucionOT.NroOrden = dataReader["NroOrden"].ToString();

                        oEjecucionOT.os_ot = dataReader["os_ot"].ToString();
                        oEjecucionOT.ncod_centro = Convert.ToInt32(dataReader["ncod_centro"].ToString());
                        oEjecucionOT.center = dataReader["center"].ToString();
                        oEjecucionOT.nro_ot = dataReader["nro_ot"].ToString();
                        oEjecucionOT.nis_rad = dataReader["nis_rad"].ToString();
                        oEjecucionOT.cliente = dataReader["cliente"].ToString();
                        oEjecucionOT.municipio = dataReader["municipio"].ToString();
                        oEjecucionOT.localidad = dataReader["localidad"].ToString();
                        oEjecucionOT.direccion = dataReader["direccion"].ToString();
                        //oEjecucionOT.estado = dataReader["estado"].ToString();
                        //oEjecucionOT.nest_ot = Convert.ToInt32(dataReader["nest_ot"].ToString());
                        oEjecucionOT.actividad = Convert.ToInt32(dataReader["actividad"].ToString());
                        oEjecucionOT.desc_actividad = dataReader["desc_actividad"].ToString();
                        oEjecucionOT.subactividad = Convert.ToInt32(dataReader["subactividad"].ToString());
                        oEjecucionOT.desc_subactividad = dataReader["desc_subactividad"].ToString();
                        oEjecucionOT.ncosto_ot = Convert.ToDecimal(dataReader["ncosto_ot"].ToString());
                        oEjecucionOT.vobservacion_contrata = dataReader["vobservacion_contrata"].ToString();
                        oEjecucionOT.f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString());
                        oEjecucionOT.f_ini = Convert.ToDateTime(dataReader["f_ini"].ToString());
                        oEjecucionOT.f_fin = Convert.ToDateTime(dataReader["f_fin"].ToString());
                        oEjecucionOT.f_atendido = Convert.ToDateTime(dataReader["f_atendido"].ToString());
                        oEjecucionOT.f_res_contrata = Convert.ToDateTime(dataReader["f_res_contrata"].ToString());
                        oEjecucionOT.tipo_red = dataReader["tipo_red"].ToString();
                        oEjecucionOT.ntip_red = Convert.ToInt32(dataReader["ntip_red"].ToString());
                        oEjecucionOT.vdescripcion = dataReader["vdescripcion"].ToString();
                        oEjecucionOT.vref_direccion = dataReader["vref_direccion"].ToString();
                        oEjecucionOT.vusuario = dataReader["vusuario"].ToString();
                        oEjecucionOT.nres_contrata = Convert.ToInt32(dataReader["nres_contrata"].ToString());
                        oEjecucionOT.ncod_cuadrilla = Convert.ToInt32(dataReader["ncod_cuadrilla"].ToString());
                        oEjecucionOT.ncod_incidencia = Convert.ToInt32(dataReader["ncod_incidencia"].ToString());
                        oEjecucionOT.ncod_factura = Convert.ToInt32(dataReader["ncod_factura"].ToString());
                        oEjecucionOT.secs = dataReader["secs"].ToString();
                        oEjecucionOT.secsfin = dataReader["secsfin"].ToString();
                        oEjecucionOT.ot_contrata = dataReader["ot_contrata"].ToString();
                        oEjecucionOT.ntip_ot = Convert.ToInt32(dataReader["ntip_ot"].ToString());
                        oEjecucionOT.tipo_ot = dataReader["tipo_ot"].ToString();
                        oEjecucionOT.nnum_os = Convert.ToInt32(dataReader["nnum_os"].ToString());
                        oEjecucionOT.Direccion = dataReader["Direccion"].ToString();
                        oEjecucionOT.DesCuadrilla = dataReader["DesCuadrilla"].ToString();

                        olEjecucionOT.Add(oEjecucionOT);
                        posicion++;
                    }

                }

                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<EjecucionOTMasivaGridDTO>();
            }
        }

        public List<EjecucionOTGridDTO> GetEjecucionOTGridPorObra(int IdObra, string SGI, int IdEstado,string NIS,string direccion,int NroRegistro,string fdesde, string fhasta,string NroOrden,int IdCuadrilla,int area)
        {
            try
            {
                List<EjecucionOTGridDTO> olEjecucionOT = new List<EjecucionOTGridDTO>();
                int posicion = 1;
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTListarPorObra", new object[]
                {
                    IdObra,SGI,IdEstado,NIS,direccion,NroRegistro,fdesde,fhasta,NroOrden,IdCuadrilla,area
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        EjecucionOTGridDTO oEjecucionOT = new EjecucionOTGridDTO();
                        oEjecucionOT.Item = posicion;
                        oEjecucionOT.NroRegistro =Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        oEjecucionOT.NroOT = (dataReader["nro_ot"].ToString()==null ? "" : dataReader["nro_ot"].ToString());
                        oEjecucionOT.NIS = (dataReader["nis_rad"].ToString()==null ? "" : dataReader["nis_rad"].ToString());
                        oEjecucionOT.Distrito = (dataReader["municipio"].ToString()==null ? "" : dataReader["municipio"].ToString()).Replace(Convert.ToChar(1), Convert.ToChar(32));;
                        oEjecucionOT.Direccion = ((dataReader["direccion"].ToString()==null ? "" : dataReader["direccion"].ToString()) + " - " + (dataReader["localidad"].ToString()==null ? "" : dataReader["localidad"].ToString())).Replace("*","").Replace("'","");
                        oEjecucionOT.Direccion2 = (dataReader["direccion"].ToString()==null ? "" : dataReader["direccion"].ToString());
                        oEjecucionOT.Localidad = (dataReader["localidad"].ToString()==null ? "" : dataReader["localidad"].ToString());
                        oEjecucionOT.Cliente = (dataReader["cliente"].ToString()==null ? "" : dataReader["cliente"].ToString());
                        oEjecucionOT.Actividad = (dataReader["desc_actividad"].ToString()==null ? "" : dataReader["desc_actividad"].ToString());
                        oEjecucionOT.Actividad = oEjecucionOT.Actividad.Replace(Convert.ToChar(1), Convert.ToChar(32));
                        oEjecucionOT.Actividad = oEjecucionOT.Actividad.Replace(Convert.ToChar(191), Convert.ToChar(32));

                        oEjecucionOT.SubActividad = (dataReader["desc_subactividad"].ToString()==null ? "" : dataReader["desc_subactividad"].ToString());
                        
                        oEjecucionOT.SubActividad = oEjecucionOT.SubActividad.Replace(Convert.ToChar(1), Convert.ToChar(32));
                        oEjecucionOT.SubActividad = oEjecucionOT.SubActividad.Replace(Convert.ToChar(191), Convert.ToChar(32));

                        oEjecucionOT.Descripcion = (dataReader["vdescripcion"].ToString()==null ? "" : dataReader["vdescripcion"].ToString());
                        oEjecucionOT.FechaAlta = (dataReader["f_alta"].ToString()==null ? "" : dataReader["f_alta"].ToString());
                        oEjecucionOT.Estado = (dataReader["DescripcionEstado"].ToString()==null ? "" : dataReader["DescripcionEstado"].ToString());
                        oEjecucionOT.DesCuadrilla = (dataReader["DesCuadrilla"].ToString()==null ? "" : dataReader["DesCuadrilla"].ToString());
                        oEjecucionOT.NroOrden = (dataReader["NroOrden"].ToString()==null ? "" : dataReader["NroOrden"].ToString());
                        oEjecucionOT.CambioMasivo = Convert.ToBoolean(dataReader["CambioMasivo"].ToString());
                        oEjecucionOT.TipoTrabajo = (dataReader["TipoTrabajo"].ToString() == null ? "" : dataReader["TipoTrabajo"].ToString());
                        oEjecucionOT.Ingeniero = (dataReader["Ingeniero"].ToString() == null ? "" : dataReader["Ingeniero"].ToString());
                        oEjecucionOT.FechaHoraIni = (dataReader["FechaHoraIni"].ToString() == null ? "" : dataReader["FechaHoraIni"].ToString());
                        oEjecucionOT.FechaHoraFin = (dataReader["FechaHoraFin"].ToString() == null ? "" : dataReader["FechaHoraFin"].ToString());
                        oEjecucionOT.GESTION = (dataReader["GESTION"].ToString() == null ? "" : dataReader["GESTION"].ToString());
                        olEjecucionOT.Add(oEjecucionOT);
                        posicion++;
                        //System.Diagnostics.Debug.WriteLine("item:" + posicion.ToString());
                    }
                }

                return olEjecucionOT;

            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<EjecucionOTGridDTO>() ;
            }
        }

        public EjecucionOTDTO GetEjecucionOTPorNroRegistro(int NroRegistro)
        {
            try
            {
                EjecucionOTDTO oEjecucionOT = new EjecucionOTDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTListarPorNroRegistro", new object[]
                {
                    NroRegistro                    
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oEjecucionOT = new EjecucionOTDTO();
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        oEjecucionOT.NroPosicion = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.OrdenTrabajo = new OrdenTrabajoDTO()
                        {
                            IdOrdenTrabajo = Convert.ToInt32(dataReader["IdOrdenTrabajo"].ToString()),
                            os_ot = dataReader["os_ot"].ToString(),
                            ncod_centro = Convert.ToInt32(dataReader["ncod_centro"].ToString()),
                            center = dataReader["center"].ToString(),
                            nro_ot = dataReader["nro_ot"].ToString() == "" ? "0" : dataReader["nro_ot"].ToString(),
                            nis_rad = dataReader["nis_rad"].ToString(),
                            cliente = dataReader["cliente"].ToString(),
                            municipio = dataReader["municipio"].ToString(),
                            localidad = dataReader["localidad"].ToString(),
                            direccion = dataReader["direccion"].ToString(),
                            estado = dataReader["estado"].ToString(),
                            nest_ot = Convert.ToInt32(dataReader["nest_ot"].ToString()),
                            actividad = Convert.ToInt32(dataReader["actividad"].ToString()),
                            desc_actividad = dataReader["desc_actividad"].ToString(),
                            subactividad = Convert.ToInt32(dataReader["subactividad"].ToString()),
                            desc_subactividad = dataReader["desc_subactividad"].ToString(),
                            ncosto_ot = Convert.ToDecimal(dataReader["ncosto_ot"].ToString()),
                            vobservacion_contrata = dataReader["vobservacion_contrata"].ToString(),
                            f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString()),
                            f_ini = Convert.ToDateTime(dataReader["f_ini"].ToString()),
                            f_fin = Convert.ToDateTime(dataReader["f_fin"].ToString()),
                            f_atendido = Convert.ToDateTime(dataReader["f_atendido"].ToString()),
                            f_res_contrata = Convert.ToDateTime(dataReader["f_res_contrata"].ToString()),
                            tipo_red = dataReader["tipo_red"].ToString(),
                            ntip_red = Convert.ToInt32(dataReader["ntip_red"].ToString()),
                            vdescripcion = dataReader["vdescripcion"].ToString(),
                            vref_direccion = dataReader["vref_direccion"].ToString(),
                            vusuario = dataReader["vusuario"].ToString(),
                            nres_contrata = Convert.ToInt32(dataReader["nres_contrata"].ToString()),
                            ncod_cuadrilla = Convert.ToInt32(dataReader["ncod_cuadrilla"].ToString()),
                            ncod_incidencia = Convert.ToInt32(dataReader["ncod_incidencia"].ToString()),
                            ncod_factura = Convert.ToInt32(dataReader["ncod_factura"].ToString()),
                            secs = dataReader["secs"].ToString(),
                            secsfin = dataReader["secsfin"].ToString(),
                            ot_contrata = dataReader["ot_contrata"].ToString(),
                            ntip_ot = Convert.ToInt32(dataReader["ntip_ot"].ToString()),
                            tipo_ot = dataReader["tipo_ot"].ToString(),
                            nnum_os = Convert.ToInt32(dataReader["nnum_os"].ToString()),



                        };
                        oEjecucionOT.CodigoEjecucionOT = dataReader["CodigoEjecucionOT"].ToString();
                        oEjecucionOT.Direccion = dataReader["Direccion"].ToString();
                        oEjecucionOT.FechaInicio = dataReader["FechaInicio"].ToString();
                        oEjecucionOT.HoraInicio = dataReader["HoraInicio"].ToString();
                        oEjecucionOT.FechaFin = dataReader["FechaFin"].ToString();
                        oEjecucionOT.HoraFin = dataReader["HoraFin"].ToString();
                        oEjecucionOT.FechaProg = dataReader["FechaProg"].ToString();
                        


                        if (dataReader["IdTipoTrabajo"].ToString() != "")
                        {
                            oEjecucionOT.TipoTrabajo = new GenericaDAO().GetGenerica(eTabla.TipoTrabajo).Where(x => x.IdGenerica == Convert.ToInt32(dataReader["IdTipoTrabajo"].ToString())).FirstOrDefault();
                        }
                        else
                            oEjecucionOT.TipoTrabajo = new GenericaDTO()
                            {
                                IdGenerica = 0,
                                A2 = "",
                            };
                        oEjecucionOT.NroOrden = dataReader["NroOrden"].ToString();
                        oEjecucionOT.FechaOrden = dataReader["FechaOrden"].ToString();
                        //oEjecucionOT.EstadoOrden = Convert.ToBoolean(dataReader["EstadoOrden"].ToString());
                        oEjecucionOT.PermisoMunicipal = Convert.ToBoolean(dataReader["PermisoMunicipal"].ToString());
                        oEjecucionOT.FechaPermiso = dataReader["FechaPermiso"].ToString();
                        oEjecucionOT.Observacion = dataReader["Observacion"].ToString();

                        //detalle
                        if (dataReader["IdArea"].ToString() != "")
                            oEjecucionOT.Area = new GenericaDTO()
                            {
                                IdGenerica = Convert.ToInt32(dataReader["IdArea"].ToString()),
                            };
                        else
                            oEjecucionOT.Area = new GenericaDTO()
                            {
                                IdGenerica = 0,
                            };

                        if (dataReader["IdResponsable"].ToString() != "")
                            oEjecucionOT.IdResponsable = new EmpleadoDTO()
                            {
                                IdEmpleado = Convert.ToInt32(dataReader["IdResponsable"].ToString()),
                            };
                        else
                            oEjecucionOT.IdResponsable = new EmpleadoDTO()
                            {
                                IdEmpleado = 0,
                            };

                        if (dataReader["IdCuadrilla"].ToString() != "")
                            oEjecucionOT.Cuadrilla = new CuadrillaDTO()
                            {
                                IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString()),
                            };
                        else
                            oEjecucionOT.Cuadrilla = new CuadrillaDTO()
                            {
                                IdCuadrilla = 0,
                            };
                        oEjecucionOT.EstadoOT = new EstadoOTDTO()
                        {
                            IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"].ToString()),
                        };
                        oEjecucionOT.FechaRegistro = dataReader["FechaRegistro"].ToString();
                        oEjecucionOT.HoraRegistro = dataReader["HoraRegistro"].ToString();
                        oEjecucionOT.TuberiaRota = Convert.ToBoolean(dataReader["TuberiaRota"].ToString());
                        oEjecucionOT.FugaToma = Convert.ToBoolean(dataReader["FugaToma"].ToString());
                        oEjecucionOT.RoturaMedidor = Convert.ToBoolean(dataReader["RoturaMedidor"].ToString());
                        oEjecucionOT.Limpieza = Convert.ToBoolean(dataReader["Limpieza"].ToString());
                        oEjecucionOT.Bombeo = Convert.ToBoolean(dataReader["Bombeo"].ToString());
                        oEjecucionOT.UsuarioMod = dataReader["UsuModi"].ToString();
                        oEjecucionOT.VBIngeniero = Convert.ToBoolean(dataReader["VBIngeniero"].ToString());
                        oEjecucionOT.UsuarioVB = Convert.ToInt32(dataReader["UsuarioVB"].ToString() == "" ? "0" : dataReader["UsuarioVB"].ToString());


                        oEjecucionOT.Puntaje = Convert.ToDecimal(dataReader["Puntaje"].ToString() == "" ? 0 : Convert.ToDecimal(dataReader["Puntaje"].ToString()));

                        if (!string.IsNullOrEmpty(dataReader["FechaVB"].ToString()))
                            oEjecucionOT.FechaVB = Convert.ToDateTime(dataReader["FechaVB"].ToString());
                        else
                            oEjecucionOT.FechaVB = Convert.ToDateTime("01/01/1900");
                        oEjecucionOT.UsuVBIngeniero = dataReader["UsuVBIngeniero"].ToString();
                        oEjecucionOT.DMTU = Convert.ToBoolean(dataReader["DMTU"].ToString());
                        oEjecucionOT.CUS = dataReader["CUS"].ToString();
                    }
                }

                return oEjecucionOT;
            }
            catch (Exception ex)
            {
                InsertarError(ex.StackTrace, 0);
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new EjecucionOTDTO();
            }
        }

        public EjecucionOTDTO GetEjecucionOTPorID(int IdEjecucionOT)
        {
            try
            {
                EjecucionOTDTO oEjecucionOT = new EjecucionOTDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTListarPorID", new object[]
                {
                    IdEjecucionOT                    
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oEjecucionOT = new EjecucionOTDTO();
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        oEjecucionOT.NroPosicion = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.OrdenTrabajo = new OrdenTrabajoDTO()
                        {
                            IdOrdenTrabajo = Convert.ToInt32(dataReader["IdOrdenTrabajo"].ToString()),
                            os_ot = dataReader["os_ot"].ToString(),
                            ncod_centro = Convert.ToInt32(dataReader["ncod_centro"].ToString()),
                            center = dataReader["center"].ToString(),
                            nro_ot = dataReader["nro_ot"].ToString() == "" ? "0" : dataReader["nro_ot"].ToString(),
                            nis_rad = dataReader["nis_rad"].ToString(),
                            cliente = dataReader["cliente"].ToString(),
                            municipio = dataReader["municipio"].ToString(),
                            localidad = dataReader["localidad"].ToString(),
                            direccion = dataReader["direccion"].ToString(),
                            estado = dataReader["estado"].ToString(),
                            nest_ot = Convert.ToInt32(dataReader["nest_ot"].ToString()),
                            actividad = Convert.ToInt32(dataReader["actividad"].ToString()),
                            desc_actividad = dataReader["desc_actividad"].ToString(),
                            subactividad = Convert.ToInt32(dataReader["subactividad"].ToString()),
                            desc_subactividad = dataReader["desc_subactividad"].ToString(),
                            ncosto_ot = Convert.ToDecimal(dataReader["ncosto_ot"].ToString()),
                            vobservacion_contrata = dataReader["vobservacion_contrata"].ToString(),
                            f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString()),
                            f_ini = Convert.ToDateTime(dataReader["f_ini"].ToString()),
                            f_fin = Convert.ToDateTime(dataReader["f_fin"].ToString()),
                            f_atendido = Convert.ToDateTime(dataReader["f_atendido"].ToString()),
                            f_res_contrata = Convert.ToDateTime(dataReader["f_res_contrata"].ToString()),
                            tipo_red = dataReader["tipo_red"].ToString(),
                            ntip_red = Convert.ToInt32(dataReader["ntip_red"].ToString()),
                            vdescripcion = dataReader["vdescripcion"].ToString(),
                            vref_direccion = dataReader["vref_direccion"].ToString(),
                            vusuario = dataReader["vusuario"].ToString(),
                            nres_contrata = Convert.ToInt32(dataReader["nres_contrata"].ToString()),
                            ncod_cuadrilla = Convert.ToInt32(dataReader["ncod_cuadrilla"].ToString()),
                            ncod_incidencia = Convert.ToInt32(dataReader["ncod_incidencia"].ToString()),
                            ncod_factura = Convert.ToInt32(dataReader["ncod_factura"].ToString()),
                            secs = dataReader["secs"].ToString(),
                            secsfin = dataReader["secsfin"].ToString(),
                            ot_contrata = dataReader["ot_contrata"].ToString(),
                            ntip_ot = Convert.ToInt32(dataReader["ntip_ot"].ToString()),
                            tipo_ot = dataReader["tipo_ot"].ToString(),
                            nnum_os = Convert.ToInt32(dataReader["nnum_os"].ToString()),
                            
                            
                            
                        };
                        oEjecucionOT.CodigoEjecucionOT = dataReader["CodigoEjecucionOT"].ToString();
                        oEjecucionOT.Direccion = dataReader["Direccion"].ToString();
                        oEjecucionOT.FechaInicio = dataReader["FechaInicio"].ToString();
                        oEjecucionOT.HoraInicio = dataReader["HoraInicio"].ToString();
                        oEjecucionOT.FechaFin = dataReader["FechaFin"].ToString();
                        oEjecucionOT.HoraFin = dataReader["HoraFin"].ToString();
                        oEjecucionOT.FechaProg = dataReader["FechaProg"].ToString();
                        

                        if (dataReader["IdTipoTrabajo"].ToString() != "")
                        {
                            oEjecucionOT.TipoTrabajo = new GenericaDAO().GetGenerica(eTabla.TipoTrabajo).Where(x => x.IdGenerica == Convert.ToInt32(dataReader["IdTipoTrabajo"].ToString())).FirstOrDefault();
                        }
                        else
                            oEjecucionOT.TipoTrabajo = new GenericaDTO()
                            {
                                IdGenerica = 0,
                                A2 = "",
                            };
                        oEjecucionOT.NroOrden = dataReader["NroOrden"].ToString();
                        oEjecucionOT.FechaOrden = dataReader["FechaOrden"].ToString();
                        //oEjecucionOT.EstadoOrden = Convert.ToBoolean(dataReader["EstadoOrden"].ToString());
                        oEjecucionOT.PermisoMunicipal = Convert.ToBoolean(dataReader["PermisoMunicipal"].ToString());
                        oEjecucionOT.FechaPermiso = dataReader["FechaPermiso"].ToString();
                        oEjecucionOT.Observacion = dataReader["Observacion"].ToString();

                        //detalle
                        if (dataReader["IdArea"].ToString() != "")
                            oEjecucionOT.Area = new GenericaDTO()
                            {
                                IdGenerica = Convert.ToInt32(dataReader["IdArea"].ToString()),
                            };
                        else
                            oEjecucionOT.Area = new GenericaDTO()
                            {
                                IdGenerica = 0,
                            };

                        if (dataReader["IdResponsable"].ToString() != "")
                            oEjecucionOT.IdResponsable = new EmpleadoDTO()
                            {
                                IdEmpleado = Convert.ToInt32(dataReader["IdResponsable"].ToString()),
                            };
                        else
                            oEjecucionOT.IdResponsable = new EmpleadoDTO()
                            {
                                IdEmpleado = 0,
                            };

                        if (dataReader["IdCuadrilla"].ToString() != "")
                            oEjecucionOT.Cuadrilla = new CuadrillaDTO()
                            {
                                IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString()),
                            };
                        else
                            oEjecucionOT.Cuadrilla = new CuadrillaDTO()
                            {
                                IdCuadrilla = 0,
                            };
                        oEjecucionOT.EstadoOT = new EstadoOTDTO()
                        {
                            IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"].ToString()),
                        };
                        oEjecucionOT.FechaRegistro = dataReader["FechaRegistro"].ToString();
                        oEjecucionOT.HoraRegistro = dataReader["HoraRegistro"].ToString();
                        oEjecucionOT.TuberiaRota = Convert.ToBoolean(dataReader["TuberiaRota"].ToString());
                        oEjecucionOT.FugaToma = Convert.ToBoolean(dataReader["FugaToma"].ToString());
                        oEjecucionOT.RoturaMedidor = Convert.ToBoolean(dataReader["RoturaMedidor"].ToString());
                        oEjecucionOT.Limpieza = Convert.ToBoolean(dataReader["Limpieza"].ToString());
                        oEjecucionOT.Bombeo = Convert.ToBoolean(dataReader["Bombeo"].ToString());
                        oEjecucionOT.UsuarioMod = dataReader["UsuModi"].ToString();
                        oEjecucionOT.VBIngeniero = Convert.ToBoolean(dataReader["VBIngeniero"].ToString());
                        oEjecucionOT.UsuarioVB = Convert.ToInt32(dataReader["UsuarioVB"].ToString() == "" ? "0" : dataReader["UsuarioVB"].ToString());
                        

                        oEjecucionOT.Puntaje = Convert.ToDecimal(dataReader["Puntaje"].ToString() == "" ? 0 : Convert.ToDecimal(dataReader["Puntaje"].ToString()));

                        if (!string.IsNullOrEmpty(dataReader["FechaVB"].ToString()))
                            oEjecucionOT.FechaVB = Convert.ToDateTime(dataReader["FechaVB"].ToString());
                        else
                            oEjecucionOT.FechaVB = Convert.ToDateTime("01/01/1900");
                        oEjecucionOT.UsuVBIngeniero = dataReader["UsuVBIngeniero"].ToString();
                        oEjecucionOT.DMTU = Convert.ToBoolean(dataReader["DMTU"].ToString());
                        oEjecucionOT.CUS = dataReader["CUS"].ToString();
                    }
                }

                return oEjecucionOT;
            }
            catch (Exception ex)
            {
                InsertarError(ex.StackTrace,0);
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new EjecucionOTDTO();
            }
        }

        public eResultado InsertarEjecucionOT(EjecucionOTDTO oEjecucionOT)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    try
                    {
                        DbCommand oCommand = db.GetStoredProcCommand("PRO_EjecucionOTInsertar",
                                new object[]
                        {
                            oEjecucionOT.IdEjecucionOT
                             ,oEjecucionOT.Area.IdGenerica
                             ,oEjecucionOT.IdResponsable.IdEmpleado
                             ,oEjecucionOT.Cuadrilla.IdCuadrilla
                             ,oEjecucionOT.EstadoOT.IdEstadoOT      
                             ,oEjecucionOT.FechaRegistro        
                             ,oEjecucionOT.HoraRegistro        
                             ,oEjecucionOT.UsuarioCreacion 
                             ,oEjecucionOT.FechaCreacion
                             
                        });

                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(db.ExecuteScalar(oCommand));

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
                InsertarError(ex.StackTrace, oEjecucionOT.UsuarioCreacion);
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return eResultado.Error;
            }
        }

        public eResultado ActualizarEjecucionOT(EjecucionOTDTO oEjecucionOT)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTActualizar",
                    new object[]
                {
                    oEjecucionOT.IdEjecucionOT
                    ,oEjecucionOT.Direccion
                    ,oEjecucionOT.FechaInicio
                    ,oEjecucionOT.HoraInicio
                    ,oEjecucionOT.FechaFin
                    ,oEjecucionOT.HoraFin
                    ,oEjecucionOT.FechaProg
                    ,oEjecucionOT.TipoTrabajo.IdGenerica
                    ,oEjecucionOT.NroOrden
                    ,oEjecucionOT.FechaOrden
                    ,oEjecucionOT.EstadoOrden
                    ,oEjecucionOT.Observacion
                    ,oEjecucionOT.TuberiaRota
                    ,oEjecucionOT.FugaToma
                    ,oEjecucionOT.RoturaMedidor
                    ,oEjecucionOT.Limpieza
                    ,oEjecucionOT.Bombeo
                    ,oEjecucionOT.PermisoMunicipal
                    ,oEjecucionOT.FechaPermiso
                    ,oEjecucionOT.UsuarioModificacion
                    ,oEjecucionOT.FechaModificacion
                    ,oEjecucionOT.VBIngeniero
                    ,oEjecucionOT.UsuarioVB
                    ,oEjecucionOT.FechaVB
                    ,oEjecucionOT.DMTU
                    ,oEjecucionOT.Puntaje
                    ,oEjecucionOT.DiasEstimadoEjec
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
                InsertarError(ex.StackTrace, oEjecucionOT.UsuarioModificacion);
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return eResultado.Error;
            }
        }

        public List<EjecucionOTGridDTO> GetEjecucionOTGridPorObraSinSGI(int IdObra,string f_alta, int IdEstado,string NIS,string direccion,string cliente)
        {
            try
            {
                List<EjecucionOTGridDTO> olEjecucionOT = new List<EjecucionOTGridDTO>();
                int posicion = 1;
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_ListarSinSGIPorObra", new object[]
                {
                    IdObra,f_alta,IdEstado,NIS,direccion,cliente
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        EjecucionOTGridDTO oEjecucionOT = new EjecucionOTGridDTO();
                        oEjecucionOT.Item = posicion;
                        oEjecucionOT.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        oEjecucionOT.NIS = dataReader["nis_rad"].ToString();
                        oEjecucionOT.Distrito = dataReader["municipio"].ToString();
                        oEjecucionOT.Direccion = dataReader["direccion"].ToString();
                        oEjecucionOT.Cliente = dataReader["cliente"].ToString();
                        oEjecucionOT.Actividad = dataReader["desc_actividad"].ToString();
                        oEjecucionOT.Descripcion = dataReader["Observacion"].ToString();
                        oEjecucionOT.FechaAlta = dataReader["f_alta"].ToString();
                        oEjecucionOT.Estado = dataReader["DescripcionEstado"].ToString();
                        oEjecucionOT.TipoTrabajo = dataReader["TipoTrabajo"].ToString();

                        oEjecucionOT.DesCuadrilla = dataReader["Cuadrilla"].ToString();
                        oEjecucionOT.Ingeniero = dataReader["Ingeniero"].ToString();
                        oEjecucionOT.FechaHoraIni = dataReader["FechaHoraIni"].ToString();
                        oEjecucionOT.FechaHoraFin = dataReader["FechaHoraFin"].ToString();
                        oEjecucionOT.SubActividad = dataReader["desc_subactividad"].ToString();

                        olEjecucionOT.Add(oEjecucionOT);
                        posicion++;
                    }
                }

                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<EjecucionOTGridDTO>();
            }
        }



        public List<EjecucionOTGridDTO> MonitoreoOperacion(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT,
            string fecDesde, string fecHasta, int idarea, string tipoFecha, string SinCuadrilla,string cliente)
        {
            try
            {
                //usp_monitoreo 20,0,0,'1,2,3,45,100,154','02/03/2017','02/03/2017',0,'INICIO',0    
                List<EjecucionOTGridDTO> olEjecucionOT = new List<EjecucionOTGridDTO>();
                int posicion = 1;
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("usp_monitoreo", new object[]
                {
                    20,0,0,"1,2,3,45,100,154",fecDesde,fecHasta,0,"INICIO",0,cliente
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        EjecucionOTGridDTO oEjecucionOT = new EjecucionOTGridDTO();
                        oEjecucionOT.Item = posicion;
                        oEjecucionOT.GESTION = dataReader["GESTION"].ToString();
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        oEjecucionOT.DesCuadrilla = dataReader["nomCuadrilla"].ToString();
                        oEjecucionOT.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.diascont = Convert.ToInt32(dataReader["diascont"].ToString());
                        oEjecucionOT.FechaAlta = dataReader["f_alta"].ToString();
                        oEjecucionOT.Actividad = dataReader["desc_actividad"].ToString();
                        oEjecucionOT.Descripcion = dataReader["Observacion"].ToString();
                        oEjecucionOT.Cliente = dataReader["cliente"].ToString();
                        oEjecucionOT.Estado = dataReader["DescripcionEstado"].ToString();
                        oEjecucionOT.FechaHoraFin = dataReader["Fechafin"].ToString() + '-' + dataReader["horafin"].ToString();
                        oEjecucionOT.FechaHoraIni = dataReader["fechainicio"].ToString() + '-' + dataReader["horainicio"].ToString();
                        oEjecucionOT.TipoTrabajo = dataReader["TipoTrabajo"].ToString();


                        //oEjecucionOT.NIS = dataReader["nis_rad"].ToString();
                        //oEjecucionOT.Distrito = dataReader["municipio"].ToString();
                        //oEjecucionOT.Direccion = dataReader["direccion"].ToString();
                        
                        //oEjecucionOT.Ingeniero = dataReader["Ingeniero"].ToString();
                        //oEjecucionOT.FechaHoraIni = dataReader["FechaHoraIni"].ToString();
                        //oEjecucionOT.SubActividad = dataReader["desc_subactividad"].ToString();
                        olEjecucionOT.Add(oEjecucionOT);
                        posicion++;
                    }
                }
             

                dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTListarPorObra_ENTCYSINASIGNAR", new object[]
                {
                    IdObra,0,IdEstadoOT,"","",0,fecDesde,fecHasta,0,IdCuadrilla,idarea,cliente
                    //IdCuadrilla,IdTipoTrabajo,IdEstadoOT,fecDesde,fecHasta,idarea,tipoFecha,SinCuadrilla
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        EjecucionOTGridDTO oEjecucionOT = new EjecucionOTGridDTO();
                        oEjecucionOT.Item = posicion;
                        oEjecucionOT.GESTION = dataReader["GESTION"].ToString();
                        oEjecucionOT.IdEjecucionOT = Convert.ToInt32(dataReader["IdEjecucionOT"].ToString());
                        oEjecucionOT.DesCuadrilla = dataReader["nomCuadrilla"].ToString();
                        oEjecucionOT.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oEjecucionOT.diascont = Convert.ToInt32(dataReader["diascont"].ToString());
                        oEjecucionOT.FechaAlta = dataReader["f_alta"].ToString();
                        oEjecucionOT.Actividad = dataReader["desc_actividad"].ToString();
                        oEjecucionOT.Descripcion = dataReader["Observacion"].ToString();
                        oEjecucionOT.Cliente = dataReader["cliente"].ToString();
                        oEjecucionOT.Estado = dataReader["DescripcionEstado"].ToString();
                        oEjecucionOT.FechaHoraFin = dataReader["Fechafin"].ToString() + '-' + dataReader["horafin"].ToString();
                        oEjecucionOT.FechaHoraIni = dataReader["fechainicio"].ToString() + '-' + dataReader["horainicio"].ToString();
                        oEjecucionOT.TipoTrabajo = dataReader["TipoTrabajo"].ToString();


                        //oEjecucionOT.NIS = dataReader["nis_rad"].ToString();
                        //oEjecucionOT.Distrito = dataReader["municipio"].ToString();
                        //oEjecucionOT.Direccion = dataReader["direccion"].ToString();
                        
                        //oEjecucionOT.Ingeniero = dataReader["Ingeniero"].ToString();
                        //oEjecucionOT.FechaHoraIni = dataReader["FechaHoraIni"].ToString();
                        //oEjecucionOT.SubActividad = dataReader["desc_subactividad"].ToString();
                        olEjecucionOT.Add(oEjecucionOT);
                        posicion++;
                    }
                }

                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<EjecucionOTGridDTO>();
            }
        }



        public List<ProgramacionCuadrillaDTO>  ObtenerProgramacionCuadrilla(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, string fecDesde, string fecHasta,int idarea,string tipoFecha,string SinCuadrilla)
        {
            try
            {
                List<ProgramacionCuadrillaDTO> olProg = new List<ProgramacionCuadrillaDTO>();
                
                Database db = DatabaseFactory.CreateDatabase();
                
                DbCommand dbCommand = db.GetStoredProcCommand("dbo.OTPrograCuad3", new object[]
                {
                    IdObra,IdCuadrilla,IdTipoTrabajo,IdEstadoOT,fecDesde,fecHasta,idarea,tipoFecha,SinCuadrilla
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ProgramacionCuadrillaDTO oProg = new ProgramacionCuadrillaDTO();
                        oProg.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oProg.DiasCont = Convert.ToInt32(dataReader["DiasCont"].ToString());
                        oProg.FechaProg = dataReader["FechaProg"].ToString();
                        oProg.f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString());
                        oProg.HoraProg = dataReader["HoraProg"].ToString();
                        oProg.desc_actividad = dataReader["Desc_Actividad"].ToString();
                        oProg.ObservacionCONCYSSA = "Gestionando - " + dataReader["Observacion"].ToString();
                        oProg.NombreTipoTrabajo = dataReader["Cliente"].ToString();
                        oProg.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString() == "" ? "0" : dataReader["IdCuadrilla"].ToString());
                        oProg.NombreCuadrilla = dataReader["NomCuadrilla"].ToString();
                        oProg.NombreEstadoOT = dataReader["DescripcionEstado"].ToString();
                        oProg.NombreResponsable = dataReader["TITULO"].ToString();
                        oProg.FechaFin = dataReader["FechaFin"].ToString();
                        oProg.HoraFin = dataReader["HoraFin"].ToString();
                        oProg.FechaInicio = dataReader["FechaInicio"].ToString();
                        oProg.HoraInicio = dataReader["HoraInicio"].ToString();
                        
                        olProg.Add(oProg);
                    }
                }

                dbCommand = db.GetStoredProcCommand("PRO_EjecucionOTListarPorObra_ENTCYSINASIGNAR", new object[]
                {
                    IdObra,0,IdEstadoOT,"","",0,fecDesde,fecHasta,0,IdCuadrilla,idarea,""
                    //IdCuadrilla,IdTipoTrabajo,IdEstadoOT,fecDesde,fecHasta,idarea,tipoFecha,SinCuadrilla
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ProgramacionCuadrillaDTO oProg = new ProgramacionCuadrillaDTO();
                        oProg.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oProg.DiasCont = Convert.ToInt32(dataReader["DiasCont"].ToString());
                        oProg.FechaProg = dataReader["FechaProg"].ToString();
                        oProg.f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString());
                        oProg.HoraProg = dataReader["HoraProg"].ToString();
                        oProg.desc_actividad = dataReader["Desc_Actividad"].ToString();
                        oProg.ObservacionCONCYSSA =dataReader["Observacion"].ToString();
                        oProg.NombreTipoTrabajo = dataReader["Cliente"].ToString();
                        oProg.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString() == "" ? "0" : dataReader["IdCuadrilla"].ToString());
                        oProg.NombreCuadrilla = dataReader["NomCuadrilla"].ToString();
                        oProg.NombreEstadoOT = dataReader["DescripcionEstado"].ToString();
                        oProg.NombreResponsable = dataReader["TITULO"].ToString();
                        oProg.FechaFin = dataReader["FechaFin"].ToString();
                        oProg.HoraFin = dataReader["HoraFin"].ToString();
                        oProg.FechaInicio = dataReader["FechaInicio"].ToString();
                        oProg.HoraInicio = dataReader["HoraInicio"].ToString();

                        olProg.Add(oProg);
                    }
                }








                return olProg;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<ProgramacionCuadrillaDTO>();
            }



        }

        public List<PermisoMunicipalDTO> ObtenerProgramacionPermisoMunicipal(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, bool PermisoMunicipal, string fecDesde, string fecHasta)
        {
            try
            {


                List<PermisoMunicipalDTO> olProg = new List<PermisoMunicipalDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ProgramacionPermisoMunicipal", new object[]
                {
                    IdObra,IdCuadrilla,IdTipoTrabajo,IdEstadoOT,PermisoMunicipal,fecDesde,fecHasta
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        PermisoMunicipalDTO oProg = new PermisoMunicipalDTO();
                        oProg.Cuadrilla = dataReader["NomCuadrilla"].ToString();
                        oProg.SGI = dataReader["nro_ot"].ToString();
                        oProg.direccion = dataReader["Direccion"].ToString();
                        oProg.localidad = dataReader["localidad"].ToString();
                        oProg.distrito = dataReader["municipio"].ToString();
                        oProg.subactividad = dataReader["desc_actividad"].ToString();
                        oProg.observacion = dataReader["Observacion"].ToString();
                        olProg.Add(oProg);
                    }
                }

                return olProg;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<PermisoMunicipalDTO>();
            }
        }

        public List<ProgramacionCuadrillaDTO> ObtenerProgramacionTC(int IdObra, string TipoTC, string Ejecutor, int IdEjecutor, string IdEstadoOT, string fecDesde, string fecHasta, int IdArea, string tipoObservacion)
        {
            try
            {


                List<ProgramacionCuadrillaDTO> olProg = new List<ProgramacionCuadrillaDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ProgramacionTrabajoComplementario", new object[]
                {
                    IdObra,TipoTC,Ejecutor,IdEjecutor,IdEstadoOT,fecDesde,fecHasta,IdArea,tipoObservacion
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ProgramacionCuadrillaDTO oProg = new ProgramacionCuadrillaDTO();
                        oProg.NroRegistro = Convert.ToInt32(dataReader["NroRegistro"].ToString());
                        oProg.DiasCont = Convert.ToInt32(dataReader["DiasDesde"].ToString() == "" ? "0" : dataReader["DiasDesde"].ToString());
                        oProg.FechaProg = dataReader["FechaProgramada"].ToString();
                        oProg.nro_ot = dataReader["nro_ot"].ToString();

                        oProg.direccionCONCYSSA = dataReader["direccion"].ToString() + " - " + dataReader["localidad"].ToString();
                        oProg.municipio = dataReader["municipio"].ToString();
                        oProg.desc_actividad = dataReader["Desc_subActividad"].ToString();
                        oProg.ObservacionCONCYSSA = dataReader["Observacion"].ToString();

                        oProg.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrillaOrden"].ToString() == "" ? "0" : dataReader["IdCuadrillaOrden"].ToString());
                        oProg.NombreCuadrilla = dataReader["NombreCuadrillaOrden"].ToString();

                        oProg.IdEstadoTC = Convert.ToInt32(dataReader["IdEstadoTC"].ToString());
                        oProg.NombreEstadoTC = dataReader["NombreEstadoTC"].ToString();
                        oProg.Titulo = dataReader["Titulo"].ToString();
                        switch (TipoTC)
                        {
                            case "RESANE":
                                oProg.NombreTipoTrabajo = dataReader["Descripcion"].ToString();
                                oProg.Largo = Convert.ToDecimal(dataReader["Largo"].ToString() == "" ? "0" : dataReader["Largo"].ToString());
                                oProg.Ancho = Convert.ToDecimal(dataReader["Ancho"].ToString() == "" ? "0" : dataReader["Ancho"].ToString());
                                oProg.NroOrden = dataReader["NroOrden"].ToString();
                                oProg.IdEjecutor = Convert.ToInt32(dataReader["IdEjecutor"].ToString() == "" ? "0" : dataReader["IdEjecutor"].ToString());
                                oProg.NombreEjecutor = dataReader["NombreEjecutor"].ToString();

                                break;
                            case "SEÑALIZACION":
                                oProg.IdEjecutor = Convert.ToInt32(dataReader["IdEjecutor"].ToString() == "" ? "0" : dataReader["IdEjecutor"].ToString());
                                oProg.NombreEjecutor = dataReader["NombreEjecutor"].ToString();
                                oProg.Parantes = Convert.ToInt32(dataReader["Parantes"].ToString() == "" ? "0" : dataReader["Parantes"].ToString());//Convert.ToInt32(dataReader["Parantes"].ToString());
                                oProg.Machones = Convert.ToInt32(dataReader["Machones"].ToString() == "" ? "0" : dataReader["Machones"].ToString());// Convert.ToInt32(dataReader["Machones"].ToString());
                                oProg.Tranqueras = Convert.ToInt32(dataReader["Tranqueras"].ToString() == "" ? "0" : dataReader["Tranqueras"].ToString());// Convert.ToInt32(dataReader["Tranqueras"].ToString());
                                break;
                            case "DESMONTE":
                                oProg.IdEjecutor = Convert.ToInt32(dataReader["IdEjecutor"].ToString() == "" ? "0" : dataReader["IdEjecutor"].ToString());
                                oProg.NombreEjecutor = dataReader["NombreEjecutor"].ToString();
                                oProg.Cubico = Convert.ToDecimal(dataReader["Cubico"].ToString() == "" ? "0" : dataReader["Cubico"].ToString());
                                oProg.Relleno = Convert.ToDecimal(dataReader["Relleno"].ToString() == "" ? "0" : dataReader["Relleno"].ToString());

                                oProg.IdEjecutor = Convert.ToInt32(dataReader["IdEjecutor"].ToString() == "" ? "0" : dataReader["IdEjecutor"].ToString());
                                oProg.NombreEjecutor = dataReader["NombreEjecutor"].ToString();
                                break;
                            case "CORTE":
                                oProg.IdEjecutor = Convert.ToInt32(dataReader["IdEjecutor"].ToString() == "" ? "0" : dataReader["IdEjecutor"].ToString());
                                oProg.NombreEjecutor = dataReader["NombreEjecutor"].ToString();
                                break;
                            case "ROTURA":
                                oProg.IdEjecutor = Convert.ToInt32(dataReader["IdEjecutor"].ToString() == "" ? "0" : dataReader["IdEjecutor"].ToString());
                                oProg.NombreEjecutor = dataReader["NombreEjecutor"].ToString();
                                break;
                        }
                        olProg.Add(oProg);
                    }
                }

                return olProg;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<ProgramacionCuadrillaDTO>();
            }
        }

        public eResultado AsignarOTSinSGI(int IdEjecucionConSGI,int IdEjecucionSinSGI)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_AsignarOTSinSGI2", new object[]
                {
                    IdEjecucionConSGI,IdEjecucionSinSGI
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return eResultado.Error;
            }
        }

        public eResultado AsignarMasivoCuadrillaEstado(List<EjecucionOTMasivaGridDTO> olMasivo,int IdCuadrilla,int IdEstadoOT,int Usuario)
        {
           
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                    try{
                        foreach (var item in olMasivo)
                        {
                            DbCommand dbCommand = db.GetStoredProcCommand("PRO_DetalleEjecucionOT_AsignarCuadrillaEstado", new object[]
                            {
                                item.IdEjecucionOT,IdCuadrilla,IdEstadoOT,Usuario
                            });
                            db.ExecuteNonQuery(dbCommand);
                        }
                        transaction.Commit();
                        connection.Close();
                        return eResultado.Correcto;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        connection.Close();
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                        return eResultado.Error;
                    }
                }
           
        }


        public eResultado InsertarError(string Error,int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_Error_insertar", new object[]
                {
                    'x',Error,Usuario
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return eResultado.Error;
            }
        }

        //public List<MontoEstadoDTO> ObtenerMontosEstado(int obra, string estado, int responsable, int cuadrilla, string fechaini, string fechafin)
        //{
        //    try
        //    {


        //        List<MontoEstadoDTO> olProg = new List<MontoEstadoDTO>();
        //        Database db = DatabaseFactory.CreateDatabase();
        //        DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_ObtenerMontosEstado", new object[]
        //        {
        //            obra,estado,responsable,cuadrilla,fechaini,fechafin
        //        });

        //        using (IDataReader dataReader = db.ExecuteReader(dbCommand))
        //        {
        //            while (dataReader.Read())
        //            {
        //                MontoEstadoDTO oProg = new MontoEstadoDTO();
        //                oProg.titulo = dataReader["TITULO"].ToString();
        //                oProg.fecha = Convert.ToDateTime(dataReader["Fecha"].ToString());
        //                oProg.estado = dataReader["ESTADO"].ToString();
        //                oProg.responsable = dataReader["Responsable"].ToString();
        //                oProg.cuadrilla = dataReader["Cuadrilla"].ToString();
        //                oProg.subtotal = Convert.ToDecimal(dataReader["SUBTOTAL"].ToString());

        //                olProg.Add(oProg);
        //            }
        //        }

        //        return olProg;
        //    }
        //    catch (Exception ex)
        //    {
        //        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
        //        return new List<MontoEstadoDTO>();
        //    }
        //}

        //public List<MontoEstadoDTO> ObtenerMontosEstadoResumen(int obra, string estado, int responsable, int cuadrilla, string fechaini,string fechafin)
        //{
        //    try
        //    {


        //        List<MontoEstadoDTO> olProg = new List<MontoEstadoDTO>();
        //        Database db = DatabaseFactory.CreateDatabase();
        //        DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_ObtenerMontosEstadoResumen", new object[]
        //        {
        //            obra,estado,responsable,cuadrilla,fechaini,fechafin
        //        });

        //        using (IDataReader dataReader = db.ExecuteReader(dbCommand))
        //        {
        //            while (dataReader.Read())
        //            {
        //                MontoEstadoDTO oProg = new MontoEstadoDTO();
        //                oProg.titulo = dataReader["TITULO"].ToString();
        //                oProg.FecInicio = dataReader["FecInicio"].ToString();
        //                oProg.FecFin = dataReader["FecFin"].ToString();
        //                oProg.estado = dataReader["ESTADO"].ToString();
        //                oProg.responsable = dataReader["Responsable"].ToString();
        //                oProg.cuadrilla = dataReader["Cuadrilla"].ToString();
        //                oProg.subtotal = Convert.ToDecimal(dataReader["SUBTOTAL"].ToString());

        //                olProg.Add(oProg);
        //            }
        //        }

        //        return olProg;
        //    }
        //    catch (Exception ex)
        //    {
        //        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
        //        return new List<MontoEstadoDTO>();
        //    }
        //}

        public List<MontoEstadoDTO> ObtenerReporteMontoEstado(int obra, string fechaini, string fechafin)
        {
            try
            {


                List<MontoEstadoDTO> olProg = new List<MontoEstadoDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_ReporteMontoPorEstado", new object[]
                {
                    obra,fechaini,fechafin
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        MontoEstadoDTO oProg = new MontoEstadoDTO();
                        oProg.titulo = dataReader["TITULO"].ToString();
                        oProg.sbase = dataReader["Base"].ToString();
                        oProg.obra = dataReader["Obra"].ToString();
                        oProg.FecInicio = dataReader["FecInicio"].ToString();
                        oProg.FecFin = dataReader["FecFin"].ToString();
                        oProg.responsable = dataReader["Responsable"].ToString();
                        oProg.pendiente = Convert.ToDecimal(dataReader["pendiente"].ToString());
                        oProg.asignado = Convert.ToDecimal(dataReader["asignado"].ToString());
                        oProg.trabajando = Convert.ToDecimal(dataReader["trabajando"].ToString());
                        oProg.atendido = Convert.ToDecimal(dataReader["atendido"].ToString());
                        oProg.resuelto = Convert.ToDecimal(dataReader["resuelto"].ToString());
                        oProg.facturado = Convert.ToDecimal(dataReader["facturado"].ToString());
                        olProg.Add(oProg);
                    }
                }

                return olProg;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<MontoEstadoDTO>();
            }
        }

        public List<ObservacionEstadisticaDTO> ObtenerObservacionOT(int IdObra, int IdCuadrilla, int IdTipoTrabajo, string IdEstadoOT, string fecDesde, string fecHasta, int idarea, string tipoObservacion)
        {
            try
            {


                List<ObservacionEstadisticaDTO> olProg = new List<ObservacionEstadisticaDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                //DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ObservacionOT", new object[]
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ObservacionOT2", new object[]
                {
                    IdObra,IdCuadrilla,IdTipoTrabajo,IdEstadoOT,fecDesde,fecHasta,idarea,tipoObservacion
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ObservacionEstadisticaDTO oProg = new ObservacionEstadisticaDTO();
                        oProg.SGI = dataReader["nro_ot"].ToString();
                        oProg.NIS = dataReader["nis_rad"].ToString();
                        oProg.Direccion = dataReader["Direccion"].ToString();
                        oProg.Urbanizacion= dataReader["localidad"].ToString();
                        oProg.Distrito = dataReader["municipio"].ToString();
                        oProg.Actividad = dataReader["Desc_Actividad"].ToString();
                        oProg.Observacion = dataReader["Observacion"].ToString();
                        oProg.FechaProg = dataReader["FechaProg"].ToString();
                        oProg.HoraProg = dataReader["HoraProg"].ToString();
                        oProg.FechaInicio = dataReader["FechaInicio"].ToString();
                        oProg.HoraInicio = dataReader["HoraInicio"].ToString();
                        oProg.FechaFin = dataReader["FechaFin"].ToString();
                        oProg.HoraFin = dataReader["HoraFin"].ToString();
                        oProg.Cuadrilla = dataReader["NomCuadrilla"].ToString();
                        oProg.Estado = dataReader["DescripcionEstado"].ToString();
                        oProg.Correlativo = dataReader["NroRegistro"].ToString();
                        oProg.NroOrden = dataReader["NroOrden"].ToString();
                        oProg.FechaOrden = dataReader["FechaOrden"].ToString();
                        oProg.NombreReporte = dataReader["TITULO"].ToString();
                        oProg.FDesde = fecDesde;
                        oProg.FHasta = fecHasta;
                        olProg.Add(oProg);
                    }
                }

                return olProg;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<ObservacionEstadisticaDTO>();
            }
        }

        public List<VBIngenieroDTO> ObtenerVBIngenieros(int IdObra, int IdResponsable, bool ConVB)
        {
            try
            {


                List<VBIngenieroDTO> olProg = new List<VBIngenieroDTO>();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_ObtenerOTSinVB", new object[]
                {
                    IdObra,IdResponsable,ConVB
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        VBIngenieroDTO oProg = new VBIngenieroDTO();
                        oProg.Base = dataReader["Base"].ToString();
                        oProg.Obra = dataReader["Obra"].ToString();
                        oProg.Responsable = dataReader["Responsable"].ToString().ToUpper();
                        oProg.NroRegistro = dataReader["NroRegistro"].ToString();
                        oProg.FechaProg = dataReader["FechaProg"].ToString();
                        oProg.desc_subactividad = dataReader["desc_subactividad"].ToString();
                        oProg.Direccion = dataReader["Direccion"].ToString();
                        oProg.localidad = dataReader["localidad"].ToString();
                        oProg.municipio = dataReader["municipio"].ToString();
                        oProg.Estado = dataReader["Estado"].ToString();
                        olProg.Add(oProg);
                    }
                }

                return olProg;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<VBIngenieroDTO>();
            }
        }

        public List<DMTUDTO> GetEjecucionOTDMTU(int IdObra, string fDesde, string fHasta)
        {
            try
            {
                List<DMTUDTO> olEjecucionOT = new List<DMTUDTO>();
                int posicion = 1;
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_EjecucionOT_ObtenerDatosDMTU", new object[]
                {
                    IdObra,fDesde,fHasta
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        DMTUDTO oEjecucionOT = new DMTUDTO();
                        oEjecucionOT.Base = dataReader["Base"].ToString();
                        oEjecucionOT.Obra = dataReader["Obra"].ToString();
                        oEjecucionOT.FDesde = dataReader["FDesde"].ToString();
                        oEjecucionOT.FHasta = dataReader["FHasta"].ToString();
                        oEjecucionOT.Direccion = dataReader["Direccion"].ToString();
                        oEjecucionOT.Localidad = dataReader["Localidad"].ToString();
                        oEjecucionOT.Distrito = dataReader["Distrito"].ToString();
                        oEjecucionOT.Actividad = dataReader["Actividad"].ToString();
                        oEjecucionOT.SubActividad = dataReader["SubActividad"].ToString();

                        olEjecucionOT.Add(oEjecucionOT);
                        posicion++;
                    }
                }

                return olEjecucionOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "SMC GESTION DE OPERACIONES" });
                return new List<DMTUDTO>();
            }
        }
    }
}
