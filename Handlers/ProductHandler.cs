using System.Data;
using System.Data.SqlClient;

namespace PrimerEntrega
{
    public class ProductoHandler : DbHandler
    {
        public List<Producto> GetProductos()
        {
            List<Producto> todosProductos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = 1", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto productos = new Producto();
                                productos.Id = Convert.ToInt32(dataReader["Id"]);
                                productos.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productos.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                productos.Costo = Convert.ToInt32(dataReader["Costo"]);
                                productos.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                productos.Descripciones = dataReader["Descripciones"].ToString();

                                todosProductos.Add(productos);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return todosProductos;
        }
    }
}