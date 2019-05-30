using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class Producto
    {
        // Atributos persistentes
        public int id { set; get; }
        public int cantidadDisponible { set; get; }
        public String descripcion { set; get; }
        public Double precio { set; get; }
        public TipoProducto tipoProducto { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares

    }
    public sealed class CAT_ProductoCollection_CE : List<Producto>
    {
    }
}
