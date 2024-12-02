using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConectorJamenSotf.Views
{
    public partial class ConfiguracionView : Form
    {
        public ConfiguracionView()
        {
            InitializeComponent();
        }
        // Cadena de conexión a SQL Server
       
        private void ConfiguracionView_Load(object sender, EventArgs e)
        {


        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void btCrea_Click(object sender, EventArgs e)
        {
            string databaseName = txtDB.Text.Trim();
            string tableName = textTabla.Text.Trim();

            if (string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Por favor ingrese el nombre de la base de datos y de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recuperar configuración guardada
            string rutaArchivo = "conexion.txt";
            if (!File.Exists(rutaArchivo))
            {
                MessageBox.Show("Primero configura la conexión antes de crear bases de datos y tablas.");
                return;
            }

            string[] datos = File.ReadAllText(rutaArchivo).Split(';');
            if (datos.Length != 4)
            {
                MessageBox.Show("El archivo de configuración no tiene el formato esperado.");
                return;
            }

            string gestor = datos[0]; // Gestor de base de datos (SQLServer, MySQL, Firebird)
            string servidor = datos[1];
            string usuario = datos[2];
            string contrasena = datos[3];

            if (gestor == "SQLServer")
            {
                CrearBaseDatosYTablaSQLServer(servidor, usuario, contrasena, databaseName, tableName);
            }
            else if (gestor == "MySQL")
            {
                CrearBaseDatosYTablaMySQL(servidor, usuario, contrasena, databaseName, tableName);
            }
            else if (gestor == "Firebird")
            {
                CrearBaseDatosYTablaFirebird(servidor, usuario, contrasena, databaseName, tableName);
            }
            else
            {
                MessageBox.Show("Gestor de base de datos no soportado.");
            }
        }

        private void CrearBaseDatosYTablaSQLServer(string servidor, string usuario, string contrasena, string databaseName, string tableName)
        {
            string connectionString = $"Server={servidor};User ID={usuario};Password={contrasena};";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Crear base de datos
                    string createDbQuery = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{databaseName}') " +
                                           $"CREATE DATABASE {databaseName};";
                    SqlCommand cmd = new SqlCommand(createDbQuery, conn);
                    cmd.ExecuteNonQuery();

                    conn.ChangeDatabase(databaseName);

                    // Crear tabla
                    string createTableQuery = $@"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}')
                    CREATE TABLE {tableName} (
                        CodigoSeguridad INT PRIMARY KEY IDENTITY(1,1),
                        TrackID NVARCHAR(50) NOT NULL,
                        FechaFirma DATETIME NOT NULL,
                        UrlLarga NVARCHAR(300) NOT NULL
                    );";

                    cmd.CommandText = createTableQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Base de datos '{databaseName}' y tabla '{tableName}' creadas exitosamente (SQL Server).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearBaseDatosYTablaMySQL(string servidor, string usuario, string contrasena, string databaseName, string tableName)
        {
            string connectionString = $"Server={servidor};User ID={usuario};Password={contrasena};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Crear base de datos
                    string createDbQuery = $"CREATE DATABASE IF NOT EXISTS {databaseName};";
                    MySqlCommand cmd = new MySqlCommand(createDbQuery, conn);
                    cmd.ExecuteNonQuery();

                    conn.ChangeDatabase(databaseName);

                    // Crear tabla
                    string createTableQuery = $@"
                    CREATE TABLE IF NOT EXISTS {tableName} (
                        CodigoSeguridad INT AUTO_INCREMENT PRIMARY KEY,
                        TrackID VARCHAR(50) NOT NULL,
                        FechaFirma DATETIME NOT NULL,
                        UrlLarga VARCHAR(300) NOT NULL
                    );";

                    cmd.CommandText = createTableQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Base de datos '{databaseName}' y tabla '{tableName}' creadas exitosamente (MySQL).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearBaseDatosYTablaFirebird(string servidor, string usuario, string contrasena, string databaseName, string tableName)
        {
            string filePath = $"{servidor}\\{databaseName}.fdb"; // Ruta completa del archivo de base de datos
            string connectionString = $"User={usuario};Password={contrasena};Database={filePath};DataSource={servidor};Dialect=3;Charset=UTF8;";

            try
            {
                // Verificar si la base de datos ya existe
                if (!File.Exists(filePath))
                {
                    FbConnection.CreateDatabase(connectionString);
                    MessageBox.Show($"Base de datos '{databaseName}' creada exitosamente en Firebird.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                using (FbConnection conn = new FbConnection(connectionString))
                {
                    conn.Open();

                    // Crear tabla si no existe
                    string createTableQuery = $@"
                    CREATE TABLE IF NOT EXISTS {tableName} (
                        CodigoSeguridad INT PRIMARY KEY,
                        TrackID VARCHAR(50) NOT NULL,
                        FechaFirma TIMESTAMP NOT NULL,
                        UrlLarga VARCHAR(300) NOT NULL
                    );";

                    FbCommand cmd = new FbCommand(createTableQuery, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Tabla '{tableName}' creada exitosamente en la base de datos '{databaseName}' (Firebird).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}