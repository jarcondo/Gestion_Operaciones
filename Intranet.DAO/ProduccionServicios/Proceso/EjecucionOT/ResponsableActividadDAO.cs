using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Intranet.DTO.Global;
using Intranet.DTO.ProduccionServicios;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Intranet.DAO.SGE;
using Intranet.DTO.SGE;
using Intranet.DTO.ProduccionServicios.Maestras;
using Intranet.DTO.ProduccionServicios.Procesos;
namespace Intranet.DAO.ProduccionServicios.Proceso
{ 
    public class ResponsableActividadDAO
    {
        public List<ResponsableActividadDTO> GetResponsableActividad(int IdObra,string CodMap)
        {
            try
            {


                List<ResponsableActividadDTO> olResponsableActividad = new List<ResponsableActividadDTO>();
                ResponsableActividadDTO oResponsableActividad = new ResponsableActividadDTO();

                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableActividadObtenerDetalle", new object[]
                {
                    IdObra,CodMap
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oResponsableActividad = new ResponsableActividadDTO();
                        //oResponsableActividad.IdResponsableActividad = Convert.ToInt32(dataReader["IdResponsableActividad"].ToString());

                        ActividadDTO oActividad = new ActividadDTO();
                        oActividad.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                        oActividad.CodigoActividad = dataReader["CodigoActividad"].ToString();
                        oActividad.Descripcion1 = dataReader["Descripcion1"].ToString();
                        oActividad.Descripcion2 = dataReader["Descripcion2"].ToString();
                        ObraDTO oObra = new ObraDTO();
                        oObra.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                        oActividad.Obra = oObra;
                        oResponsableActividad.Actividad = oActividad;

                        GenericaDTO oArea = new GenericaDTO();
                        oArea.IdGenerica = Convert.ToInt32(dataReader["IdGenerica"].ToString());
                        oArea.A1 = dataReader["A1"].ToString();
                        oArea.A2 = dataReader["A2"].ToString();
                        oResponsableActividad.Area = oArea;

                        EmpleadoDTO oEmpleado = new EmpleadoDTO();
                        oEmpleado.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                        oEmpleado.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString();
                        oEmpleado.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oResponsableActividad.Responsable = oEmpleado;
                        olResponsableActividad.Add(oResponsableActividad);
                    }
                }

                return olResponsableActividad;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return new List<ResponsableActividadDTO>();
            }
        }

        public List<ResponsableActividadDTO> ObtenerResponsableActividad(int IdObra)
        {
            try
            {
                List<ResponsableActividadDTO> olResponsableActividad = new List<ResponsableActividadDTO>();
                ResponsableActividadDTO oResponsableActividad = new ResponsableActividadDTO();

                Database db = DatabaseFactory.CreateDatabase();

                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableActividad_Obtener", new object[]
                {
                    IdObra,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        oResponsableActividad = new ResponsableActividadDTO();
                        oResponsableActividad.IdResponsableActividad = Convert.ToInt32(dataReader["IdResponsableActividad"].ToString());

                        ActividadDTO oActividad = new ActividadDTO();
                        oActividad.IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString());
                        oActividad.CodigoActividad = dataReader["CodigoActividad"].ToString();
                        oActividad.Descripcion1 = dataReader["Descripcion1"].ToString();
                        oActividad.Descripcion2 = dataReader["Descripcion2"].ToString();
                        ObraDTO oObra = new ObraDTO();
                        oObra.IdObra = Convert.ToInt32(dataReader["IdObra"].ToString());
                        oActividad.Obra = oObra;
                        oResponsableActividad.Actividad = oActividad;

                        GenericaDTO oArea = new GenericaDTO();
                        oArea.IdGenerica = Convert.ToInt32(dataReader["IdGenerica"].ToString());
                        oArea.A1 = dataReader["A1"].ToString();
                        oArea.A2 = dataReader["A2"].ToString();
                        oResponsableActividad.Area = oArea;

                        EmpleadoDTO oEmpleado = new EmpleadoDTO();
                        oEmpleado.IdEmpleado = Convert.ToInt32(dataReader["IdEmpleado"].ToString());
                        oEmpleado.CodigoEmpleado = dataReader["CodigoEmpleado"].ToString();
                        oEmpleado.NombresApellidos = dataReader["NombresApellidos"].ToString();
                        oResponsableActividad.Responsable = oEmpleado;
                        olResponsableActividad.Add(oResponsableActividad);
                    }
                }

                return olResponsableActividad;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return new List<ResponsableActividadDTO>();
            }
        }

        public ResponsableActividadDTO ObtenerResponsableActividadPorID(int IdRespAct)
        {
            try
            {
                ResponsableActividadDTO oResponsableActividad = new ResponsableActividadDTO();

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableActividad_ObtenerPorID", new object[]
                {
                    IdRespAct,
                });
                using (IDataReader dataReader = db.ExecuteReader(dbCommand))
                {
                    if (dataReader.Read())
                    {
                        oResponsableActividad = new ResponsableActividadDTO();
                        oResponsableActividad.IdResponsableActividad = Convert.ToInt32(dataReader["IdResponsableActividad"].ToString());

                        oResponsableActividad.Actividad = new ActividadDTO()
                        {
                            IdActividad = Convert.ToInt32(dataReader["IdActividad"].ToString()),
                        };

                        oResponsableActividad.Area = new GenericaDTO()
                        {
                            IdGenerica = Convert.ToInt32(dataReader["IdArea"].ToString()),
                        };

                        oResponsableActividad.Responsable = new EmpleadoDTO()
                        {
                            IdEmpleado = Convert.ToInt32(dataReader["IdResponsable"].ToString()),
                        };
                    }
                }

                return oResponsableActividad;
            }
            catch (Exception ex)
            {
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return new ResponsableActividadDTO();
            }
        }

        public eResultado InsertarResponsableActividad(ResponsableActividadDTO oResponsableActividad, int Usuario)
        {
            try
            {


                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableActividad_Insert",
                    new object[]
                {
                    oResponsableActividad.Actividad.IdActividad,
  	                oResponsableActividad.Area.IdGenerica,
  	                oResponsableActividad.Responsable.IdEmpleado,
  	                Usuario,
  	                DateTime.Now
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return eResultado.Error;
            }
        }

        public eResultado ActualizarResponsableActividad(ResponsableActividadDTO oResponsableActividad, int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableActividad_Update",
                    new object[]
                {
                    oResponsableActividad.IdResponsableActividad,
                    oResponsableActividad.Actividad.IdActividad,
  	                oResponsableActividad.Area.IdGenerica,
  	                oResponsableActividad.Responsable.IdEmpleado,
  	                Usuario,
  	                DateTime.Now
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return eResultado.Error;
            }
        }

        public eResultado EliminarResponsableActividad(int IdResponsableActividad, int Usuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("PRO_ResponsableActividad_Delete",
                    new object[]
                {
                    IdResponsableActividad,
                    Usuario,
                    DateTime.Now
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
                new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK, Title = "Intranet" });
                return eResultado.Error;
            }
        }
    }
}
