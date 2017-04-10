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

namespace Intranet.DAO.ProduccionServicios.Maestra
{
    public class CatalogoDAO
    {
        public List<CatalogoDTO> ListarCatalogo(int IdObra)
        {
            List<CatalogoDTO> oListaCatalogoDTO = new List<CatalogoDTO>();
            CatalogoDTO oCatalogoDTO = new CatalogoDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_CatalogoListar",
                new object[]
                {
                    IdObra,
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oCatalogoDTO = new CatalogoDTO();
                    oCatalogoDTO.CodMap = Convert.ToInt32(dataReader["CodMap"].ToString());
                    oCatalogoDTO.CodMapActividad = Convert.ToInt32(dataReader["CodMapActividad"].ToString());
                    oCatalogoDTO.Descripcion1 = dataReader["Descripcion1"].ToString();
                    oCatalogoDTO.Descripcion2 = dataReader["Descripcion2"].ToString();
                    oCatalogoDTO.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                    oCatalogoDTO.IdProCatalogo = Convert.ToInt32(dataReader["IdProCatalogo"].ToString());
                    oCatalogoDTO.Precio = Convert.ToDecimal(dataReader["Precio"].ToString());
                    oCatalogoDTO.Unidad = dataReader["Unidad"].ToString();
                    oCatalogoDTO.Valorizable = Convert.ToBoolean(dataReader["Valorizable"].ToString());
                    oCatalogoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oListaCatalogoDTO.Add(oCatalogoDTO);
                }
            }
            return oListaCatalogoDTO;
        }

        public List<CatalogoDTO> ListarPorActividad(int IdObra,int IdActividad)
        {
            List<CatalogoDTO> oListaCatalogoDTO = new List<CatalogoDTO>();
            CatalogoDTO oCatalogoDTO = new CatalogoDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_Catalogo_ListarPorActividad",
                new object[]
                {
                    IdObra,IdActividad
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    try
                    {


                        oCatalogoDTO = new CatalogoDTO();
                        oCatalogoDTO.CodMap = Convert.ToInt32(dataReader["CodMap"].ToString());
                        //oCatalogoDTO.CodMapActividad = Convert.ToInt32(dataReader["CodMapActividad"].ToString());
                        oCatalogoDTO.Descripcion1 = dataReader["Descripcion1"].ToString();
                        oCatalogoDTO.Descripcion2 = dataReader["Descripcion2"].ToString();
                        oCatalogoDTO.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                        oCatalogoDTO.IdProCatalogo = Convert.ToInt32(dataReader["IdProCatalogo"].ToString());
                        oCatalogoDTO.Precio = Convert.ToDecimal(dataReader["Precio"].ToString());
                        oCatalogoDTO.Unidad = dataReader["Unidad"].ToString();
                        oCatalogoDTO.Valorizable = Convert.ToBoolean(dataReader["Valorizable"].ToString());
                        oCatalogoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                        oListaCatalogoDTO.Add(oCatalogoDTO);
                    }
                    catch (Exception)
                    {

                     
                    }
                }
            }
            return oListaCatalogoDTO;
        }
    }
}
