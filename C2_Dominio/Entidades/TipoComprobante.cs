using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class TipoComprobante
    {
        // Atributos persistentes
        public int id { set; get; }
        public String descripcion { set; get; }
        public Double igv { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares
        public List<Pago> listaPago { set; get; }
    }
}
