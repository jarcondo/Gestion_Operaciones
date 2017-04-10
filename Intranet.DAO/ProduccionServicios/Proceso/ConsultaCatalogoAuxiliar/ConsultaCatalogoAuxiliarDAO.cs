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
    public class ConsultaCatalogoAuxiliarDAO
    {
        public List<ConsultaCatalogoAuxiliarDTO> ListarCatalogoAuxiliarObra(int IdObra)
        {
            try
            {
                List<ConsultaCatalogoAuxiliarDTO> oListaCruceMaterial = new List<ConsultaCatalogoAuxiliarDTO>();
                ConsultaCatalogoAuxiliarDTO oCruceMaterialDTO = new ConsultaCatalogoAuxiliarDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ListarAuxiliarCatalogo",
                    new object[]
                {
                    IdObra,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new ConsultaCatalogoAuxiliarDTO();
                        //oCruceMaterialDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoAuxiliar = dataReader["IdAuxiliar"].ToString().PadRight(5,' ');
                        oCruceMaterialDTO.IdProCatalogo = Convert.ToInt32(dataReader["IdProCatalogo"].ToString());
                        oCruceMaterialDTO.DescripcionCatalogo = dataReader["DescripcionCatalogo"].ToString();
                        oCruceMaterialDTO.UnidadSedapro = dataReader["UnidadSedapro"].ToString();
                        oCruceMaterialDTO.CodigoActividad = dataReader["CodigoActividad"].ToString();
                  
                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<ConsultaCatalogoAuxiliarDTO>();
            }
        }


        public List<ConsultaCatalogoAuxiliarDTO> ListarProductoAuxiliar()
        {
            try
            {
                List<ConsultaCatalogoAuxiliarDTO> oListaCruceMaterial = new List<ConsultaCatalogoAuxiliarDTO>();
                ConsultaCatalogoAuxiliarDTO oCruceMaterialDTO = new ConsultaCatalogoAuxiliarDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ListarAuxiliarProducto");
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oCruceMaterialDTO = new ConsultaCatalogoAuxiliarDTO();
                        //oCruceMaterialDTO.Item = Convert.ToInt32(dataReader["Item"].ToString());
                        oCruceMaterialDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                        oCruceMaterialDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                        oCruceMaterialDTO.CodigoAuxiliar = dataReader["IdAuxiliar"].ToString().PadRight(5,' ');
                        oCruceMaterialDTO.IdProducto = Convert.ToInt32(dataReader["IdProducto"].ToString());
                        oCruceMaterialDTO.DescripcionAlmacen = dataReader["DescripcionAlmacen"].ToString();
                        oCruceMaterialDTO.unidadalmacen = dataReader["unidadalmacen"].ToString();

                        oListaCruceMaterial.Add(oCruceMaterialDTO);
                    }
                }
                return oListaCruceMaterial;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "Intranet", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<ConsultaCatalogoAuxiliarDTO>();
            }
        }


    }
}
