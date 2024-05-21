using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Repositories
{
    internal class ProductoRepository
    {
        RestaurantContext context = new();
        public IEnumerable<Productos> GetAllPRoductos()
        {
            return context.Productos.OrderBy(x => x.Nombre);
        }
        public Productos? GetByIdProducto(int id)
        {
            return context.Productos.FirstOrDefault(x => x.Id == id);
        }
        public void Agregar(Productos p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void Eliminar(Productos p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void Editar(Productos pEditar)
        {
            if (pEditar != null)
            {
                var p = context.Productos.FirstOrDefault(x => x.Id == pEditar.Id);
                if (p != null)
                {
                    p.UrlImagen= pEditar.UrlImagen;
                    p.Descripcion= pEditar.Descripcion;
                    p.Nombre= pEditar.Nombre;
                    p.Precio= pEditar.Precio;
                    context.SaveChanges();
                }
            }
        }
        public bool Validar (Productos p, out List<string> Errores)
        {
            Errores = new List<string>();
            if (p != null)
            {
                if (string.IsNullOrEmpty(p.Nombre))
                {
                    Errores.Add("Escriba el nombre del producto");
                }
                if (string.IsNullOrEmpty(p.Descripcion))
                {
                    Errores.Add("Escriba la descripciòn del producto");
                }
                if (p.Precio<=0)
                {
                    Errores.Add("Escriba el precio del producto");
                    
                }
            }
            return Errores.Count == 0;//true si no hay errores y false si hay errores
        }

    }
}
