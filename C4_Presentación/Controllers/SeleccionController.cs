using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C4_Presentación.Controllers
{
    public class SeleccionController : Controller
    {
        [HttpGet]
        public ActionResult Principal()
        {
            if (Session["objLogin"] == null) return RedirectToAction("Principal", "Login");
            return View();
        }

    }
}
