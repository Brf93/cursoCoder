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
    public class ValidarUsuarioHandler : DbHandler
    {
        public List<string> InicioSesion()
        {
            List<string> Credenciales = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", sqlConnection);

                sqlConnection.Open();

                DataSet valindandoUsuario = new DataSet();
                sqlDataAdapter.Fill(valindandoUsuario);

                sqlConnection.Close();
            }

            return Credenciales;
        }
    }
}