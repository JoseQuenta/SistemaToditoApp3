using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SistemaToditoApp3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //prueba conexion a la base de datos, con el boton de la pagina principal por favor

            //se crea un objeto de tipo conexion
            Model.Conexion conexion = new Model.Conexion();

            //se abre la conexion

            conexion.AbrirConexion();

            //se cierra la conexion

            conexion.CerrarConexion();

            //se muestra un mensaje de conexion exitosa

            DisplayAlert("Conexion", "Conexion exitosa", "OK");


        }
    }
}
