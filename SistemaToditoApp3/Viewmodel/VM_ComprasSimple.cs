using SistemaToditoApp3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SistemaToditoApp3.Viewmodel
{
    public class VM_ComprasSimple : INotifyPropertyChanged
    {
     
        private ObservableCollection<DetalleIngresoRapido> _detallesIngresoRapido;
        private List<detalleingresorapido> _productos;
        private string _valorBusqueda;
        private VM_Listar _listarViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AgregarProductoCommand { get; set; }

        public ICommand SeleccionarItem_Command { get; set; }
        private detalleingresorapido _productoSeleccionado;
        public detalleingresorapido ProductoSeleccionado
        {
            get { return _productoSeleccionado; }
            set
            {
                if (_productoSeleccionado != value)
                {
                    _productoSeleccionado = value;
                    OnPropertyChanged(nameof(ProductoSeleccionado));
                }
            }
        }

        public VM_ComprasSimple()
        {
            _listarViewModel = new VM_Listar();
            ProductosSeleccionados = new ObservableCollection<DetalleIngresoRapido>();
            Productos = _listarViewModel.Listar();

            AgregarProductoCommand = new Command(AgregarProducto);

        }


        public ObservableCollection<DetalleIngresoRapido> ProductosSeleccionados
        {
            get => _detallesIngresoRapido;
            set
            {
                if (_detallesIngresoRapido != value)
                {
                    _detallesIngresoRapido = value;
                    OnPropertyChanged(nameof(ProductosSeleccionados));
                }
            }
        }

        public List<detalleingresorapido> Productos
        {
            get => _productos;
            set
            {
                if (_productos != value)
                {
                    _productos = value;
                    OnPropertyChanged(nameof(Productos));
                }
            }
        }

        public string ValorBusqueda
        {
            get
            {
                return _valorBusqueda;
            }
            set
            {
                if (_valorBusqueda != value)
                {
                    _valorBusqueda = value;
                    OnPropertyChanged(nameof(ValorBusqueda));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AgregarProducto()
        {
            string codigoBusqueda = ValorBusqueda.Trim();

            if (string.IsNullOrEmpty(codigoBusqueda))
            {
                App.Current.MainPage.DisplayAlert("Mensaje", "Ingrese un código de producto", "OK");
                return;
            }

            detalleingresorapido producto = Productos.FirstOrDefault(p => p.Codigo.Equals(codigoBusqueda));

            if (producto == null)
            {
                App.Current.MainPage.DisplayAlert("Mensaje", "No se encontró el producto", "OK");
                return;
            }

            DetalleIngresoRapido detalleExistente = ProductosSeleccionados.FirstOrDefault(d => d.oProducto.Codigo == producto.Codigo);

            if (detalleExistente == null)
            {
                DetalleIngresoRapido nuevoDetalle = new DetalleIngresoRapido
                {
                    oProducto = producto,
                    Cantidad = 1
                };
                ProductosSeleccionados.Add(nuevoDetalle);
                Limpiar();
            }
            else
            {
                detalleExistente.Cantidad++;

                Limpiar();
            }

            OnPropertyChanged(nameof(ProductosSeleccionados));
        }

        public void Limpiar()
        {
            ValorBusqueda = string.Empty;

            MessagingCenter.Send(this, "FocusBusqueda");

        }


    }
}