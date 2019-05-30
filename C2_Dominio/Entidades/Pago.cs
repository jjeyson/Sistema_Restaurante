using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.ReglasNegocio.EntidadPago.Estrategia;
using C2_Dominio.ReglasNegocio.EntidadPago;

namespace C2_Dominio.Entidades
{
    public class Pago
    {
        private ICalcularRecargoTarjeta CalcularRT;
        private ICalcularDescuentoFestivalMarinera CalcularDescuentoFM;
        private ICalcularDescuentoSemanaPiscoSour CalcularDescuentoSPS;
        private ICalcularDescuentoDiaPolloBrasa CalcularDescuentoDPB;
        private ICalcularDescuentoFiestasPatrias CalcularDescuentoFP;
        private ICalcularDescuentoDiaCancionCriolla CalcularDescuentoDCC;
        private ICalcularDescuentoFundacionTrujillo CalcularDescuentoFT;
        private ICalcularDescuentoCumpleaños CalcularDescuentoC;
        private ICalcularDescuentoMenu CalcularDescuentoM;
        private ICalcularImpuestoSubTotalIGV CalcularImpuestoSTIGV;
        private ICalcularImpuestoIGV CalcularImpuestoIGV;
        public Pago()
        {
            FabricaEstrategia fabricaEstrategia = FabricaEstrategia.getInstancia();
            CalcularRT = fabricaEstrategia.crearCalcularRecargoTarjeta();
            CalcularDescuentoFM = fabricaEstrategia.crearCalcularDescuentoFestivalMarinera();
            CalcularDescuentoSPS = fabricaEstrategia.crearCalcularDescuentoSemanaPiscoSour();
            CalcularDescuentoDPB = fabricaEstrategia.crearCalcularDescuentoDiaPolloBrasa();
            CalcularDescuentoFP = fabricaEstrategia.crearCalcularDescuentoFiestasPatrias();
            CalcularDescuentoDCC = fabricaEstrategia.crearCalcularDescuentoDiaCancionCriolla();
            CalcularDescuentoFT = fabricaEstrategia.crearCalcularDescuentoFundacionTrujillo();
            CalcularDescuentoC = fabricaEstrategia.crearCalcularDescuentoCumpleaños();
            CalcularDescuentoM = fabricaEstrategia.crearCalcularDescuentoMenu();
            CalcularImpuestoSTIGV = fabricaEstrategia.crearCalcularImpuestoSubTotalIGV();
            CalcularImpuestoIGV = fabricaEstrategia.crearCalcularImpuestoIGV();
        }
        // Atributos persistentes
        public int id { set; get; }
        public DateTime fecha { set; get; }
        public TipoComprobante tipoComprobante { set; get; }
        public Cliente cliente { set; get; }
        public Pedido pedido { set; get; }

        // Atributos auxiliares
        public Boolean conTarjeta { set; get; }
        public Double subTotal { set; get; }
        public Double descuentoTotal { set; get; }
        public Double recargoTarjeta { set; get; }
        public Double pagoTotal { set; get; }
        public Double pagoIGV { set; get; }
        public Double pagoSubTotalIGV { set; get; }
        public int numeroError { set; get; }
        #region reglas_negocio

        public void generarDatosImpuesto()
        {
            this.pagoSubTotalIGV = this.CalcularImpuestoSTIGV.calcularImpuestoSubTotalIGV(this.pagoTotal, this.tipoComprobante);
            this.pagoIGV = this.CalcularImpuestoIGV.calcularImpuestoIGV(this.pagoSubTotalIGV, this.pagoTotal, this.tipoComprobante);
        }
        public void generarRecargoTarjeta()
        {
            this.recargoTarjeta = this.CalcularRT.calcularRecargoTarjeta(this.conTarjeta, this.subTotal);
        }
        public void generarDescuentoTotal()
        {
            DateTime fechaHoy = DateTime.Today;
            this.descuentoTotal = Math.Round(
                this.CalcularDescuentoFM.calcularDescuentoFestivalMarinera(fechaHoy, this.pedido.listaDetallePedido)
                + this.CalcularDescuentoSPS.calcularDescuentoSemanaPiscoSour(fechaHoy, this.pedido.listaDetallePedido)
                + this.CalcularDescuentoDPB.calcularDescuentoDiaPolloBrasa(fechaHoy, this.pedido.listaDetallePedido)
                + this.CalcularDescuentoFP.calcularDescuentoFiestasPatrias(fechaHoy, this.pedido.listaDetallePedido)
                + this.CalcularDescuentoDCC.calcularDescuentoDiaCancionCriolla(fechaHoy, this.pedido.listaDetallePedido)
                + this.CalcularDescuentoFT.calcularDescuentoFundacionTrujillo(fechaHoy, this.pedido.listaDetallePedido)
                + this.CalcularDescuentoC.calcularDescuentoCumpleaños(this.subTotal, this.cliente)
                + this.CalcularDescuentoM.calcularDescuentoMenu(this.subTotal, pedido.listaDetallePedido)
            , 2);
        }
        public void generarPagoTotal()
        {
            this.pagoTotal = this.subTotal - this.descuentoTotal + this.recargoTarjeta;
        }
        #endregion reglas_negocio
    }
}
