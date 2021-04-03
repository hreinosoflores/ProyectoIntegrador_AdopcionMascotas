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
    public class LogueoController : Controller
    {

        //BD_SISTEMA_ADOPCIONEntities bd = new BD_SISTEMA_ADOPCIONEntities();

        Usuario_BL u_bl = new Usuario_BL();

        public ActionResult Logueo(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }


        public ActionResult Log_in(string id, string pwd)
        {
            Usuario u = u_bl.logueo(id, pwd);
            if (u == null) return RedirectToAction("Logueo", new { mensaje = "Logueo Incorrecto" });
            Session["Usuario"] = u;
            string[] next_page = (string[])Session["next_page"];
            if (next_page == null) return RedirectToAction("Index","Home");
            switch (next_page[0])
            {
                case "RA":  
                    return RedirectToAction("ElegirTipo", "Animal");
                case "RI":      
                    return RedirectToAction("Detalle", "Animal", new { codigo = long.Parse(next_page[1]) });
                default:
                    return RedirectToAction("ConfirmarOperacion", "Confirmacion",new { mensaje= next_page[0] + "-" + next_page[1]});
            }



        }

        public ActionResult Log_out()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}