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
    public class AuxiliarCatalogoDAO
    {
        public List<AuxiliarCatalogoDTO> ListarAuxilarCatalogo(int IdObra)
        {
            try
            {


                List<AuxiliarCatalogoDTO> oListaAuxiliarCatalogoDTO = new List<AuxiliarCatalogoDTO>();
                AuxiliarCatalogoDTO oAuxiliarCatalogoDTO = new AuxiliarCatalogoDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarCatalogoListar",
                    new object[]
                {
                    IdObra,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oAuxiliarCatalogoDTO = new AuxiliarCatalogoDTO();
                        oAuxiliarCatalogoDTO.IdAuxiliar = Convert.ToInt32(dataReader["idauxiliar"].ToString());
                        oAuxiliarCatalogoDTO.DescripcionCatalogo = dataReader["DescripcionCatalogo"].ToString();
                        oAuxiliarCatalogoDTO.IdProCatalogo = Convert.ToInt32(dataReader["idprocatalogo"].ToString());
                        oAuxiliarCatalogoDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oAuxiliarCatalogoDTO.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                        oAuxiliarCatalogoDTO.CodigoActividad = dataReader["CodigoActividad"].ToString();
                        oListaAuxiliarCatalogoDTO.Add(oAuxiliarCatalogoDTO);
                    }
                }
                return oListaAuxiliarCatalogoDTO;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new  List<AuxiliarCatalogoDTO>();
            }
        }


        public eResultado AuxiliarCatalogoUpdate(AuxiliarCatalogoDTO oAuxiliarCatalogoDTO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarCatalogoActualizar",
                    new object[]
                {
                    oAuxiliarCatalogoDTO.IdObra,
                    oAuxiliarCatalogoDTO.IdAuxiliar,
                    oAuxiliarCatalogoDTO.IdProCatalogo,
                    oAuxiliarCatalogoDTO.IdActividad,
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
            catch (Exception ex)
            {

                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }

        public eResultado AuxiliarCatalogoDelete(AuxiliarCatalogoDTO oAuxiliarCatalogoDTO)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarCatalogoEliminar",
                    new object[]
                {
                    oAuxiliarCatalogoDTO.IdObra,
                    oAuxiliarCatalogoDTO.IdActividad,
                    oAuxiliarCatalogoDTO.IdProCatalogo,
                    oAuxiliarCatalogoDTO.IdAuxiliar,
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
            catch (Exception ex)
            {

                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }

        }



    }
}
