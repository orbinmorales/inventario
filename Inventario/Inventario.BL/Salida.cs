using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class Salida
    {
        public int ID { get; set; }
        public int SeccionID { get; set; }
        public Seccion Seccion { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public List<SalidaDetalle> ListadeSalidaDetalle { get; set; }

        public Salida()
        {
            Activo = true;
            Fecha = DateTime.Now;

            ListadeSalidaDetalle = new List<SalidaDetalle>();
        }
    }

    public class SalidaDetalle
    {
        public int Id { get; set; }
        public int SalidaID { get; set; }
        public Salida Salida { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
    }
}
