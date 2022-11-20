using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CA_inlämmning1
{
    internal class Connect
    {
        public MySqlConnection Conn()
        {
            var connString = @"server=ns8.inleed.net;uid=s60127_Carlo;pwd=81htRoKUjd6egLrc;database=s60127_MolnstersInc";
            var cnn = new MySqlConnection(connString);
            cnn.Open();
            return cnn;
        }


    }
}
