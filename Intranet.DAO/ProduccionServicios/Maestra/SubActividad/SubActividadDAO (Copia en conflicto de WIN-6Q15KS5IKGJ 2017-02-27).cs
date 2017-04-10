using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.Global;

namespace Intranet.DAO.ProduccionServicios.Maestra
{
    public class SubActividadDAO
    {
        public List<SubActividadDTO> ObtenerSubActividad(int IdObra,int IdActividad)
        {
            List<SubActividadDTO> olSubAct = new List<SubActividadDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_Listar", new object[]
                {
                    IdObra,
                    IdActividad
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    SubActividadDTO oSubAct = new SubActividadDTO();
                    oSubAct.IdSubActividad = Convert.ToInt32(dataReader["IdSubActividad"].ToString());
                    oSubAct.CodigoSubActividad = dataReader["CodigoSubActividad"].ToString();
                    oSubAct.CodMap = Convert.ToInt32(dataReader["CodMap"].ToString());
                    oSubAct.DescripcionSubActividad1 = dataReader["DescripcionSubActividad1"].ToString();
                    oSubAct.DescripcionSubActividad2 = dataReader["DescripcionSubActividad2"].ToString();
                    oSubAct.Unidad = dataReader["Unidad"].ToString();
                    oSubAct.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    oSubAct.Puntaje = Convert.ToDecimal(dataReader["Puntaje"].ToString());
                    oSubAct.Observacion = dataReader["Observacion"].ToString();
                    oSubAct.TrabajoComplementario = Convert.ToBoolean(dataReader["TrabajoComplementario"].ToString());
                    oSubAct.Resane = Convert.ToBoolean(dataReader["Resane"].ToString());
                    olSubAct.Add(oSubAct);
                }
            }

            return olSubAct;
        }

        public List<SubActividadDTO> ObtenerSubActividadCreacion(int IdObra, int CodMapActividad)
        {
            List<SubActividadDTO> olSubAct = new List<SubActividadDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_ListarCreacion", new object[]
                {
                    IdObra,
                    CodMapActividad
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    SubActividadDTO oSubAct = new SubActividadDTO();
                    oSubAct.IdSubActividad = Convert.ToInt32(dataReader["IdSubActividad"].ToString());
                    oSubAct.CodigoSubActividad = dataReader["CodigoSubActividad"].ToString();
                    oSubAct.CodMap = Convert.ToInt32(dataReader["CodMap"].ToString());
                    oSubAct.DescripcionSubActividad1 = dataReader["DescripcionSubActividad1"].ToString();
                    oSubAct.DescripcionSubActividad2 = dataReader["DescripcionSubActividad2"].ToString();
                    oSubAct.Unidad = dataReader["Unidad"].ToString();
                    oSubAct.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    oSubAct.Puntaje = Convert.ToDecimal(dataReader["Puntaje"].ToString());
                    oSubAct.Observacion = dataReader["Observacion"].ToString();
                    oSubAct.TrabajoComplementario = Convert.ToBoolean(dataReader["TrabajoComplementario"].ToString());
                    oSubAct.Resane = Convert.ToBoolean(dataReader["Resane"].ToString());
                    olSubAct.Add(oSubAct);
                }
            }

            return olSubAct;
        }

        public SubActividadDTO ListarSubActividadPorID(int IdSubActividad)
        {
            SubActividadDTO oSubActividad = new SubActividadDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_ListarPorID",
                new object[]
                {
                    IdSubActividad, 
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    oSubActividad = new SubActividadDTO();
                    oSubActividad.IdSubActividad = Convert.ToInt32(dataReader["IdSubActividad"].ToString());
                    oSubActividad.CodigoSubActividad = dataReader["CodigoSubActividad"].ToString();
                    oSubActividad.CodMap = Convert.ToInt32(dataReader["CodMap"].ToString());
                    oSubActividad.Actividad = new ActividadDTO()
                    {
                        IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString()),
                    };
                    oSubActividad.DescripcionSubActividad1 = dataReader["DescripcionSubActividad1"].ToString();
                    oSubActividad.DescripcionSubActividad2 = dataReader["DescripcionSubActividad2"].ToString();
                    oSubActividad.Unidad = dataReader["Unidad"].ToString(); ;
                    oSubActividad.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    oSubActividad.Observacion = dataReader["Observacion"].ToString();
                    oSubActividad.TrabajoComplementario = Convert.ToBoolean(dataReader["TrabajoComplementario"].ToString());
                    oSubActividad.Resane = Convert.ToBoolean(dataReader["Resane"].ToString());
                }
            }
            return oSubActividad;
        }
        
        public List<SubActividadDTO> ObtenerTrabajoComplemantario(int IdObra,int IdActividad)
        {
            List<SubActividadDTO> olSubAct = new List<SubActividadDTO>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_ListarTrabajoComplementario", new object[]
                {
                    IdObra,
                    IdActividad
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    SubActividadDTO oSubAct = new SubActividadDTO();
                    oSubAct.IdSubActividad = Convert.ToInt32(dataReader["IdSubActividad"].ToString());
                    oSubAct.CodigoSubActividad = dataReader["CodigoSubActividad"].ToString();
                    oSubAct.CodMap = Convert.ToInt32(dataReader["CodMap"].ToString());
                    oSubAct.DescripcionSubActividad1 = dataReader["DescripcionSubActividad1"].ToString();
                    oSubAct.Unidad = dataReader["Unidad"].ToString();
                    oSubAct.CostoProgramado = Convert.ToDecimal(dataReader["CostoProgramado"].ToString());
                    olSubAct.Add(oSubAct);
                }
            }

            return olSubAct;
        }

        public eResultado InsertarSubActividad(SubActividadDTO oSubActividad, int Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_Insert",
                new object[]
                {
                    oSubActividad.CodigoSubActividad,
  	                oSubActividad.CodMap,
  	                oSubActividad.Actividad.IdActividad,
  	                oSubActividad.DescripcionSubActividad1,
  	                oSubActividad.DescripcionSubActividad2,
                    oSubActividad.Unidad,
                    oSubActividad.CostoProgramado,
                    oSubActividad.Puntaje,
                    oSubActividad.Observacion,
                    oSubActividad.TrabajoComplementario,
  	                Usuario,
  	                DateTime.Now, oSubActividad.Resane,oSubActividad.T
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

        public eResultado ActualizarSubActividad(SubActividadDTO oSubActividad, int Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_Update",
                new object[]
                {
                    oSubActividad.IdSubActividad,
                    oSubActividad.CodMap,
                    oSubActividad.DescripcionSubActividad1,
                    oSubActividad.DescripcionSubActividad2,
                    oSubActividad.Unidad,
                    oSubActividad.CostoProgramado,
                    oSubActividad.Puntaje,
                    oSubActividad.Observacion,
                    oSubActividad.TrabajoComplementario,
                    Usuario,
                    DateTime.Now,oSubActividad.Resane
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

        public eResultado EliminarSubActividad(int IdSubActividad, int Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_SubActividad_Delete",
                new object[]
                {
                    IdSubActividad,
                    Usuario,
                    DateTime.Now
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
