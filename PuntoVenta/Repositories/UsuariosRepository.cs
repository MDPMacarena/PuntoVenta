using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Repositories
{
    internal class UsuariosRepository
    {
        RestaurantContext context = new RestaurantContext();
        //READ
        public IEnumerable<Usuarios> GetAll()
        {
            return context.Usuarios.OrderBy(x => x.Nombre);
        }
        public Usuarios? GetById(int id)
        {
            return context.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        //CREATE
        void Add(Usuarios usuario)
        {
            context.Add(usuario);
            context.SaveChanges();
        }
    }
}
