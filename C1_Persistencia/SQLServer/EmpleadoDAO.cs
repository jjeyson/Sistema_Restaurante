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
    public class EmpleadoDAO : IEmpleadoDAO
    {
        #region Singleton
        private static readonly EmpleadoDAO _instancia = new EmpleadoDAO();
        public static EmpleadoDAO Instancia
        {
            get { return EmpleadoDAO._instancia; }
        }
        #endregion Singleton
    }
}
