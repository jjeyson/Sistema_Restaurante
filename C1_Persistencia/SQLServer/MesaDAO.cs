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
    public class MesaDAO : IMesaDAO
    {
        #region Singleton
        private static readonly MesaDAO _instancia = new MesaDAO();
        public static MesaDAO Instancia
        {
            get { return MesaDAO._instancia; }
        }
        #endregion Singleton
        public List<Mesa> CU02_listarMesaOcupada()
        {
            SqlCommand cmd = null;
            List<Mesa> lista = new List<Mesa>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU02_listarMesaOcupada", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Mesa m = new Mesa();
                    m.id = Convert.ToInt32(dr["id"]);
                    lista.Add(m);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public List<Mesa> CU01_ListarMesaTotal()
        {
            SqlCommand cmd = null;
            List<Mesa> lista = new List<Mesa>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU01_ListarMesaTotal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Mesa c = new Mesa();
                    c.id = Convert.ToInt32(dr["id"]);
                    c.cantidadAsientos = Convert.ToInt32(dr["cantidadAsientos"]);
                    c.disponible = Convert.ToBoolean(dr["disponible"]);
                    c.habilitado = Convert.ToBoolean(dr["habilitado"]);
                    lista.Add(c);
                }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return lista;
        }
    }
}
