using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class DetallePedido
    {
        // Atributos persistentes
        public int id { set; get; }
        public int cantidad { set; get; }
        public Producto producto { set; get; }
        public Pedido pedido { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares
        public Double subTotal { set; get; }
        public void calcularSubTotal()
        {
            this.subTotal = this.cantidad * this.producto.precio;
        }
    }
    public sealed class PedidoDetCollection : List<DetallePedido>
    {
    }
}
