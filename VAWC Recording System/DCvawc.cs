using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace VAWC_Recording_System
{
    internal class DCvawc
    {
    }

    public class RSBDConnection
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;

        private string con;

        //Method/Function
        public string MyConnect()
        {

            con = @"SERVER=localhost;PORT=3306;DATABASE=vawcrsdb;UID=root;PASSWORD=#EvilQweEn45;default command timeout=120";

            return con;
        }
    }
}
