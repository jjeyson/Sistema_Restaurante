using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;
using C2_Dominio.Contratos;
using C1_Persistencia.FabricaDAO;

namespace C3_Aplicación
{
    public class GestionarPedidoServicio
    {
        private IMesaDAO mesaDAO;
        private IProductoDAO productoDAO;
        private ITipoProductoDAO tipoProductoDAO;
        private IPedidoDAO pedidoDAO;
        public GestionarPedidoServicio()
        {
            FabricaAbstractaDAO fabricaAbstractaDAO = FabricaAbstractaDAO.getInstancia();
            mesaDAO = fabricaAbstractaDAO.crearMesaDAO();
            productoDAO = fabricaAbstractaDAO.crearProductoDAO();
            tipoProductoDAO = fabricaAbstractaDAO.crearTipoProductoDAO();
            pedidoDAO = fabricaAbstractaDAO.crearPedidoDAO();
        }
        #region Singleton
        private static readonly GestionarPedidoServicio _instancia = new GestionarPedidoServicio();
        public static GestionarPedidoServicio Instancia
        {
            get { return GestionarPedidoServicio._instancia; }
        }
        #endregion Singleton
        public List<Mesa> ListarMesa()
        {
            try
            {
                return mesaDAO.CU01_ListarMesaTotal();
            }
            catch (Exception e) { throw e; }
        }
        public CAT_ProductoCollection_CE GetByCategoria_ID(int Categoria_ID)
        {
            try
            {
                return productoDAO.CU01_GetByCategoria_ID(Categoria_ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public CAT_CategoriaCollection_CE GetAll(string cadena)
        {
            try
            {
                return tipoProductoDAO.CU01_uspTipoProductoGetAll(cadena);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Pedido(Pedido obj, Empleado obj1)
        {
            string cadenaXML = "<?xml version = '1.0' encoding = 'windows-1252'?>";
            cadenaXML += "<ROOT>";
            cadenaXML += "<Mesa ";
            cadenaXML += "IdMesa = '" + obj.id + "' >";
            cadenaXML += "</Mesa>";
            cadenaXML += "<DEL_Delivery ";
            cadenaXML += "idEmpleado = '" + obj1.dni.ToString() + "' ";
            cadenaXML += "idMesa = '" + obj.id.ToString() + "' >";
            foreach (DetallePedido o in obj.DEL_DeliveryDetCollection)
            {
                cadenaXML += "<DEL_DeliveryDet ";
                cadenaXML += "Producto_ID = '" + o.producto.id.ToString() + "' ";
                //cadenaXML += "Cant = '" + o.cantidad.ToString() + "' ";
                cadenaXML += "cantidad = '" + o.cantidad.ToString() + "' >";
                cadenaXML += "</DEL_DeliveryDet>";
            }
            cadenaXML += "</DEL_Delivery>";
            cadenaXML += "</ROOT>";
            try
            {
                pedidoDAO.CU01_uspGuardarPedido(cadenaXML);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
