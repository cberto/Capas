using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Common;
using Datos;

namespace CapaDatos
{
    public class DatosProveedores
    {
        private ConnSQL conn = new ConnSQL();
        private string conexion = "";

        public IList<Proveedor> Buscar()
        {
            IList<Proveedor> proveedores = new List<Proveedor>();
            conexion = conn.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string query = "SELECT P.ID_Proveedor AS 'id',P.Razon_Social AS 'RazonSocial',P.Nombre_Fantasia AS 'NombreFantasia',P.CUIT AS 'Cuit',P.Codigo_Postal AS 'CodigoPostal',P.Telefono AS 'Telefono',P.E_mail AS 'Email',P.Codigo_IVA  AS 'CodigoIva',CI.Descripcion_IVA AS 'DescripcionIva',  P.Contacto AS 'Contacto' FROM EV_Proveedores P INNER JOIN EV_Condiciones_IVA CI ON P.Codigo_IVA = CI.Codigo_IVA";

                    using (SqlCommand sqlcom = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = sqlcom.ExecuteReader();

                        while (reader.Read())
                        {
                            Proveedor prov = new Proveedor();

                            prov.Id = int.Parse(reader[0].ToString());
                            prov.RazonSocial = reader[1].ToString();
                            prov.NombreFantasia = reader[2].ToString();
                            prov.Cuit = int.Parse(reader[3].ToString());
                            prov.CodigoPostal = reader[4].ToString();
                            prov.Telefono = reader[5].ToString();
                            prov.Email = reader[6].ToString();
                            prov.CodigoIva = reader[7].ToString();
                            prov.DescripcionIva = reader[8].ToString();
                            prov.Contacto = reader[9].ToString();

                            proveedores.Add(prov);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex) { throw; }

            return proveedores;
        }

        public Proveedor Buscar(int id)
        {
            Proveedor prov = new Proveedor();
            conexion = conn.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string query = "SELECT P.ID_Proveedor AS 'id',P.Razon_Social AS 'RazonSocial',P.Nombre_Fantasia AS 'NombreFantasia',P.CUIT AS 'Cuit',P.Codigo_Postal AS 'CodigoPostal',P.Telefono AS 'Telefono',P.E_mail AS 'Email',P.Codigo_IVA  AS 'CodigoIva',CI.Descripcion_IVA AS 'DescripcionIva', P.Contacto AS 'Contacto' FROM EV_Proveedores P INNER JOIN EV_Condiciones_IVA CI ON P.Codigo_IVA = CI.Codigo_IVA WHERE P.ID_Proveedor = " + id;

                    using (SqlCommand sqlcom = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = sqlcom.ExecuteReader();

                        while (reader.Read())
                        {
                            prov.Id = int.Parse(reader[0].ToString());
                            prov.RazonSocial = reader[1].ToString();
                            prov.NombreFantasia = reader[2].ToString();
                            prov.Cuit = int.Parse(reader[3].ToString());
                            prov.CodigoPostal = reader[4].ToString();
                            prov.Telefono = reader[5].ToString();
                            prov.Email = reader[6].ToString();
                            prov.CodigoIva = reader[7].ToString();
                            prov.DescripcionIva = reader[8].ToString();
                            prov.Contacto = reader[9].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex) { throw; }

            return prov;
        }

        public string Borrar(int id)
        {
            conexion = conn.ConnectionString;
            string msgError = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();
                    string query = "DELETE FROM EV_Proveedores WHERE ID_Proveedor = " + id;

                    using (SqlCommand sqlcom = new SqlCommand(query, connection))
                    {
                        sqlcom.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e) { msgError = e.Message; }

            return msgError;
        }

        public bool Crear(Proveedor p)
        {
            bool flag = false;
            conexion = conn.ConnectionString;
            string query = "";

            if (p.Id == 0)
                query = string.Format("INSERT INTO EV_Proveedores (Razon_Social, Nombre_Fantasia , CUIT, Codigo_Postal, Telefono, E_mail, Codigo_IVA, Contacto) VALUES('{0}','{1}',{2}, '{3}', '{4}','{5}','{6}', '{7}')", p.RazonSocial, p.NombreFantasia, p.Cuit, p.CodigoPostal, p.Telefono, p.Email, p.CodigoIva, p.Contacto);
            else
                query = String.Format("UPDATE EV_Proveedores SET Razon_Social='{0}', Nombre_Fantasia='{1}', CUIT={2}, Codigo_Postal='{3}', Telefono='{4}', E_mail='{5}', Codigo_IVA='{6}', Contacto='{7}' WHERE ID_Proveedor={8}", p.RazonSocial, p.NombreFantasia, p.Cuit, p.CodigoPostal, p.Telefono, p.Email, p.CodigoIva, p.Contacto, p.Id);

            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
                {
                    connection.Open();

                    using (SqlCommand sqlcom = new SqlCommand(query, connection))
                    {
                        sqlcom.ExecuteNonQuery();
                        flag = true;
                    }
                }
            }
            catch (Exception ex) { flag = false; }
            return flag;
        }
    }
}