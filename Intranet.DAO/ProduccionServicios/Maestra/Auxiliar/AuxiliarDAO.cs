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
    public class AuxiliarDAO
    {
        public List<AuxiliarDTO> ListarAuxilar(int IdObra)
        {
            List<AuxiliarDTO> oListaAuxiliarDTO = new List<AuxiliarDTO>();
            AuxiliarDTO oAuxiliarDTO = new AuxiliarDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarListar",
                new object[]
                {
                    IdObra,
                });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oAuxiliarDTO = new AuxiliarDTO();
                    oAuxiliarDTO.CodigoAuxiliar = dataReader["IdAuxiliar"].ToString().PadRight(5,' ');
                    oAuxiliarDTO.Descripcion = dataReader["Descripcion"].ToString();
                    oAuxiliarDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                    //oAuxiliarDTO.Precio = Convert.ToDecimal(dataReader["Precio"].ToString());
                    //oAuxiliarDTO.Unidad = dataReader["Unidad"].ToString();
                    //oAuxiliarDTO.Valorizable = Convert.ToBoolean(dataReader["Valorizable"].ToString());
                    oAuxiliarDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oListaAuxiliarDTO.Add(oAuxiliarDTO);
                }
            }
            return oListaAuxiliarDTO;
        }


        public eResultado AuxiliarInsert(AuxiliarDTO oAuxiliarDTO)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarInsertar",
                new object[]
                {
                    oAuxiliarDTO.IdObra,
                    oAuxiliarDTO.Descripcion,
                    oAuxiliarDTO.Unidad,
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
