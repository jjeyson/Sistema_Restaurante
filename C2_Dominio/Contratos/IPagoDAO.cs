using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface IPagoDAO
    {
        Boolean ADM_registrarPago(Pago pago);
        List<Pago> CU08_RankingConsumoCliente(int cantidad, double montominimo);
        List<Pago> CU07_ReporteNivelVentasB(DateTime fechaInicioBuscar, DateTime fechaFinalBuscar);
    }
}
