using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaToditoApp3.Model
{
    public class ProductoAlmacen
    {
        public int IdProductoAlmacen { get; set; }
        public detalleingresorapido oProducto { get; set; }
        public Almacen oAlmacen { get; set; }
        public int Stock { get; set; }
        public string FechaRegistro { get; set; }
    }
}
