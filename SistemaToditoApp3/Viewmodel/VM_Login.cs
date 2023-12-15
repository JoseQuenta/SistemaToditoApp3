using SistemaToditoApp3.Model;
using SistemaToditoApp3.Views;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;

namespace SistemaToditoApp3.Viewmodel
{
    public class VM_Login
    {
        private string _documento;
        private string _clave;
        public ICommand LoginCommand { get; set; }
        private Conexion _conexion;

        public string Documento
        {
            get { return _documento; }
            set
            {
                if (_documento != value)
                {
                    _documento = value;
                    OnPropertyChanged(nameof(Documento));
                }
            }
        }

        public string Clave
        {
            get { return _clave; }
            set
            {
                if (_clave != value)
                {
                    _clave = value;
                    OnPropertyChanged(nameof(Clave));
                }
            }
        }

        public VM_Login()
        {
            Documento = string.Empty;
            Clave = string.Empty;
            LoginCommand = new Command(OnLogin);

            _conexion = new Conexion();
        }

        private async void OnLogin()
        {
            if (string.IsNullOrEmpty(Documento) || string.IsNullOrEmpty(Clave))
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Debe ingresar usuario y contraseña", "Aceptar");
                return;
            }

            try
            {
                using (SqlConnection conexion = _conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "SELECT * FROM Usuario WHERE Documento = @Documento AND Clave = @Clave";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Documento", Documento);
                    cmd.Parameters.AddWithValue("@Clave", Clave);

                    using (SqlDataReader dt = cmd.ExecuteReader())
                    {
                        if (dt.HasRows)
                        {
                            await dt.ReadAsync();
                            var usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dt["IdUsuario"].ToString()),
                                Documento = dt["Documento"].ToString(),
                                NombreCompleto = dt["NombreCompleto"].ToString(),
                                Correo = dt["Correo"].ToString(),
                                Clave = dt["Clave"].ToString(),
                                Telefono = dt["Telefono"].ToString(),
                            };
                            await Application.Current.MainPage.DisplayAlert("Mensaje", "Bienvenido " + dt["NombreCompleto"].ToString(), "Aceptar");
                            //await Application.Current.MainPage.Navigation.PushAsync(new MenuPrincipal(usuario));
                            Application.Current.MainPage = new NavigationPage(new MenuPrincipal(usuario));
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Mensaje", "Usuario o contraseña incorrectos", "Aceptar");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de Conexión: {ex.Message}", "Aceptar");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}