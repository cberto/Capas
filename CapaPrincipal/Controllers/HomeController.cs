using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;

namespace CapaPrincipal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Listar/

        public ActionResult Index()
        {
            return View();
        }

    }
}
