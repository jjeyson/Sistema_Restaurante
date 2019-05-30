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
    public class GestionarPagoServicio
    {
        private IPagoDAO pagoDAO;
        private IClienteDAO clienteDAO;
        private IDetallePedidoDAO detallePedidoDAO;
        private ITipoComprobanteDAO tipoComprobanteDAO;
        private IMesaDAO mesaDAO;
        private IPedidoDAO pedidoDAO;
        public GestionarPagoServicio()
        {
            FabricaAbstractaDAO fabricaAbstractaDAO = FabricaAbstractaDAO.getInstancia();
            pagoDAO = fabricaAbstractaDAO.crearPagoDAO();
            clienteDAO = fabricaAbstractaDAO.crearClienteDAO();
            detallePedidoDAO = fabricaAbstractaDAO.crearDetallePedidoDAO();
            tipoComprobanteDAO = fabricaAbstractaDAO.crearTipoComprobanteDAO();
            mesaDAO = fabricaAbstractaDAO.crearMesaDAO();
            pedidoDAO = fabricaAbstractaDAO.crearPedidoDAO();
        }
        #region Singleton
        private static readonly GestionarPagoServicio _instancia = new GestionarPagoServicio();
        public static GestionarPagoServicio Instancia
        {
            get { return GestionarPagoServicio._instancia; }
        }
        #endregion Singleton
        public TipoComprobante buscarTipoComprobante(int id)
        {
            try
            {
                return tipoComprobanteDAO.ADM_buscarTipoComprobante(id);
            }
            catch (Exception ex) { throw ex; }
        }
        public Boolean registrarPago(Pago pago)
        {
            try
            {
                return pagoDAO.ADM_registrarPago(pago);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Mesa> listarMesaOcupada()
        {
            try
            {
                return mesaDAO.CU02_listarMesaOcupada();
            }
            catch (Exception ex) { throw ex; }
        }
        public Cliente buscarCliente(String dni)
        {
            try
            {
                return clienteDAO.ADM_buscarCliente(dni);
            }
            catch (Exception ex) { throw ex; }
        }
        public Pedido buscarPedidoMesaNoPagado(int idMesa)
        {
            try
            {
                return pedidoDAO.CU02_buscarPedidoMesaNoPagado(idMesa);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<DetallePedido> listarDetallePedidoMesa(int idPedido)
        {
            try
            {
                return detallePedidoDAO.CU02_listarDetallePedidoMesa(idPedido);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<TipoComprobante> listarTipoComprobanteHabilitado()
        {
            try
            {
                return tipoComprobanteDAO.CU02_listarTipoComprobanteHabilitado();
            }
            catch (Exception ex) { throw ex; }
        }
        public Boolean registrarCliente(Cliente cliente)
        {
            try
            {
                return clienteDAO.ADM_registrarCliente(cliente);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
