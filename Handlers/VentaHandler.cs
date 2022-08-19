using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace PrimerEntrega
    {
        public class VentaHandler : DbHandler
        {
            public List<Venta> GetVentas()
            {
                List<Venta> ventaUsuario = new List<Venta>();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Venta WHERE Id = 1", sqlConnection))
                    {
                        sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta ventaConId = new Venta();

                                ventaConId.Id = Convert.ToInt32(dataReader["Id"]);
                                ventaConId.Comentarios = dataReader["Comentarios"].ToString();
                            }
                        }
                    }
                        sqlConnection.Close();
                    }
                }

                return ventaUsuario;
            }
        }
    }
