using SistemaToditoApp3.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SistemaToditoApp3.Viewmodel.VM_mdProducto;

namespace SistemaToditoApp3.Views.Modales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class mdProducto : ContentPage
	{
		public mdProducto ()
		{
			InitializeComponent ();

			//BindingContext = new Viewmodel.VM_Listar();
			//BindingContext = new Viewmodel.VM_mdProducto();

			var mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;


            //Para limpiar el buscador de la pagina de View mdProducto
            //MessagingCenter.Subscribe<VM_mdProducto>(this, "LimpiarBuscador", LimpiarBuscadorCallback);

        }
		//Metodo para limpiar el buscador
        //private void LimpiarBuscadorCallback(VM_mdProducto producto)
        //{
        //    NombreProductoABuscar.Text = string.Empty;
        //}
    }
}