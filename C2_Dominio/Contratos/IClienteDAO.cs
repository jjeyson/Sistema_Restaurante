using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface IClienteDAO
    {
        Cliente ADM_buscarCliente(String dni);
        List<Cliente> ADM_listarCliente();
        Boolean ADM_registrarCliente(Cliente cliente);
        Boolean ADM_editarCliente(Cliente cliente);
        Cliente CU06_devolverCliente(String dni);
    }
}
