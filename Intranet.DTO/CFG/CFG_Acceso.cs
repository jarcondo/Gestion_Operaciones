using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.DTO.CFG
{
    public static class AuditoriaCFG
    {
        public static string IdUsuario { get; set; }
        public static RolCFG Rol { get; set; }
        public static string Usuario { get; set; }
        public static string Password { get; set; }
        public static string PeriodoAno { get; set; }
        public static string PeriodoMes { get; set; }
        public static int IdBase { get; set; }
        public static string CodigoBase { get; set; }
        public static string Base { get; set; }
        public static int IdAlmacen { get; set; }
        public static string CodigoAlmacen { get; set; }
        public static string Almacen { get; set; }
        public static int IdDivision { get; set; }
        public static decimal PorcentajeIGV { get; set; }
    }

    public enum eResultadoCFG
    {
        Ninguno,
        Correcto,
        Error,
    }

    public class UsuarioCFG
    {
        public string IdUsuario { get; set; }
        public RolCFG Rol { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string PeriodoAno { get; set; }
        public string PeriodoMes { get; set; }
    }

    public class RolCFG
    {
        public int IdRol { get; set; }
        public string TipoRol { get; set; }

    }

    public class AccesoCFG
    {
        public int IdAcceso { get; set; }
        public int IdRol { get; set; }
        public string TipoRol { get; set; }
        public int IdMenu { get; set; }
        public string Modulo { get; set; }
        public string Proceso { get; set; }
        public string Menu { get; set; }
        //  public MenuCFG Menu { get; set; }
        //  public RolCFG Rol { get; set; }
    }


    public class MenuCFG
    {

        public int IdMenu { get; set; }
        public string Modulo { get; set; }
        public string Proceso { get; set; }
        public string Menu { get; set; }
        public string Objeto { get; set; }
        public string Parametro { get; set; }
        public string Parametro2 { get; set; }
        public string Descripcion { get; set; }
        public string Parametro3 { get; set; }
        public string Parametro4 { get; set; }
        public bool Seleccion { get; set; }

        public string DireccionURL { get; set; }

        public override string ToString()
        {
            return Objeto.ToString();
        }
    }


    public class UsuarioLoginCFG : EventArgs
    {
        public int IdUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public int IdRol { get; set; }
        public string TipoRol { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdBase { get; set; }
        public int IdAlmacen { get; set; }
        public string Base { get; set; }
        public string NombresApellidos { get; set; }
        public string CodigoBase { get; set; }
        public string CodigoAlmacen { get; set; }
        public string Almacen { get; set; }
        public int IdDivision { get; set; }
        public int CentroServicio { get; set; }
        public int NroContrato { get; set; }
        public int IdEmpleado { get; set; }
        public string EstadoCarga { get; set; }
        public string EMPRESA { get; set; }
    }
}
