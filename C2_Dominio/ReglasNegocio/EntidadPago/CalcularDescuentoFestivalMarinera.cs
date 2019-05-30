using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoFestivalMarinera : ICalcularDescuentoFestivalMarinera
    {
        public Double calcularDescuentoFestivalMarinera(DateTime fecha, List<DetallePedido> listadp)
        {
            Double descuentoFestivalMarinera = 0;
            if (fecha.Month == 1 && fecha.Day >= 24 && fecha.Day <= 31)
            {
                foreach (DetallePedido dp in listadp) if (dp.producto.tipoProducto.descripcion.Equals("Bebida"))
                        descuentoFestivalMarinera += dp.producto.precio * dp.cantidad * 0.1;
                return descuentoFestivalMarinera;
            }
            else
                return 0;
        }
    }
}
