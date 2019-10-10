using Inventario.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.WebAdmin.Controllers
{
    public class SalidaDetalleController : Controller
    {
        SalidasBL _salidaBL;
        ProductosBL _productosBL;

        public SalidaDetalleController()
        {
            _salidaBL = new SalidasBL();
            _productosBL = new ProductosBL();
        }

        // GET: SalidasDetalle
        public ActionResult Index(int id)
        {
            var salida= _salidaBL.ObtenerSalida(id);
            salida.ListadeSalidaDetalle = _salidaBL.ObtenerSalidaDetalle(id);

            return View(salida);
        }

        public ActionResult Crear(int id)
        {
            var nuevaSalidaDetalle = new SalidaDetalle();
            nuevaSalidaDetalle.SalidaID = id;

            var productos = _productosBL.ObtenerProductos();

            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(nuevaSalidaDetalle);
        }

        [HttpPost]
        public ActionResult Crear(SalidaDetalle salidaDetalle)
        {
            if (ModelState.IsValid)
            {
                if (salidaDetalle.ProductoId == 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View(salidaDetalle);
                }

                _salidaBL.GuardarSalidaDetalle(salidaDetalle);
                return RedirectToAction("Index", new { id = salidaDetalle.SalidaID});
            }

            var productos = _productosBL.ObtenerProductos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(salidaDetalle);
        }

        public ActionResult Eliminar(int id)
        {
            var salidaDetalle = _salidaBL.ObtenerSalidaDetallePorId(id);

            return View(salidaDetalle);
        }

        [HttpPost]
        public ActionResult Eliminar(SalidaDetalle salidaDetalle)
        {
            _salidaBL.EliminarSalidaDetalle(salidaDetalle.Id);
            return RedirectToAction("Index", new { id = salidaDetalle.SalidaID });
        }
    }
}