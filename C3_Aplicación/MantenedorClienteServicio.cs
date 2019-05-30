using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C1_Persistencia.FabricaDAO;
using C2_Dominio.Entidades;
using C2_Dominio.Contratos;

namespace C3_Aplicación
{
    public class MantenedorClienteServicio
    {
        private IClienteDAO clienteDAO;
        public MantenedorClienteServicio()
        {
            FabricaAbstractaDAO fabricaAbstractaDAO = FabricaAbstractaDAO.getInstancia();
            clienteDAO = fabricaAbstractaDAO.crearClienteDAO();
        }
        #region Singleton
        private static readonly MantenedorClienteServicio _instancia = new MantenedorClienteServicio();
        public static MantenedorClienteServicio Instancia
        {
            get { return MantenedorClienteServicio._instancia; }
        }
        #endregion Singleton
        public List<Cliente> listarCliente()
        {
            try
            {
                return clienteDAO.ADM_listarCliente();
            }
            catch (Exception e) { throw e; }
        }
        public Boolean insertarCliente(Cliente c)
        {
            try
            {
                if (c.correoElectronico.Equals("") || c.correoElectronico == String.Empty)
                {
                    throw new ApplicationException("Se debe ingresar correo electronico");
                }

                else if (c.direccion.Equals("") || c.direccion == String.Empty)
                {
                    throw new ApplicationException("Se debe ingresar direccion");
                }
                else if (c.esEmpresa.Equals(""))    ///  || c.esEmpresa == bool.Equals)
                {
                    throw new ApplicationException("Se debe ingresar esEmpresa");
                }
                else if (c.fechaNacimiento.Equals(""))   // || c.fechaNacimiento == DateTime.Equals)
                {
                    throw new ApplicationException("Se debe ingresar fechaNacimiento");
                }
                else if (c.fechaRegistro.Equals(""))   // || c.fechaNacimiento == DateTime.Equals)
                {
                    throw new ApplicationException("Se debe ingresar fechaRegistro");
                }
                else if (c.habilitado.Equals(""))   // || c.fechaNacimiento == DateTime.Equals)
                {
                    throw new ApplicationException("Se debe marcar");
                }
                else if (c.dni.Equals("") || c.dni == String.Empty)
                {
                    throw new ApplicationException("Se debe ingresar el dni");
                }
                else if (c.razonSocial.Equals("") || c.razonSocial == String.Empty)
                {
                    throw new ApplicationException("Se debe ingresar la razonSocial");
                }
                else if (c.nombre.Equals("") || c.nombre == String.Empty)
                {
                    throw new ApplicationException("Se debe ingresar nombre");
                }
                else if (c.ruc.Equals("") || c.ruc == String.Empty)
                {
                    throw new ApplicationException("Se debe ingresar ruc");
                }
                return clienteDAO.ADM_registrarCliente(c);
            }
            catch (AppDomainUnloadedException ae) { throw ae; }
            catch (Exception e) { throw e; }
        }
    
        public Cliente buscarCliente(String dni)
        {
            try
            {
                return clienteDAO.ADM_buscarCliente(dni);

            }
            catch (Exception e) { throw e; }
        }

        public Cliente  devolverCliente(String  dni)
        {
            try
            {
                return clienteDAO.CU06_devolverCliente(dni);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean editarCliente(Cliente c)
        {
            try
            {
                return clienteDAO.ADM_editarCliente(c);
                
            }
            catch (Exception e) { throw e; }
        }  
    }
}        

