using SistemaToditoApp3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SistemaToditoApp3.Viewmodel
{
    public class VM_mdProducto : INotifyPropertyChanged
    {
        private VM_Listar _listarViewModel;

        private string _valorBusqueda;
        public string ValorBusqueda
        {
            get { return _valorBusqueda; }
            set
            {
                if (_valorBusqueda != value)
                {
                    _valorBusqueda = value;
                    OnPropertyChanged(nameof(ValorBusqueda));
                    FiltrarProductos();
                }
            }
        }

        private List<detalleingresorapido> _productos;
        public List<detalleingresorapido> Productos
        {
            get { return _productos; }
            set
            {
                if (_productos != value)
                {
                    _productos = value;
                    OnPropertyChanged(nameof(Productos));
                }
            }
        }

        private List<detalleingresorapido> _productosFiltrados;
        public List<detalleingresorapido> ProductosFiltrados
        {
            get { return _productosFiltrados; }
            set
            {
                if (_productosFiltrados != value)
                {
                    _productosFiltrados = value;
                    OnPropertyChanged(nameof(ProductosFiltrados));
                }
            }
        }

        public ICommand BuscarProductoCommand { get; set; }

        public VM_mdProducto()
        {
            _listarViewModel = new VM_Listar();
            Productos = _listarViewModel.Listar();
            ProductosFiltrados = Productos;
            BuscarProductoCommand = new Command(BuscarProducto);
        }

        private void FiltrarProductos()
        {
            if (string.IsNullOrEmpty(ValorBusqueda))
            {
                ProductosFiltrados = Productos;
            }
            else
            {
                string ValorBusquedaMinuscula = ValorBusqueda.ToLower();
                ProductosFiltrados = Productos
                    .Where(p => p.Codigo.Contains(ValorBusqueda) ||
                                p.Nombre.ToLower().Contains(ValorBusquedaMinuscula) ||
                                p.Marca.ToLower().Contains(ValorBusquedaMinuscula) ||
                                p.Descripcion.ToLower().Contains(ValorBusquedaMinuscula) ||
                                p.Tamaño.Contains(ValorBusquedaMinuscula) ||
                                p.UnidadMedida.ToLower().Contains(ValorBusquedaMinuscula)
                                )
                    .ToList();
            }
        }

        private void BuscarProducto()
        {
            FiltrarProductos();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}