using SistemaToditoApp3.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaToditoApp3.Viewmodel
{
    public class VM_Listar
    {
        private Conexion _conexion;
        //esta clase es para listar todos los productos de la base de datos


        public VM_Listar()
        {
            _conexion = new Conexion();
        }



        public List<detalleingresorapido> Listar()
        {
            List<detalleingresorapido> listaProductos = new List<detalleingresorapido>();

            using (SqlConnection conexion = _conexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "select p.idProducto, p.codigo, p.nombreProducto, p.marca, p.descripcion, p.tamaño, p.unidadMedida, c.idCategoria, c.descripcion[DescripcionCategoria], precioCompra, precioVenta,p.estado from PRODUCTO p inner join CATEGORIA c on c.idCategoria = p.idCategoria";
                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            detalleingresorapido producto = new detalleingresorapido()
                            {
                                IdProducto = Convert.ToInt32(dr["idProducto"]),
                                Codigo = Convert.ToString(dr["codigo"]),
                                Nombre = Convert.ToString(dr["nombreProducto"]),
                                Marca = Convert.ToString(dr["marca"]),
                                Descripcion = Convert.ToString(dr["descripcion"]),
                                Tamaño = Convert.ToString(dr["tamaño"]),
                                UnidadMedida = Convert.ToString(dr["unidadMedida"]),
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(dr["idCategoria"]),
                                    Descripcion = Convert.ToString(dr["DescripcionCategoria"])
                                },
                                PrecioCompra = Convert.ToDecimal(dr["precioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["precioVenta"]),
                                Estado = Convert.ToBoolean(dr["estado"]),
                            };
                            listaProductos.Add(producto);
                        }
                    }
                }
                catch(Exception ex)
                {
                    listaProductos = new List<detalleingresorapido>();
                }
            }
            return listaProductos;
        }
    }
}