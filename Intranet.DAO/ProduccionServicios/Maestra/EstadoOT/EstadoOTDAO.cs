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

namespace Intranet.DAO.ProduccionServicios.Maestra
{
    public class EstadoOTDAO
    {
        public List<EstadoOTDTO> ListarEstadoOT()
        {
            List<EstadoOTDTO> oListaEstadoOT = new List<EstadoOTDTO>();
            EstadoOTDTO oEstadoOT = new EstadoOTDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_EstadoOTListar");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oEstadoOT = new EstadoOTDTO();
                    oEstadoOT.IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"]);
                    oEstadoOT.CodigoEstadoOT = dataReader["CodigoEstadoOT"].ToString();
                    oEstadoOT.DescripcionEstado = dataReader["DescripcionEstado"].ToString();
                    oListaEstadoOT.Add(oEstadoOT);
                }
            }
            return oListaEstadoOT;
        }

        public eResultado ElimnarEstadoOT(string CodigoEstadoOT)
        {
     
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_EstadoOTEliminar",
                new object[]
                {
                   CodigoEstadoOT
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

        public eResultado InsertarEstadoOT(string CodigoEstadoOT, string DescripcionEstadoOT ,int IdUsuario)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_EstadoOTInsert",
                new object[]
                {
                   CodigoEstadoOT, DescripcionEstadoOT,IdUsuario
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

        public eResultado UpdateEstadoOT(string CodigoEstadoOT, string DescripcionEstadoOT, int IdUsuario)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_EstadoOTUpdate",
                new object[]
                {
                   CodigoEstadoOT, DescripcionEstadoOT,IdUsuario
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

        public List<EstadoOTDTO> ListarEstadoOTTodos()
        {
            List<EstadoOTDTO> oListaEstadoOT = new List<EstadoOTDTO>();
            EstadoOTDTO oEstadoOT = new EstadoOTDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_EstadoOTListarTodos");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oEstadoOT = new EstadoOTDTO();
                    oEstadoOT.IdEstadoOT = Convert.ToInt32(dataReader["IdEstadoOT"]);
                    oEstadoOT.CodigoEstadoOT = dataReader["CodigoEstadoOT"].ToString();
                    oEstadoOT.DescripcionEstado = dataReader["DescripcionEstado"].ToString();
                    oListaEstadoOT.Add(oEstadoOT);
                }
            }
            return oListaEstadoOT;
        }
    }
}
