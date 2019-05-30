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
    public class TipoComprobanteDAO : ITipoComprobanteDAO
    {
        #region Singleton
        private static readonly TipoComprobanteDAO _instancia = new TipoComprobanteDAO();
        public static TipoComprobanteDAO Instancia
        {
            get { return TipoComprobanteDAO._instancia; }
        }
        #endregion Singleton
        public TipoComprobante ADM_buscarTipoComprobante(int id)
        {
            SqlCommand cmd = null;
            TipoComprobante tc = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_buscarTipoComprobante", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintid", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tc = new TipoComprobante();
                    tc.id = Convert.ToInt32(dr["id"]);
                    tc.descripcion = dr["descripcion"].ToString();
                    tc.igv = Convert.ToDouble(dr["igv"]);
                    tc.habilitado = Convert.ToBoolean(dr["habilitado"]);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return tc;
        }
        public List<TipoComprobante> CU02_listarTipoComprobanteHabilitado()
        {
            SqlCommand cmd = null;
            List<TipoComprobante> lista = new List<TipoComprobante>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU02_listarTipoComprobanteHabilitado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoComprobante tc = new TipoComprobante();
                    tc.id = Convert.ToInt32(dr["id"]);
                    tc.descripcion = dr["descripcion"].ToString();
                    tc.igv = Convert.ToDouble(dr["igv"]);
                    lista.Add(tc);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return lista;
        }
    }
}
