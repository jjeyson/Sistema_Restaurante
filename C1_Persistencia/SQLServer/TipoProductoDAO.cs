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
    public class TipoProductoDAO : ITipoProductoDAO
    {
        #region Singleton
        private static readonly TipoProductoDAO _instancia = new TipoProductoDAO();
        public static TipoProductoDAO Instancia
        {
            get { return TipoProductoDAO._instancia; }
        }
        #endregion Singleton
        public CAT_CategoriaCollection_CE CU01_uspTipoProductoGetAll(string cadena)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CAT_CategoriaCollection_CE Lista = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU01_uspTipoProductoGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cadena", cadena);
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();
                Lista = new CAT_CategoriaCollection_CE();
                while (dr.Read())
                {
                    TipoProducto obj = new TipoProducto();
                    obj.id = Convert.ToInt32(dr["id"]);
                    obj.descripcion = dr["descripcion"].ToString();
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dr = null;
                cmd.Dispose();
                cmd.Connection.Close();
                cmd = null;
            }
        }
    }
}
