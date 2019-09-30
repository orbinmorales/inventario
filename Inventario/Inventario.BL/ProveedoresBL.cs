using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.BL
{
    public class ProveedoresBL
    {
        Contexto _contexto;
        public List<Proveedor> ListadeProveedores { get; set; }

        public ProveedoresBL()
        {
            _contexto = new Contexto();
            ListadeProveedores = new List<Proveedor>();
        }

        public List<Proveedor> ObtenerProveedores()
        {
            ListadeProveedores = _contexto.Proveedores
                .OrderBy(r => r.Nombre)
                .ToList();
            return ListadeProveedores; 
        }

        public List<Proveedor> ObtenerProveedoresActivos()
        {
            ListadeProveedores = _contexto.Proveedores
                .Where(r => r.Activo == true)
                .OrderBy(r =>r.Nombre)
                .ToList();
            return ListadeProveedores;
        }

        public void GuardarProveedor(Proveedor proveedor)
        {
            if(proveedor.Id == 0)
            {
                _contexto.Proveedores.Add(proveedor);
            }
            else
            {
                var proveedorExistente = _contexto.Proveedores.Find(proveedor.Id);
                proveedorExistente.Nombre = proveedor.Nombre;
                proveedorExistente.Telefono = proveedor.Telefono;
                proveedorExistente.Direccion = proveedor.Direccion;
                proveedorExistente.Activo = proveedor.Activo;
            }

            _contexto.SaveChanges();
        }
        
        public Proveedor ObtenerProveedor(int id)
        {
            var proveedor = _contexto.Proveedores.Find(id);

            return proveedor;
        }

        public void EliminarProveedor(int id)
        {
            var proveedor = _contexto.Proveedores.Find(id);

            _contexto.Proveedores.Remove(proveedor);
            _contexto.SaveChanges();

        }
    }
}
