using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.ReglasNegocio.EntidadPago.Estrategia
{
    public interface ICalcularRecargoTarjeta
    {
        Double calcularRecargoTarjeta(Boolean conTarjeta, Double subTotal);
    }
}
