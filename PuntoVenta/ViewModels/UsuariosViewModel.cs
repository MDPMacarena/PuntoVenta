using CommunityToolkit.Mvvm.Input;
using PuntoVenta.Models;
using PuntoVenta.Repositories;
using System;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PuntoVenta.ViewModels
{
    public enum Ventanasus { ver, Agregarus, Editarus, Eliminarus, Usuariosus }
    public class UsuariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Usuarios> ListaUsuarios { get; set; }
        public string Error { get; set; } = "";
        public Usuarios? Usuariosbb { get; set; }
        public Ventanasus? Vista { get; set; } = null;
        public ICommand VerAgregarusCommand {  get; set; }
        UsuariosRepository Usuariosrepo=new ();
        public UsuariosViewModel()
        {
            ListaUsuarios = new ObservableCollection<Usuarios>(Usuariosrepo.GetAll());
            VerAgregarusCommand = new RelayCommand(VerAgregarus);

        }
       public  void Cancelar()
        {
            Usuariosbb= null;
            Vista = Ventanasus.Usuariosus;
            Actualizar();
        }
       public  void VerAgregarus ()
        {
            Usuariosbb=new Usuarios();
            Error = "";
            Vista = Ventanasus.Agregarus;
            Actualizar();
        }
       public  void Agregar()
        {
            if (Usuariosbb != null)
            {
                if (Usuariosrepo.Validar(Usuariosbb,out List<string> Errores))
                {
                    Usuariosrepo.Add(Usuariosbb);
                    Vista = Ventanasus.Usuariosus;
                    ListaUsuarios = new ObservableCollection<Usuarios>(Usuariosrepo.GetAll());
                }
            }
        }
       public void Actualizar()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
