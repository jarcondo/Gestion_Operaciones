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
    public class ObraDAO
    {

        public List<ObraDTO> ListarObraCPxBase(int idbase)
        {
            List<ObraDTO> olista = new List<ObraDTO>();
            ObraDTO oObraDTO = new ObraDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_ObraListarCP", new object[]{idbase});

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oObraDTO = new ObraDTO();
                    oObraDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oObraDTO.CodigoObra = dataReader["CodigoObra"].ToString();
                    oObraDTO.Descripcion = dataReader["Descripcion"].ToString();
                    oObraDTO.DescripcionCorta = dataReader["DescripcionCorta"].ToString();
                    oObraDTO.IdDivision = Convert.ToInt32(dataReader["IdDivision"].ToString());
                    oObraDTO.CP = Convert.ToBoolean(dataReader["CP"].ToString());
                    olista.Add(oObraDTO);
                }
            }
            return olista;
        }

        public List<ObraDTO> ListarObraTodas()
        {
            List<ObraDTO> olista = new List<ObraDTO>();
            ObraDTO oObraDTO = new ObraDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_ObraListar4");

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oObraDTO = new ObraDTO();
                    oObraDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oObraDTO.CodigoObra = dataReader["CodigoObra"].ToString();
                    oObraDTO.Descripcion = dataReader["Descripcion"].ToString();
                    oObraDTO.DescripcionCorta = dataReader["DescripcionCorta"].ToString();
                    oObraDTO.IdDivision = Convert.ToInt32(dataReader["IdDivision"].ToString());
                    oObraDTO.CP = Convert.ToBoolean(dataReader["CP"].ToString());
                    olista.Add(oObraDTO);
                }
            }
            return olista;
        }

        public List<ObraDTO> ListarObra(int IdBase)
        {
            List<ObraDTO> olista = new List<ObraDTO>();
            ObraDTO oObraDTO = new ObraDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_ObraListar2", new object[]
                {
                    IdBase                    
                });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oObraDTO = new ObraDTO();
                    oObraDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oObraDTO.CodigoObra = dataReader["CodigoObra"].ToString();
                    oObraDTO.Descripcion = dataReader["Descripcion"].ToString().ToUpper();
                    oObraDTO.DescripcionCorta = dataReader["DescripcionCorta"].ToString().ToUpper();
                    oObraDTO.IdDivision = Convert.ToInt32(dataReader["IdDivision"].ToString());
                    oObraDTO.CP = Convert.ToBoolean(dataReader["CP"].ToString());
                    olista.Add(oObraDTO);
                }
            }
            return olista;
        }

        public ObraDTO GetObraId(int idobra)
        {
            ObraDTO oObraDTO = new ObraDTO();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_ObraListarxIde", new object[] { idobra });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oObraDTO = new ObraDTO();
                    oObraDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                    oObraDTO.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                    oObraDTO.CodigoObra = dataReader["CodigoObra"].ToString() == null ? "" : dataReader["CodigoObra"].ToString();
                    oObraDTO.Descripcion = dataReader["Descripcion"].ToString() == null ? "" : dataReader["Descripcion"].ToString().ToUpper();
                    oObraDTO.DescripBase = dataReader["DescripBase"].ToString() == null ? "" : dataReader["DescripBase"].ToString().ToUpper();
                    oObraDTO.DescripcionCorta = dataReader["DescripcionCorta"].ToString() == null ? "" : dataReader["DescripcionCorta"].ToString().ToUpper();
                    oObraDTO.IdDivision = Convert.ToInt32(dataReader["IdDivision"].ToString());
                    oObraDTO.CP = Convert.ToBoolean(dataReader["CP"].ToString());
                }
            }
            return oObraDTO;
        }
    }
}
