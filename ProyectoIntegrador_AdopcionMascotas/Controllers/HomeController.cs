using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoIntegrador_AdopcionMascotas.Models;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace ProyectoIntegrador_AdopcionMascotas.Controllers
{
    public class HomeController : Controller
    {

        Animal_BL a_bl = new Animal_BL();
        TipoAnimal_BL t_bl = new TipoAnimal_BL();
        RazaAnimal_BL r_bl = new RazaAnimal_BL();
        public ActionResult Index(long? tipo, long? raza)
        {

            if (Session["Usuario"] == null)
            {
                return View(a_bl.lista(null, tipo, raza));
            }
            else
            {
                Usuario u = (Usuario)Session["Usuario"];
                return View(a_bl.lista(u.CODUSUARIO, tipo, raza));
            }

        }


        public ActionResult Filtrar_tipo() {
            return View();

        }

        public ActionResult Filtrar_raza(long tipo) {
            ViewBag.razas = new SelectList(r_bl.lista(tipo), "CODRAZA", "DESC_RAZA");
            ViewBag.tipo = tipo;
            return View();
        }

        [HttpPost]
        public ActionResult Filtrar_raza(long tipo,long raza) {

            ViewBag.razas = new SelectList(r_bl.lista(tipo), "CODRAZA", "DESC_RAZA",raza);
            return RedirectToAction("Index", new { tipo, raza });        
        }



    }
}