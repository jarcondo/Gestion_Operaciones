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
   public class AuxiliarProductoDAO
    {
       public List<AuxiliarProductoDTO> ListarAuxilarProducto(int IdObra)
       {
           try
           {


               List<AuxiliarProductoDTO> oListaAuxiliarProducto = new List<AuxiliarProductoDTO>();
               AuxiliarProductoDTO oAuxiliarProductoDTO = new AuxiliarProductoDTO();
               Database db = DatabaseFactory.CreateDatabase();
               DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarProductoListar",
                   new object[]
                {
                    IdObra,
                });
               using (IDataReader dataReader = db.ExecuteReader(dbCommand))
               {
                   while (dataReader.Read())
                   {
                       oAuxiliarProductoDTO = new AuxiliarProductoDTO();
                       oAuxiliarProductoDTO.DescripcionAuxiliar = dataReader["DescripcionAuxiliar"].ToString();
                       oAuxiliarProductoDTO.DescripcionProducto = dataReader["DescripcionProducto"].ToString();
                       oAuxiliarProductoDTO.IdAuxiliar = Convert.ToInt32(dataReader["IdAuxiliar"].ToString());
                       oAuxiliarProductoDTO.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                       oAuxiliarProductoDTO.IdProducto = Convert.ToInt32(dataReader["IdProducto"].ToString());
                       oAuxiliarProductoDTO.IdProductoAuxiliar = Convert.ToInt32(dataReader["IdProductoAuxiliar"].ToString());
                       oAuxiliarProductoDTO.CodigoProducto = dataReader["CodigoProducto"].ToString();
                       oListaAuxiliarProducto.Add(oAuxiliarProductoDTO);
                   }
               }
               return oListaAuxiliarProducto;
           }
           catch (Exception ex)
           {
               new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
               return new List<AuxiliarProductoDTO>();
               
           }
       }

       public eResultado AuxiliarProductoInsert(AuxiliarProductoDTO oAuxiliarProductoDTO)
       {
           try
           {


               Database db = DatabaseFactory.CreateDatabase();
               DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarProductoInsertar",
                   new object[]
                {
                    oAuxiliarProductoDTO.IdProducto,
                    oAuxiliarProductoDTO.IdAuxiliar,
                    oAuxiliarProductoDTO.IdObra,
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

       public eResultado AuxiliarProductoDelete(int IdProductoAuxiliar)
       {
           try
           {


               Database db = DatabaseFactory.CreateDatabase();
               DbCommand dbCommand = db.GetStoredProcCommand("PRO_AuxiliarProductoEliminar",
                   new object[]
                {
                    IdProductoAuxiliar
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
