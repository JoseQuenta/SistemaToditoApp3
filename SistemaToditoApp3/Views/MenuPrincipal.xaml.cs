using SistemaToditoApp3.Model;
using SistemaToditoApp3.Views.Modales;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        private static Usuario usuarioActual;
        public MenuPrincipal(Usuario objusuario)
        {
            InitializeComponent();

            usuarioActual = objusuario;
            
            nombreUsuario.Text = objusuario.NombreCompleto;

            BindingContext = new Viewmodel.VM_CerrarSesion();

            //if (usuarioActual.TipoUsuario == "Administrador")
            //{
            //    btnUsuarios.IsVisible = true;
            //    btnProductos.IsVisible = true;
            //    btnProveedores.IsVisible = true;
            //    btnClientes.IsVisible = true;
            //    btnVentas.IsVisible = true;
            //    btnCompras.IsVisible = true;
            //    btnTransferencias.IsVisible = true;
            //}
            //else if (usuarioActual.TipoUsuario == "Vendedor")
            //{
            //    btnUsuarios.IsVisible = false;
            //    btnProductos.IsVisible = false;
            //    btnProveedores.IsVisible = false;
            //    btnClientes.IsVisible = true;
            //    btnVentas.IsVisible = true;
            //    btnCompras.IsVisible = false;
            //    btnTransferencias.IsVisible = false;
            //}
            //else if (usuarioActual.TipoUsuario == "Bodeguero")
            //{
            //    btnUsuarios.IsVisible = false;
            //    btnProductos.IsVisible = true;
            //    btnProveedores.IsVisible = true;
            //    btnClientes.IsVisible = false;
            //    btnVentas.IsVisible = false;
            //    btnCompras.IsVisible = true;
            //    btnTransferencias.IsVisible = true;
            //}

        }

        private void Ingresos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Compras(usuarioActual));
        }

        private void Transferencias_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Transferencias(usuarioActual));
        }

        //private void VerProducto_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new Producto(usuarioActual));
        //}

        private void ComprasRapidas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ComprasSimple(usuarioActual));
        }

        private void MDProductos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new mdProducto());
        }
    }
}