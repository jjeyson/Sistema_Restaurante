using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class CalcularImpuestoSubTotalIGV : ICalcularImpuestoSubTotalIGV
    {
        public Double calcularImpuestoSubTotalIGV(Double pagoTotal, TipoComprobante tc)
        {
            if (tc.descripcion.Equals("Factura"))
                return Math.Round(pagoTotal / (1 + tc.igv), 2);
            else
                return 0;
        }
    }
}
