using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoMenu : ICalcularDescuentoMenu
    {
        public Double calcularDescuentoMenu(Double subTotal, List<DetallePedido> listadp)
        {
            List<TipoProducto> listaTemporal = new List<TipoProducto>();
            TipoProducto itemTemporal;
            foreach (DetallePedido dp in listadp)
            {
                itemTemporal = new TipoProducto();
                itemTemporal.id = dp.producto.tipoProducto.id;
                listaTemporal.Add(itemTemporal);
            }
            listaTemporal.Distinct();
            if (listaTemporal.Count() >= 3)
                return subTotal * 0.05;
            else
                return 0;
        }
    }
}
