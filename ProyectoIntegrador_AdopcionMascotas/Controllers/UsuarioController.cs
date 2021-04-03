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
    public class UsuarioController : Controller
    {

        Usuario_BL u_bl = new Usuario_BL();

        public ActionResult Registrar(bool estado)
        {
            return View(new Usuario(estado));
        }

        [HttpPost]
        public ActionResult Registrar(Usuario u)
        {
           
            string msg;

            if (ModelState.IsValid == false) return View(u);
            if (u.EMAIL == null) u.EMAIL = "";
            if (u.TELEFONO == null) u.TELEFONO = "";
            if (u.FOTO == null) u.FOTO = "";            

            msg = u_bl.registrar(u);            

            return RedirectToAction("ConfirmarOperacion", "Confirmacion", new { mensaje = msg });
        }


        public ActionResult Detalle(long codusuario) {
            Usuario_Tuneado ut = u_bl.lista().Where(x => x.CODUSUARIO == codusuario).FirstOrDefault();
            return View(ut);
        }
    }
}