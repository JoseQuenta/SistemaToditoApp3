using SistemaToditoApp3.Model;
using SistemaToditoApp3.Viewmodel;
using SistemaToditoApp3.Views.Modales;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComprasSimple : ContentPage
    {
        private Usuario usuarioActual;
        private mdDetalle detallePage;
        private bool isSelectionHandled = false;

        public ComprasSimple(Usuario usuarioActual)
        {
            InitializeComponent();

            //BindingContext = new Viewmodel.VM_ComprasSimple();
            nombreUsuario.Text = usuarioActual.NombreCompleto;

            //BindingContext = new Viewmodel.VM_CerrarSesion();

            var mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;

            Device.BeginInvokeOnMainThread(() =>
            {
                ValorBusqueda2.Focus();
            });


            MessagingCenter.Subscribe<VM_ComprasSimple>(this, "FocusBusqueda", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ValorBusqueda2.Focus();
                });
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Enfocar la SearchBar al abrir la página
            ValorBusqueda2.Focus();
        }


        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                
                    Navigation.PushModalAsync(new mdDetalle());

                //Navigation.PushModalAsync(new NavigationPage(new mdDetalle()));

                // Deseleccionar el elemento
                ((CollectionView)sender).SelectedItem = null;

                
            }

        }

    }
}
