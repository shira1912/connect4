using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourServer
{
    internal class ConnectionToSql
    {
        string connectionString;
        SqlConnection connection;
        SqlCommand command;


        public ConnectionToSql()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Shira Noiman\Desktop\Cyber\MyGame2\MyGame2\App_Data\Database1.mdf"";Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
        }

        public void InsertNewUser(string username, string password, string firstName, string lastName, string email, string city, string gender)
        {
            command.CommandText = "INSERT INTO Users (username, password, firstName, lastName, email, city, gender) " +
                                  "VALUES (@username, @password, @firstName, @lastName, @email, @city, @gender)";
        
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@gender", gender);
        
            connection.Open();
            command.Connection = connection;
            int x = command.ExecuteNonQuery();
            connection.Close();
        }
      
        public bool IsExist(string username)
        {
            command.CommandText = " SELECT COUNT(username) FROM Users WHERE username='" + username + "'";
            connection.Open();
            command.Connection = connection;
            int x = (int)command.ExecuteScalar();
            connection.Close();
            if (x > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool IsMatchingPass(string username, string password)
        {
            command.CommandText = "SELECT COUNT(*) FROM Users WHERE username='" + username + "'AND password= '" + password + "'";
            connection.Open();
            command.Connection = connection;
            int x = (int)command.ExecuteScalar();
            connection.Close();
            if (x > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}