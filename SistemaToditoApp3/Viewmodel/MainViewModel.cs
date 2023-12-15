using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaToditoApp3.Viewmodel
{
    public class MainViewModel
    {
        public VM_Listar Listar { get; set; }
        public VM_mdProducto mdProducto { get; set; }
        public VM_CerrarSesion CerrarSesion { get; set; }
        public VM_ComprasSimple ComprasSimple { get; set; }
        public MainViewModel()
        {
            Listar = new VM_Listar();
            mdProducto = new VM_mdProducto();
            ComprasSimple = new VM_ComprasSimple();
            CerrarSesion = new VM_CerrarSesion();

        }   
    }
}
