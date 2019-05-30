using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface IProductoDAO
    {
        CAT_ProductoCollection_CE CU01_GetByCategoria_ID(int Categoria_ID);
    }
}
