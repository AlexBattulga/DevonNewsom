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
            using(IDbConnection con = Connection)
            {
                return con.Query<RegisterUser>("SELECT * FROM users_dapper").ToList();
            }
        }
        public bool UniqueEmail(string email)
        {
            using(IDbConnection con = Connection)
            {
                string SQL = $"SELECT * FROM users_dapper WHERE Email = @EmailVariable";
                object param = new 
                {
                    EmailVariable = email
                };
                var ListOfUsers = con.Query<RegisterUser>(SQL, param).ToList();
                return ListOfUsers.Count != 0;
            }
        }
        public void CreateUser(RegisterUser user)
        {
            string SQL = 
            @"
                INSERT INTO users_dapper (FirstName, LastName, Email, Password, CreatedAt)
                VALUES (@FirstName, @LastName, @Email, @Password, @CreatedAt)
            ;";
            using(IDbConnection con = Connection)
            {
                con.Execute(SQL, user);
            }
        }
        public RegisterUser GetUserById(int id)
        {
            using(IDbConnection con = Connection)
            {
                string SQL = $"SELECT * FROM users_dapper WHERE UserId = @IdVariable";
                object param = new 
                {
                    IdVariable = id
                };
                return con.Query<RegisterUser>(SQL, param).Single();
            }
        }
        public RegisterUser GetUserByEmail(string email)
        {
            using(IDbConnection con = Connection)
            {
                string SQL = $"SELECT * FROM users_dapper WHERE Email = @EmailVariable";
                object param = new 
                {
                    EmailVariable = email
                };
                return con.Query<RegisterUser>(SQL, param).Single();
            }
        }
    }
}
