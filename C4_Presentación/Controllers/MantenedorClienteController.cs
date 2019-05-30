using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using C2_Dominio.Entidades;
using C3_Aplicación;

namespace C4_Presentación.Controllers
{
    public class MantenedorClienteController : Controller
    {
        //
        // GET: /GestionarCliente/
        public ActionResult paginaListarCliente()
        {
             List<Cliente> lista = MantenedorClienteServicio.Instancia.listarCliente();
            return View(lista);
        }

        public ActionResult paginaNuevoCliente(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult paginaNuevoCliente(Cliente m)
        {

            try
            {
                MantenedorClienteServicio gestionarClienteServicio = new MantenedorClienteServicio();
                Boolean inserto = gestionarClienteServicio.insertarCliente(m);
                if (inserto)
                {
                    return RedirectToAction("paginaListarCliente");

                }
                else
                {
                    return RedirectToAction("Nuevocliente", "cliente", new { mensaje = "No se pudo insertar" });
                }

            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("nuevoCliente", "cliente", new { mensaje = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }


        }

        public ActionResult paginaeditarCliente(String dni)
        {
            MantenedorClienteServicio gestionarClienteServicio = new MantenedorClienteServicio();
            Cliente c = gestionarClienteServicio.devolverCliente(dni);
            return View(c);
        }

        [HttpPost]
        public ActionResult paginaeditarCliente(Cliente c)
        {
            try
            {
                MantenedorClienteServicio gestionarClienteServicio = new MantenedorClienteServicio();
                Boolean editar = gestionarClienteServicio.editarCliente(c);

                if (editar) return RedirectToAction("paginaListarCliente");

                else return RedirectToAction("paginaeditarCliente", new { mensaje = "No se pudo editar cliente" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }

        }




    }
}

