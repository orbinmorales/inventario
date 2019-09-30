using Inventario.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.WebAdmin.Controllers
{
    public class PedidosController : Controller
    {
        PedidosBL _pedidosBL;
        ProveedoresBL _proveedoresBL;

        public PedidosController()
        {
            _pedidosBL = new PedidosBL();
            _proveedoresBL = new ProveedoresBL();
        }

        // GET: Pedidos
        public ActionResult Index()
        {
            var listadePedidos = _pedidosBL.ObtenerPedidos();

            return View(listadePedidos);
        }

        public ActionResult Crear()
        {
            var nuevoPedido = new Pedido();
            var proveedores = _proveedoresBL.ObtenerProveedoresActivos();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre");

            return View(nuevoPedido);
        }

        [HttpPost]
        public ActionResult Crear(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                if (pedido.ProveedorId == 0)
                {
                    ModelState.AddModelError("ProveedorId", "Seleccione un proveedor");
                    return View(pedido);
                }

                _pedidosBL.GuardarPedido(pedido);

                return RedirectToAction("Index");
            }

            var proveedores = _proveedoresBL.ObtenerProveedoresActivos();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre");

            return View(pedido);
        }

        public ActionResult Editar(int id)
        {
            var pedido = _pedidosBL.ObtenerPedido(id);
            var proveedores = _proveedoresBL.ObtenerProveedoresActivos();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre", pedido.ProveedorId);


            return View(pedido);
        }

        [HttpPost]
        public ActionResult Editar(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                if(pedido.ProveedorId == 0)
                {
                    ModelState.AddModelError("ProveedorId", "Seleccione un proveedor");
                    return View(pedido);
                }

                _pedidosBL.GuardarPedido(pedido);

                return RedirectToAction("Index");
            }

            var proveedores = _proveedoresBL.ObtenerProveedoresActivos();

            ViewBag.ProveedoresId = new SelectList(proveedores, "Id", "Nombre", pedido.ProveedorId);

            return View(pedido);
        }

        public ActionResult Detalle(int id)
        {
            var pedido = _pedidosBL.ObtenerPedido(id);

            return View(pedido);
        }
    }
}