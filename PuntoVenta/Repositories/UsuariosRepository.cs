using Microsoft.EntityFrameworkCore.Update.Internal;
using PuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Collections.ObjectModel;
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
        public void Add(Usuarios usuario)
        {
            context.Add(usuario);
            context.SaveChanges();
        }
        //DELETE
        public void Delete(Usuarios usuario)
        {
            context.Remove(usuario);
            context.SaveChanges();
        }
        //UPDATE
        public void Update(Usuarios usuarioEd)
        {
            if (usuarioEd != null)
            {
                var p = context.Usuarios.FirstOrDefault(x => x.Id == usuarioEd.Id);
                if (p != null)
                {
                    p.Nombre = usuarioEd.Nombre;
                    p.Rol=usuarioEd.Rol;
                    p.Password=usuarioEd.Password;
                    p.Usuario=usuarioEd.Usuario;
                    context.SaveChanges();
                }
            }
        }
        public bool Validar (Usuarios p, out List<string> Errores)
        {
            Errores = new List<string>();
            if (p!=null)
            {
                if (string.IsNullOrEmpty(p.Usuario))
                {
                    Errores.Add("Escriba el usuario");
                }
                if (string.IsNullOrEmpty(p.Rol))
                {
                    Errores.Add("Escriba el rol del usario");
                }
                if (string.IsNullOrEmpty(p.Nombre))
                {
                    Errores.Add("Escriba un nombre");
                }
                if (!string.IsNullOrEmpty(p.Password))
                {
                    Errores.Add("Escriba una password");
                }
            }
            return Errores.Count == 0;
        }
    }
}
