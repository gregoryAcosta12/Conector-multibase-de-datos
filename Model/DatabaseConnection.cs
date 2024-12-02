using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient; // Asegúrate de instalar el paquete MySql.Data desde NuGet

public class DatabaseConnection
{
    public string RutaDB { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }
    public string TipoBaseDatos { get; set; } // "SQLServer" o "MySQL"

    public bool ProbarConexion()
    {
        if (TipoBaseDatos == "SQLServer")
        {
            return ProbarConexionSQL();
        }
        else if (TipoBaseDatos == "MySQL")
        {
            return ProbarConexionMySQL();
        }
        return false;
    }

    private bool ProbarConexionSQL()
    {
        string connectionString = $"Server={RutaDB};User ID={Usuario};Password={Contrasena};";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    private bool ProbarConexionMySQL()
    {
        string connectionString = $"Server={RutaDB};User ID={Usuario};Password={Contrasena};";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
