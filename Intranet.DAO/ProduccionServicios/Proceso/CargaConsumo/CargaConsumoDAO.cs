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
using System.Data.SqlClient;
using System.Configuration;
namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class CargaConsumoDAO
    {


        public void CargarConsumoCliente(string rutaCabecera, string rutaDetalle, ref DataTable datosgrilla, ref DataTable cab, ref DataTable det, ref string Mensaje
            , int CentroServicio, int nroContrato, string EstadoCarga, Int32 IdObra, int usuario)
        {

            #region  Cabecera

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




            DataTable dt = null;
            OleDbConnection objConn = null;
            DataSet ds = new DataSet();
            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + rutaCabecera + ";Extended Properties=Excel 8.0;";
            objConn = new OleDbConnection(connString);
            objConn.Open();
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return;
            }
            String[] excelSheets = new String[dt.Rows.Count];
            int i = 0;
            excelSheets[i] = dt.Rows[0].Table.TableName.ToString();
            DataRow row = dt.Rows[i];
            excelSheets[i] = row["TABLE_NAME"].ToString();
            OleDbCommand cmdCab = new OleDbCommand("SELECT os_ot,ncod_centro,center,nro_ot,nis_rad,f_alta,f_atendido,secs,estado,nest_ot,actividad,"+
                                                    "desc_actividad,subactividad,desc_subactividad,ncosto_ot,nres_contrata,contratista,municipio,"+
                                                    "localidad,direccion,cliente,tipo_red,ntip_red,f_ini,f_fin,f_res_contrata,secsfin,vobservacion_contrata,"+
                                                    "vdescripcion,vusuario,ncod_cuadrilla,cuadrilla,ncod_incidencia,ncod_factura,ot_contrata,ntip_ot,tipo_ot,"+
                                                    "nnum_os,cod_lotep"+
                                                    "  FROM [" + excelSheets[i] + "]", objConn);
            OleDbDataAdapter oledacab = new OleDbDataAdapter();
            oledacab.SelectCommand = cmdCab;
            oledacab.Fill(ds, "TABLE");
            // valido que no existan datos diferentes al centro de servicio y nrocontrato
            IEnumerable<DataRow> query = (from campo in ds.Tables["TABLE"].AsEnumerable()
                                          where campo["estado"].ToString().Trim().ToUpper() == EstadoCarga
                                          select campo);
            // solo los registro segun  el ESTADOCARGA.
            IEnumerable<DataRow> query2 = (from campo in ds.Tables["TABLE"].AsEnumerable()
                                           where Convert.ToDecimal(campo["ncod_centro"].ToString()) != Convert.ToDecimal(CentroServicio) ||
                                           Convert.ToDecimal(campo["nres_contrata"].ToString()) != Convert.ToDecimal(nroContrato) &&
                                           Convert.ToDecimal(campo["nres_contrata"].ToString()) != Convert.ToDecimal(nroContrato2)
                                           select campo);
            if (query2.Count() > 0)
            {
                Mensaje = "EXISTEN INCONSISTENCIAS EN EL ARCHIVO CARGADO. LA INFORMACIÓN NO CORRESPONDE AL CENTRO DE COSTO NI AL CONTRATO REQUERIDO. ITEM:";
                return;
            }
            DataTable oDataTableFiltro = query.CopyToDataTable<DataRow>();
            char[] valores = { '<', '>', '=', '+', '*' }; //,'/','-'};
            foreach (char item in valores)
            {
                oDataTableFiltro.Rows.ToString().Replace(item, ' ');
            }

            oDataTableFiltro.Columns.Add("tieneDetalle", typeof(int));
            oDataTableFiltro.Columns.Add("EXISTE", typeof(int));

            #endregion


            #region Cargo Detalle

            ds = new DataSet();
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + rutaDetalle + ";Extended Properties=Excel 8.0;";
            objConn = new OleDbConnection(connString);
            objConn.Open();
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return;
            }
            row = dt.Rows[i];
            excelSheets = new String[dt.Rows.Count];
            i = 0;
            excelSheets[i] = row["TABLE_NAME"].ToString();
            OleDbCommand cmd = new OleDbCommand("SELECT ncod_centro,center,nro_ot,ncod_actividad,ncod_sub_act,cantidad,ncod_material,ncantidad,estado "+
                                                " FROM [" + excelSheets[i] + "]", objConn);
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            oleda.SelectCommand = cmd;
            oleda.Fill(ds, "TABLE");
            IEnumerable<DataRow> queryd = (from campo in ds.Tables["TABLE"].AsEnumerable()
                                           where campo["estado"].ToString().Trim().ToUpper() == EstadoCarga
                                           select campo);
            DataTable oDataTableFiltroD = queryd.CopyToDataTable<DataRow>();

            DataTable oDataTabledetallejoin = new DataTable();

            //CORRECTIVO

            //if (IdObra != 40  && IdObra != 39)
            //{
            //    IEnumerable<DataRow> tmpdjoin;
            //    tmpdjoin = (from detjoin in oDataTableFiltroD.AsEnumerable()
            //                                     join cabjoin in oDataTableFiltro.AsEnumerable()
            //                                     on detjoin.Field<double>("nro_ot") equals cabjoin.Field<double>("nro_ot")
            
            //                select detjoin);

            //    oDataTabledetallejoin = tmpdjoin.CopyToDataTable<DataRow>();
                
            //}

           // if (IdObra == 40 || IdObra == 39) //cambiar se puso por mientras... 
           // {

                IEnumerable<DataRow> tmpdjoin;

                //PREVENTIVO
               tmpdjoin = (from detjoin in oDataTableFiltroD.AsEnumerable()
                                                 join cabjoin in oDataTableFiltro.AsEnumerable()
                                                 on detjoin.Field<double>("nro_ot") equals cabjoin.Field<double>("nro_ot")
                                                 into cabdet
                                                 from item in cabdet.DefaultIfEmpty()
                                                 select detjoin);
                oDataTabledetallejoin = tmpdjoin.CopyToDataTable<DataRow>();
           // }

            

            

            #endregion

            DataSet datasetdatos = new DataSet();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PRO_CargarConsumoCliente_datatable";
                sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                sqlCommand.Parameters.Add("CABECERA_OPEN", SqlDbType.Structured).Value = oDataTableFiltro;
                sqlCommand.Parameters.Add("DETALLE_OPEN", SqlDbType.Structured).Value = oDataTabledetallejoin;
                Database db = DatabaseFactory.CreateDatabase();
                sqlCommand.CommandTimeout = 0;
                datasetdatos = db.ExecuteDataSet(sqlCommand);
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                Mensaje = ex.Message;
                datosgrilla = new DataTable();
                cab = new DataTable();
                det = new DataTable();
            }

            datosgrilla = datasetdatos.Tables[0];
            cab = datasetdatos.Tables[1];
            
            /*
            cab.Columns.Remove("tieneDetalle");
            cab.Columns.Remove("EXISTE");

            cab.Columns["tieneDetalle1"].ColumnName = "tieneDetalle";
            cab.Columns["EXISTE1"].ColumnName = "EXISTE";
            
            */

            det = oDataTabledetallejoin;





        }

        public List<DetalleConsumoDTO> CargarConsumoCliente(string rutaCabecera, string rutaDetalle, ref List<CabeceraConsumoDTO> olCabecera, ref string Mensaje, int CentroServicio, int nroContrato, string EstadoCarga,
            Int32 IdObra, ref List<CabeceraConsumoDTO> olCabecerasActualizar, ref List<CabeceraConsumoDTO> olCabecerasInsertar)
        {
            try
            {
                CabeceraConsumoDTO oCabecera = new CabeceraConsumoDTO();
                List<DetalleConsumoDTO> olDetalle = new List<DetalleConsumoDTO>();
                DetalleConsumoDTO oDetalle = new DetalleConsumoDTO();
                DataTable dt = null;
                OleDbConnection objConn = null;
                try
                {
                    #region Cargo Cabecera


                    DataSet ds = new DataSet();
                    String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + rutaCabecera + ";Extended Properties=Excel 8.0;";
                    objConn = new OleDbConnection(connString);
                    objConn.Open();
                    dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }
                    String[] excelSheets = new String[dt.Rows.Count];
                    int i = 0;
                    excelSheets[i] = dt.Rows[0].Table.TableName.ToString();
                    DataRow row = dt.Rows[i];
                    excelSheets[i] = row["TABLE_NAME"].ToString();

                    OleDbCommand cmdCab = new OleDbCommand("SELECT * FROM [" + excelSheets[i] + "]", objConn);
                    OleDbDataAdapter oledacab = new OleDbDataAdapter();
                    oledacab.SelectCommand = cmdCab;
                    oledacab.Fill(ds, "TABLE");

                    int II = 0;


                    // valido que no existan datos diferentes al centro de servicio y nrocontrato

                    IEnumerable<DataRow> query = (from campo in ds.Tables["TABLE"].AsEnumerable()
                                                  where campo[9].ToString().Trim().ToUpper() == EstadoCarga
                                                  select campo);




                    // solo los registro segun  el ESTADOCARGA.
                    IEnumerable<DataRow> query2 = (from campo in ds.Tables["TABLE"].AsEnumerable()
                                                   where Convert.ToDecimal(campo[1].ToString()) != Convert.ToDecimal(CentroServicio) &&
                                                   Convert.ToDecimal(campo[27].ToString()) != Convert.ToDecimal(nroContrato)
                                                   select campo);

                    if (query2.Count() > 0)
                    {
                        Mensaje = "EXISTEN INCONSISTENCIAS EN EL ARCHIVO CARGADO. LA INFORMACIÓN NO CORRESPONDE AL CENTRO DE COSTO NI AL CONTRATO REQUERIDO. ITEM:" + II.ToString();
                        olCabecera = new List<CabeceraConsumoDTO>();
                        olDetalle = new List<DetalleConsumoDTO>();
                        return olDetalle;
                    }


                    DataTable oDataTableFiltro = query.CopyToDataTable<DataRow>();
                    char[] valores = { '<', '>', '=', '+', '*' }; //,'/','-'};
                    foreach (char item in valores)
                    {
                        oDataTableFiltro.Rows.ToString().Replace(item, ' ');
                    }

                    #endregion

                    #region Cargo Detalle

                    olDetalle = new List<DetalleConsumoDTO>();
                    ds = new DataSet();
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + rutaDetalle + ";Extended Properties=Excel 8.0;";
                    objConn = new OleDbConnection(connString);
                    objConn.Open();

                    dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }
                    row = dt.Rows[i];

                    excelSheets = new String[dt.Rows.Count];
                    i = 0;

                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + excelSheets[i] + "]", objConn);
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    oleda.Fill(ds, "TABLE");

                    foreach (DataRow row2 in ds.Tables["TABLE"].Rows) { }

                    IEnumerable<DataRow> queryd = (from campo in ds.Tables["TABLE"].AsEnumerable()
                                                   where campo[8].ToString().Trim().ToUpper() == EstadoCarga
                                                   select campo);
                    DataTable oDataTableFiltroD = queryd.CopyToDataTable<DataRow>();

                    #endregion



                    foreach (DataRow fila in oDataTableFiltro.Rows)
                    {
                        try
                        {

                            oCabecera = new CabeceraConsumoDTO();
                            oCabecera.os_ot = fila[0].ToString();
                            oCabecera.ncod_centro = Convert.ToInt32(fila[1].ToString());
                            oCabecera.center = fila[2].ToString();
                            oCabecera.nro_ot = fila[3].ToString();
                            oCabecera.nis_rad = fila[4].ToString();
                            oCabecera.cliente = fila[5].ToString();
                            oCabecera.municipio = fila[6].ToString();
                            oCabecera.localidad = fila[7].ToString();
                            oCabecera.direccion = fila[8].ToString();
                            oCabecera.estado = fila[9].ToString();
                            oCabecera.nest_ot = Convert.ToInt32(fila[10].ToString());
                            oCabecera.actividad = Convert.ToInt32(fila[11].ToString());
                            oCabecera.desc_actividad = fila[12].ToString();
                            oCabecera.subactividad = Convert.ToInt32(fila[13].ToString());
                            oCabecera.desc_subactividad = fila[14].ToString();
                            oCabecera.ncosto_ot = Convert.ToDecimal(fila[15].ToString());
                            oCabecera.vobservacion_contrata = fila[16].ToString();
                            oCabecera.f_alta = Convert.ToDateTime(fila[17].ToString());
                            oCabecera.f_ini = Convert.ToDateTime(fila[18].ToString());
                            oCabecera.f_fin = Convert.ToDateTime(fila[19].ToString());
                            oCabecera.f_atendido = Convert.ToDateTime(fila[20].ToString());
                            oCabecera.f_res_contrata = Convert.ToDateTime(fila[21].ToString());
                            oCabecera.tipo_red = fila[22].ToString();
                            oCabecera.ntip_red = Convert.ToInt32(fila[23].ToString());

                            oCabecera.vdescripcion = fila[24].ToString();

                            oCabecera.vref_direccion = fila[25].ToString();
                            oCabecera.vusuario = fila[26].ToString();
                            oCabecera.nres_contrata = Convert.ToInt32(fila[27].ToString());
                            oCabecera.ncod_cuadrilla = Convert.ToInt32(fila[28].ToString());
                            oCabecera.ncod_incidencia = Convert.ToInt32(fila[29].ToString());
                            oCabecera.ncod_factura = Convert.ToInt32(fila[30].ToString());
                            oCabecera.secs = fila[31].ToString();
                            oCabecera.secsfin = fila[32].ToString();
                            oCabecera.ot_contrata = fila[33].ToString();
                            oCabecera.ntip_ot = Convert.ToInt32(fila[34].ToString());
                            oCabecera.tipo_ot = fila[35].ToString();
                            oCabecera.nnum_os = Convert.ToInt32(fila[36].ToString());

                            //detalle------------------------------------------------------------------------------


                            IEnumerable<DataRow> query1detalle = (from campo in oDataTableFiltroD.AsEnumerable()
                                                                  where campo[8].ToString().Trim().ToUpper() == EstadoCarga &&
                                                                  campo[2].ToString().Trim() == fila[3].ToString()
                                                                  select campo);

                            if (query1detalle.Count() > 0)
                            {
                                DataTable table1detalle = query1detalle.CopyToDataTable<DataRow>();

                                foreach (DataRow filadetalle in table1detalle.Rows)
                                {

                                    oDetalle = new DetalleConsumoDTO();
                                    oDetalle.ncod_centro = Convert.ToInt32(filadetalle[0].ToString());
                                    oDetalle.center = filadetalle[1].ToString();
                                    oDetalle.nro_ot = filadetalle[2].ToString();
                                    oDetalle.ncod_actividad = Convert.ToInt32(filadetalle[3].ToString());
                                    oDetalle.ncod_sub_act = Convert.ToInt32(filadetalle[4].ToString());
                                    oDetalle.cantidad = Convert.ToDecimal(filadetalle[5].ToString());
                                    oDetalle.ncod_material = Convert.ToInt32(filadetalle[6].ToString());
                                    oDetalle.ncantidad = Convert.ToDecimal(filadetalle[7].ToString());
                                    oDetalle.estado = filadetalle[8].ToString();
                                }
                                olDetalle.Add(oDetalle);
                            }
                            //------------------------------------------------------------------


                            #region Observaciones

                            DataSet oDataSetVal = new OrdenTrabajoDAO().ObtenerDatosValidacionCABYDET(IdObra, fila[3].ToString());
                            string mensaje = "<ul style='color:red;'>";
                            DataTable dtobs = oDataSetVal.Tables[0];
                            if (dtobs.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtobs.Rows[0][7].ToString()) > 0)
                                {
                                    mensaje += "<li>La O/T ya fue cargada al sistema";
                                    oCabecera.existe = true;
                                }
                                else
                                {
                                    oCabecera.existe = false;
                                }


                                if (dtobs.Rows[0][2].ToString().Trim() != oCabecera.nest_ot.ToString().Trim())
                                    mensaje += "<li>Estado de O/T no actualizado en seguimiento</li>";

                                if (dtobs.Rows[0][3].ToString().Trim() != oCabecera.municipio.ToString().Trim())
                                    mensaje += "<li>Distrito de O/T no actualizado en seguimiento</li>";

                                if (dtobs.Rows[0][5].ToString().Trim() != oCabecera.direccion.ToString().Trim())
                                    mensaje += "<li>Dirección de O/T no actualizada en seguimiento</li>";

                                if (Convert.ToDateTime(dtobs.Rows[0][6]).ToShortDateString() != oCabecera.f_alta.ToShortDateString())
                                    mensaje += "<li>Fecha de Alta de O/T no actualizada en seguimiento</li>";


                                DataTable dt2 = oDataSetVal.Tables[1];

                                if (dt2.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt2.Rows)
                                    {
                                        if (dr[1].ToString().Trim() != "7")
                                        {
                                            mensaje += "<li>Estado de T/C no actualizado en seguimiento</li>";
                                            continue;
                                        }
                                    }
                                }
                                else
                                    mensaje += "<li>La O/T no presenta T/C en seguimiento</li>";
                            }
                            else
                            {
                                mensaje += "<li>La O/T no registra seguimiento.</li>";

                                if (oCabecera.existe == true)
                                {
                                    mensaje += "<li>La O/T ya fue cargada al sistema";
                                    //olCabecerasActualizar.Add(item);
                                }
                                //else
                                olCabecerasInsertar.Add(oCabecera);
                            }
                            mensaje += "</ul>";
                            oCabecera.observaciones = mensaje;

                            #endregion


                            olCabecera.Add(oCabecera);
                        }
                        catch (Exception ex)
                        {

                            new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                            olCabecera = new List<CabeceraConsumoDTO>();
                            olDetalle = new List<DetalleConsumoDTO>();
                            return olDetalle;
                        }


                    }
                    return olDetalle;
                }
                catch (Exception ex)
                {
                    new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                    Mensaje = ex.Message;
                    olCabecera = new List<CabeceraConsumoDTO>();
                    olDetalle = new List<DetalleConsumoDTO>();
                    return olDetalle;
                }

            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                olCabecera = new List<CabeceraConsumoDTO>();
                return new List<DetalleConsumoDTO>();
            }
        }

        public eEstadoTransaccion CargarConsumoServidor(int IdObra, int UsuarioCrea, DataTable olCabeceraInsertar, DataTable olDetalleInsertar)
        {

            try
            {

                if (IdObra==21)
                {

                    for (int i = 0; i < olCabeceraInsertar.Rows.Count; i++)
                    {
                        if (olCabeceraInsertar.Rows[i]["nres_contrata"].ToString() == "27")
                        {
                            olCabeceraInsertar.Rows[i]["nres_contrata"] = "29";
                        }
                        
                    }
                    
                     
                }

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PRO_Cabecera_detalle_Insertar_datatable";
                sqlCommand.Parameters.Add("IdObra", SqlDbType.Int).Value = IdObra;
                sqlCommand.Parameters.Add("usuariocrea", SqlDbType.Int).Value = UsuarioCrea;
                sqlCommand.Parameters.Add("CABECERA_OPEN", SqlDbType.Structured).Value = olCabeceraInsertar;
                sqlCommand.Parameters.Add("DETALLE_OPEN", SqlDbType.Structured).Value = olDetalleInsertar;



                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    //DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);



                    try
                    {
                        sqlCommand.CommandTimeout = 0;

                        //int result = db.ExecuteNonQuery(sqlCommand, transaction);

                      //  transaction.Commit();
                        int result = db.ExecuteNonQuery(sqlCommand);

                        //connection.Close();



                    }
                    catch (Exception ex)
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                        //transaction.Rollback();
                        connection.Close();
                        return eEstadoTransaccion.ErrorBaseDatos;
                    }

                }

            }
            catch (Exception ex)
            {
                //new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                //transaction.Rollback();
                //connection.Close();
                return eEstadoTransaccion.ErrorBaseDatos;

            }

            return eEstadoTransaccion.Correctamente;
        }

        public eEstadoTransaccion CargarConsumoServidor(int IdObra, int UsuarioCrea, List<CabeceraConsumoDTO> olCabeceraInsertar, List<CabeceraConsumoDTO> olCabeceraActualizar, List<DetalleConsumoDTO> olDetalleInsertar)
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);



                    try
                    {
                        foreach (var item in olCabeceraInsertar)
                        {
                            bool tieneDetalle;
                            if (olDetalleInsertar.Where(x => x.nro_ot == item.nro_ot).ToList().Count > 0)
                                tieneDetalle = true;
                            else
                                tieneDetalle = false;
                            try
                            {
                                DbCommand oCommand = db.GetStoredProcCommand("PRO_Cabecera_Insertar",
                                new object[]
                            {
                                IdObra,
                                item.nro_ot.Trim(),
                                item.nis_rad.Trim(),
                                item.cliente.Trim() ,
                                item.municipio.Trim(),
                                item.localidad.Trim(),
                                item.direccion.Trim(),
                                item.nest_ot,
                                item.actividad,
                                item.subactividad,
                                UsuarioCrea,
                                DateTime.Now,
                                item.ncosto_ot,
                                tieneDetalle,
                                Convert.ToInt32(item.ot_contrata)
                            });
                                db.ExecuteNonQuery(oCommand, transaction);
                            }
                            catch (Exception ex)
                            {
                                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                                transaction.Rollback();
                                connection.Close();
                                return eEstadoTransaccion.ErrorBaseDatos;
                            }

                        }



                        foreach (var item in olDetalleInsertar)
                        {
                            try
                            {
                                List<CabeceraConsumoDTO> olbus = new List<CabeceraConsumoDTO>();
                                olbus = olCabeceraInsertar.Where(x => x.nro_ot == item.nro_ot).ToList();
                                if (olbus.Count > 0)
                                {
                                    DbCommand oCommand = db.GetStoredProcCommand("PRO_Detalle_Insertar",
                                    new object[]
                                    {
                                        IdObra,
                                        item.nro_ot,
                                        item.ncod_actividad,
                                        item.ncod_sub_act,
                                        item.cantidad,
                                        item.ncod_material,
                                        item.ncantidad,
                                        UsuarioCrea,
                                        DateTime.Now,
                                    });
                                    db.ExecuteNonQuery(oCommand, transaction);
                                }
                            }
                            catch (Exception ex)
                            {
                                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                                transaction.Rollback();
                                connection.Close();
                                return eEstadoTransaccion.ErrorBaseDatos;

                            }


                        }

                        transaction.Commit();
                        connection.Close();
                        return eEstadoTransaccion.Correctamente;
                    }
                    catch (Exception ex)
                    {
                        new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                        transaction.Rollback();
                        connection.Close();
                        return eEstadoTransaccion.ErrorBaseDatos;
                    }

                }
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eEstadoTransaccion.ErrorBaseDatos;
            }
        }
    }
}
