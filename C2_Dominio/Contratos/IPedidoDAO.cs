using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface IPedidoDAO
    {
        Pedido CU02_buscarPedidoMesaNoPagado(int idMesa);
        void CU01_uspGuardarPedido(string cadenaXML);
    }
}
