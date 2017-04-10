using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intranet.DTO.SGE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace Intranet.DAO.SGE
{
    public class EmpleadoDAO
    {
        public List<EmpleadoDTO> CargaEmpleado(int IdBase)
        {

            List<EmpleadoDTO> olistaEmpleado = new List<EmpleadoDTO>();
            
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand2 = db.GetStoredProcCommand("MA_EmpleadoListar3",
                new object[]
                        {
                           IdBase,
       
                        });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand2))
            {
                while (dataReader.Read())
                {
                    EmpleadoDTO oEmpleado = new EmpleadoDTO();
                    oEmpleado.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString();
                    oEmpleado.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                    oEmpleado.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    oEmpleado.IdCargo = Convert.ToInt32(dataReader["IdCargo"].ToString());
                    oEmpleado.CentroCosto = dataReader["CentroCosto"].ToString() == null ? "" : dataReader["CentroCosto"].ToString();
                    oEmpleado.Cargo = dataReader["Cargo"].ToString() == null ? "" : dataReader["Cargo"].ToString();
                    oEmpleado.LicenciaConducir = dataReader["LicenciaConducir"].ToString();
                    olistaEmpleado.Add(oEmpleado);
                }
            }

            return olistaEmpleado;

            //---
        }

        public List<EmpleadoDTO> GetEmpleadosAdmin(int idbase)
        {
            List<EmpleadoDTO> olEmpleado = new List<EmpleadoDTO>();
            EmpleadoDTO oEmpleado = new EmpleadoDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_EmpleadoListar4", new object[] { idbase });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oEmpleado = new EmpleadoDTO();
                    oEmpleado.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString();
                    oEmpleado.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                    oEmpleado.NombresApellidos = dataReader["NombresApellidos"].ToString().ToUpper() ;
                    olEmpleado.Add(oEmpleado);
                }
            }
            return olEmpleado;
        }

        public List<EmpleadoDTO> ObtenerResponsables(int IdObra)
        {
            List<EmpleadoDTO> olEmpleado = new List<EmpleadoDTO>();
            EmpleadoDTO oEmpleado = new EmpleadoDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_Empleado_ListarResponsables", new object[] { IdObra });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oEmpleado = new EmpleadoDTO();
                    //oEmpleado.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString();
                    oEmpleado.IdEmpleado = Convert.ToInt32(dataReader["IdResponsable"].ToString());
                    oEmpleado.NombresApellidos = dataReader["Nombre"].ToString().ToUpper();
                    olEmpleado.Add(oEmpleado);
                }
            }
            return olEmpleado;
        }
    }
}
