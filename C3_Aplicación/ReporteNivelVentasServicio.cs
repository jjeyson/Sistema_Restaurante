using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C1_Persistencia.FabricaDAO;
using C2_Dominio.Entidades;
using C2_Dominio.Contratos;

namespace C3_Aplicación
{
    public class ReporteNivelVentasServicio
    {
        private IPagoDAO pagoDAO;
        public ReporteNivelVentasServicio()
        {
            FabricaAbstractaDAO fabricaAbstractaDAO = FabricaAbstractaDAO.getInstancia();
            pagoDAO = fabricaAbstractaDAO.crearPagoDAO();
        }
        #region Singleton
        private static readonly ReporteNivelVentasServicio _instancia = new ReporteNivelVentasServicio();
        public static ReporteNivelVentasServicio Instancia
        {
            get { return ReporteNivelVentasServicio._instancia; }
        }
        #endregion Singleton
        public List<Pago> ReporteNivelVentasB(DateTime fechaInicioBuscar, DateTime fechaFinalBuscar)
        {
            try
            {
                return pagoDAO.CU07_ReporteNivelVentasB(fechaInicioBuscar, fechaFinalBuscar);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
