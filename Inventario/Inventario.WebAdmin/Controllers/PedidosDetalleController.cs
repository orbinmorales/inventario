using Inventario.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.WebAdmin.Controllers
{
    public class PedidoDetalleController : Controller
    {
        PedidosBL _pedidoBL;
        ProductosBL _productosBL;

        public PedidoDetalleController()
        {
            _pedidoBL = new PedidosBL();
            _productosBL = new ProductosBL();
        }

        // GET: PedidosDetalle
        public ActionResult Index(int id)
        {
            var pedido = _pedidoBL.ObtenerPedido(id);
            pedido.ListadePedidoDetalle = _pedidoBL.ObtenerPedidoDetalle(id);

            return View(pedido);
        }

        public ActionResult Crear(int id)
        {
            var nuevoPedidoDetalle = new PedidoDetalle();
            nuevoPedidoDetalle.PedidoId = id;

            var productos = _productosBL.ObtenerProductosActivos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(nuevoPedidoDetalle);
        }

        [HttpPost]
        public ActionResult Crear(PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                if (pedidoDetalle.ProductoId == 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View(pedidoDetalle);
                }

                _pedidoBL.GuardarPedidoDetalle(pedidoDetalle);
                return RedirectToAction("Index", new { id = pedidoDetalle.PedidoId });
            }

            var productos = _productosBL.ObtenerProductosActivos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(pedidoDetalle);
        }

        public ActionResult Eliminar(int id)
        {
            var pedidoDetalle = _pedidoBL.ObtenerPedidoDetallePorId(id);

            return View(pedidoDetalle);
        }

        [HttpPost]
        public ActionResult Eliminar(PedidoDetalle pedidoDetalle)
        {
            _pedidoBL.EliminarPedidoDetalle(pedidoDetalle.Id);

            return RedirectToAction("Index", new { id = pedidoDetalle.PedidoId });
        }
    }
}