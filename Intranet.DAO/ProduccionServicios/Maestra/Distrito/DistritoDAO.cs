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
   public class DistritoDAO
    {
       public List<DistritoDTO> ListarDistrito()
       {
           List<DistritoDTO> oListaDistrito = new List<DistritoDTO>();
           DistritoDTO oDistritoDTO = new DistritoDTO();
           Database db = DatabaseFactory.CreateDatabase();
           DbCommand dbCommand = db.GetStoredProcCommand("PRO_DistritoListar");
           using (IDataReader dataReader = db.ExecuteReader(dbCommand))
           {
               while (dataReader.Read())
               {
                   oDistritoDTO = new DistritoDTO();
                   oDistritoDTO.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"]);
                   oDistritoDTO.Distrito = dataReader["Distrito"].ToString();
                   oListaDistrito.Add(oDistritoDTO);
               }
           }
           return oListaDistrito;
       }

    }
}
