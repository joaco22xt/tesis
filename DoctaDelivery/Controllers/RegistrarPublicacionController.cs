using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class RegistrarPublicacionController : Controller
    {
        private DoctaDBDataContext db = new DoctaDBDataContext();

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                String log = User.Identity.Name;
                var logeado = from l in db.Usuarios
                              where l.usuario1 == log
                              select l;

                var logeado2 = from l in db.Negocios
                               where l.usuario1 == log
                               select l;
                ViewBag.logear = logeado.ToArray();
                ViewBag.logear2 = logeado2.ToArray();

            }

            var tipoProd = from t in db.Tipo_productos
                           select t;
            ViewBag.TiposProductos = tipoProd.ToArray();
            return View();
        }

        public ActionResult CrearPubli(Publicacion p,int id_negocio,string nombre,Foto f) 
        {
            var valid = from v in db.Publicacions
                        where v.id_negocio == id_negocio
                        select v;
            int validacion = valid.ToArray().Length;

            if (validacion == 0)
            {
                if (System.Web.HttpContext.Current.Request.Files != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.Files.Keys.Count; i++)
                    {
                        HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Imagen"), fileName);
                            file.SaveAs(path);
                            nombre = fileName;
                        }
                    }
                }
                
                p.id_negocio = id_negocio;
                p.valoracion = "0";
                db.Publicacions.InsertOnSubmit(p);
                db.SubmitChanges();
                f.id_publicacion = p.id_publicacion;
                f.nombre = nombre;
                f.borrado = 0;
                db.Fotos.InsertOnSubmit(f);
                db.SubmitChanges();
                TempData["Publicacion"]="Publicacion creada con Exito !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Publicacion"] = "Ya tienes una publicacion creada.";
                return RedirectToAction("Index");
            }
        }

    }
}
