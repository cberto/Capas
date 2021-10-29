using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    [Serializable]
    public class ConnSQL
    {
        public ConnSQL() { }

        public string ConnectionString
        {
            get { return "Data Source=svr-sqlqa02;Initial Catalog=CAP_2020;Persist Security Info=True;User ID=sa;Password=codes"; }
        }

        //Valida la conexión
        public Boolean TestConnection()
        {
            SqlConnection SQLConnection = new SqlConnection();

            try
            {
                SQLConnection.ConnectionString = this.ConnectionString;
                SQLConnection.Open();
                SQLConnection.Close();
                SQLConnection.Dispose();
                return true;
            }
            catch
            {
                if (SQLConnection != null)
                    SQLConnection.Dispose();

                return false;
            }
        }
    }
}