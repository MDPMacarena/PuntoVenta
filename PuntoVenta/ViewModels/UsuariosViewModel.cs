using PuntoVenta.Models;
using PuntoVenta.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PuntoVenta.ViewModels
{
    //public enum Ventanas { ver, Agregar, Editar, Eliminar, Usuarios }
   public class UsuariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Usuarios> ListaUsuarios { get; set; }
        public Usuarios? Usuariosbb { get; set; }
        public Ventanas? Vista { get; set; } = null;
        UsuariosRepository Usuariosrepo=new ();
        public UsuariosViewModel()
        {
            ListaUsuarios = new ObservableCollection<Usuarios>(Usuariosrepo.GetAll());
        }
        void Cancelar()
        {
            Usuariosbb= null;
            Vista = Ventanas.Usuarios;
            Actualizar();
        }
        void VerAgregar ()
        {
            Usuariosbb=new Usuarios();
            Vista = Ventanas.Agregar;
            Actualizar();
        }
        void Agregar()
        {
            if (Usuariosbb != null)
            {
                if (Usuariosrepo.Validar(Usuariosbb,out List<string> Errores))
                {
                    Usuariosrepo.Add(Usuariosbb);
                    Vista = Ventanas.Usuarios;
                    ListaUsuarios = new ObservableCollection<Usuarios>(Usuariosrepo.GetAll());
                }
            }
        }
        void Actualizar()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
