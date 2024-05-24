using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_23_de_mayo.Data
{
    internal class ConexionMysql
    {
        string connectionString = "server=localhost;database=LaboratorioCRUD;user=root;password=Shyro#23112004";

        private MySqlConnection connection;
        public ConexionMysql()
        {
            connection = new MySqlConnection(connectionString);
        }
        public void Insertar(string nombre, string apellido, DateTime fechaNacimiento, string email, decimal saldo, bool activo)
        {
            try
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellido, FechaNacimiento, Email, Saldo, Activo) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Email, @Saldo, @Activo)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Saldo", saldo); //decimal.Parse(txtSaldo.Text)
                cmd.Parameters.AddWithValue("@Activo", activo);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
