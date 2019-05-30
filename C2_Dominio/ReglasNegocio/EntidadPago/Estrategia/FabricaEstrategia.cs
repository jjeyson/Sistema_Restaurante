using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.ReglasNegocio.EntidadPago.Estrategia
{
    public abstract class FabricaEstrategia
    {
        public static FabricaEstrategia getInstancia()
        {
            Type tipoFabricaEstrategia = Type.GetType(C2_Dominio.ReglasNegocio.EntidadPago.Estrategia.Parametros.Default.claseEstrategiaPago);
            FabricaEstrategia fabricaEstrategiaPago = (FabricaEstrategia)Activator.CreateInstance(tipoFabricaEstrategia);
            return fabricaEstrategiaPago;
        }
        public abstract ICalcularRecargoTarjeta crearCalcularRecargoTarjeta();
        public abstract ICalcularDescuentoFestivalMarinera crearCalcularDescuentoFestivalMarinera();
        public abstract ICalcularDescuentoSemanaPiscoSour crearCalcularDescuentoSemanaPiscoSour();
        public abstract ICalcularDescuentoDiaPolloBrasa crearCalcularDescuentoDiaPolloBrasa();
        public abstract ICalcularDescuentoFiestasPatrias crearCalcularDescuentoFiestasPatrias();
        public abstract ICalcularDescuentoDiaCancionCriolla crearCalcularDescuentoDiaCancionCriolla();
        public abstract ICalcularDescuentoFundacionTrujillo crearCalcularDescuentoFundacionTrujillo();
        public abstract ICalcularDescuentoCumpleaños crearCalcularDescuentoCumpleaños();
        public abstract ICalcularDescuentoMenu crearCalcularDescuentoMenu();
        public abstract ICalcularImpuestoSubTotalIGV crearCalcularImpuestoSubTotalIGV();
        public abstract ICalcularImpuestoIGV crearCalcularImpuestoIGV();
    }
}
