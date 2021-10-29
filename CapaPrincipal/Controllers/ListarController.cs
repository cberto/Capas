using System;
using System.Web.Mvc;
using CapaNegocio;

namespace CapaPrincipal.Controllers
{
    public class ListarController : Controller
    {
        private NEGProveedores nprov = new NEGProveedores();
        //
        // GET: /Listar/

        public ActionResult Lista()
        {
            return View(nprov.Buscar());
        }

        public JsonResult BorrarProveedor(string id)
        {
            var _json = "{ \"Resultado\": ";
            // "{ \"Resultado\": , \"Error\": ";

            if (String.IsNullOrEmpty(id))
            {
                _json = _json + "-1, \"Error\": \"No se recibio ningún proveedor para borrar.\" }";
                // "{ \"Resultado\": -1, \"Error\": \"No se recibio ningún proveedor para borrar.\" }";
            }
            else
            {
                int auxId = 0;
                if (int.TryParse(id, out auxId))
                {
                    string msgError = nprov.Borrar(auxId);
                    if (String.IsNullOrEmpty(msgError))
                    {
                        _json = _json + "0, \"Error\": \"\" }";
                    }
                    else
                    {
                        _json = _json + "-1, \"Error\": \"" + msgError + "\" }";
                    }
                }
                else
                {
                    _json = _json + "-1, \"Error\": \"El id recibido no es valido.\" }";
                }
            }

            _json.Replace("\"", "\"");

            return new JsonResult { Data = _json, ContentType = "application/json" };
        }
    }
}