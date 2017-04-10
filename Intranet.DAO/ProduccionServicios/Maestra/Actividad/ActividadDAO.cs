using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intranet.DTO.ProduccionServicios.Maestras;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Intranet.DTO.SGE;
using Intranet.DTO.Global;

namespace Intranet.DAO.ProduccionServicios.Maestra
{
    public class ActividadDAO
    {
        public List<ActividadDTO> ListarActividad(int IdObra)
        {
            List<ActividadDTO> olActividad = new List<ActividadDTO>();
            ActividadDTO oActividad = new ActividadDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Actividad_Listar",
                new object[]
                {
                    IdObra, 
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oActividad = new ActividadDTO();
                    oActividad.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                    oActividad.CodigoActividad = dataReader["CodigoActividad"].ToString();
                    oActividad.CodMap = dataReader["CodMap"].ToString();
                    oActividad.Obra = new ObraDTO()
                    {
                        IdObra = Convert.ToInt32(dataReader["IdObra"].ToString()),
                    };
                    oActividad.Descripcion1 = dataReader["Descripcion1"].ToString();
                    oActividad.Descripcion2 = dataReader["Descripcion2"].ToString();
                    olActividad.Add(oActividad);
                }
            }
            return olActividad;
        }


        public ActividadDTO ListarActividadPorCODIGO(string CodActividad)
        {
            ActividadDTO oActividad = new ActividadDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Actividad_ListarPorCodigo",
                new object[]
                {
                    CodActividad, 
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    oActividad = new ActividadDTO();
                    oActividad.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                    oActividad.CodigoActividad = dataReader["CodigoActividad"].ToString();
                    oActividad.CodMap = dataReader["CodMap"].ToString();
                    oActividad.Obra = new ObraDTO()
                    {
                        IdObra = Convert.ToInt32(dataReader["IdObra"].ToString()),
                    };
                    oActividad.Descripcion1 = dataReader["Descripcion1"].ToString();
                    oActividad.Descripcion2 = dataReader["Descripcion2"].ToString();
                }
            }
            return oActividad;
        }

        public ActividadDTO ListarActividadPorID(int IdActividad)
        {
            ActividadDTO oActividad = new ActividadDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Actividad_ListarPorID",
                new object[]
                {
                    IdActividad, 
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    oActividad = new ActividadDTO();
                    oActividad.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                    oActividad.CodigoActividad = dataReader["CodigoActividad"].ToString();
                    oActividad.CodMap = dataReader["CodMap"].ToString();
                    oActividad.Obra = new ObraDTO()
                    {
                        IdObra = Convert.ToInt32(dataReader["IdObra"].ToString()),
                    };
                    oActividad.Descripcion1 = dataReader["Descripcion1"].ToString();
                    oActividad.Descripcion2 = dataReader["Descripcion2"].ToString();
                }
            }
            return oActividad;
        }

        public eResultado InsertarActividad(ActividadDTO oActividad, int Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Actividad_Insert",
                new object[]
                {
                    oActividad.CodigoActividad,
  	                oActividad.CodMap,
  	                oActividad.Obra.IdObra,
  	                oActividad.Descripcion1,
  	                oActividad.Descripcion2,
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

        public eResultado ActualizarActividad(ActividadDTO oActividad, int Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Actividad_Update",
                new object[]
                {
                    oActividad.IdActividad,
                    oActividad.CodigoActividad,
                    oActividad.CodMap,
                    oActividad.Obra.IdObra,
                    oActividad.Descripcion1,
                    oActividad.Descripcion2,
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

        public eResultado EliminarActividad(int IdActividad, int Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Actividad_Eliminar",
                new object[]
                {
                    IdActividad,
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
