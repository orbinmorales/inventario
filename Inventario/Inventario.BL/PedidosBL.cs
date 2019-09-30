using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class PedidosBL
    {
        Contexto _contexto;
        public List<Pedido> ListadePedidos { get; set; }

        public PedidosBL()
        {
            _contexto = new Contexto();
            ListadePedidos = new List<Pedido>();
        }

        public List<Pedido> ObtenerPedidos()
        {
            ListadePedidos = _contexto.Pedidos
                .Include("Proveedor")
                .ToList();

            return ListadePedidos;
        }

        public List<PedidoDetalle> ObtenerPedidoDetalle(int pedidoId)
        {
            var listadePedidosDetalle = _contexto.PedidoDetalle
                .Include("Producto")
                .Where(p => p.PedidoId == pedidoId).ToList();

            return listadePedidosDetalle;
        }

        public PedidoDetalle ObtenerPedidoDetallePorId(int id)
        {
            var pedidoDetalle = _contexto.PedidoDetalle
                .Include("Producto").FirstOrDefault(p => p.Id == id);

            return pedidoDetalle;
        }

        public Pedido ObtenerPedido(int id)
        {
            var pedido = _contexto.Pedidos
                .Include("Proveedor").FirstOrDefault(p => p.Id == id);

            return pedido;
        }

        public void GuardarPedido(Pedido pedido)
        {
            if (pedido.Id  == 0)
            {
                _contexto.Pedidos.Add(pedido);
            }
            else
            {
                var pedidoExistente = _contexto.Pedidos.Find(pedido.Id);
                pedidoExistente.ProveedorId = pedido.ProveedorId;
                pedidoExistente.Activo = pedido.Activo;
            }

            _contexto.SaveChanges();
        }

        public void GuardarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            var producto = _contexto.Productos.Find(pedidoDetalle.ProductoId);

            pedidoDetalle.Precio = producto.Precio;
            pedidoDetalle.Total = pedidoDetalle.Cantidad * pedidoDetalle.Precio;

            _contexto.PedidoDetalle.Add(pedidoDetalle);

            var pedido = _contexto.Pedidos.Find(pedidoDetalle.PedidoId);
            pedido.Total = pedido.Total + pedidoDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarPedidoDetalle(int id)
        {
            var pedidoDetalle = _contexto.PedidoDetalle.Find(id);
            _contexto.PedidoDetalle.Remove(pedidoDetalle);

            var pedido = _contexto.Pedidos.Find(pedidoDetalle.PedidoId);
            pedido.Total = pedido.Total - pedidoDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
