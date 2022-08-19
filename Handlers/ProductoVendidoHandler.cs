using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimerEntrega
{
    public class ProductosVendido : DbHandler
    {
        public List<ProductosVendido> GetProdVend()
        {
            List<ProductosVendido> prodVendidoTodos = new List<ProductosVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido WHERE Id = 1", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido ProductoVendido = new ProductoVendido();

                                ProductoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                ProductoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                ProductoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                ProductoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return prodVendidoTodos;
        }
    }
}