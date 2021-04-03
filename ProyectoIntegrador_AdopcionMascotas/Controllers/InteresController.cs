using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace ProyectoIntegrador_AdopcionMascotas.Controllers
{
    public class InteresController : Controller
    {
        Interes_BL i_bl = new Interes_BL();

        public ActionResult Registrar(long animal)
        {
            if (Session["Usuario"] == null)
            {
                Session["next_page"] = new string[] { "RI",animal+"" };
                return RedirectToAction("Logueo", "Logueo");
            }
            Usuario u = (Usuario)Session["Usuario"];
            string msg;
            msg = i_bl.registrar(animal, u.CODUSUARIO);
            return RedirectToAction("ConfirmarOperacion","Confirmacion",new { mensaje=msg});
        }


        public ActionResult Listar(long codanimal) {
            
            return View(i_bl.listar(codanimal));
        }
    }
}