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
    public class ProductoDAO
    {
        public List<ProductoDTO> ListarProductoMaterial()
        {
            List<ProductoDTO> oListaProductoDTO = new List<ProductoDTO>();
            ProductoDTO oProductoDTO = new ProductoDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_ProductoListarMateriales");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oProductoDTO = new ProductoDTO();
                    oProductoDTO.CodigoProducto = dataReader["CodigoProducto"].ToString();
                    oProductoDTO.Descripcion = dataReader["Descripcion1"].ToString();
                    oProductoDTO.IdProducto = Convert.ToInt32(dataReader["IdProducto"].ToString());
                    oListaProductoDTO.Add(oProductoDTO);
                }
            }
            return oListaProductoDTO;
        }


    }
}
