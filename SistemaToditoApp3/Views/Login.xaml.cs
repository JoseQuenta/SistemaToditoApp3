using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            //El binding context da el contexto de que viewmodel se va a utilizar.
            BindingContext = new Viewmodel.VM_Login();
        }

    }
}