using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Contratos;
using C1_Persistencia.FabricaDAO;

namespace C1_Persistencia.SQLServer
{
    public class FabricaDAOSQL : FabricaAbstractaDAO
    {
        override
        public IClienteDAO crearClienteDAO()
        {
            return new ClienteDAO();
        }
        override
        public IDetallePedidoDAO crearDetallePedidoDAO()
        {
            return new DetallePedidoDAO();
        }
        override
        public IEmpleadoDAO crearEmpleadoDAO()
        {
            return new EmpleadoDAO();
        }
        override
        public ILoginDAO crearLoginDAO()
        {
            return new LoginDAO();
        }
        override
        public IMesaDAO crearMesaDAO()
        {
            return new MesaDAO();
        }
        override
        public IPagoDAO crearPagoDAO()
        {
            return new PagoDAO();
        }
        override
        public IPedidoDAO crearPedidoDAO()
        {
            return new PedidoDAO();
        }
        override
        public IProductoDAO crearProductoDAO()
        {
            return new ProductoDAO();
        }
        override
        public ITipoComprobanteDAO crearTipoComprobanteDAO()
        {
            return new TipoComprobanteDAO();
        }
        override
        public ITipoEmpleadoDAO crearTipoEmpleadoDAO()
        {
            return new TipoEmpleadoDAO();
        }
        override
        public ITipoProductoDAO crearTipoProductoDAO()
        {
            return new TipoProductoDAO();
        }
    }
}
