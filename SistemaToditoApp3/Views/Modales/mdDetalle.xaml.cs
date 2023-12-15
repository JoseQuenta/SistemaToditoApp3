using SistemaToditoApp3.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaToditoApp3.Views.Modales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class mdDetalle : ContentPage
	{
        public int Cantidad { get; set; }

        private static detalleingresorapido productoActual;
        public mdDetalle ()
		{
            InitializeComponent();
            CantidadEntry.Text = Cantidad.ToString();
            //para que se muestre el producto seleccionado en la pagina de detalle 
            //BindingContext = producto;
            

            //nombreProducto.Text = objproducto.Nombre;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(CantidadEntry.Text != null)
            {
                Cantidad = Convert.ToInt32(CantidadEntry.Text);
                
            }
            else
            {
                Cantidad = 1;
            }

            productoActual.Stock = Cantidad;
            

            Navigation.PopModalAsync();

        }
    }
}