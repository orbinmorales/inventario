using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class ReporteVentasPorProductoBL
    {
        Contexto _contexto;
        public List<ReporteVentasPorProducto> ListadeVentasPorProducto { get; set; }


        public ReporteVentasPorProductoBL()
        {
            _contexto = new Contexto();
            ListadeVentasPorProducto = new List<ReporteVentasPorProducto>();

        }
        public List<ReporteVentasPorProducto> ObtenerVentasPorProducto()
        {
            ListadeVentasPorProducto = _contexto.PedidoDetalle
                .Include("Producto")
                .Where(r => r.Pedido.Activo)
                .GroupBy(r => r.Producto.Descripcion)
                .Select(r => new ReporteVentasPorProducto()
                {
                    Producto = r.Key,
                    Cantidad = r.Sum(s => s.Cantidad),
                    Total = r.Sum(s => s.Total)
                }).ToList();
            return ListadeVentasPorProducto;
        }
    }
}
