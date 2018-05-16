using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using LoginReg.Models;
using MySql.Data.MySqlClient;

namespace LoginReg
{
    public class UserFactory
    {
        static string server = "localhost";
        static string db = "mydb"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        
        public List<RegisterUser> GetAllUsers()
        {
            using(IDbConnection connection = Connection)
            {
                return connection.Query<RegisterUser>("SELECT * FROM users_dapper").ToList();
            }
        }
        public bool EmailIsUnique(string email)
        {
            using(IDbConnection connection = Connection)
            {
                object param = new 
                {
                    EmailVar = email
                };
                var users = connection.Query<RegisterUser>($"SELECT * FROM users_dapper WHERE Email = @EmailVar", param).ToList();
                return users.Count < 1;
            }
        }
        public void CreateUser(RegisterUser user)
        {
            string SQL = "INSERT INTO users_dapper (FirstName, LastName, Email, Password, CreatedAt) VALUES (@FirstName, @LastName, @Email, @Password, @CreatedAt)";
            using(IDbConnection connection = Connection)
            {
                connection.Execute(SQL, user);
            }
        }

    }
}