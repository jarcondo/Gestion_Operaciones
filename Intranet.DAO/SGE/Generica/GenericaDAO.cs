using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intranet.DTO.SGE;
using Intranet.DTO.Global;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace Intranet.DAO.SGE
{
    public class GenericaDAO
    {
        public List<GenericaDTO> GetGenerica(eTabla nomtabla)
        {

            List<GenericaDTO> olGenerica = new List<GenericaDTO>();
            GenericaDTO oGenerica = new GenericaDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_GenericaListar",
            new object[] { nomtabla.ToString() });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {

                    oGenerica = new GenericaDTO();
                    oGenerica.IdGenerica = Convert.ToInt32(dataReader["IdGenerica"].ToString());
                    oGenerica.A1 = dataReader["A1"].ToString() == null ? "" : dataReader["A1"].ToString();
                    oGenerica.A2 = dataReader["A2"].ToString() == null ? "" : dataReader["A2"].ToString().ToUpper();

                    oGenerica.A3 = dataReader["A3"].ToString() == null ? "" : dataReader["A3"].ToString();
                    oGenerica.A4 = dataReader["A4"].ToString() == null ? "" : dataReader["A4"].ToString();
                    oGenerica.Tabla = (eTabla)Enum.Parse(typeof(eTabla), dataReader["Tabla"].ToString());

                    olGenerica.Add(oGenerica);
                }
            }
            return olGenerica;
        }

    }
}
