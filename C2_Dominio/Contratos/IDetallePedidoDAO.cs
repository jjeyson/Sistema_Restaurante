using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface IDetallePedidoDAO
    {
        Boolean ADM_registrarDetallePedido(DetallePedido dp);
        List<DetallePedido> CU02_listarDetallePedidoMesa(int idPedido);
        Boolean CU01_registrarListaDetallePedido(List<DetallePedido> lista);
    }
}
