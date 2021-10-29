using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaPrincipal.Models;
using Common;

namespace CapaPrincipal.Controllers
{
    public class AltaController : Controller
    {
        private NEGProveedores negPer = new NEGProveedores();
        private NEGCondicionesIva negCI = new NEGCondicionesIva();

        //
        // GET: /Alta/

        public ActionResult Alta(string id)
        {
            if (String.IsNullOrEmpty(id))
                id = "0";

            return View(ConseguirPersonaCrearEditar(int.Parse(id)));
        }

        [HttpPost]
        public ActionResult Alta(ProveedorModel proveedor)
        {
            if (ModelState.IsValid)
            {
                Proveedor per = new Proveedor()
                {
                    Id = proveedor.Id,
                    RazonSocial = proveedor.RazonSocial,
                    NombreFantasia = proveedor.NombreFantasia,
                    Cuit = proveedor.Cuit,
                    CodigoPostal = proveedor.CodigoPostal,
                    Telefono = proveedor.Telefono,
                    Email = proveedor.Email,
                    CodigoIva = proveedor.CodigoIva,
                    DescripcionIva = proveedor.DescripcionIva,
                    Contacto = proveedor.Contacto,

                };

                negPer.Crear(per);

                return RedirectToAction("../Listar/Lista");
            }
            else
                return View(new CEProveedorModel() { Proveedor = proveedor, ListaCondicionesIva = ConseguirLista() });
        }

        private CEProveedorModel ConseguirPersonaCrearEditar(int id)
        {
            return new CEProveedorModel() { Proveedor = ConseguirPersona(id), ListaCondicionesIva = ConseguirLista() };
        }

        private ProveedorModel ConseguirPersona(int id)
        {
            Proveedor prov = negPer.Buscar(id);
            ProveedorModel provModel = new ProveedorModel()
            {
                Id = prov.Id,
                RazonSocial = prov.RazonSocial,
                NombreFantasia = prov.NombreFantasia,
                Cuit = prov.Cuit,
                CodigoPostal = prov.CodigoPostal,
                Telefono = prov.Telefono,
                Email = prov.Email,
                CodigoIva = prov.CodigoIva,
                DescripcionIva = prov.DescripcionIva,
                Contacto = prov.Contacto,
            };
            return provModel;
        }

        private IList<SelectListItem> ConseguirLista()
        {
            IList<SelectListItem> selectItems = new List<SelectListItem>();

            selectItems.Add(new SelectListItem { Text = "Seleccione", Value = "" });

            foreach (CondicionesIVA t in negCI.Buscar())
                selectItems.Add(new SelectListItem { Text = t.DescripcionIva, Value = t.CodigoIva });

            return selectItems;
        }
    }
}