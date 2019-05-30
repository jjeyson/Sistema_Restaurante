using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C1_Persistencia.FabricaDAO;
using C2_Dominio.Contratos;
using C2_Dominio.Entidades;

namespace C3_Aplicación
{
    public class LoginServicio
    {
        private ILoginDAO loginDAO;
        public LoginServicio()
        {
            FabricaAbstractaDAO fabricaAbstractaDAO = FabricaAbstractaDAO.getInstancia();
            loginDAO = fabricaAbstractaDAO.crearLoginDAO();
        }
        #region Singleton
        private static readonly LoginServicio _instancia = new LoginServicio();
        public static LoginServicio Instancia
        {
            get { return LoginServicio._instancia; }
        }
        #endregion Singleton
        public Login verificarAccesoEmpleado(String usu, String pass)
        {
            try
            {
                return loginDAO.CU09_verificarAccesoEmpleado(usu, pass);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
