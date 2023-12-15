using SistemaToditoApp3.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace SistemaToditoApp3.Viewmodel
{
    public class VM_CerrarSesion
    {
        public ICommand CerrarSesionCommand { get; set; }

        public VM_CerrarSesion()
        {
            CerrarSesionCommand = new Command(OnCerrarSesion);
        }

        private void OnCerrarSesion(object obj)
        {
            Application.Current.MainPage = new Login();
        }
    }
}
