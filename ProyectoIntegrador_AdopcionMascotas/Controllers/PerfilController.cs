using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace ProyectoIntegrador_AdopcionMascotas.Controllers
{
    public class PerfilController : Controller
    {

        Usuario_BL u_bl = new Usuario_BL();
        Animal_BL a_bl = new Animal_BL();
        

        public ActionResult Detalle()
        {
            Usuario u_sesion = (Usuario)Session["Usuario"];
            Usuario_Tuneado ut = u_bl.lista().Where(x => x.CODUSUARIO == u_sesion.CODUSUARIO).FirstOrDefault();
            return View(ut);
        }

        public ActionResult Editar() {

            Usuario u_sesion = (Usuario)Session["Usuario"];

            return View(u_sesion);

        }

        [HttpPost]
        public ActionResult Editar(Usuario u)
        {
            string msg;

            if (ModelState.IsValid == false) return View(u);
            if (u.EMAIL == null) u.EMAIL = "";
            if (u.TELEFONO == null) u.TELEFONO = "";
            if (u.FOTO == null) u.FOTO = "";

            msg = u_bl.editar(u);


            return RedirectToAction("ConfirmarOperacion", "Confirmacion", new { mensaje = msg });

        }


        public ActionResult Anadidas() {

            Usuario u_sesion = (Usuario)Session["Usuario"];
            return View(a_bl.mis_mascotas_anadidas(u_sesion.CODUSUARIO));
        }

        public ActionResult Favoritas() {
            Usuario u_sesion = (Usuario)Session["Usuario"];
            return View(a_bl.mis_mascotas_favoritas(u_sesion.CODUSUARIO));
        }

    }
}