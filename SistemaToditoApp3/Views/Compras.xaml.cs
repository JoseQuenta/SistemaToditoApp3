using SistemaToditoApp3.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compras : ContentPage
    {
        private Usuario usuarioActual;
        public Compras(Usuario usuarioActual)
        {
            InitializeComponent();

            //this.usuarioActual = usuarioActual;

            nombreUsuario.Text = usuarioActual.NombreCompleto;

            BindingContext = new Viewmodel.VM_CerrarSesion();
        }
    }
}