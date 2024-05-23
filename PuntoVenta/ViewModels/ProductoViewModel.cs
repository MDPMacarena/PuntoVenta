using CommunityToolkit.Mvvm.Input;
using PuntoVenta.Models;
using PuntoVenta.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PuntoVenta.ViewModels
{
    //paso uno
    public enum Ventanas {ver,Agregar,Editar,Eliminar,Usuarios}
   public class ProductoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;               
        //Lista
        public ObservableCollection<Productos> ListaProducto { get; set; }
        //Objeto que vamos a vincular
        public Productos? Producto { get; set; }
        //Vistas
        public Ventanas? Vista { get; set; } = null;
        //Error
        public string Error { get; set; } = "";
        //Comandos
        public ICommand CancelarCommand { get; set; }
        public ICommand VerAgregarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand VerEditarCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand CambiarVistaCommand { get; set; }
        //Instanciar el repocitorio
        ProductoRepository productorepos = new ();
        //Constructor
        public ProductoViewModel()
        {
            ListaProducto = new ObservableCollection<Productos>(productorepos.GetAllPRoductos());
            VerAgregarCommand=new RelayCommand(VerAgregar);
            AgregarCommand=new RelayCommand(Agregar);
            VerEditarCommand=new RelayCommand(VerEditar);
            EditarCommand=new RelayCommand(Editar);
            VerEliminarCommand=new RelayCommand(VerEliminar);
            EliminarCommand=new RelayCommand(Eliminar);
            CambiarVistaCommand = new RelayCommand<Ventanas>(CambiarVista);
            CancelarCommand=new RelayCommand(Cancelar);
        }
        //Metodos Agregar Eliminar Editar verAgregar vereliminar vereditar cancelar cambirvista
        void Cancelar ()
        {
            Producto = null;
            Vista=Ventanas.ver;
            Actualizar();
        }
        void VerAgregar()
        { 
            Producto= new Productos();
            Error = "";
            Vista = Ventanas.Agregar;
            Actualizar();
        }
        void Agregar ()
        {
            if (Producto !=null)
            {
                if (productorepos.Validar(Producto,out  List<string> Errores))
                {
                    productorepos.Agregar(Producto);
                    Vista = Ventanas.ver;
                    ListaProducto = new ObservableCollection<Productos>(productorepos.GetAllPRoductos());
                }
            }
            Actualizar();
        }
        void VerEditar () 
        {
            Error = "";
            if (Producto!=null)
            {
                Productos copi = new();
                copi.Id = Producto.Id;
                copi.Nombre = Producto.Nombre;
                copi.UrlImagen = Producto.UrlImagen;
                copi.Precio = Producto.Precio;
                copi.Descripcion = Producto.Descripcion;
                Producto=copi;
                Vista = Ventanas.Editar;
                Actualizar ();
            }
        }
        void Editar ()
        {
            if (Producto != null)
            {
                if (productorepos.Validar(Producto, out List<string> errores))
                {
                    productorepos.Editar(Producto);
                    Vista = Ventanas.ver;
                    ListaProducto = new ObservableCollection<Productos>(productorepos.GetAllPRoductos());
                }
            }
            Actualizar();
        }
        void VerEliminar ()
        {
            Error = "";
            Vista = Ventanas.Eliminar;
            Actualizar();
        }
        void Eliminar()
        {
            if (Producto != null)
            {
                productorepos.Eliminar(Producto);
                ListaProducto.Remove(Producto);
                Vista = Ventanas.ver;

            }
            Actualizar();
        }
        void CambiarVista (Ventanas vista)
        {
            Vista=vista;
            Actualizar();
        }
        void Actualizar ()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
   }
}