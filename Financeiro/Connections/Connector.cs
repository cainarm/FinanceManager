using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associations.Connections
{
    public class Connector
    {
        MySqlConnection conn;
        MySqlCommand cmm;
        MySqlDataReader dr;

        public Connector()
        {
            conn = new MySqlConnection(StrConnection);
        }

        private string StrConnection
        {
            get
            {
                return "Server=localhost" +
                        ";Port=3306" +
                        ";Database=financeiro" +
                        ";Uid=root" +
                        ";Pwd=vertrigo";
            }
        }

        private void Connect()
        {            
            if(conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        private void Close()
        {
            conn.Close();
        }

        public void ExecuteCommand(MySqlCommand pCmd)
        {
            Connect();
            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();
            Close();
        }

        public MySqlDataReader GetDataReader(MySqlCommand pCmd)
        {
            Connect();
            pCmd.Connection = conn;
            dr = pCmd.ExecuteReader();

            return dr;
        }
    }
}