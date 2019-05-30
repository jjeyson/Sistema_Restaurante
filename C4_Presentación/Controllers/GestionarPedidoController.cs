using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using C2_Dominio.Entidades;
using C3_Aplicación;

namespace C4_Presentación.Controllers
{
    public class GestionarPedidoController : Controller
    {
        public ActionResult PaginaPedidook(int id)
        {
            Pedido obj = new Pedido();
            obj.id = id;
            Session["Delivery"] = obj;
            return RedirectToAction("PaginaPedido");
        }

        public ActionResult PaginaPedido(int Categoria_ID = 0)
        {
            CAT_ProductoCollection_CE lista = new CAT_ProductoCollection_CE();
            try
            {
                lista = GestionarPedidoServicio.Instancia.GetByCategoria_ID(Categoria_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(lista);
        }
        [HttpPost]
        public ActionResult PaginaPedido()
        {
            try
            {
                return View();
            }
            catch (Exception e) { throw e; }
        }

        public ActionResult PaginaMesas1()
        {
            List<Mesa> lista = GestionarPedidoServicio.Instancia.ListarMesa();

            return View(lista);
        }


        [HttpPost]
        public ActionResult Agregar(FormCollection form)
        {
            PedidoDetCollection lista = null;
            if (Session["Pedido"] != null)
                lista = (PedidoDetCollection)Session["Pedido"];
            else
                lista = new PedidoDetCollection();
            if (lista.Count == 0)
            {
                DetallePedido obj = new DetallePedido();
                Producto p = new Producto();
                p.id = Convert.ToInt32(form["txtProducto_ID"].ToString());
                p.descripcion = form["txtNomProducto"].ToString();
                p.precio = Convert.ToDouble(form["txtPreUnitario"].ToString());
                //p.Imagen = form["txtImagen"].ToString();
                obj.producto = p;
                obj.cantidad = Convert.ToInt32(form["txtCantidad"].ToString());
                lista.Add(obj);
            }
            else
            {
                foreach (DetallePedido o in lista)
                {
                    if (o.producto.id == Convert.ToInt32(form["txtProducto_ID"].ToString()))
                    {
                        o.cantidad += Convert.ToInt32(form["txtCantidad"].ToString());
                        Session["Pedido"] = lista;
                        return RedirectToAction("PaginaPedido", "GestionarPedido");
                    }
                }
                DetallePedido obj = new DetallePedido();
                Producto p = new Producto();
                p.id = Convert.ToInt32(form["txtProducto_ID"].ToString());
                p.descripcion = form["txtNomProducto"].ToString();
                p.precio = Convert.ToDouble(form["txtPreUnitario"].ToString());
                //p.Imagen = form["txtImagen"].ToString();
                obj.producto = p;

                obj.cantidad = Convert.ToInt32(form["txtCantidad"].ToString());
                lista.Add(obj);

            }
            Session["Pedido"] = lista;
            return RedirectToAction("PaginaPedido", "GestionarPedido");
        }

        [HttpGet]
        public ActionResult PaginaDetallePedido()
        {
            return View();
        }


        public ActionResult GuardarPedido(FormCollection form)
        {
            try
            {
                Login log = (Login)Session["objLogin"];
                Empleado u = new Empleado();
                u.dni = log.dniEmpleado;
                Pedido d = (Pedido)Session["Delivery"];
                d.DEL_DeliveryDetCollection = (PedidoDetCollection)Session["Pedido"];
                decimal total = 0;
                foreach (DetallePedido o in d.DEL_DeliveryDetCollection)
                {
                    total += Convert.ToDecimal(o.subTotal);
                }
                //d.Total = total;

                //d.empleado = u.dni;
                GestionarPedidoServicio.Instancia.Pedido(d, u);
                Session["Delivery"] = null;
                Session["Pedido"] = null;
                TempData["Tipo"] = "1";
                TempData["Mensaje"] = "Pedido de Delivery realizado correctamente.";
                return RedirectToAction("PaginaMesas1", "GestionarPedido");

            }
            catch (Exception ex)
            {
                TempData["Tipo"] = "2";
                TempData["Mensaje"] = ex.Message;
            }
            return View();
        }

    }
}
