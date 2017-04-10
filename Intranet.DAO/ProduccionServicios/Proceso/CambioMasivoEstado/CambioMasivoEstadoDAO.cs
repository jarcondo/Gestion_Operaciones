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
    public class CambioMasivoEstadoDAO
    {

        public List<DatosSGIEstadoDTO> ListarSgiArchivoTexto(int IdObra ,int IdEstadoOT)
        {
            try
            {
                List<DatosSGIEstadoDTO> oListaSgiArchivoTexto = new List< DatosSGIEstadoDTO>();
                DatosSGIEstadoDTO oDatosSGIEstadoDTO = new DatosSGIEstadoDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_CambioMasivoEstadoListarTXT",
                    new object[]
                {
                    IdObra,IdEstadoOT,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                         oDatosSGIEstadoDTO = new DatosSGIEstadoDTO();
                         oDatosSGIEstadoDTO.SGI = dataReader["Sgi"].ToString();
                         oDatosSGIEstadoDTO.DescripcionEstadoActual = dataReader["EstadoActual"].ToString();
                         oDatosSGIEstadoDTO.DescripcionEstadoCambio = dataReader["EstadoCambio"].ToString();
                         oDatosSGIEstadoDTO.Observacion = dataReader["Observacion"].ToString();
                         oDatosSGIEstadoDTO.Situacion = Convert.ToInt32(dataReader["Situacion"].ToString());
                         oListaSgiArchivoTexto.Add(oDatosSGIEstadoDTO);
                    }
                }
                return oListaSgiArchivoTexto;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<DatosSGIEstadoDTO>();
            }
        }



        public eEstadoTransaccion CambioMasivoEstadoUpdate(int IdObra , int IdEstado ,int IdUsuario )
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();

                DbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                try
                {

                    DbCommand Command = db.GetStoredProcCommand("Pro_CambioMasivoEstadoUpdate",
                            new object[]
                        {
                            IdObra,
                            IdEstado,
                            IdUsuario,
                        });

                    db.ExecuteNonQuery(Command, transaction);
                    transaction.Commit();
                    connection.Close();
                    return eEstadoTransaccion.Correctamente;

                }
                catch
                {
                    transaction.Rollback();
                    connection.Close();
                    return eEstadoTransaccion.ErrorBaseDatos;
                }

            }

        }




    }
}
