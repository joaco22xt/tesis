using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class EditarPublicacionController : Controller
    {
        private DoctaDBDataContext db = new DoctaDBDataContext();

        public ActionResult Index(int idNegocio)
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

            var publi = from p in db.Publicacions
                        where p.id_negocio == idNegocio
                        select p;

            var f = publi.ToArray();
            var foto = from fo in db.Fotos
                       where fo.id_publicacion == f[0].id_publicacion && fo.borrado==0
                       select fo;
            var count = publi.Count();
            ViewBag.Cantidad = count;
            ViewBag.fotos = foto.ToArray();
            ViewBag.publicacion = publi.ToArray();

            return View();
        }

        public ActionResult EditarPubli(Publicacion p, int id_negocio, string fotosSacar, Foto f, int id_publicacion,Foto g,Foto h)
        {
            var valid = from v in db.Publicacions
                        where v.id_negocio == id_negocio
                        select v;

            var tabfoto = from j in db.Fotos
                          where j.id_publicacion == id_publicacion
                          select j;



            int c = 0;

            var a = valid.ToArray();
            var b = tabfoto.ToArray();
            var foto = fotosSacar.Split('*');
            foto = foto.Except(new string[] { "" }).ToArray();

            for (int i = 0; i < foto.Length; i++)
            {
                for (int m = 0; m < b.Length; m++)
                {
                    if (foto[i] == b[m].nombre)
                    {
                        b[m].borrado = 1;
                    }
                }
            }

            if (System.Web.HttpContext.Current.Request.Files != null)
            {
                for (int i = 0; i < System.Web.HttpContext.Current.Request.Files.Keys.Count; i++)
                {
                    HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        c++;
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Imagen"), fileName);
                        file.SaveAs(path);
                        if (c == 1)
                        {
                            f.nombre = fileName;
                            f.id_publicacion = id_publicacion;
                            f.borrado = 0;
                            db.Fotos.InsertOnSubmit(f);
                            db.SubmitChanges();
                        }
                        if (c == 2)
                        {
                            g.nombre = fileName;
                            g.id_publicacion = id_publicacion;
                            g.borrado = 0;
                            db.Fotos.InsertOnSubmit(g);
                            db.SubmitChanges();
                        }
                        if (c == 3)
                        {
                            h.nombre = fileName;
                            h.id_publicacion = id_publicacion;
                            h.borrado = 0;
                            db.Fotos.InsertOnSubmit(h);
                            db.SubmitChanges();
                        }
 
                    }
                }
            }
            a[0].titulo = p.titulo;
            a[0].descripcion = p.descripcion;
            db.SubmitChanges();

            return RedirectToAction("Index", "EditarPublicacion", new { idNegocio = id_negocio });
        }
        
    }
}
