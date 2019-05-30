using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;

namespace C2_Dominio.ReglasNegocio.EntidadPago
{
    public class FabricaPago : FabricaEstrategia
    {
        override
        public ICalcularRecargoTarjeta crearCalcularRecargoTarjeta()
        {
            return new CalcularRecargoTarjeta();
        }
        override
        public ICalcularDescuentoFestivalMarinera crearCalcularDescuentoFestivalMarinera()
        {
            return new CalcularDescuentoFestivalMarinera();
        }
        override
        public ICalcularDescuentoSemanaPiscoSour crearCalcularDescuentoSemanaPiscoSour()
        {
            return new CalcularDescuentoSemanaPiscoSour();
        }
        override
        public ICalcularDescuentoDiaPolloBrasa crearCalcularDescuentoDiaPolloBrasa()
        {
            return new CalcularDescuentoDiaPolloBrasa();
        }
        override
        public ICalcularDescuentoFiestasPatrias crearCalcularDescuentoFiestasPatrias()
        {
            return new CalcularDescuentoFiestasPatrias();
        }
        override
        public ICalcularDescuentoDiaCancionCriolla crearCalcularDescuentoDiaCancionCriolla()
        {
            return new CalcularDescuentoDiaCancionCriolla();
        }
        override
        public ICalcularDescuentoFundacionTrujillo crearCalcularDescuentoFundacionTrujillo()
        {
            return new CalcularDescuentoFundacionTrujillo();
        }
        override
        public ICalcularDescuentoCumpleaños crearCalcularDescuentoCumpleaños()
        {
            return new CalcularDescuentoCumpleaños();
        }
        override
        public ICalcularDescuentoMenu crearCalcularDescuentoMenu()
        {
            return new CalcularDescuentoMenu();
        }
        override
        public ICalcularImpuestoSubTotalIGV crearCalcularImpuestoSubTotalIGV()
        {
            return new CalcularImpuestoSubTotalIGV();
        }
        override
        public ICalcularImpuestoIGV crearCalcularImpuestoIGV()
        {
            return new CalcularImpuestoIGV();
        }
    }
}
