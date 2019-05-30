using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class Mesa
    {
        // Atributos persistentes
        public int id { set; get; }
        public int cantidadAsientos { set; get; }
        public Boolean disponible { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares

        #region reglas_negocio
        public Boolean consultarHayCapacidad(int cantPersonas) { if(cantPersonas>this.cantidadAsientos) return false; else return true; }
        #endregion reglas_negocio
    }
}
