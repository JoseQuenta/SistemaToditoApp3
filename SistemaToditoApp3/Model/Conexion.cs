using System.Data.Common;
using System.Data.SqlClient;

namespace SistemaToditoApp3.Model
{
    public class Conexion
    {
        private SqlConnection _conexionBD;

        private string Server = "josequenta.database.windows.net,1433";
        private string Database = "ToditoApp2";
        private string UserID = "josequenta";
        private string Password = "744872Xd@";

        public Conexion()
        {
            string cadenaConexion = $"server=tcp:{Server};initial catalog={Database};user id={UserID};password={Password};persist security info=false;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;connection timeout=30;";
            //crea la cadena de conexion

            //se crea un objeto de tipo sqlconnection y se le pasa la cadena de conexion como parametro 
            _conexionBD = new SqlConnection(cadenaConexion);

        }

        public void AbrirConexion()
        {
            //metodo para abrir la conexion
            if (_conexionBD.State == System.Data.ConnectionState.Closed)
            {
                _conexionBD.Open();
            }
        }

        public void CerrarConexion()
        {
            //metodo para cerrar la conexion
            if (_conexionBD.State == System.Data.ConnectionState.Open)
            {
                _conexionBD.Close();
            }
        }

        public SqlConnection ObtenerConexion()
        {
            //metodo para retornar la conexion
            _conexionBD.ConnectionString = $"server=tcp:{Server};initial catalog={Database};user id={UserID};password={Password};persist security info=false;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;connection timeout=30;";
            return _conexionBD;
        }

        public void Dispose()
        {
            if (_conexionBD != null)
            {
                CerrarConexion();
                _conexionBD.Dispose();
            }
        }
    }
}