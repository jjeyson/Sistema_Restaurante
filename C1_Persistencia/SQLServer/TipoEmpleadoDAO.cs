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
    public class TipoEmpleadoDAO : ITipoEmpleadoDAO
    {
        #region Singleton
        private static readonly TipoEmpleadoDAO _instancia = new TipoEmpleadoDAO();
        public static TipoEmpleadoDAO Instancia
        {
            get { return TipoEmpleadoDAO._instancia; }
        }
        #endregion Singleton
        public TipoEmpleado CU02_buscarTipoEmpleado(int id)
        {
            SqlCommand cmd = null;
            TipoEmpleado te = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU02_buscarTipoEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintid", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    te = new TipoEmpleado();
                    te.descripcion = dr["descripcion"].ToString();
                    te.habilitado = Convert.ToBoolean(dr["descripcion"]);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return te;
        }
    }
}
