using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }

        public int Id { get; set; }
        [Display(Name = "Descripcion")]

        [Required(ErrorMessage = "ingrese la descripcion")]
        [MinLength(3, ErrorMessage = "Ingrese un minimo de 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Se permite solo 20 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(0, 1000, ErrorMessage = "Ingrese un precio valido ")]
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }

    }
}
