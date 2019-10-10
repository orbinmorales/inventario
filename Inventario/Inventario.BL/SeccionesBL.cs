using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class SeccionesBL
    {
        Contexto _contexto;
        public List<Seccion> ListadeSecciones { get; set; }

        public SeccionesBL()
        {
            _contexto = new Contexto();
            ListadeSecciones = new List<Seccion>();
        }

       public List<Seccion> ObtenerSecciones()
        {
            ListadeSecciones = _contexto.Secciones.ToList();
            return ListadeSecciones;
        }

        public void GuardarSeccion(Seccion seccion)
        {
            if(seccion.ID == 0)
            {
                _contexto.Secciones.Add(seccion);
            } else
            {
                var seccionExistente = _contexto.Secciones.Find(seccion.ID);
                seccionExistente.Nombre = seccion.Nombre;
                seccionExistente.Pasillo = seccion.Pasillo;
            }
            
            _contexto.SaveChanges();
        }

        public Seccion ObtenerSeccion(int id)
        {
            var seccion = _contexto.Secciones.Find(id);

            return seccion;
        }

        public void EliminarSeccion(int id)
        {
            var seccion = _contexto.Secciones.Find(id);

            _contexto.Secciones.Remove(seccion);
            _contexto.SaveChanges();
        }
    }
}
