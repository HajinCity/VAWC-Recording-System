using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAWC_Recording_System.NewForms
{

    public class RSBDConnection
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;

        private string con;

        //Method/Function
        public string MyConnect()
        {

            con = @"SERVER=localhost;PORT=3307;DATABASE=vawcrsdb_v1;UID=root;PASSWORD=@dar1234;default command timeout=120";

            return con;
        }

        public string GetPassword(string user)
        {
            try
            {
                RSDBConnect.Open();
                RSDBCommand.CommandText = "SELECT password FROM users WHERE user_id = @name";
                RSDBCommand.Parameters.AddWithValue("@name", user);

                RSBDReader = RSDBCommand.ExecuteReader();
                if (RSBDReader.Read())
                {
                    return RSBDReader["password"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                RSBDReader?.Close();
                RSDBConnect.Close();
            }
            return "";
        }
    }


    }
