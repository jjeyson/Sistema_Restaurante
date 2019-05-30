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
    public class ProductoDAO : IProductoDAO
    {
        #region Singleton
        private static readonly ProductoDAO _instancia = new ProductoDAO();
        public static ProductoDAO Instancia
        {
            get { return ProductoDAO._instancia; }
        }
        #endregion Singleton
        public CAT_ProductoCollection_CE CU01_GetByCategoria_ID(int Categoria_ID)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            CAT_ProductoCollection_CE lista = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU01_GetByCategoria_ID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Categoria_ID", Categoria_ID);
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();
                lista = new CAT_ProductoCollection_CE();
                while (dr.Read())
                {
                    Producto obj = new Producto();
                    obj.id = Convert.ToInt32(dr["id"]);
                    obj.descripcion = dr["descripcion"].ToString();
                    obj.cantidadDisponible = Convert.ToInt32(dr["cantidadDisponible"]);
                    obj.precio = Convert.ToDouble(dr["precio"]);

                    lista.Add(obj);
                }
                return lista;
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
