using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoDiaCancionCriolla : ICalcularDescuentoDiaCancionCriolla
    {
        public Double calcularDescuentoDiaCancionCriolla(DateTime fecha, List<DetallePedido> listadp)
        {
            Double descuento = 0;
            if (fecha.Month == 10 && fecha.Day >= 30 && fecha.Day <= 31)
            {
                foreach (DetallePedido dp in listadp) if (dp.producto.tipoProducto.descripcion.Equals("Plato Criollo"))
                        descuento += dp.producto.precio * dp.cantidad * 0.15;
            }
            return descuento;
        }
    }
}
