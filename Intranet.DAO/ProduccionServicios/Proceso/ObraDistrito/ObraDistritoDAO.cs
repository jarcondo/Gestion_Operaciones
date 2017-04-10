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

namespace Intranet.DAO.ProduccionServicios.Proceso
{
    public class ObraDistritoDAO
    {
        public List<ObraDistritoDTO> ListarObraDistrito(int IdObra)
        {
            try
            {


                List<ObraDistritoDTO> oListaObraDistrito = new List<ObraDistritoDTO>();
                ObraDistritoDTO oObraDistrito = new ObraDistritoDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ObraDistritoListar",
                    new object[]
                        {
                           IdObra,
                        });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oObraDistrito = new ObraDistritoDTO();
                        oObraDistrito.IdObra = Convert.ToInt32(dataReader["IdObra"]);
                        oObraDistrito.IdDistrito = Convert.ToInt32(dataReader["IdDistrito"]);
                        oObraDistrito.Distrito = dataReader["Distrito"].ToString();

                        oListaObraDistrito.Add(oObraDistrito);
                    }
                }
                return oListaObraDistrito;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return new List<ObraDistritoDTO>();
            }
        }

        public eResultado InsertarObraDistrito(int IdObra, int IdDistrito)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommandVerifica = db.GetStoredProcCommand("PRO_ObraDistritoVerificarExiste2",
                    new object[]
                {
                   IdDistrito,IdObra
                });

                int nresultado1 = Convert.ToInt32(db.ExecuteScalar(dbCommandVerifica));

                if (nresultado1 > 0)
                {
                    return eResultado.Error;
                }
                else
                {

                    DbCommand dbCommand = db.GetStoredProcCommand("PRO_ObraDistritoInsert",
                        new object[]
                        {
                           IdObra, IdDistrito
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
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return eResultado.Error;
                
            }
        }


        public eResultado DeleteObraDistrito(int IdDistrito,int IdObra)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommandVerifica = db.GetStoredProcCommand("PRO_ObraZonaVerificarExiste",
                    new object[]
                {
                   IdDistrito,IdObra
                });

                int nresultado1 = Convert.ToInt32(db.ExecuteScalar(dbCommandVerifica));

                if (nresultado1 > 0)
                {
                    return eResultado.Error;
                }
                else
                {

                    DbCommand dbCommand = db.GetStoredProcCommand("PRO_ObraDistritoEliminar",
                        new object[]
                {
                   IdDistrito,IdObra
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
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return eResultado.Error;
                
            }
        }


    }
}
