using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class TipoEmpleado
    {
        // Atributos persistentes
        public int id { set; get; }
        public String descripcion { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares
        public List<Empleado> listaEmpleado { set; get; }
    }
}
