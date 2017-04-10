using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DTO.ProduccionServicios.Procesos;
using Intranet.DTO.Global;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class OrdenTrabajoDAO
    {
        List<OrdenTrabajoDTO> olOrdenTrabajo = new List<OrdenTrabajoDTO>();

        public List<OrdenTrabajoDTO> ObtenerSGIsIngresados(int IdObra)
        {
            List<OrdenTrabajoDTO> olSGis = new List<OrdenTrabajoDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ListarSGIsIngresados", new object[]
                {
                    IdObra                    
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    olSGis.Add(new OrdenTrabajoDTO() { nro_ot = dataReader["nro_ot"].ToString() });
                }
            }

            return olSGis;
        }

        public List<OrdenTrabajoDTO> CargarOrdenTrabajoCliente(string rutaArchivo, ref string resultado, int IdObra, int CentroServicio, int nroContrato, int usuario)
        {

            int nroContrato2 = 0;

            Database dbx = DatabaseFactory.CreateDatabase();
            DbCommand dbCommandx = dbx.GetSqlStringCommand("select nrocontrato2 from MA_Usuario where idusuario =" + usuario.ToString());


            using (IDataReader dataReader = dbx.ExecuteReader(dbCommandx))
            {
                while (dataReader.Read())
                {
                    nroContrato2 = Convert.ToInt32(dataReader["nroContrato2"].ToString());

                }
            }


            OrdenTrabajoDTO oOrdenTrabajo = new OrdenTrabajoDTO();
            OrdenTrabajoDTO oOrdenTrabajoVer = new OrdenTrabajoDTO();

            List<OrdenTrabajoDTO> olOrdenTrabajoBD = new List<OrdenTrabajoDTO>();
            olOrdenTrabajoBD = new OrdenTrabajoDAO().ObtenerSGIsIngresados(IdObra);

            DataTable dt = null;
            OleDbConnection objConn = null;
            try
            {
                DataSet ds = new DataSet();
                String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + rutaArchivo + ";Extended Properties=Excel 8.0;";
                objConn = new OleDbConnection(connString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    resultado = "No existen datos en el archivo a importar.";
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + excelSheets[i] + "]", objConn);
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    oleda.Fill(ds, "TABLE");

                    int oo = ds.Tables[0].Rows.Count;
                    foreach (DataRow fila in ds.Tables[0].Rows)
                        {
                            if (Convert.ToDecimal(fila["ncod_centro"].ToString()) == Convert.ToDecimal(CentroServicio) && Convert.ToDecimal(fila["nres_contrata"].ToString()) == Convert.ToDecimal(nroContrato) ||
                                Convert.ToDecimal(fila["nres_contrata"].ToString()) == Convert.ToDecimal(nroContrato2))
                            {


                                oOrdenTrabajo = new OrdenTrabajoDTO();
                                oOrdenTrabajo.IdOrdenTrabajo = 0;
                                oOrdenTrabajo.ArchivoCargaOT = null;
                                oOrdenTrabajo.os_ot = fila["os_ot"].ToString();
                                oOrdenTrabajo.ncod_centro = Convert.ToInt32(fila["ncod_centro"].ToString());
                                oOrdenTrabajo.center = fila["center"].ToString();
                                oOrdenTrabajo.nro_ot = fila["nro_ot"].ToString();
                                oOrdenTrabajo.nis_rad = fila["nis_rad"].ToString();
                                oOrdenTrabajo.cliente = fila["cliente"].ToString();
                                oOrdenTrabajo.municipio = fila["municipio"].ToString();
                                oOrdenTrabajo.localidad = fila["localidad"].ToString();
                                oOrdenTrabajo.direccion = fila["direccion"].ToString();
                                oOrdenTrabajo.estado = fila["estado"].ToString();
                                oOrdenTrabajo.nest_ot = Convert.ToInt32(fila["nest_ot"].ToString());
                                oOrdenTrabajo.actividad = Convert.ToInt32(fila["actividad"].ToString());
                                oOrdenTrabajo.desc_actividad = fila["desc_actividad"].ToString();
                                oOrdenTrabajo.subactividad = Convert.ToInt32(fila["subactividad"].ToString());
                                oOrdenTrabajo.desc_subactividad = fila["desc_subactividad"].ToString();
                                oOrdenTrabajo.ncosto_ot = Convert.ToDecimal(fila["ncosto_ot"].ToString());
                                oOrdenTrabajo.vobservacion_contrata = fila["vobservacion_contrata"].ToString();
                                oOrdenTrabajo.f_alta = Convert.ToDateTime(fila["f_alta"].ToString());
                                oOrdenTrabajo.f_ini = Convert.ToDateTime(fila["f_ini"].ToString());
                                oOrdenTrabajo.f_fin = Convert.ToDateTime(fila["f_fin"].ToString());
                                oOrdenTrabajo.f_atendido = Convert.ToDateTime(fila["f_atendido"].ToString());
                                oOrdenTrabajo.f_res_contrata = Convert.ToDateTime(fila["f_res_contrata"].ToString());
                                oOrdenTrabajo.tipo_red = fila["tipo_red"].ToString();
                                oOrdenTrabajo.ntip_red = Convert.ToInt32(fila["ntip_red"].ToString());

                                string desc = fila["vdescripcion"].ToString();
                                char[] valores = {'<','>','=','+','*'}; //,'/','-'};
                                foreach (char item in valores)
                                {
                                    desc = desc.Replace(item, ' ');
                                }
                                oOrdenTrabajo.vdescripcion = desc;

                                oOrdenTrabajo.vref_direccion = fila["direccion"].ToString();
                                oOrdenTrabajo.vusuario = fila["vusuario"].ToString();
                                oOrdenTrabajo.nres_contrata = Convert.ToInt32(fila["nres_contrata"].ToString());
                                oOrdenTrabajo.ncod_cuadrilla = Convert.ToInt32(fila["ncod_cuadrilla"].ToString());
                                oOrdenTrabajo.ncod_incidencia = Convert.ToInt32(fila["ncod_incidencia"].ToString());
                                oOrdenTrabajo.ncod_factura = Convert.ToInt32(fila["ncod_factura"].ToString());
                                oOrdenTrabajo.secs = fila["secs"].ToString();
                                oOrdenTrabajo.secsfin = fila["secsfin"].ToString();
                                oOrdenTrabajo.ot_contrata = fila["ot_contrata"].ToString();
                                oOrdenTrabajo.ntip_ot = Convert.ToInt32(fila["ntip_ot"].ToString());
                                oOrdenTrabajo.tipo_ot = fila["tipo_ot"].ToString();
                                oOrdenTrabajo.nnum_os = Convert.ToInt32(fila["nnum_os"].ToString());
                                string sgi = fila["nro_ot"].ToString();
                                oOrdenTrabajoVer = olOrdenTrabajoBD.Where(x => x.nro_ot == sgi).FirstOrDefault();
                                if (oOrdenTrabajoVer == null)
                                    oOrdenTrabajo.Existe = false;
                                else
                                    oOrdenTrabajo.Existe = true;
                                olOrdenTrabajo.Add(oOrdenTrabajo);
                            }
                            else
                            {
                                resultado = "INCONSISTENCIA";
                                return null;
                            }
                        }
                    i++;
                }
                resultado = "CORRECTO";
                return olOrdenTrabajo;
            }
            catch(Exception ex)
            {
                resultado = ex.Message;
                return null;
            }
            
        }

        public List<OrdenTrabajoDTO> GetOrdenTrabajo(int IdObra)
        {
            olOrdenTrabajo = new List<OrdenTrabajoDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajoListaPorObra", new object[]
                {
                    IdObra                    
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    OrdenTrabajoDTO oOrdenTrabajo = new OrdenTrabajoDTO();
                    oOrdenTrabajo.IdOrdenTrabajo = Convert.ToInt32(dataReader["IdOrdenTrabajo"].ToString());
                    oOrdenTrabajo.ArchivoCargaOT = new ArchivoCargaOTDAO().GetArchivoCargaPorID(Convert.ToInt32(dataReader["IdArchivoCargaOT"].ToString()));
                    oOrdenTrabajo.os_ot = dataReader["os_ot"].ToString();
                    oOrdenTrabajo.ncod_centro = Convert.ToInt32(dataReader["ncod_centro"].ToString());
                    oOrdenTrabajo.center = dataReader["center"].ToString();
                    oOrdenTrabajo.nro_ot = dataReader["nro_ot"].ToString();
                    oOrdenTrabajo.nis_rad = dataReader["nis_rad"].ToString();
                    oOrdenTrabajo.cliente = dataReader["cliente"].ToString();
                    oOrdenTrabajo.municipio = dataReader["municipio"].ToString();
                    oOrdenTrabajo.localidad = dataReader["localidad"].ToString();
                    oOrdenTrabajo.direccion = dataReader["direccion"].ToString();
                    oOrdenTrabajo.estado = dataReader["estado"].ToString();
                    oOrdenTrabajo.nest_ot = Convert.ToInt32(dataReader["nest_ot"].ToString());
                    oOrdenTrabajo.actividad = Convert.ToInt32(dataReader["actividad"].ToString());
                    oOrdenTrabajo.desc_actividad = dataReader["desc_actividad"].ToString();
                    oOrdenTrabajo.subactividad = Convert.ToInt32(dataReader["subactividad"].ToString());
                    oOrdenTrabajo.desc_subactividad = dataReader["desc_subactividad"].ToString();
                    oOrdenTrabajo.ncosto_ot = Convert.ToDecimal(dataReader["ncosto_ot"].ToString());
                    oOrdenTrabajo.vobservacion_contrata = dataReader["vobservacion_contrata"].ToString();
                    oOrdenTrabajo.f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString());
                    oOrdenTrabajo.f_ini = Convert.ToDateTime(dataReader["f_ini"].ToString());
                    oOrdenTrabajo.f_fin = Convert.ToDateTime(dataReader["f_fin"].ToString());
                    oOrdenTrabajo.f_atendido = Convert.ToDateTime(dataReader["f_atendido"].ToString());
                    oOrdenTrabajo.f_res_contrata = Convert.ToDateTime(dataReader["f_res_contrata"].ToString());
                    oOrdenTrabajo.tipo_red = dataReader["tipo_red"].ToString();
                    oOrdenTrabajo.ntip_red = Convert.ToInt32(dataReader["ntip_red"].ToString());
                    oOrdenTrabajo.vdescripcion = dataReader["vdescripcion"].ToString();
                    oOrdenTrabajo.vref_direccion = dataReader["vref_direccion"].ToString();
                    oOrdenTrabajo.vusuario = dataReader["vusuario"].ToString();
                    oOrdenTrabajo.nres_contrata = Convert.ToInt32(dataReader["nres_contrata"].ToString());
                    oOrdenTrabajo.ncod_cuadrilla = Convert.ToInt32(dataReader["ncod_cuadrilla"].ToString());
                    oOrdenTrabajo.ncod_incidencia = Convert.ToInt32(dataReader["ncod_incidencia"].ToString());
                    oOrdenTrabajo.ncod_factura = Convert.ToInt32(dataReader["ncod_factura"].ToString());
                    oOrdenTrabajo.secs = dataReader["secs"].ToString();
                    oOrdenTrabajo.secsfin = dataReader["secsfin"].ToString();
                    oOrdenTrabajo.ot_contrata = dataReader["ot_contrata"].ToString();
                    oOrdenTrabajo.ntip_ot = Convert.ToInt32(dataReader["ntip_ot"].ToString());
                    oOrdenTrabajo.tipo_ot = dataReader["tipo_ot"].ToString();
                    oOrdenTrabajo.nnum_os = Convert.ToInt32(dataReader["nnum_os"].ToString());
                    olOrdenTrabajo.Add(oOrdenTrabajo);
                }
            }
            return olOrdenTrabajo;
        }

        public eEstadoTransaccion InsertarOrdenTrabajo(ArchivoCargaOTDTO oArchivo, List<OrdenTrabajoDTO> olOrdenTrabajo)
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                //DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                try
                {
                    DbCommand oCommand = db.GetStoredProcCommand("PRO_ArchivoCargaOTInsert",
                            new object[]
                        {
                            oArchivo.ArchivoRuta,
                            oArchivo.DescripcionCarga,
                            oArchivo.Obra.IdObra,
                            oArchivo.UsuarioCarga,
                            oArchivo.FechaCarga
                        });

                    //oArchivo.IdArchivoCargaOT = Convert.ToInt32(db.ExecuteScalar(oCommand, transaction));
                    oArchivo.IdArchivoCargaOT = Convert.ToInt32(db.ExecuteScalar(oCommand));


                    foreach (var item in olOrdenTrabajo)
                    {
                        DbCommand oCommand2 = db.GetStoredProcCommand("PRO_OrdenTrabajoInsert", new object[]
                                {
                                    oArchivo.IdArchivoCargaOT,
                                    item.os_ot,
                                    item.ncod_centro ,
                                    item.center,
                                    item.nro_ot,
                                    item.nis_rad,
                                    item.cliente ,
                                    item.municipio,
                                    item.localidad,
                                    item.direccion,
                                    item.estado ,
                                    item.nest_ot ,
                                    item.actividad,
                                    item.desc_actividad ,
                                    item.subactividad ,
                                    item.desc_subactividad ,
                                    item.ncosto_ot ,
                                    item.vobservacion_contrata ,
                                    item.f_alta ,
                                    item.f_ini ,
                                    item.f_fin,
                                    item.f_atendido ,
                                    item.f_res_contrata,
                                    item.tipo_red,
                                    item.ntip_red,
                                    item.vdescripcion ,
                                    item.vref_direccion,
                                    item.vusuario ,
                                    item.nres_contrata ,
                                    item.ncod_cuadrilla ,
                                    item.ncod_incidencia ,
                                    item.ncod_factura ,
                                    item.secs ,
                                    item.secsfin,
                                    item.ot_contrata ,
                                    item.ntip_ot,
                                    item.tipo_ot,
                                    item.nnum_os,
                                    oArchivo.UsuarioCarga,
                                    DateTime.Now,
                                    oArchivo.Obra.IdObra,
                                });

                        //db.ExecuteNonQuery(oCommand2, transaction);
                        db.ExecuteNonQuery(oCommand2);
                    }
                    //foreach (var item in olOrdenTrabajoExiste)
                    //{
                    //    DbCommand oCommand3 = db.GetStoredProcCommand("PRO_OrdenTrabajoUpdate", new object[]
                    //            {
                    //                item.os_ot,
                    //                item.ncod_centro ,
                    //                item.center,
                    //                item.nro_ot,
                    //                item.nis_rad,
                    //                item.cliente ,
                    //                item.municipio,
                    //                item.localidad,
                    //                item.direccion,
                    //                item.estado ,
                    //                item.nest_ot ,
                    //                item.actividad,
                    //                item.desc_actividad ,
                    //                item.subactividad ,
                    //                item.desc_subactividad ,
                    //                item.ncosto_ot ,
                    //                item.vobservacion_contrata ,
                    //                item.f_alta ,
                    //                item.f_ini ,
                    //                item.f_fin,
                    //                item.f_atendido ,
                    //                item.f_res_contrata,
                    //                item.tipo_red,
                    //                item.ntip_red,
                    //                item.vdescripcion ,
                    //                item.vref_direccion,
                    //                item.vusuario ,
                    //                item.nres_contrata ,
                    //                item.ncod_cuadrilla ,
                    //                item.ncod_incidencia ,
                    //                item.ncod_factura ,
                    //                item.secs ,
                    //                item.secsfin,
                    //                item.ot_contrata ,
                    //                item.ntip_ot,
                    //                item.tipo_ot,
                    //                item.nnum_os,
                    //                oArchivo.UsuarioCarga,
                    //                DateTime.Now
                    //            });

                    //    db.ExecuteNonQuery(oCommand3, transaction);
                    //}

                    //transaction.Commit();
                    connection.Close();
                    return eEstadoTransaccion.Correctamente;
                }
                catch
                {
                    //transaction.Rollback();
                    connection.Close();
                    return eEstadoTransaccion.ErrorBaseDatos;
                }

            }
        }

        public OrdenTrabajoDTO GetOrdenTrabajoPorID(int IdOrdenTrabajo)
        {
            OrdenTrabajoDTO oOrdenTrabajo = new OrdenTrabajoDTO();
            olOrdenTrabajo = new List<OrdenTrabajoDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajoListaPorID", new object[]
                {
                    IdOrdenTrabajo                    
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    oOrdenTrabajo = new OrdenTrabajoDTO();
                    oOrdenTrabajo.IdOrdenTrabajo = Convert.ToInt32(dataReader["IdOrdenTrabajo"].ToString());
                    oOrdenTrabajo.ArchivoCargaOT =new ArchivoCargaOTDAO().GetArchivoCargaPorID(Convert.ToInt32(dataReader["IdArchivoCargaOT"].ToString()));
                    oOrdenTrabajo.os_ot = dataReader["os_ot"].ToString();
                    oOrdenTrabajo.ncod_centro = Convert.ToInt32(dataReader["ncod_centro"].ToString());
                    oOrdenTrabajo.center = dataReader["center"].ToString();
                    oOrdenTrabajo.nro_ot = dataReader["nro_ot"].ToString();
                    oOrdenTrabajo.nis_rad = dataReader["nis_rad"].ToString();
                    oOrdenTrabajo.cliente = dataReader["cliente"].ToString();
                    oOrdenTrabajo.municipio = dataReader["municipio"].ToString();
                    oOrdenTrabajo.localidad = dataReader["localidad"].ToString();
                    oOrdenTrabajo.direccion = dataReader["direccion"].ToString();
                    oOrdenTrabajo.estado = dataReader["estado"].ToString();
                    oOrdenTrabajo.nest_ot = Convert.ToInt32(dataReader["nest_ot"].ToString());
                    oOrdenTrabajo.actividad = Convert.ToInt32(dataReader["actividad"].ToString());
                    oOrdenTrabajo.desc_actividad = dataReader["desc_actividad"].ToString();
                    oOrdenTrabajo.subactividad = Convert.ToInt32(dataReader["subactividad"].ToString());
                    oOrdenTrabajo.desc_subactividad = dataReader["desc_subactividad"].ToString();
                    oOrdenTrabajo.ncosto_ot = Convert.ToDecimal(dataReader["ncosto_ot"].ToString());
                    oOrdenTrabajo.vobservacion_contrata = dataReader["vobservacion_contrata"].ToString();
                    oOrdenTrabajo.f_alta = Convert.ToDateTime(dataReader["f_alta"].ToString());
                    oOrdenTrabajo.f_ini = Convert.ToDateTime(dataReader["f_ini"].ToString());
                    oOrdenTrabajo.f_fin = Convert.ToDateTime(dataReader["f_fin"].ToString());
                    oOrdenTrabajo.f_atendido = Convert.ToDateTime(dataReader["f_atendido"].ToString());
                    oOrdenTrabajo.f_res_contrata = Convert.ToDateTime(dataReader["f_res_contrata"].ToString());
                    oOrdenTrabajo.tipo_red = dataReader["tipo_red"].ToString();
                    oOrdenTrabajo.ntip_red = Convert.ToInt32(dataReader["ntip_red"].ToString());
                    oOrdenTrabajo.vdescripcion = dataReader["vdescripcion"].ToString();
                    oOrdenTrabajo.vref_direccion = dataReader["vref_direccion"].ToString();
                    oOrdenTrabajo.vusuario = dataReader["vusuario"].ToString();
                    oOrdenTrabajo.nres_contrata = Convert.ToInt32(dataReader["nres_contrata"].ToString());
                    oOrdenTrabajo.ncod_cuadrilla = Convert.ToInt32(dataReader["ncod_cuadrilla"].ToString());
                    oOrdenTrabajo.ncod_incidencia = Convert.ToInt32(dataReader["ncod_incidencia"].ToString());
                    oOrdenTrabajo.ncod_factura = Convert.ToInt32(dataReader["ncod_factura"].ToString());
                    oOrdenTrabajo.secs = dataReader["secs"].ToString();
                    oOrdenTrabajo.secsfin = dataReader["secsfin"].ToString();
                    oOrdenTrabajo.ot_contrata = dataReader["ot_contrata"].ToString();
                    oOrdenTrabajo.ntip_ot = Convert.ToInt32(dataReader["ntip_ot"].ToString());
                    oOrdenTrabajo.tipo_ot = dataReader["tipo_ot"].ToString();
                    oOrdenTrabajo.nnum_os = Convert.ToInt32(dataReader["nnum_os"].ToString());
                    return oOrdenTrabajo;
                }
            }
            return oOrdenTrabajo;
        }


        public DataSet ObtenerDatosValidacionCABYDET(int IdObra, string NroOT)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ObtenerDatosValidacionCABYDET", new object[]
                {
                    NroOT,IdObra                    
                });

            return db.ExecuteDataSet(dbCommand);
        }

        public DataTable ObtenerDatosValidacion(int IdObra, string NroOT)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ObtenerDatosValidacion", new object[]
                {
                    NroOT,IdObra                    
                });
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            return dt;
        }

        public DataTable ObtenerDatosDetalleValidacion(int IdObra, string NroOT)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ObtenerDatosDetalleValidacion", new object[]
                {
                    NroOT,IdObra                    
                });
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            return dt;
        }

        public Boolean ObtenerValidacionOT(int IdObra, string NroOT)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_ValidarOT", new object[]
                {
                    NroOT,IdObra                    
                });
            bool resultado =Convert.ToBoolean(db.ExecuteScalar(dbCommand));
            return resultado;
        }

        
        public eResultado InsertarOrdenTrabajoSinSGI(OrdenTrabajoDTO oOrdenTrabajo,int IdObra,int Usuario){
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand oCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_InsertarSinSGI", new object[]
                                {
                                    oOrdenTrabajo.nis_rad,
                                    oOrdenTrabajo.municipio,
                                    oOrdenTrabajo.localidad,
                                    oOrdenTrabajo.direccion,
                                    oOrdenTrabajo.actividad,
                                    oOrdenTrabajo.desc_actividad ,
                                    oOrdenTrabajo.subactividad ,
                                    oOrdenTrabajo.desc_subactividad ,
                                    oOrdenTrabajo.f_alta ,
                                    oOrdenTrabajo.vdescripcion ,
                                    Usuario,
                                    DateTime.Now,
                                    IdObra,
                                    oOrdenTrabajo.cliente,
                                    oOrdenTrabajo.TipoTrabajo.IdGenerica,
                            
                                });

                        db.ExecuteNonQuery(oCommand);
            }
            return eResultado.Correcto;
        }

        public eResultado ActualizarOrdenTrabajoSinSGI(EjecucionOTDTO oEjecucionOT,int Usuario){
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                DbCommand oCommand = db.GetStoredProcCommand("PRO_OrdenTrabajo_UpdateSinSGIO", new object[]
                                {
                                    oEjecucionOT.OrdenTrabajo.IdOrdenTrabajo,
                                    oEjecucionOT.IdEjecucionOT,
                                    oEjecucionOT.OrdenTrabajo.nro_ot,
                                    oEjecucionOT.OrdenTrabajo.nis_rad,
                                    oEjecucionOT.OrdenTrabajo.municipio,
                                    oEjecucionOT.OrdenTrabajo.localidad,
                                    oEjecucionOT.OrdenTrabajo.direccion,
                                    oEjecucionOT.OrdenTrabajo.actividad,
                                    oEjecucionOT.OrdenTrabajo.desc_actividad ,
                                    oEjecucionOT.OrdenTrabajo.subactividad ,
                                    oEjecucionOT.OrdenTrabajo.desc_subactividad ,
                                    oEjecucionOT.OrdenTrabajo.f_alta ,
                                    oEjecucionOT.Observacion ,
                                    Usuario,
                                    DateTime.Now,oEjecucionOT.OrdenTrabajo.cliente,oEjecucionOT.OrdenTrabajo.TipoTrabajo.IdGenerica
                                });

                        db.ExecuteNonQuery(oCommand);
            }
            return eResultado.Correcto;
        }

    }
}
