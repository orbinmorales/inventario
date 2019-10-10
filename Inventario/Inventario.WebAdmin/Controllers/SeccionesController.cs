using Inventario.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.WebAdmin.Controllers
{
    public class SeccionesController : Controller
    {
        SeccionesBL _seccionesBL;

        public SeccionesController()
        {
            _seccionesBL = new SeccionesBL();
        }
        // GET: Secciones
        public ActionResult Index()
        {
            var listadeSecciones = _seccionesBL.ObtenerSecciones();

            return View(listadeSecciones);
        }

        public ActionResult Crear()
        {
            var nuevaSeccion = new Seccion();

            return View(nuevaSeccion);
        }

        [HttpPost]
        public ActionResult Crear(Seccion seccion)
        {
            _seccionesBL.GuardarSeccion(seccion);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var seccion = _seccionesBL.ObtenerSeccion(id);

            return View(seccion);
        }

        [HttpPost]
        public ActionResult Editar (Seccion seccion)
        {
            _seccionesBL.GuardarSeccion(seccion);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var seccion = _seccionesBL.ObtenerSeccion(id);

            return View(seccion);
        }

        public ActionResult Eliminar(int id)
        {
            var seccion = _seccionesBL.ObtenerSeccion(id);

            return View(seccion);
        }

        [HttpPost]
        public ActionResult Eliminar(Seccion seccion)
        {
            _seccionesBL.EliminarSeccion(seccion.ID);

            return RedirectToAction("Index");
        }
    }
}