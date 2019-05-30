using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Contratos;

namespace C1_Persistencia.FabricaDAO
{
    public abstract class FabricaAbstractaDAO
    {
        public static FabricaAbstractaDAO getInstancia()
        {
            Type tipoFabricaDAO = Type.GetType(C1_Persistencia.FabricaDAO.Parametros.Default.claseFabricaDAO);
            FabricaAbstractaDAO fabricaDAO = (FabricaAbstractaDAO)Activator.CreateInstance(tipoFabricaDAO);
            return fabricaDAO;
        }
        public abstract IClienteDAO crearClienteDAO();
        public abstract IDetallePedidoDAO crearDetallePedidoDAO();
        public abstract IEmpleadoDAO crearEmpleadoDAO();
        public abstract ILoginDAO crearLoginDAO();
        public abstract IMesaDAO crearMesaDAO();
        public abstract IPagoDAO crearPagoDAO();
        public abstract IPedidoDAO crearPedidoDAO();
        public abstract IProductoDAO crearProductoDAO();
        public abstract ITipoComprobanteDAO crearTipoComprobanteDAO();
        public abstract ITipoEmpleadoDAO crearTipoEmpleadoDAO();
        public abstract ITipoProductoDAO crearTipoProductoDAO();
    }
}
