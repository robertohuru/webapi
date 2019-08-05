using System;
using System.Collections.Generic;
using Npgsql;
using webapi.Models;

namespace webapi.Utils
{
    public class DatabaseConnectionUtil
    {
        public static string server = "130.89.221.193";
        public static int port = 5432;
        public static string user = "postgres";
        public static string password = "admin$";
        public static string dbname = "maris_db";

        public static NpgsqlConnection GetConnection() {
            string connstring = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", server, port, user, password, dbname);
            connstring = "Host=130.89.221.193;Database=maris_db;Username=postgres;Password=admin$";
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            return conn;
        }

        public static User[] getUsers()
        {
            List<User> users = new List<User>();
            NpgsqlConnection conn = DatabaseConnectionUtil.GetConnection();
            string sql = "SELECT id, firstname, lastname, company, email, roleid, date_created, last_updated FROM mamase.users ORDER BY ID ASC";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                User user = new User();
                user.id = int.Parse("" + dr[0]);
                user.name = dr[1] + " " + dr[2];
                user.phone = "" + dr[3];
                user.email = "" + dr[4];
                user.role = int.Parse(dr[5].ToString());
                users.Add(user);
            }
            conn.Close();
            return users.ToArray();
        }
    }
}