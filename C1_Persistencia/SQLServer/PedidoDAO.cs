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
    public class PedidoDAO : IPedidoDAO
    {
        #region Singleton
        private static readonly PedidoDAO _instancia = new PedidoDAO();
        public static PedidoDAO Instancia
        {
            get { return PedidoDAO._instancia; }
        }
        #endregion Singleton
        public Pedido CU02_buscarPedidoMesaNoPagado(int idMesa)
        {
            SqlCommand cmd = null;
            Pedido p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU02_buscarPedidoMesaNoPagado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidmesa", idMesa);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new Pedido();
                    p.id = Convert.ToInt32(dr["id"]);
                        p.empleado = new Empleado();
                        p.empleado.dni = dr["idEmpleado"].ToString();
                        p.mesa = new Mesa();
                        p.mesa.id = Convert.ToInt32(dr["idMesa"]);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return p;
        }
        public void CU01_uspGuardarPedido(string cadenaXML)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU01_uspGuardarPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cadenaXML", cadenaXML);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Close();
                cmd = null;
            }
        }
    }
}
