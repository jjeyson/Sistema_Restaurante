using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using C2_Dominio.Entidades;
using C3_Aplicación;

namespace C4_Presentación.Controllers
{
    public class ReporteNivelVentasController : Controller
    {
        //
        // GET: /ReporteNivelVentas/

        public ActionResult NivelVentas()
        {
            if(Session["objLogin"] == null) return RedirectToAction("Principal", "Login");

            //ViewBag.entrar = 0;
            return View();
        }

        [HttpPost]
        public ActionResult NivelVentas(FormCollection frm)
        {
            DateTime fechaInicioBuscar = Convert.ToDateTime(frm["dateInicial"].Equals("") ? "1754-01-01" : frm["dateInicial"]);
            DateTime fechaFinalBuscar = Convert.ToDateTime(frm["dateFinal"].Equals("") ? "9999-12-31" : frm["dateFinal"]);
            ViewBag.entrar = 1;

            if (fechaFinalBuscar < fechaInicioBuscar)
           {
                ViewBag.errorfecha = "Error en fechas";
            }
            List<Pago> lista = ReporteNivelVentasServicio.Instancia.ReporteNivelVentasB(
                 fechaInicioBuscar, fechaFinalBuscar);
             return View(lista);
        }
    }
}
