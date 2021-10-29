using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPrincipal.Models
{
    public class CEProveedorModel
    {
        public ProveedorModel Proveedor { get; set; }
        public IList<SelectListItem> ListaCondicionesIva { get; set; }

        public CEProveedorModel()
        {
            Proveedor = new ProveedorModel();
            ListaCondicionesIva = new List<SelectListItem>();
        }
    }
}