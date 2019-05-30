using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoFundacionTrujillo : ICalcularDescuentoFundacionTrujillo
    {
        public Double calcularDescuentoFundacionTrujillo(DateTime fecha, List<DetallePedido> listadp)
        {
            Double descuento = 0;
            if (fecha.Month == 11 && fecha.Day >= 30 && fecha.Day <= 31)
                foreach (DetallePedido dp in listadp)
                    descuento += dp.producto.precio * dp.cantidad * 0.15;
            return descuento;
        }
    }
}
