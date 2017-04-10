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
    public class ProveedorDAO
    {

        public List<ProveedorDTO> GetCliente()
        {
            List<ProveedorDTO> olProveedor = new List<ProveedorDTO>();
            ProveedorDTO oProveedor = new ProveedorDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("[MA_ClienteListar1]");

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oProveedor = new ProveedorDTO();
                    oProveedor.IdProveedor = Convert.ToInt32(dataReader["IdProveedor"].ToString());
                    oProveedor.CodigoProveedor = dataReader["CodigoProveedor"].ToString();
                    oProveedor.Proveedor = dataReader["Proveedor"].ToString();
                    oProveedor.RUC = dataReader["RUC"].ToString() == null ? "" : dataReader["RUC"].ToString();
                   
                    olProveedor.Add(oProveedor);
                }
            }
            return olProveedor;
        }

        public List<ProveedorDTO> GetProveedor()
        {
            List<ProveedorDTO> olProveedor = new List<ProveedorDTO>();
            ProveedorDTO oProveedor = new ProveedorDTO();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_ProveedorListar");

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oProveedor = new ProveedorDTO();
                    oProveedor.IdProveedor = Convert.ToInt32(dataReader["IdProveedor"].ToString());
                    oProveedor.CodigoProveedor = dataReader["CodigoProveedor"].ToString();
                    oProveedor.Proveedor = dataReader["Proveedor"].ToString();
                    oProveedor.RUC = dataReader["RUC"].ToString() == null ? "" : dataReader["RUC"].ToString();
                    oProveedor.Rubro = dataReader["A2"].ToString() == null ? "" : dataReader["A2"].ToString();
                    oProveedor.Direccion = dataReader["Direccion"].ToString() == null ? "" : dataReader["Direccion"].ToString();
                    oProveedor.TelefonoFijo = dataReader["TelefonoFijo"].ToString() == null ? "" : dataReader["TelefonoFijo"].ToString();
                    oProveedor.Contacto = dataReader["Contacto"].ToString() == null ? "" : dataReader["Contacto"].ToString();
                    oProveedor.Referencia = dataReader["Referencia"].ToString() == null ? "" : dataReader["Referencia"].ToString();
                    oProveedor.Fax = dataReader["Fax"].ToString() == null ? "" : dataReader["Fax"].ToString();
                    oProveedor.Entrega = Convert.ToInt32(dataReader["Entrega"].ToString());
                    oProveedor.IdFormaPago = Convert.ToInt32(dataReader["IdFormaPago"].ToString());
                    oProveedor.IdRubro = Convert.ToInt32(dataReader["IdRubro"].ToString());
                    oProveedor.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString() == "" ? "0" : dataReader["IdBase"].ToString());
                    oProveedor.ProveedorGeneral = Convert.ToBoolean(dataReader["ProveedorGeneral"].ToString());
                    oProveedor.CP = Convert.ToBoolean(string.IsNullOrEmpty(dataReader["CP"].ToString()) ? "false" : dataReader["CP"].ToString());
                    olProveedor.Add(oProveedor);
                }
            }
            return olProveedor;
        }
    }
}
