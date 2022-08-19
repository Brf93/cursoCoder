using PrimerEntrega;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEntrega
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuarios> GetUsuarios()
        {
            List<Usuarios> unUsuario = new List<Usuarios>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT NombreUsuario FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    { 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuarios datoUsuario = new Usuarios();

                                datoUsuario.Id = Convert.ToInt32(dataReader["Id"]);
                                datoUsuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                datoUsuario.Nombre = dataReader["Nombre"].ToString();
                                datoUsuario.Apellido = dataReader["Apellido"].ToString();
                                datoUsuario.Contraseña = dataReader["Contraseña"].ToString();
                                datoUsuario.Mail = dataReader["Mail"].ToString();
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }
            return unUsuario;
        }
    }
}