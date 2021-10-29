using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Common;
using Datos;

namespace CapaDatos
{
    public class DatosCondicionesIva
    {
        private ConnSQL conn = new ConnSQL();
        private string conexion = "";

        public IList<CondicionesIVA> Buscar()
        {
            IList<CondicionesIVA> condicionesIva = new List<CondicionesIVA>();
            conexion = conn.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string query = "SELECT Codigo_IVA  AS 'CodigoIva', Descripcion_IVA AS 'DescripcionIva' FROM EV_Condiciones_IVA";

                    using (SqlCommand sqlcom = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = sqlcom.ExecuteReader();

                        while (reader.Read())
                        {
                            CondicionesIVA condi = new CondicionesIVA();

                            condi.CodigoIva = reader[0].ToString();
                            condi.DescripcionIva = reader[1].ToString();

                            condicionesIva.Add(condi);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex) { throw; }

            return condicionesIva;
        }
    }
}

