using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoFiestasPatrias : ICalcularDescuentoFiestasPatrias
    {
        public Double calcularDescuentoFiestasPatrias(DateTime fecha, List<DetallePedido> listadp)
        {
            Double descuento = 0;
            if (fecha.Month == 7 && fecha.Day >= 28 && fecha.Day <= 29)
            {
                foreach (DetallePedido dp in listadp) if (dp.producto.tipoProducto.descripcion.Equals("Plato Criollo"))
                        descuento += dp.producto.precio * dp.cantidad * 0.15;
            }
            return descuento;
        }
    }
}
