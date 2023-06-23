﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using listadeProducto;
using listadeProductoVendido;
using listadeUsuario;
using listadeVentas;

namespace ConsoleApp9.Properties.Rep
{
    public class ADO_Metodos
    {
        static string connectionString = @"Server=DESKTOP-U5JEBRP;Database=SistemaGestion;Trusted_Connection=True;";
        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, descripciones, costo, precioVenta, stock, idUsuario FROM Producto";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(reader["id"]);
                    producto.Descripciones = (string)reader["descripciones"];
                    producto.Costo = Convert.ToInt32(reader["costo"]);
                    producto.PrecioVenta = Convert.ToInt32(reader["precioVenta"]);
                    producto.Stock = Convert.ToInt32(reader["stock"]);
                    producto.IdUsuario = Convert.ToInt32(reader["idUsuario"]);

                    productos.Add(producto);
                }

                reader.Close();
            }

            return productos;
        }

        public static List<ProductoVendido> ObtenerProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, idProducto, stock, idVenta FROM ProductoVendido";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.Id = Convert.ToInt32(reader["id"]);
                    productoVendido.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    productoVendido.Stock = Convert.ToInt32(reader["stock"]);
                    productoVendido.IdVenta = Convert.ToInt32(reader["idVenta"]);

                    productosVendidos.Add(productoVendido);
                }

                reader.Close();
            }

            return productosVendidos;
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, nombre, apellido, nombreUsuario, contrasena, mail FROM Usuario";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.Nombre = (string)reader["nombre"];
                    usuario.Apellido = (string)reader["apellido"];
                    usuario.NombreUsuario = (string)reader["nombreUsuario"];
                    usuario.Contrasena = (string)reader["contrasena"];
                    usuario.Mail = (string)reader["mail"];

                    usuarios.Add(usuario);
                }

                reader.Close();
            }
            return usuarios;
        }

        public static List<Ventas> ObtenerVentas()
        {
            List<Ventas> ventas = new List<Ventas>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, comentarios FROM Venta";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ventas venta = new Ventas();
                    venta.Id = Convert.ToInt32(reader["id"]);
                    venta.Comentarios = (string)reader["comentarios"];

                    ventas.Add(venta);
                }

                reader.Close();
            }

            return ventas;
        }

        public static Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contrasena, Mail FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contrasena = @contrasena";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@contrasena", contrasena);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader[0]),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                NombreUsuario = reader.GetString(3),
                                Contrasena = reader.GetString(4),
                                Mail = reader.GetString(5)
                            };
                        }
                        else
                        {

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                            return null;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
                        }
                    }
                }
            }
        }

    }
}