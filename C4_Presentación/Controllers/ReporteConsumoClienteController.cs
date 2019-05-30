using C2_Dominio.Entidades;
using C3_Aplicación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C4_Presentación.Controllers
{
    public class ReporteConsumoClienteController : Controller
    {
        //
        // GET: /ListarReporteCliente/
        public ActionResult ListarReporteCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListarReporteCliente(FormCollection frm)
        {


            int cantidadclientes; double montominimo;
            String cantidadclie = frm["datoDNI"];
            String monto = frm["datoMonto"];

            if (cantidadclie.Equals("") || monto.Equals("")) { cantidadclientes = 0; montominimo = 0; }
            else { cantidadclientes = Convert.ToInt32(cantidadclie); montominimo = Convert.ToDouble(monto); }
            try
            {
                if (cantidadclientes != 0 && montominimo >= 1)
                {
                    ViewBag.activa = 1;
                    ReporteConsumoClienteServicio reporteconsumocliente = new ReporteConsumoClienteServicio();
                    List<Pago> p = reporteconsumocliente.RankingConsumoCliente(cantidadclientes, montominimo);
                    return View(p);
                }
                else
                {
                    ViewBag.mensaje = "Ingrese datos Correctos";
                    return View();
                }

            }
            catch (Exception e)
            {
                ViewBag.mensaje = "No hay datos para mostrar";
                return View();
                throw e;
            }

        }
    }
}
