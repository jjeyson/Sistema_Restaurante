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
    public class PagoDAO : IPagoDAO
    {
        #region Singleton
        private static readonly PagoDAO _instancia = new PagoDAO();
        public static PagoDAO Instancia
        {
            get { return PagoDAO._instancia; }
        }
        #endregion Singleton
        public Boolean ADM_registrarPago(Pago pago)
        {
            SqlCommand cmd = null;
            Boolean validacion = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_registrarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmdatfecha", DateTime.Today);
                cmd.Parameters.AddWithValue("@prmintidTipoComprobante", pago.tipoComprobante.id);
                cmd.Parameters.AddWithValue("@prmstrdni", pago.cliente.dni);
                cmd.Parameters.AddWithValue("@prmintidPedido", pago.pedido.id);
                cmd.Parameters.AddWithValue("@prmintidMesa", pago.pedido.mesa.id);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0) validacion = true;
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return validacion;
        }
        public List<Pago> CU08_RankingConsumoCliente(int cantidad, double montominimo)
        {
            SqlCommand cmd = null;
            List<Pago> lista = new List<Pago>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU08_RankingConsumoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prointcantidad", cantidad);
                cmd.Parameters.AddWithValue("@prodecimalCantidadMinima", montominimo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pago p = new Pago();
                    p.pagoTotal = Convert.ToDouble(dr["total"].ToString());
                    Cliente c = new Cliente();
                    c.dni = dr["dni"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.ruc = dr["ruc"].ToString();
                    c.razonSocial = dr["razonSocial"].ToString();
                    TipoComprobante tc = new TipoComprobante();
                    tc.descripcion = dr["descripcion"].ToString();
                    p.cliente = c;
                    p.tipoComprobante = tc;
                    lista.Add(p);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public List<Pago> CU07_ReporteNivelVentasB(DateTime fechaInicioBuscar, DateTime fechaFinalBuscar)
        {
            SqlCommand cmd = null;
            List<Pago> lista = new List<Pago>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU07_ReporteNivelVentasB", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@profechaInicio", fechaInicioBuscar);
                cmd.Parameters.AddWithValue("@profechafinal", fechaFinalBuscar);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pago p = new Pago();
                    p.fecha = Convert.ToDateTime(dr["fecha"]);
                    p.pagoTotal = Convert.ToDouble(dr["total"]);
                    TipoComprobante tc = new TipoComprobante();
                    tc.descripcion = dr["descripcion"].ToString();
                    p.tipoComprobante = tc;
                    Cliente C = new Cliente();
                    C.dni = dr["dni"].ToString();
                    C.nombre = dr["nombre"].ToString();
                    C.ruc = dr["ruc"].ToString();
                    C.razonSocial = dr["razonSocial"].ToString();
                    p.cliente = C;
                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
    }
}
