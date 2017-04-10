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
    public class ZonaDAO
    {
        public List<ZonaDTO> ListarZona(int IdDistrito)
        {
            List<ZonaDTO> oListaZona = new List<ZonaDTO>();
            ZonaDTO oZonaDTO = new ZonaDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_ZonaListar",
                new object[]
                        {
                           IdDistrito,
                        });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oZonaDTO = new ZonaDTO();
                    oZonaDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"]);
                    oZonaDTO.DescripcionZona = dataReader["DescripcionZona"].ToString();
                    oZonaDTO.IdZona = Convert.ToInt32(dataReader["IdZona"]);
                    oListaZona.Add(oZonaDTO);
                }
            }
            return oListaZona;
        }
        public List<ZonaDTO> ListarZona2()
        {
            List<ZonaDTO> oListaZona = new List<ZonaDTO>();
            ZonaDTO oZonaDTO = new ZonaDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_ZonaListar2");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oZonaDTO = new ZonaDTO();
                    oZonaDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"]);
                    oZonaDTO.DescripcionZona = dataReader["DescripcionZona"].ToString();
                    oZonaDTO.IdZona = Convert.ToInt32(dataReader["IdZona"]);
                    oListaZona.Add(oZonaDTO);
                }
            }
            return oListaZona;
        }

        public List<ZonaDTO> ListarZona3(int IdObra)
        {
            List<ZonaDTO> oListaZona = new List<ZonaDTO>();
            ZonaDTO oZonaDTO = new ZonaDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_ZonaListar3",
                new object[]
                        {
                           IdObra,
                        });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oZonaDTO = new ZonaDTO();
                    oZonaDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"]);
                    oZonaDTO.DescripcionZona = dataReader["DescripcionZona"].ToString();
                    oZonaDTO.IdZona = Convert.ToInt32(dataReader["IdZona"]);
                    oZonaDTO.Distrito = dataReader["Distrito"].ToString();
                    oZonaDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString()); 
                    oListaZona.Add(oZonaDTO);
                }
            }
            return oListaZona;
        }
        public eResultado InsertarZona(string DescripcionZona, int IdDistrito ,int IdObra)
        {

            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("PRO_ZonaInsert",
                new object[]
                {
                   DescripcionZona, IdDistrito , IdObra,
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

        public eResultado UpdateZona(string DescripcionZona, int IdDistrito, int IdZona ,int IdObra)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_ZonaUpdate",
                new object[]
                {
                   DescripcionZona, IdDistrito ,IdZona,IdObra,
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

        public eResultado DeleteZona(int IdZona,int IdObra)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommandVerifica = db.GetStoredProcCommand("PRO_ZonaVerificarExiste",
                new object[]
                {
                   IdZona,IdObra
                });

            int nresultado1 = Convert.ToInt32(db.ExecuteScalar(dbCommandVerifica));

            if (nresultado1 > 0)
            {
                return eResultado.Error;
            }
            else
            {

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ZonaDelete",
                    new object[]
                {
                   IdZona,IdObra
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
}

