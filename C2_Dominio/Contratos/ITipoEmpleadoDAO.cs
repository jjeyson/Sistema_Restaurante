using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface ITipoEmpleadoDAO
    {
        TipoEmpleado CU02_buscarTipoEmpleado(int id);
    }
}
