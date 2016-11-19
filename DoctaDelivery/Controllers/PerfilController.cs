using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/
        private DoctaDBDataContext db = new DoctaDBDataContext();

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                String log = User.Identity.Name;
                var logeado = from l in db.Usuarios
                              where l.usuario1 == log
                              select l;
               ViewBag.logear = logeado.ToArray();

                var zona = from z in db.Zonas
                           select z;
                ViewBag.zonas = zona;

                var barrio = from b in db.Barrios
                             orderby b.nombre
                             select b;
                ViewBag.barrios = barrio;
                return View();
            }
            return RedirectToAction("index","Index");
        }

        [HttpPost]
        public ActionResult EditarPerfil(Usuario u)
        {
            String log = User.Identity.Name;
            var edit = from e in db.Usuarios
                       where e.usuario1 == log
                       select e;
            var editar = edit.ToArray();

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
                        editar[0].avatar = fileName;
                    }
                }
            }

            editar[0].apellido = u.apellido;
            editar[0].id_barrio = u.id_barrio;
            editar[0].nombre = u.nombre;
            editar[0].telefono = u.telefono;
            editar[0].calle_numero = u.calle_numero;
            editar[0].e_mail = u.e_mail;
            editar[0].fecha_nac = u.fecha_nac;
            editar[0].documento = u.documento;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

    }
}
