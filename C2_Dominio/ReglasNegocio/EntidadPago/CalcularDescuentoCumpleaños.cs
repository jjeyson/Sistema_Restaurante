using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularDescuentoCumpleaños : ICalcularDescuentoCumpleaños
    {
        public Double calcularDescuentoCumpleaños(Double subTotal, Cliente cliente)
        {
            if (cliente.verificarHoyCumpleaños())
                return subTotal * 0.2;
            else
                return 0;
        }
    }
}
