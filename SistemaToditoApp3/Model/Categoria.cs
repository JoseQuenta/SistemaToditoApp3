using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaToditoApp3.Model
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
