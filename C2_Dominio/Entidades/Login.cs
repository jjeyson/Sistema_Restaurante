using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class Login
    {
        public String dniEmpleado { set; get; }
        public String nombreEmpleado { set; get; }
        public String contrasena { set; get; }
        public String usuario { set; get; }
        public Boolean empHabilitado { set; get; }
        public Boolean tipoEmpHabilitado { set; get; }
        public String tipoEmpleado { set; get; }

        #region reglas_negocio
        public Boolean usuarioNulo(String usu)
        {
            if (usu.Trim().Length == 0) return true; else return false;
        }
        public Boolean contrasenaNulo(String pass)
        {
            if (pass.Trim().Length == 0) return true; else return false;
        }
        #endregion
    }
}
