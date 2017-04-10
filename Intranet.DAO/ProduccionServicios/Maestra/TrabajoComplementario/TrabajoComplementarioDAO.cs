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
using Intranet.DTO.ProduccionServicios.Maestras;

namespace Intranet.DAO.ProduccionServicios.Maestra
{
    public class TrabajoComplementarioDAO
    {
        public List<TrabajoComplementarioDTO> GetTrabajoComplementarioPorBase(int IdBase)
        {
            olTrabajo = new List<TrabajoComplementarioDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioListarPorBase", new object[]
                {
                    IdBase                    
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    TrabajoComplementarioDTO oTrabajo = new TrabajoComplementarioDTO();
                    oTrabajo.IdTrabajoComplementario = Convert.ToInt32(dataReader["IdTrabajoComplementario"].ToString());
                    oTrabajo.CodigoTrabajoComplementario = dataReader["CodigoTrabajoComplementario"].ToString();
                    oTrabajo.CodMap = dataReader["CodMap"].ToString();
                    oTrabajo.Descripcion = dataReader["Descripcion"].ToString();
                    oTrabajo.Unidad = dataReader["Unidad"].ToString().ToUpper();
                    oTrabajo.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    //oTrabajo.Activo = Convert.ToBoolean(dataReader["Activo"].ToString());
                    oTrabajo.Observacion = dataReader["Observacion"].ToString();
                    oTrabajo.Obra = new ObraDAO().GetObraId(Convert.ToInt32(dataReader["IdObra"].ToString()));
                    olTrabajo.Add(oTrabajo);
                }
            }
            return olTrabajo;
        }

        List<TrabajoComplementarioDTO> olTrabajo = new List<TrabajoComplementarioDTO>();
        public List<TrabajoComplementarioDTO> GetTrabajoComplementarioPorObra(int IdObra)
        {
            olTrabajo = new List<TrabajoComplementarioDTO>();

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioListarPorObra", new object[]
                {
                    IdObra                    
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    TrabajoComplementarioDTO oTrabajo = new TrabajoComplementarioDTO();
                    oTrabajo.IdTrabajoComplementario=Convert.ToInt32(dataReader["IdTrabajoComplementario"].ToString());
                    oTrabajo.CodigoTrabajoComplementario = dataReader["CodigoTrabajoComplementario"].ToString();
                    oTrabajo.CodMap = dataReader["CodMap"].ToString();
                    oTrabajo.Descripcion = dataReader["Descripcion"].ToString();
                    oTrabajo.Unidad = dataReader["Unidad"].ToString();
                    oTrabajo.CostoProgramado =Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    //oTrabajo.Activo = Convert.ToBoolean(dataReader["Activo"].ToString());
                    oTrabajo.Observacion = dataReader["Observacion"].ToString();
                    oTrabajo.Obra = new ObraDAO().GetObraId(Convert.ToInt32(dataReader["IdObra"].ToString()));
                    olTrabajo.Add(oTrabajo);
                }
            }

            return olTrabajo;
        }
        
        public List<TrabajoComplementarioDTO> GetTrabajoComplementario()
        {
            olTrabajo = new List<TrabajoComplementarioDTO>();

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioListar");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    TrabajoComplementarioDTO oTrabajo = new TrabajoComplementarioDTO();
                    oTrabajo.IdTrabajoComplementario=Convert.ToInt32(dataReader["IdTrabajoComplementario"].ToString());
                    oTrabajo.CodigoTrabajoComplementario = dataReader["CodigoTrabajoComplementario"].ToString();
                    oTrabajo.CodMap = dataReader["CodMap"].ToString();
                    oTrabajo.Descripcion = dataReader["Descripcion"].ToString();
                    oTrabajo.Unidad = dataReader["Unidad"].ToString();
                    oTrabajo.CostoProgramado =Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    //oTrabajo.Activo = Convert.ToBoolean(dataReader["Activo"].ToString());
                    oTrabajo.Observacion = dataReader["Observacion"].ToString();
                    oTrabajo.Obra = new ObraDAO().GetObraId(Convert.ToInt32(dataReader["IdObra"].ToString()));
                    olTrabajo.Add(oTrabajo);
                }
            }

            return olTrabajo;
        }

        public TrabajoComplementarioDTO GetTrabajoComplementarioPorID(int IdTrabajoComplementario)
        {
            TrabajoComplementarioDTO oTrabajo = new TrabajoComplementarioDTO();

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioListarPorID", new object[]
                {
                    IdTrabajoComplementario                    
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    oTrabajo = new TrabajoComplementarioDTO();
                    oTrabajo.IdTrabajoComplementario = Convert.ToInt32(dataReader["IdTrabajoComplementario"].ToString());
                    oTrabajo.CodigoTrabajoComplementario = dataReader["CodigoTrabajoComplementario"].ToString();
                    oTrabajo.CodMap = dataReader["CodMap"].ToString();
                    oTrabajo.Descripcion = dataReader["Descripcion"].ToString();
                    oTrabajo.Unidad = dataReader["Unidad"].ToString();
                    oTrabajo.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    //oTrabajo.Activo = Convert.ToBoolean(dataReader["Activo"].ToString());
                    oTrabajo.Observacion = dataReader["Observacion"].ToString();
                    oTrabajo.Obra = new ObraDAO().GetObraId(Convert.ToInt32(dataReader["IdObra"].ToString()));
                }
            }

            return oTrabajo;
        }

        public eResultado InsertarTrabajoComplementario(TrabajoComplementarioDTO oTrabajo,int idusuario)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioInsertar",
                new object[]
                {
                    oTrabajo.CodigoTrabajoComplementario 
                    ,oTrabajo.CodMap 
                    ,oTrabajo.Descripcion 
                    ,oTrabajo.Unidad 
                    ,oTrabajo.CostoProgramado 
                    ,oTrabajo.Observacion 
                    ,oTrabajo.Obra.IdObra
                    ,idusuario
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

        public eResultado UpdateTrabajoComplementario(TrabajoComplementarioDTO oTrabajo, int idusuario)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioActualizar",
                new object[]
                {
                    oTrabajo.IdTrabajoComplementario
                    ,oTrabajo.CodMap
                    ,oTrabajo.Descripcion 
                    ,oTrabajo.Unidad
                    ,oTrabajo.CostoProgramado
                    ,oTrabajo.Observacion 
                    ,oTrabajo.Obra.IdObra ,idusuario
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

        public eResultado ElimnarTrabajoComplementario(int IdTrabajoComplementario,int idusuario)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TrabajoComplementarioDelete",
                new object[]
                {
                   IdTrabajoComplementario,idusuario
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


    }
}
