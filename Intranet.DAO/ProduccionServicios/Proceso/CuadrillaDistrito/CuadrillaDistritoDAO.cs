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

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class CuadrillaDistritoDAO
    {
        public List<CuadrillaDistritoDTO> ListarCuadrillaDistrito()
        {
            List<CuadrillaDistritoDTO> oListaCuadrillaDistritoDTO = new List<CuadrillaDistritoDTO>();
            CuadrillaDistritoDTO oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CuadrillaDistritoListar");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
                    oCuadrillaDistritoDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                    oCuadrillaDistritoDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                    oCuadrillaDistritoDTO.DescripcionDistrito = dataReader["DescripcionDistrito"].ToString();
                    oCuadrillaDistritoDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrillaDistritoDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"].ToString());
                    oCuadrillaDistritoDTO.IdZona = Convert.ToInt32(dataReader["IdZona"].ToString());
                    oCuadrillaDistritoDTO.DescripcionZona = dataReader["DescripcionZona"].ToString();
                    oCuadrillaDistritoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oListaCuadrillaDistritoDTO.Add(oCuadrillaDistritoDTO);
                }
            }
            return oListaCuadrillaDistritoDTO;
        }

        public List<CuadrillaDistritoDTO> ListarCuadrillaDistrito2(int IdObra)
        {
            List<CuadrillaDistritoDTO> oListaCuadrillaDistritoDTO = new List<CuadrillaDistritoDTO>();
            CuadrillaDistritoDTO oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CuadrillaDistritoListar2",
                new object[]
                {
                    IdObra,
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
                    oCuadrillaDistritoDTO.IdCuadrillaDistrito = Convert.ToInt32(dataReader["IdCuadrillaDistrito"].ToString());
                    oCuadrillaDistritoDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                    oCuadrillaDistritoDTO.DescripcionCuadrilla = dataReader["DescripcionCuadrilla"].ToString();
                    oCuadrillaDistritoDTO.DescripcionDistrito = dataReader["DescripcionDistrito"].ToString();
                    oCuadrillaDistritoDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrillaDistritoDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"].ToString());
                    oCuadrillaDistritoDTO.IdZona = Convert.ToInt32(dataReader["IdZona"].ToString());
                    oCuadrillaDistritoDTO.DescripcionZona = dataReader["DescripcionZona"].ToString();
                    oCuadrillaDistritoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oListaCuadrillaDistritoDTO.Add(oCuadrillaDistritoDTO);
                }
            }
            return oListaCuadrillaDistritoDTO;
        }


        public eResultado CuadrillaDistritoUpdate(CuadrillaDistritoDTO oCuadrillaDistritoDTO)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CuadrillaDistritoActualizar",
                new object[]
                {

                    oCuadrillaDistritoDTO.IdObra
                    ,oCuadrillaDistritoDTO.IdDistrito
                    ,oCuadrillaDistritoDTO.DescripcionDistrito
                    ,oCuadrillaDistritoDTO.IdZona
                    ,oCuadrillaDistritoDTO.DescripcionZona
                    ,oCuadrillaDistritoDTO.CodigoCuadrilla
                    ,oCuadrillaDistritoDTO.IdCuadrilla
                    ,oCuadrillaDistritoDTO.DescripcionCuadrilla
                    ,oCuadrillaDistritoDTO.IdCuadrillaDistrito


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

        public eResultado CuadrillaDistritoInsert(CuadrillaDistritoDTO oCuadrillaDistritoDTO)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CuadrillaDistritoInsert",
                new object[]
                {

                    oCuadrillaDistritoDTO.IdObra
                    ,oCuadrillaDistritoDTO.IdDistrito
                    ,oCuadrillaDistritoDTO.DescripcionDistrito
                    ,oCuadrillaDistritoDTO.IdZona
                    ,oCuadrillaDistritoDTO.DescripcionZona
                    ,oCuadrillaDistritoDTO.CodigoCuadrilla
                    ,oCuadrillaDistritoDTO.IdCuadrilla
                    ,oCuadrillaDistritoDTO.DescripcionCuadrilla
                    ,oCuadrillaDistritoDTO.IdCuadrillaDistrito


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

        //public eResultado CuadrillaDistritoDelete(CuadrillaDistritoDTO oCuadrillaDistritoDTO)
        public eResultado CuadrillaDistritoDelete(int IdCuadrilla, int IdObra, int IdCuadrillaDistrito)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CuadrillaDistritoEliminar",
                new object[]
                {
                    IdCuadrilla,
                    IdObra,
                    IdCuadrillaDistrito,
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


        public List<CuadrillaDistritoDTO> ListarCuadrillaProduccion(int IdObra)
        {
            List<CuadrillaDistritoDTO> oListaCuadrillaDistritoDTO = new List<CuadrillaDistritoDTO>();
            CuadrillaDistritoDTO oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CuadrillaProduccionListar",
                new object[]
                {
                    IdObra,
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCuadrillaDistritoDTO = new CuadrillaDistritoDTO();
                    oCuadrillaDistritoDTO.CodigoCuadrilla = dataReader["CodigoCuadrilla"].ToString();
                    oCuadrillaDistritoDTO.DescripcionCuadrilla = dataReader["descripcion"].ToString();
                    oCuadrillaDistritoDTO.IdCuadrilla = Convert.ToInt32(dataReader["IdCuadrilla"].ToString());
                    oCuadrillaDistritoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oListaCuadrillaDistritoDTO.Add(oCuadrillaDistritoDTO);
                }
            }
            return oListaCuadrillaDistritoDTO;
        }


    }
}
