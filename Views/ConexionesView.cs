using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System.Drawing.Drawing2D;
using Npgsql;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OracleClient;
using System.IO; // Usado para PostgreSQL


namespace ConectorJamenSotf.Views
{
    public partial class ConexionesView : Form
    {

        private readonly string logFilePath = @"C:\LogsAplicacion\log_conexiones.txt";



        // Método para escribir en el log
        private void Log(string message, bool isError = false)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {(isError ? "ERROR" : "INFO")} - {message}";
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo escribir en el log: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public ConexionesView()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            // Verifica y establece conexión
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un tipo de base de datos.");
                return;
            }

            string tipoBaseDatos = comboBox1.SelectedItem.ToString();
            string servidor = textBox4.Text;
            string usuario = textBox3.Text;
            string contrasena = textBox2.Text;

            if (string.IsNullOrWhiteSpace(servidor) || string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Lógica de conexión
            switch (tipoBaseDatos)
            {
                case "SQLServer":
                    ConectarSQLServer(servidor, usuario, contrasena);
                    break;
                case "MySQL":
                    ConectarMySQL(servidor, usuario, contrasena);
                    break;
                case "Firebase":
                    ConectarFirebase(servidor);
                    break;
                case "PostgreSQL":
                    ConectarPostgreSQL(servidor, usuario, contrasena);
                    break;
                case "Firebird":
                    ConectarFirebird(servidor, usuario, contrasena);
                    break;
                case "Oracle":
                    ConectarOracle(servidor, usuario, contrasena);
                    break;
                default:
                    MessageBox.Show("Tipo de base de datos no soportado.");
                    break;
            }
        }

        // Método para conectar a SQL Server
        private void ConectarSQLServer(string servidor, string usuario, string contrasena)
        {
            string connectionString = $"Server={servidor};User ID={usuario};Password={contrasena};";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión correcta a SQL Server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conexión incorrecta a SQL Server: {ex.Message}");
            }
        }

        // Método para conectar a MySQL
        private void ConectarMySQL(string servidor, string usuario, string contrasena)
        {
            string connectionString = $"Server={servidor};Uid={usuario};Pwd={contrasena};";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión correcta a MySQL.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conexión incorrecta a MySQL: {ex.Message}");
            }
        }

        // Método para conectar a Firebase
        private void ConectarFirebase(string jsonPath)
        {
            try
            {
                // Inicializa la aplicación de Firebase
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(jsonPath)
                });

                MessageBox.Show("Conexión correcta a Firebase.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conexión incorrecta a Firebase: {ex.Message}");
            }
        }

        // Método para conectar a PostgreSQL
        private void ConectarPostgreSQL(string servidor, string usuario, string contrasena)
        {
            string connectionString = $"Host={servidor};Username={usuario};Password={contrasena};";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión correcta a PostgreSQL.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conexión incorrecta a PostgreSQL: {ex.Message}");
            }
        }

        // Método para conectar a Firebird
        private void ConectarFirebird(string servidor, string usuario, string contrasena)
        {
            // Para Firebird, debes especificar la base de datos, pero usaremos un archivo ficticio vacío para la conexión.
            string connectionString = $"User={usuario};Password={contrasena};Database={servidor}:dummy.fdb;";

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión correcta a Firebird.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conexión incorrecta a Firebird: {ex.Message}");
            }
        }

        // Método para conectar a Firebird
        private void ConectarOracle(string servidor, string usuario, string contrasena)
        {
            string connectionString = $"User Id={usuario};Password={contrasena};Data Source={servidor};";

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión correcta a Oracle.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conexión incorrecta a Oracle: {ex.Message}");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

            Log("Se presionó el botón Guardar.");
            // Guarda la configuración
            string rutaArchivo = "conexion.txt";
            string datos = $"{comboBox1.SelectedItem};{textBox4.Text};{textBox3.Text};{textBox2.Text}";

            File.WriteAllText(rutaArchivo, datos);
            MessageBox.Show("Conexión guardada correctamente.");

        }


 

        private void button4_Click(object sender, EventArgs e)
        {
            Log("Se presionó el botón Eliminar.");
            // Lógica de eliminar aquí
            // Restablece configuraciones
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            comboBox1.SelectedItem = null;

            string rutaArchivo = "conexion.txt";
            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }

            MessageBox.Show("Conexión eliminada.");
        }


        // Evento al escribir en el campo servidor
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Log($"Servidor ingresado: {textBox4.Text}");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void ConexionesView_Load(object sender, EventArgs e)
        {

            Log("La vista de conexiones se ha cargado correctamente.");

            // Cargar la configuración guardada al iniciar el programa
    string rutaArchivo = "conexion.txt";
    if (File.Exists(rutaArchivo))
    {
        string[] datos = File.ReadAllText(rutaArchivo).Split(';');
        if (datos.Length == 4)
        {
            comboBox1.SelectedItem = datos[0];
            textBox4.Text = datos[1];
            textBox3.Text = datos[2];
            textBox2.Text = datos[3];
            MessageBox.Show("Configuración cargada correctamente.");
        }
    }




         

        }

       

        // Evento al seleccionar un gestor de base de datos
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gestorSeleccionado = comboBox1.SelectedItem?.ToString() ?? "Ninguno";
            Log($"Gestor de base de datos seleccionado: {gestorSeleccionado}");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Log($"Usuario ingresado: {textBox3.Text}");
        }

        // Evento al escribir en el campo contraseña (sin registrar la contraseña por seguridad)
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Log("Se ingresó una contraseña (no se registra el valor por seguridad).");
        }

        // Evento al escribir en el campo token
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Log($"Token ingresado: {textBox5.Text}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Log("Se presionó el botón Validar.");
            // Lógica de validación aquí
        }
    }
}
