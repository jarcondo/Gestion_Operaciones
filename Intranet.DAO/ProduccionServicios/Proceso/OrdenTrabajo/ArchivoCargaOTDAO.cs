using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intranet.DTO.ProduccionServicios;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DAO.SGE;
using Intranet.DTO.ProduccionServicios.Procesos;

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    [Serializable]
    public class ArchivoCargaOTDAO
    {
        public ArchivoCargaOTDTO GetArchivoCargaPorID(int IdArchivoCargaOT)
        {
            try
            {


                ArchivoCargaOTDTO oArchivoCargaOT = new ArchivoCargaOTDTO();

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ArchivoCargaOTListarPorID", new object[]
                {
                    IdArchivoCargaOT                    
                });

                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oArchivoCargaOT = new ArchivoCargaOTDTO();
                        oArchivoCargaOT.IdArchivoCargaOT = Convert.ToInt32(dataReader["IdArchivoCargaOT"].ToString());
                        oArchivoCargaOT.ArchivoRuta = dataReader["ArchivoRuta"].ToString();
                        oArchivoCargaOT.DescripcionCarga = dataReader["DescripcionCarga"].ToString();
                        oArchivoCargaOT.Obra = new ObraDAO().GetObraId(Convert.ToInt32(dataReader["IdObra"].ToString()));
                    }
                }
                return oArchivoCargaOT;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return new ArchivoCargaOTDTO();
            }
        }
    }
}
