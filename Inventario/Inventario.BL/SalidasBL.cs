using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class SalidasBL
    {
        Contexto _contexto;
        public List<Salida> ListadeSalidas { get; set; }

        public SalidasBL()
        {
            _contexto = new Contexto();
            ListadeSalidas = new List<Salida>();
        }

        public List<Salida> ObtenerSalidas()
        {
            ListadeSalidas = _contexto.Salidas
                .Include("Seccion")
                .ToList();

            return ListadeSalidas;
        }

        public List<SalidaDetalle> ObtenerSalidaDetalle(int salidaID)
        {
            var listadeSalidasDetalle = _contexto.SalidaDetalle
                .Include("Producto")
                .Where(s => s.SalidaID == salidaID).ToList();
             
            return listadeSalidasDetalle;
        }

        public SalidaDetalle ObtenerSalidaDetallePorId(int id)
        {
            var salidaDetalle = _contexto.SalidaDetalle
                 .Include("Producto").FirstOrDefault(p => p.Id == id);

            return salidaDetalle;
        }

        public Salida ObtenerSalida(int id)
        {
            var salida = _contexto.Salidas
                  .Include("Seccion").FirstOrDefault(p => p.ID == id);

            return salida;
        }

        public void GuardarSalida(Salida salida)
        {
            if (salida.ID == 0)
            {
                _contexto.Salidas.Add(salida);
            } else
            {
                var salidaExistente = _contexto.Salidas.Find(salida.ID);
                salidaExistente.SeccionID = salida.SeccionID;
                salidaExistente.Activo = salida.Activo;
            }

            _contexto.SaveChanges();
        }

        public void GuardarSalidaDetalle(SalidaDetalle salidaDetalle)
        {
            var producto = _contexto.Productos.Find(salidaDetalle.ProductoId);

            salidaDetalle.Precio = producto.Precio;
            salidaDetalle.Total = salidaDetalle.Cantidad * salidaDetalle.Precio;

            _contexto.SalidaDetalle.Add(salidaDetalle);

            var salida = _contexto.Salidas.Find(salidaDetalle.SalidaID);
            salida.Total = salida.Total + salidaDetalle.Total;

            _contexto.SaveChanges();
        }
         public void EliminarSalidaDetalle(int id)
        {
            var salidaDetalle = _contexto.SalidaDetalle.Find(id);
            _contexto.SalidaDetalle.Remove(salidaDetalle);

            var salida = _contexto.Salidas.Find(salidaDetalle.SalidaID);
            salida.Total = salida.Total - salidaDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
