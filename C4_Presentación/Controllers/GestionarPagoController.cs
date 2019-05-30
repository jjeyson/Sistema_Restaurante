using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using C2_Dominio.Entidades;
using C3_Aplicación;

namespace C4_Presentación.Controllers
{
    public class GestionarPagoController : Controller
    {
        [HttpGet]
        public ActionResult Principal()
        {
            if (Session["objLogin"] == null) return RedirectToAction("Principal", "Login");
            Pago pago = new Pago();
            pago.cliente = new Cliente(); pago.cliente.numeroError = -1;
            pago.pedido = new Pedido(); pago.pedido.numeroError = -1;
            pago.tipoComprobante = new TipoComprobante();
            pago.numeroError = -1; pago.conTarjeta = false;
            Session["objPago"] = pago;
            return View();
        }
        [HttpGet]
        public ActionResult listarMesaOcupada()
        {
            try
            {
                return PartialView(GestionarPagoServicio.Instancia.listarMesaOcupada());
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpGet]
        public ActionResult listarTipoComprobanteHabilitado()
        {
            try
            {
                return PartialView(GestionarPagoServicio.Instancia.listarTipoComprobanteHabilitado());
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost]
        public ActionResult mostrarDatosPago(String idTipoComprobante)
        {
            try
            {
                Pago pago = (Pago)Session["objPago"];
                if (idTipoComprobante.Equals("ninguno"))
                {
                    pago.numeroError = 1;
                }
                else if (idTipoComprobante.Equals("actualizar:tarjeta"))
                {
                    pago.conTarjeta = !pago.conTarjeta;
                    if (pago.numeroError != 0)
                    {
                        pago.numeroError = 2;
                        Session["objPago"] = pago;
                        return PartialView(pago);
                    }
                    pago.generarRecargoTarjeta();
                    pago.generarPagoTotal();
                }
                else if(idTipoComprobante.Equals("actualizar:clientepedido"))
                {
                    pago.numeroError = 4;
                }
                else
                {
                    pago.tipoComprobante = GestionarPagoServicio.Instancia.buscarTipoComprobante(
                            Convert.ToInt32(idTipoComprobante));
                    if (pago.tipoComprobante.descripcion.Equals("Factura") && !pago.cliente.esEmpresa)
                    {
                        pago.numeroError = 3;
                        Session["objPago"] = pago;
                        return PartialView(pago);
                    }
                    else 
                        pago.numeroError = 0;
                    pago.subTotal = pago.pedido.calcularSumatoriaSubTotal();
                    pago.generarDescuentoTotal();
                    pago.generarRecargoTarjeta();
                    pago.generarPagoTotal();
                    pago.generarDatosImpuesto();
                }
                Session["objPago"] = pago;
                return PartialView(pago);
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost]
        public ActionResult listarProductosPedidos(String idmesa)
        {
            try
            {
                Pago pago = (Pago)Session["objPago"];
                if (idmesa == "ninguno")
                {
                    pago.pedido.numeroError = 1;
                }
                else
                {
                    pago.pedido = GestionarPagoServicio.Instancia.buscarPedidoMesaNoPagado(Convert.ToInt32(idmesa));
                    pago.pedido.listaDetallePedido = GestionarPagoServicio.Instancia.listarDetallePedidoMesa(pago.pedido.id);
                    pago.pedido.numeroError = 0;
                }
                Session["objPago"] = pago;
                return PartialView(pago);
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost]
        public ActionResult buscarCliente(String dni)
        {
            try
            {
                Pago pago = (Pago)Session["objPago"];
                if (pago.cliente.dniVacio(dni))
                    pago.cliente.numeroError = 4;
                else if (!pago.cliente.dniEsOchoDigitos(dni))
                    pago.cliente.numeroError = 1;
                else if (!pago.cliente.dniEsTodoNumerico(dni))
                    pago.cliente.numeroError = 3;
                else
                {
                    pago.cliente = GestionarPagoServicio.Instancia.buscarCliente(dni);
                    if (pago.cliente == null)
                    {
                        pago.cliente = new Cliente();
                        pago.cliente.numeroError = 2;
                    }
                    else
                    {
                        pago.cliente.numeroError = 0;
                    }
                }
                Session["objPago"] = pago;
                return PartialView(pago);
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpGet]
        public ActionResult registrarPago()
        {
            try
            {
                Pago pago = (Pago)Session["objPago"];
                if (GestionarPagoServicio.Instancia.registrarPago(pago))
                    pago.numeroError = 0;
                else
                    pago.numeroError = 1;
                return PartialView(pago);
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost]
        public ActionResult formularioCliente(String dni)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.dni = dni;
                return PartialView(cliente);
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost]
        public ActionResult registrarCliente(String formdni, String formnombre, String formcorreoElectronico,
            String formdireccion, String formfechaNacimiento, String formesEmpresa, String formrazonSocial, String formruc)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.esEmpresa = Convert.ToBoolean(formesEmpresa);
                // Errores en DNI
                if(cliente.dniVacio(formdni))
                {
                    cliente.numeroError = 11;
                    return PartialView(cliente);
                }
                else if(!cliente.dniEsOchoDigitos(formdni))
                {
                    cliente.numeroError = 1;
                    return PartialView(cliente);
                }
                else if(!cliente.dniEsTodoNumerico(formdni))
                {
                    cliente.numeroError = 2;
                    return PartialView(cliente);
                }
                else
                    cliente = GestionarPagoServicio.Instancia.buscarCliente(formdni);
                if(cliente != null)
                {
                    cliente.numeroError = 16;
                    return PartialView(cliente);
                }
                else
                {
                    cliente = new Cliente();
                    cliente.dni = formdni;
                }
                // Errores en nombre
                if (cliente.nombreVacio(formnombre))
                {
                    cliente.numeroError = 12;
                    return PartialView(cliente);
                }
                else if(!cliente.nombreNoSuperaCapacidad(formnombre))
                {
                    cliente.numeroError = 5;
                    return PartialView(cliente);
                }
                else
                    cliente.nombre = formnombre;
                // Errores en correoElectronico
                if (cliente.correoElectronicoNoSuperaCapacidad(formcorreoElectronico))
                    cliente.correoElectronico = formcorreoElectronico;
                else
                {
                    cliente.numeroError = 6;
                    return PartialView(cliente);
                }
                // Errores en direccion
                if (cliente.direccionNoSuperaCapacidad(formdireccion))
                    cliente.direccion = formdireccion;
                else
                {
                    cliente.numeroError = 7;
                    return PartialView(cliente);
                }
                // Errores en fechaNacimiento
                DateTime fecha;
                if(DateTime.TryParse(formfechaNacimiento, out fecha))
                {
                    cliente.fechaNacimiento = fecha;
                    if (cliente.fechaNacMenorFechaReg(fecha))
                    {
                        cliente.fechaNacimiento = fecha;
                    }
                    else
                    {
                        cliente.numeroError = 4;
                        return PartialView(cliente);
                    }
                }
                else
                {
                    cliente.numeroError = 3;
                    return PartialView(cliente);
                }
                // Es empresa
                cliente.esEmpresa = Convert.ToBoolean(formesEmpresa);
                if (cliente.esEmpresa)
                {
                    // Errores en Razon social
                    if(cliente.razonsocialEsVacio(formrazonSocial))
                    {
                        cliente.numeroError = 13;
                        return PartialView(cliente);
                    }
                    else if (cliente.razonSocialNoSuperaCapacidad(formrazonSocial))
                        cliente.razonSocial = formrazonSocial;
                    else
                    {
                        cliente.numeroError = 8;
                        return PartialView(cliente);
                    }
                    // Errores en RUC
                    if(cliente.rucEsVacio(formruc))
                    {
                        cliente.numeroError = 14;
                        return PartialView(cliente);
                    }
                    else if (!cliente.rucEsOnceDigitos(formruc))
                    {
                        cliente.numeroError = 9;
                        return PartialView(cliente);
                    }
                    else if (!cliente.rucEsTodoNumerico(formruc))
                    {
                        cliente.numeroError = 10;
                        return PartialView(cliente);
                    }
                    else
                        cliente.ruc = formruc;
                }
                // Sin errores
                cliente.fechaRegistro = DateTime.Today;
                cliente.habilitado = true;
                if (GestionarPagoServicio.Instancia.registrarCliente(cliente))
                    cliente.numeroError = 0;
                else
                    cliente.numeroError = 15;
                return PartialView(cliente);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
