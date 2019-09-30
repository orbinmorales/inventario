using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class Proveedor
    {
        public Proveedor()
        {
            Activo = false;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la descripcion")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese numero telefonico")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese direcccion")]
        public string Direccion { get; set; }


        public bool Activo { get; set; }

    }
}
