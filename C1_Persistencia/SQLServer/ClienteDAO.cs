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
    public class ClienteDAO : IClienteDAO
    {
        #region Singleton
        private static readonly ClienteDAO _instancia = new ClienteDAO();
        public static ClienteDAO Instancia
        {
            get { return ClienteDAO._instancia; }
        }
        #endregion Singleton
        public Cliente ADM_buscarCliente(String dni)
        {
            SqlCommand cmd = null;
            Cliente c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_buscarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrdni", dni);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = new Cliente();
                    c.dni = dr["dni"].ToString();
                    c.ruc = dr["ruc"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.razonSocial = dr["razonSocial"].ToString();
                    c.correoElectronico = dr["correoElectronico"].ToString();
                    c.esEmpresa = Convert.ToBoolean(dr["esEmpresa"]);
                    c.direccion = dr["direccion"].ToString();
                    c.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                    c.fechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]);
                    c.habilitado = Convert.ToBoolean(dr["habilitado"]);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return c;
        }
        public List<Cliente> ADM_listarCliente()
        {
            SqlCommand cmd = null;
            List<Cliente> lista = new List<Cliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_listarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente();
                    c.habilitado = Convert.ToBoolean(dr["habilitado"]);
                    c.dni = dr["dni"].ToString();
                    c.ruc = dr["ruc"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.razonSocial = dr["razonSocial"].ToString();
                    c.correoElectronico = dr["correoElectronico"].ToString();
                    c.esEmpresa = Convert.ToBoolean(dr["esEmpresa"]);
                    c.direccion = dr["direccion"].ToString();
                    c.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                    c.fechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]);
                    lista.Add(c);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public Boolean ADM_registrarCliente(Cliente cliente)
        {
            SqlCommand cmd = null;
            Boolean validacion = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_registrarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrdni", cliente.dni);
                cmd.Parameters.AddWithValue("@prmstrruc", cliente.ruc);
                cmd.Parameters.AddWithValue("@prmstrnombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@prmstrrazonSocial", cliente.razonSocial);
                cmd.Parameters.AddWithValue("@prmstrcorreoElectronico", cliente.correoElectronico);
                cmd.Parameters.AddWithValue("@prmbolesEmpresa", cliente.esEmpresa);
                cmd.Parameters.AddWithValue("@prmstrdireccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@prmdatefechaNacimiento", cliente.fechaNacimiento);
                cmd.Parameters.AddWithValue("@prmdatefechaRegistro", DateTime.Today);
                cmd.Parameters.AddWithValue("@prmbolhabilitado", true);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0) validacion = true;
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return validacion;
        }
        public Boolean ADM_editarCliente(Cliente cliente)
        {
            SqlCommand cmd = null;
            Boolean validacion = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ADM_editarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrdni", cliente.dni);
                cmd.Parameters.AddWithValue("@prmstrruc", cliente.ruc);
                cmd.Parameters.AddWithValue("@prmstrnombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@prmstrrazonSocial", cliente.razonSocial);
                cmd.Parameters.AddWithValue("@prmstrcorreoElectronico", cliente.correoElectronico);
                cmd.Parameters.AddWithValue("@prmbolesEmpresa", cliente.esEmpresa);
                cmd.Parameters.AddWithValue("@prmstrdireccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@prmdatefechaNacimiento", cliente.fechaNacimiento);
                cmd.Parameters.AddWithValue("@prmdatefechaRegistro", cliente.fechaRegistro);
                cmd.Parameters.AddWithValue("@prmbolhabilitado", cliente.habilitado);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0) validacion = true;
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return validacion;
        }
        public Cliente CU06_devolverCliente(String dni)
        {
            SqlCommand cmd = null;
            Cliente c = new Cliente();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("CU06_devolvercliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prstrdni", dni);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.habilitado = Convert.ToBoolean(dr["habilitado"]);
                    c.dni = dr["dni"].ToString();
                    c.ruc = dr["ruc"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.razonSocial = dr["razonSocial"].ToString();
                    c.correoElectronico = dr["correoElectronico"].ToString();
                    c.esEmpresa = Convert.ToBoolean(dr["esEmpresa"]);
                    c.direccion = dr["direccion"].ToString();
                    c.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                    c.fechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]);

                }
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return c;
        }
    }
}
