using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularRecargoTarjeta : ICalcularRecargoTarjeta
    {
        public Double calcularRecargoTarjeta(Boolean conTarjeta, Double subTotal)
        {
            if (conTarjeta)
                return Math.Round(subTotal * 0.05, 2);
            else
                return  0;
        }
    }
}
