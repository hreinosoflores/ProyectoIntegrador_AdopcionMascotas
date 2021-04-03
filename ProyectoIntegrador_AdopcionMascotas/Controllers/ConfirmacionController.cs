using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegrador_AdopcionMascotas.Controllers
{
    public class ConfirmacionController : Controller
    {
        // GET: Confirmacion
        public ActionResult ConfirmarOperacion(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }
    }
}