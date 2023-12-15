using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SistemaToditoApp3.Model
{
    public class DetalleIngresoRapido : INotifyPropertyChanged
    {
        private int _idDetalleIngresoRapido;
        private detalleingresorapido _oProducto;
        private decimal _cantidad;
        private Almacen _oAlmacen;
        private string _fechaRegistro;

        public int IdDetalleIngresoRapido
        {
            get { return _idDetalleIngresoRapido; }
            set
            {
                if (_idDetalleIngresoRapido != value)
                {
                    _idDetalleIngresoRapido = value;
                    OnPropertyChanged(nameof(IdDetalleIngresoRapido));
                }
            }
        }

        public detalleingresorapido oProducto
        {
            get { return _oProducto; }
            set
            {
                if (_oProducto != value)
                {
                    _oProducto = value;
                    OnPropertyChanged(nameof(oProducto));
                }
            }
        }

        public decimal Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                }
            }
        }

        public Almacen oAlmacen
        {
            get { return _oAlmacen; }
            set
            {
                if (_oAlmacen != value)
                {
                    _oAlmacen = value;
                    OnPropertyChanged(nameof(oAlmacen));
                }
            }
        }

        public string FechaRegistro
        {
            get { return _fechaRegistro; }
            set
            {
                if (_fechaRegistro != value)
                {
                    _fechaRegistro = value;
                    OnPropertyChanged(nameof(FechaRegistro));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
