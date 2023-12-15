using SistemaToditoApp3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Transferencias : ContentPage
    {
        private Usuario usuarioActual;
        public Transferencias(Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;


            BindingContext = new Viewmodel.VM_CerrarSesion();
        }
    }
}