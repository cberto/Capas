using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public int Cuit { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CodigoIva { get; set; }
        public string DescripcionIva { get; set; }
        public string Contacto { get; set; }


        public Proveedor()
        {
            Id = 0;
            RazonSocial = "";
            NombreFantasia = "";
            Cuit = 0;
            CodigoPostal = "";
            Telefono = "";
            Email = "";
            CodigoIva = "";
            DescripcionIva = "";
            Contacto = "";
        }
    }
}