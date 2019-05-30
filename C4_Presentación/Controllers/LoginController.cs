using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using C2_Dominio.Entidades;
using C3_Aplicación;

namespace C4_Presentación.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Principal()
        {
            Session["objLogin"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Principal(FormCollection frm)
        {
            try
            {
                String usu = frm["txtUsuario"].ToString();
                String pass = frm["txtPassword"].ToString();
                Login login = new Login();
                if (login.usuarioNulo(usu))
                {
                    ViewBag.mensaje = "Ingrese usuario";
                    return View();
                }
                if(login.contrasenaNulo(pass))
                {
                    ViewBag.mensaje = "Ingrese contraseña";
                    return View();
                }
                login = LoginServicio.Instancia.verificarAccesoEmpleado(usu, pass);
                if (login == null)
                {
                    ViewBag.mensaje = "Contraseña y/o usuario incorrecto(s)";
                    return View();
                }
                else
                {
                    if(!login.empHabilitado)
                    {
                        ViewBag.mensaje = "Empleado inhabilitado.";
                        return View();
                    }
                    else if(!login.tipoEmpHabilitado)
                    {
                        ViewBag.mensaje = "Tipo de empleado inhabilitado.";
                        return View();
                    }
                    else
                    {
                        if(login.tipoEmpleado.Equals("Administrador"))
                        {
                            Session["objLogin"] = login;
                            return RedirectToAction("Principal", "Seleccion");
                        }
                        else if(login.tipoEmpleado.Equals("Cajero"))
                        {
                            Session["objLogin"] = login;
                            return RedirectToAction("Principal", "GestionarPago");
                        }
                        else if(login.tipoEmpleado.Equals("Mesero"))
                        {
                            Session["objLogin"] = login;
                            return RedirectToAction("PaginaMesas1", "GestionarPedido");
                        }
                        else
                        {
                            ViewBag.mensaje = "Tipo de empleado ajeno al sistema";
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
