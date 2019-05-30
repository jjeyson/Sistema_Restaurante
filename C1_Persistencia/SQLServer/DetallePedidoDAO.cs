using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using C2_Dominio.Entidades;
using C2_Dominio.Contratos;

namespace C1_Persistencia.SQLServer
{
    public class DetallePedidoDAO : IDetallePedidoDAO
    {
        #region Singleton
        private static readonly DetallePedidoDAO _instancia = new DetallePedidoDAO();
        public static DetallePedidoDAO Instancia
        {
            get { return DetallePedidoDAO._instancia; }
        }
        #endregion Singleton
        public Boolean ADM_registrarDetallePedido(DetallePedido dp)
        {
            SqlCommand cmd = null;
            Boolean validacion = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_registrarDetallePedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintcantidad", dp.cantidad);
                cmd.Parameters.AddWithValue("@prmintidproducto", dp.producto.id);
                cmd.Parameters.AddWithValue("@prmintidpedido", dp.pedido.id);
                cmd.Parameters.AddWithValue("@prmbolhabilitado", true);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0) validacion = true;
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return validacion;
        }
        public List<DetallePedido> CU02_listarDetallePedidoMesa(int idPedido)
        {
            SqlCommand cmd = null;
            List<DetallePedido> lista = new List<DetallePedido>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU02_listarDetallePedidoMesa", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidpedido", idPedido);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetallePedido dp = new DetallePedido();
                    dp.id = Convert.ToInt32(dr["id"]);
                    dp.cantidad = Convert.ToInt32(dr["cantidad"]);
                        dp.producto = new Producto();
                        dp.producto.id = Convert.ToInt32(dr["idProducto"]);
                        dp.producto.descripcion = (dr["pdescripcion"]).ToString();
                        dp.producto.precio = Convert.ToDouble(dr["precio"]);
                            dp.producto.tipoProducto = new TipoProducto();
                            dp.producto.tipoProducto.id = Convert.ToInt32(dr["idTipoProducto"]);
                            dp.producto.tipoProducto.descripcion = (dr["tpdescripcion"]).ToString();
                    dp.calcularSubTotal();
                    lista.Add(dp);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public Boolean CU01_registrarListaDetallePedido(List<DetallePedido> lista)
        {
            try
            {
                Boolean validacion = false;
                foreach (DetallePedido dp in lista)
                {
                    validacion = this.ADM_registrarDetallePedido(dp);
                }
                return validacion;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
