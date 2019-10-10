using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class Seccion
    {
        public int ID { get; set; }


       
        public string Nombre { get; set; }

       
        public int Pasillo { get; set; }
    }
}
