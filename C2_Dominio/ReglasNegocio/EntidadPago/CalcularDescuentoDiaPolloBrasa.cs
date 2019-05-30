using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoDiaPolloBrasa : ICalcularDescuentoDiaPolloBrasa
    {
        public Double calcularDescuentoDiaPolloBrasa(DateTime fecha, List<DetallePedido> listadp)
        {
            if (fecha.Month == 2 && fecha.Day == 21)
            {
                Double descuento = 0;
                foreach (DetallePedido dp in listadp) if (dp.producto.descripcion.Contains("Pollo a la Brasa"))
                        descuento += dp.producto.precio * dp.cantidad * 0.1;
                return descuento;
            }
            else
                return 0;
        }
    }
}