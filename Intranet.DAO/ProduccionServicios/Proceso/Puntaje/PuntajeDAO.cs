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
    public class PuntajeDAO
    {
        //Puntaje por fecha y subactividad
        public List<PuntajesDTO> ListarPuntajeDiario(int IdObra, string FechaIni, string FechaFin, int IdResponsable ,int IdCuadrilla)
        {
            try
            {
                List<PuntajesDTO> oListaPuntaje = new List<PuntajesDTO>();
                PuntajesDTO oPuntajeDTO = new PuntajesDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ListarPuntajePorDia",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdResponsable,IdCuadrilla,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oPuntajeDTO = new PuntajesDTO();
                        oPuntajeDTO.numeroorden=dataReader["numeroorden"].ToString();
                        oPuntajeDTO.fechainicio=dataReader["fechainicio"].ToString();
                        oPuntajeDTO.direccion=dataReader["direccion"].ToString();
                        oPuntajeDTO.descripcionsubactividad=dataReader["descripcionsubactividad1"].ToString();
                        oPuntajeDTO.puntaje=Convert.ToDecimal(dataReader["puntaje"].ToString());
                        oPuntajeDTO.cantidad=Convert.ToDecimal(dataReader["cantidad"].ToString());
                        oPuntajeDTO.total=Convert.ToDecimal(dataReader["total"].ToString());
                        oPuntajeDTO.codigocuadrilla = dataReader["codigocuadrilla"].ToString() + ' ' + dataReader["NombresApellidos"].ToString();
                        oPuntajeDTO.descripcioncuadrilla=dataReader["descripcion"].ToString();
                        oPuntajeDTO.NombresApellidos=dataReader["NombresApellidos"].ToString();
                        oPuntajeDTO.unidad = dataReader["unidad"].ToString();
                        oListaPuntaje.Add(oPuntajeDTO);
                    }
                }
                return oListaPuntaje;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<PuntajesDTO>();
            }
        }


        public List<PuntajesDTO> ListarPuntajeFecha(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla)
        {
            try
            {
                List<PuntajesDTO> oListaPuntaje = new List<PuntajesDTO>();
                PuntajesDTO oPuntajeDTO = new PuntajesDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ListarPuntajeFecha",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdResponsable,IdCuadrilla,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oPuntajeDTO = new PuntajesDTO();
                        
                        oPuntajeDTO.fechainicio = dataReader["fechainicio"].ToString();
                        oPuntajeDTO.total = Convert.ToDecimal(dataReader["total"].ToString());
                        oPuntajeDTO.codigocuadrilla = dataReader["codigocuadrilla"].ToString() + ' ' + dataReader["NombresApellidos"].ToString();
                        oPuntajeDTO.descripcioncuadrilla = dataReader["descripcion"].ToString();
                        oPuntajeDTO.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oListaPuntaje.Add(oPuntajeDTO);
                    }
                }
                return oListaPuntaje;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<PuntajesDTO>();
            }
        }



        public List<PuntajesDTO> ListarPuntajeAcumFecha(int IdObra, string FechaIni, string FechaFin, int IdResponsable, int IdCuadrilla)
        {
            try
            {
                List<PuntajesDTO> oListaPuntaje = new List<PuntajesDTO>();
                PuntajesDTO oPuntajeDTO = new PuntajesDTO();
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ListarPuntajeAcumFecha",
                    new object[]
                {
                    IdObra,FechaIni,FechaFin,IdResponsable,IdCuadrilla,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oPuntajeDTO = new PuntajesDTO();

                        
                        oPuntajeDTO.total = Convert.ToDecimal(dataReader["total"].ToString());
                        oPuntajeDTO.codigocuadrilla = dataReader["codigocuadrilla"].ToString() + ' ' + dataReader["NombresApellidos"].ToString();
                        oPuntajeDTO.descripcioncuadrilla = dataReader["descripcion"].ToString();
                        oPuntajeDTO.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oListaPuntaje.Add(oPuntajeDTO);
                    }
                }
                return oListaPuntaje;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = "SMC GESTION DE OPERACIONES", Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return new List<PuntajesDTO>();
            }
        }


    }
}
