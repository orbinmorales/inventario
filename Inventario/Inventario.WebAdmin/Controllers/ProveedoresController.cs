using Inventario.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.WebAdmin.Controllers
{
    public class ProveedoresController : Controller
    {
        ProveedoresBL _proveedoresBL;

        public ProveedoresController()
        {
            _proveedoresBL = new ProveedoresBL();
        }
        // GET: Proveedores
        public ActionResult Index()
        {
            var ListadeProveedores = _proveedoresBL.ObtenerProveedores();

            return View(ListadeProveedores);
        }

        public ActionResult Crear()
        {
    
            var nuevoProveedor = new Proveedor();

            return View(nuevoProveedor);
        }

        [HttpPost]
        public ActionResult Crear(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _proveedoresBL.GuardarProveedor(proveedor);

                return RedirectToAction("Index");
            }

            return View();
          
        }

        public ActionResult Editar(int id)
        {
            var proveedor = _proveedoresBL.ObtenerProveedor(id);
            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Editar(Proveedor proveedor)
        {
            _proveedoresBL.GuardarProveedor(proveedor);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var proveedor = _proveedoresBL.ObtenerProveedor(id);

            return View(proveedor);
        }

        public ActionResult Eliminar(int id)
        {
            var proveedor = _proveedoresBL.ObtenerProveedor(id);

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Eliminar(Proveedor proveedor)
        {
            _proveedoresBL.EliminarProveedor(proveedor.Id);
            return RedirectToAction("Index");
        }
    }
}