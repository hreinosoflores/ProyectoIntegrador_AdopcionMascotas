using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ProyectoIntegrador_AdopcionMascotas.Models;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace ProyectoIntegrador_AdopcionMascotas.Controllers
{
    public class AnimalController : Controller
    {
        //BD_SISTEMA_ADOPCIONEntities bd = new BD_SISTEMA_ADOPCIONEntities();

        Animal_BL a_bl = new Animal_BL();

        RazaAnimal_BL r_bl = new RazaAnimal_BL();

        public string nombreimg(long codigo)
        {

            if (1 <= codigo && codigo < 10) return "img00000" + codigo;
            else
            {
                if (10 <= codigo && codigo < 100) return "img0000" + codigo;
                else
                {
                    if (100 <= codigo && codigo < 1000) return "img000" + codigo;
                    else
                    {
                        if (1000 <= codigo && codigo < 10000) return "img00" + codigo;
                        else
                        {
                            if (10000 <= codigo && codigo < 100000) return "img0" + codigo;
                            else return "img" + codigo;
                        }
                    }
                }
            }

        }



        // GET: Animal
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detalle(long codigo)
        {


            //return View(bd.SP_DETALLE_ANIMAL().Where(x => x.CODANIMAL == codigo).FirstOrDefault());

            Animal_Tuneado at = a_bl.detalle(codigo);
            return View(at);
        }

        public ActionResult ElegirTipo()
        {
            if (Session["Usuario"] == null) {
                Session["next_page"] = new string[] {"RA","0"};
                return RedirectToAction("Logueo", "Logueo");
            } 
            Usuario u = (Usuario)Session["Usuario"];
            ViewBag.dueño = u.CODUSUARIO;
            return View();

        }

        public ActionResult Registrar(long tIPO, long dUEÑO)
        {

            SelectList cboRaza = new SelectList(r_bl.lista(tIPO), "CODRAZA", "DESC_RAZA");

            //SelectList cboRaza = new SelectList(bd.RAZAANIMAL.Where(x => x.CODTIPO == tIPO).OrderBy(x => x.DESC_RAZA).ToList(), "CODRAZA", "DESC_RAZA");
            ViewBag.razas = cboRaza;
            return View(new Animal(tIPO, dUEÑO));
        }

        [HttpPost]
        public ActionResult Registrar(Animal a, HttpPostedFileBase archivo)
        {
            string msg;

            SelectList cboRaza = new SelectList(r_bl.lista(a.TIPO), "CODRAZA", "DESC_RAZA", a.RAZA);
            //SelectList cboRaza = new SelectList(bd.RAZAANIMAL.Where(x => x.CODTIPO == a.TIPO).OrderBy(x => x.DESC_RAZA).ToList(), "CODRAZA", "DESC_RAZA", a.RAZAANIMAL);


            if (ModelState.IsValid == false)
            {
                ViewBag.razas = cboRaza;
                return View(a);
            }

            if (a.EDAD == null) a.EDAD = 0;
            if (a.PESO == null) a.PESO = 0;
            if (a.DESCRIPCION == null) a.DESCRIPCION = "";


            if (archivo == null) {
                a.FOTO = "-";
                msg = a_bl.registrar(a);
            
            }else
            {
                bool p = Path.GetExtension(archivo.FileName) == ".jpg";
                bool q = Path.GetExtension(archivo.FileName) == ".png";
                bool r = Path.GetExtension(archivo.FileName) == ".gif";


                //si el archivo no es jpg, png o gif
                if (!p && !q && !r)
                {
                    ViewBag.ext_invalida = "Debe seleccionar una imagen en formato jpg,png o gif";
                    ViewBag.razas = cboRaza;
                    return View(a);
                }


                try
                {
                    string foto = nombreimg(a_bl.cod_autogenerado()) + Path.GetExtension(archivo.FileName);

                    archivo.SaveAs(Server.MapPath("~/imagenes/animales/" + foto));

                    a.FOTO = foto;
                    
                    msg = a_bl.registrar(a);
                }
                catch (Exception e)
                {
                    msg = "Error: " + e.Message;

                }

            }
            

            ViewBag.razas = cboRaza;
            return RedirectToAction("ConfirmarOperacion", "Confirmacion", new { mensaje = msg });

        }


        public ActionResult Editar(long codanimal) {
            
            Animal a = a_bl.listaAnimales().Where(x => x.CODANIMAL == codanimal).FirstOrDefault();
            SelectList cboRaza = new SelectList(r_bl.lista(a.TIPO), "CODRAZA", "DESC_RAZA");
            ViewBag.razas = cboRaza;
            return View(a);
        }

        [HttpPost]
        public ActionResult Editar(Animal a, HttpPostedFileBase archivo) {

            string msg;

            SelectList cboRaza = new SelectList(r_bl.lista(a.TIPO), "CODRAZA", "DESC_RAZA", a.RAZA);
            //SelectList cboRaza = new SelectList(bd.RAZAANIMAL.Where(x => x.CODTIPO == a.TIPO).OrderBy(x => x.DESC_RAZA).ToList(), "CODRAZA", "DESC_RAZA", a.RAZAANIMAL);


            if (ModelState.IsValid == false)
            {
                ViewBag.razas = cboRaza;
                return View(a);
            }

            if (a.EDAD == null) a.EDAD = 0;
            if (a.PESO == null) a.PESO = 0;
            if (a.DESCRIPCION == null) a.DESCRIPCION = "";


            if (archivo == null)
            {
       
                msg = a_bl.editar(a);

            }
            else
            {
                bool p = Path.GetExtension(archivo.FileName) == ".jpg";
                bool q = Path.GetExtension(archivo.FileName) == ".png";
                bool r = Path.GetExtension(archivo.FileName) == ".gif";


                //si el archivo no es jpg, png o gif
                if (!p && !q && !r)
                {
                    ViewBag.ext_invalida = "Debe seleccionar una imagen en formato jpg,png o gif";
                    ViewBag.razas = cboRaza;
                    return View(a);
                }


                try
                {
                    string foto = nombreimg(a.CODANIMAL) + Path.GetExtension(archivo.FileName);

                    archivo.SaveAs(Server.MapPath("~/imagenes/animales/" + foto));

                    a.FOTO = foto;

                    msg = a_bl.editar(a);
                }
                catch (Exception e)
                {
                    msg = "Error: " + e.Message;

                }

            }


            ViewBag.razas = cboRaza;
            return RedirectToAction("ConfirmarOperacion", "Confirmacion", new { mensaje = msg });
        }

    }
}