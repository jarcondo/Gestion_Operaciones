using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intranet.DTO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Intranet.DTO.CFG;
namespace Intranet.DAO
{
    public class UsuarioDAO
    {
        public List<UsuarioLoginCFG> GetUsuario()
        {

            List<UsuarioLoginCFG> oListaUsuarioLoginCFG = new List<UsuarioLoginCFG>();
            UsuarioLoginCFG oUsuarioLoginCFG = new UsuarioLoginCFG();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_UsuarioListar");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oUsuarioLoginCFG = new UsuarioLoginCFG();
                    oUsuarioLoginCFG.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"].ToString());
                    oUsuarioLoginCFG.CodigoUsuario = dataReader["CodigoUsuario"].ToString();
                    oUsuarioLoginCFG.Usuario = dataReader["Usuario"].ToString();
                    oUsuarioLoginCFG.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    oUsuarioLoginCFG.Password = dataReader["Password"].ToString();
                    oUsuarioLoginCFG.IdRol = Convert.ToInt32(dataReader["IdRol"].ToString());
                    oUsuarioLoginCFG.TipoRol = dataReader["TipoRol"].ToString() == null ? "" : dataReader["TipoRol"].ToString();
                    oUsuarioLoginCFG.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                    oUsuarioLoginCFG.IdAlmacen = Convert.ToInt32(dataReader["IdAlmacen"].ToString());
                    oUsuarioLoginCFG.Base = dataReader["Base"].ToString() == null ? "" : dataReader["Base"].ToString();
                    oListaUsuarioLoginCFG.Add(oUsuarioLoginCFG);
                }
            }
            return oListaUsuarioLoginCFG;
        }

        public UsuarioLoginCFG UsuarioBuscar(int IdUsuario)
        {
            UsuarioLoginCFG oUsuarioLoginCFG = new UsuarioLoginCFG();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("MA_UsuarioBuscar", new object[] { IdUsuario });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    oUsuarioLoginCFG = new UsuarioLoginCFG();
                    oUsuarioLoginCFG.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"].ToString());
                    oUsuarioLoginCFG.CodigoUsuario = dataReader["CodigoUsuario"].ToString();
                    oUsuarioLoginCFG.Usuario = dataReader["Usuario"].ToString();
                    oUsuarioLoginCFG.NombresApellidos = dataReader["NombresApellidos"].ToString();
                    oUsuarioLoginCFG.Password = dataReader["Password"].ToString();
                    oUsuarioLoginCFG.IdRol = Convert.ToInt32(dataReader["IdRol"].ToString());
                    oUsuarioLoginCFG.TipoRol = dataReader["TipoRol"].ToString() == null ? "" : dataReader["TipoRol"].ToString();
                    oUsuarioLoginCFG.IdBase = Convert.ToInt32(dataReader["IdBase"].ToString());
                    oUsuarioLoginCFG.IdAlmacen = Convert.ToInt32(dataReader["IdAlmacen"].ToString());
                    oUsuarioLoginCFG.Base = dataReader["Base"].ToString() == null ? "" : dataReader["Base"].ToString();
                    oUsuarioLoginCFG.CodigoAlmacen = dataReader["CodigoAlmacen"].ToString() == null ? "" : dataReader["CodigoAlmacen"].ToString();
                    oUsuarioLoginCFG.CodigoBase = dataReader["CodigoBase"].ToString() == null ? "" : dataReader["CodigoBase"].ToString();
                    oUsuarioLoginCFG.Almacen = dataReader["Almacen"].ToString() == null ? "" : dataReader["Almacen"].ToString();
                    oUsuarioLoginCFG.IdDivision = Convert.ToInt32(dataReader["IdDivision"].ToString());
                    oUsuarioLoginCFG.CentroServicio = Convert.ToInt32(dataReader["CentroServicio"].ToString());
                    oUsuarioLoginCFG.NroContrato = Convert.ToInt32(dataReader["NroContrato"].ToString());
                    oUsuarioLoginCFG.IdEmpleado = Convert.ToInt32(dataReader["idempleado"].ToString());
                    oUsuarioLoginCFG.EstadoCarga = dataReader["EstadoCarga"].ToString();
                    oUsuarioLoginCFG.EMPRESA = dataReader["NombresApellidos"].ToString();
                }
            }
            return oUsuarioLoginCFG;
        }
    }
}
