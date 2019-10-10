using Inventario.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.WebAdmin.Controllers
{
    public class SalidasController : Controller
    {
        SalidasBL _salidasBL;
        SeccionesBL _seccionesBL;
        public SalidasController()
        {
            _salidasBL = new SalidasBL();
            _seccionesBL = new SeccionesBL();
        }

        // GET: Salidas
        public ActionResult Index()
        {
            var listadeSalidas = _salidasBL.ObtenerSalidas();

            return View(listadeSalidas);
        }

        public ActionResult Crear()
        {
            var nuevaSalida = new Salida();
            var secciones = _seccionesBL.ObtenerSecciones();

            ViewBag.SeccionID = new SelectList(secciones, "Id", "Nombre");

            return View(nuevaSalida);
        }

        [HttpPost]
        public ActionResult Crear(Salida salida)
        {
            if (ModelState.IsValid)
            {
                if (salida.SeccionID == 0)
                {
                    ModelState.AddModelError("SeccionID", "Seleccione una Seccion");
                    return View(salida);
                }

                _salidasBL.GuardarSalida(salida);
                return RedirectToAction("Index");
            }

            var secciones = _seccionesBL.ObtenerSecciones();

            ViewBag.SeccionesID = new SelectList(secciones, "Id", "Nombre");

            return View(salida);
        }

        public ActionResult Editar(int id)
        {
            var salida = _salidasBL.ObtenerSalida(id);
            var secciones = _seccionesBL.ObtenerSecciones();

            ViewBag.SeccionID = new SelectList(secciones, "ID", "Nombre", salida.SeccionID);
            return View(salida);
        }

        [HttpPost]
        public ActionResult Editar(Salida salida)
        {
            if (ModelState.IsValid)
            {
                if (salida.SeccionID == 0)
                {
                    ModelState.AddModelError("SeccionID", "Seleccione una seccion");
                        return View(salida);
                }

                _salidasBL.GuardarSalida(salida);

                return RedirectToAction("Index");
            }
            var secciones = _seccionesBL.ObtenerSecciones();

            ViewBag.SeccionID = new SelectList(secciones, "ID", "Nombre", salida.SeccionID);

            return View(salida);
        }

        public ActionResult Detalle(int id)
        {
            var salida = _salidasBL.ObtenerSalida(id);

            return View(salida);
        }
    }
}