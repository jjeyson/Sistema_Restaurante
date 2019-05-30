using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularImpuestoIGV : ICalcularImpuestoIGV
    {
        public Double calcularImpuestoIGV(Double pagoSubTotalIGV, Double pagoTotal, TipoComprobante tc)
        {
            if (tc.descripcion.Equals("Factura"))
                return pagoTotal - pagoSubTotalIGV;
            else
                return 0;
        }
    }
}
