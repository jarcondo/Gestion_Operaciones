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
using Intranet.DTO.SGE;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class ConsultaTeoricoDAO
    {

        public List<CruceMaterialDTO> ListarTablaTeorico(int IdObra)
        {
            try
            {
                List<CruceMaterialDTO> oListaCruceMaterial = new List<CruceMaterialDTO>();
                CruceMaterialDTO oCruceMaterialDTO = new CruceMaterialDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ListarTeorico",
                    new object[]
                {
                    IdObra,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new CruceMaterialDTO();
                        oCruceMaterialDTO.subactividad = dataReader["Subactividad"].ToString();
                        oCruceMaterialDTO.material = dataReader["Material"].ToString();
                        oCruceMaterialDTO.actividad = dataReader["Actividad"].ToString();
                        oCruceMaterialDTO.Factor = Convert.ToDecimal(dataReader["Factor"].ToString());
                        oCruceMaterialDTO.Teorico = Convert.ToDecimal(dataReader["IdTeorico"].ToString());                  
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<CruceMaterialDTO>();
            }
        }



        public eResultado TeoricoUpdate(int IdTeorico, decimal Factor)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PRO_TeoricoUpdate",
                new object[]
                {
                    IdTeorico,
                    Factor,
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
