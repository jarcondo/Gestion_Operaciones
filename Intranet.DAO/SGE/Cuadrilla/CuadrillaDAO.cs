using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intranet.DTO.SGE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Intranet.DTO.Global;
namespace Intranet.DAO.SGE
{
    public class CuadrillaDAO
    {
        public List<CuadrillaDTO> GetCuadrilla(int IdObra)
        {
            List<CuadrillaDTO> oListaCuadrillaDTO = new List<CuadrillaDTO>();
            CuadrillaDTO oCuadrillaDTO = new CuadrillaDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SER_CuadrillaListar",
                new object[]
                        {
                           IdObra,
                        });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrillaDTO = new CuadrillaDTO();
                    oCuadrillaDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrillaDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oCuadrillaDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString() == null ? "" : dataReader["CodigoCuadrilla"].ToString();
                    oCuadrillaDTO.Descripcion = dataReader["Descripcion"].ToString() == null ? "" : dataReader["Descripcion"].ToString();
                    oCuadrillaDTO.CentroCosto = dataReader["CentroCosto"].ToString() == null ? "" : dataReader["CentroCosto"].ToString();
                    oCuadrillaDTO.CodigoObra = dataReader["CodigoObra"].ToString() == null ? "" : dataReader["CodigoObra"].ToString();
                    oCuadrillaDTO.DescripcionObra = dataReader["DescripcionObra"].ToString() == null ? "" : dataReader["DescripcionObra"].ToString();
                    oCuadrillaDTO.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                    oCuadrillaDTO.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString() == null ? "" : dataReader["CodigoEmpleado"].ToString();
                    oCuadrillaDTO.NombresApellidos = dataReader["NombresApellidos"].ToString() == null ? "" : dataReader["NombresApellidos"].ToString();
                    oCuadrillaDTO.ActivoFijo = dataReader["ActivoFijo"].ToString() == "False" ? eActivoFijo.No : eActivoFijo.Si;
                    oListaCuadrillaDTO.Add(oCuadrillaDTO);
                }
            }
            return oListaCuadrillaDTO;
        }

        public List<CuadrillaDTO> GetCuadrillas()
        {

            List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
            CuadrillaDTO oCuadrilla = new CuadrillaDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SER_CuadrillaListar");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrilla = new CuadrillaDTO();
                    oCuadrilla.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrilla.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oCuadrilla.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString() == null ? "" : dataReader["CodigoCuadrilla"].ToString();
                    oCuadrilla.Descripcion = dataReader["Descripcion"].ToString() == null ? "" : dataReader["Descripcion"].ToString();
                    oCuadrilla.CentroCosto = dataReader["CentroCosto"].ToString() == null ? "" : dataReader["CentroCosto"].ToString();
                    oCuadrilla.CodigoObra = dataReader["CodigoObra"].ToString() == null ? "" : dataReader["CodigoObra"].ToString();
                    oCuadrilla.DescripcionObra = dataReader["DescripcionObra"].ToString() == null ? "" : dataReader["DescripcionObra"].ToString();
                    oCuadrilla.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                    oCuadrilla.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString() == null ? "" : dataReader["CodigoEmpleado"].ToString();
                    oCuadrilla.NombresApellidos = dataReader["NombresApellidos"].ToString() == null ? "" : dataReader["NombresApellidos"].ToString();
                    oCuadrilla.ActivoFijo = dataReader["ActivoFijo"].ToString() == "False" ? eActivoFijo.No : eActivoFijo.Si;
                    olCuadrilla.Add(oCuadrilla);
                }
            }
            return olCuadrilla;
        }

        public List<CuadrillaDTO> GetCuadrillaPorResponsable(int IdResponsable,int IdArea)
        {
            List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
            CuadrillaDTO oCuadrilla = new CuadrillaDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SER_CuadrillaObtenerPorResponsable",
                new object[]
                        {
                           IdResponsable,IdArea
                        });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrilla = new CuadrillaDTO();
                    oCuadrilla.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrilla.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString() == null ? "" : dataReader["CodigoCuadrilla"].ToString();
                    oCuadrilla.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    oCuadrilla.Descripcion = dataReader["Descripcion"].ToString() == null ? "" : dataReader["Descripcion"].ToString();
                    oCuadrilla.DetalleZona = dataReader["DescripcionZona"].ToString();
                    olCuadrilla.Add(oCuadrilla);
                }
            }

            return olCuadrilla;
        }

        public List<CuadrillaDTO> GetCuadrillasMantenimiento(int IdObra)
        {
            List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
            CuadrillaDTO oCuadrilla = new CuadrillaDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SER_Cuadrilla_ObtenerMantenimiento",
                new object[]
                        {
                           IdObra,
                        });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrilla = new CuadrillaDTO();
                    oCuadrilla.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrilla.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString() == null ? "" : dataReader["CodigoCuadrilla"].ToString();
                    oCuadrilla.Descripcion = dataReader["descripcion"].ToString() == null ? "" : dataReader["Descripcion"].ToString();
                    oCuadrilla.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    oCuadrilla.IdArea = Convert.ToInt32(dataReader["IdArea"].ToString() == "" ? "0" : dataReader["IdArea"].ToString());
                    oCuadrilla.IdResponsable = Convert.ToInt32(dataReader["IdResponsable"].ToString() == "" ? "0" : dataReader["IdResponsable"].ToString());
                    olCuadrilla.Add(oCuadrilla);
                }
            }
            return olCuadrilla;
        }


        public List<CuadrillaDTO> ListarCuadrillaPorResponsable(int IdObra,int IdResponsable)
        {
            List<CuadrillaDTO> olCuadrilla = new List<CuadrillaDTO>();
            CuadrillaDTO oCuadrilla = new CuadrillaDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SER_CuadrillaListarPorResponsable",
                new object[]
                        {
                           IdObra,IdResponsable,
                        });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrilla = new CuadrillaDTO();
                    oCuadrilla.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrilla.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString() == null ? "" : dataReader["CodigoCuadrilla"].ToString() +" "+ dataReader["NombresApellidos"].ToString();
                    oCuadrilla.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    oCuadrilla.Descripcion = dataReader["Descripcion"].ToString() == null ? "" : dataReader["Descripcion"].ToString();
                    //oCuadrilla.DetalleZona = dataReader["DescripcionZona"].ToString();
                    olCuadrilla.Add(oCuadrilla);
                }
            }

            return olCuadrilla;
        }



    }
}
