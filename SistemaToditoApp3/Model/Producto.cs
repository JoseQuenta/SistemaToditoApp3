using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaToditoApp3.Model
{
    public class detalleingresorapido
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Tamaño { get; set; }
        public string UnidadMedida { get; set; }
        public Categoria oCategoria { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
