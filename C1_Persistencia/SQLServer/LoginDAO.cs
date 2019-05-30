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
    public class LoginDAO : ILoginDAO
    {
        #region Singleton
        private static readonly LoginDAO _instancia = new LoginDAO();
        public static LoginDAO Instancia
        {
            get { return LoginDAO._instancia; }
        }
        #endregion Singleton

        #region metodos
        public Login CU09_verificarAccesoEmpleado(String usu, String pass)
        {
            SqlCommand cmd = null;
            Login login = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU09_verificarAccesoEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrusuario", usu);
                cmd.Parameters.AddWithValue("@prmstrcontrasena", pass);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    login = new Login();
                    login.dniEmpleado = dr["dni"].ToString();
                    login.usuario = dr["usuario"].ToString();
                    login.contrasena = dr["contrasena"].ToString();
                    login.nombreEmpleado = dr["nombre"].ToString();
                    login.tipoEmpleado = dr["descripcion"].ToString();
                    login.empHabilitado = Convert.ToBoolean(dr["ehabilitado"]);
                    login.tipoEmpHabilitado = Convert.ToBoolean(dr["tehabilitado"]);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return login;
        }
        #endregion metodos
    }
}
