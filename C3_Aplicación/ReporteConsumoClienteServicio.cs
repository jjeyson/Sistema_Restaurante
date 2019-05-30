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
    public class ReporteConsumoClienteServicio
    {
        private IPagoDAO pagoDAO;
        public ReporteConsumoClienteServicio()
        {
            FabricaAbstractaDAO fabricaAbstractaDAO = FabricaAbstractaDAO.getInstancia();
            pagoDAO = fabricaAbstractaDAO.crearPagoDAO();
        }
        #region Singleton
        private static readonly ReporteConsumoClienteServicio _instancia = new ReporteConsumoClienteServicio();
        public static ReporteConsumoClienteServicio Instancia
        {
            get { return ReporteConsumoClienteServicio._instancia; }
        }
        #endregion Singleton
        public List<Pago> RankingConsumoCliente(int cantidad, double montominimo)
        {
            try
            {
                return pagoDAO.CU08_RankingConsumoCliente(cantidad, montominimo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
