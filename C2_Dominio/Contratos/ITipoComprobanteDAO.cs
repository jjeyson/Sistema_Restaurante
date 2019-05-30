using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.Contratos
{
    public interface ITipoComprobanteDAO
    {
        TipoComprobante ADM_buscarTipoComprobante(int id);
        List<TipoComprobante> CU02_listarTipoComprobanteHabilitado();
    }
}
