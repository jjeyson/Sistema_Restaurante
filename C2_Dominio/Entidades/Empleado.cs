using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class Empleado
    {
        // Atributos persistentes
        public String dni { set; get; }
        public String nombre { set; get; }
        public String usuario { set; get; }
        public String contrasena { set; get; }
        public String correoElectronico { set; get; }
        public String direccion { set; get; }
        public Boolean habilitado { set; get; }
        public DateTime fechaNacimiento { set; get; }
        public DateTime fechaRegistro { set; get; }
        public TipoEmpleado tipoEmpleado { set; get; }

        // Atributos Auxiliares
    }
}
