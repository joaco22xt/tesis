using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class PublicacionController : Controller
    {
        //
        // GET: /Publicacion/
        private DoctaDBDataContext db = new DoctaDBDataContext();

        public ActionResult Index(int id_publicacion)
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

            var publicacion = from p in db.Publicacions
                              where p.id_publicacion == id_publicacion
                              select p;

            ViewBag.publicaciones = publicacion.ToArray();
            var publi =  publicacion.ToArray();

            var foto = from f in db.Fotos
                       where f.id_publicacion == id_publicacion && f.borrado==0
                       select f;

            ViewBag.fotos = foto.ToArray();

            var producto = from r in db.Productos
                            where r.id_negocio == publi[0].id_negocio
                            select r;
            ViewBag.productos = producto.ToArray();

            var tipo = from r in db.Tipo_productos
                           select r;

            ViewBag.tipos = tipo.ToArray();

            return View();
        }

        [HttpPost]
        public ActionResult Editar(int tipo , int id_negocio,int id_publicacion)
        {
            var buscar = from b in db.Productos
                         where b.id_tipo_producto == tipo && b.id_negocio == id_negocio
                         select b;
            ViewBag.Seleccionados = buscar.ToArray();

            return RedirectToAction("Index", new { id_publicacion = id_publicacion });
        }
    }
}
