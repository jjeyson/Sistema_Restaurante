using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class Pedido
    {
        // Atributos persistentes
        public int id { set; get; }
        public Boolean pagado { set; get; }
        public Empleado empleado { set; get; }
        public Mesa mesa { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares
        public List<DetallePedido> listaDetallePedido { set; get; }
        public PedidoDetCollection DEL_DeliveryDetCollection { get; set; }
        public int numeroError { set; get; }
        #region metodos
        public double calcularSumatoriaSubTotal()
        {
            double sumatoria = 0;
            foreach (DetallePedido dp in this.listaDetallePedido)
            {
                sumatoria += dp.subTotal;
            }
            return sumatoria;
        }
        #endregion reglas_negocio
    }
}
