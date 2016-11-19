using DoctaDelivery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctaDelivery.Controllers
{
    public class PerfilNegocioController : Controller
    {
        //
        // GET: /PerfilNegocio/
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

                var logeado2 = from l in db.Negocios
                               where l.usuario1 == log
                               select l;

                ViewBag.logear2 = logeado2.ToArray();

                var zona = from z in db.Zonas
                           select z;
                ViewBag.zonas = zona;

                var barrio = from b in db.Barrios
                             orderby b.nombre
                             select b;
                ViewBag.barrios = barrio;

                var tipo = from t in db.Tipo_negocios
                           select t;
                ViewBag.TipoNeg = tipo;

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditarPerfilNeg(Negocio n)
        {
            String log = User.Identity.Name;
            var edit = from e in db.Negocios
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

            editar[0].nombre = n.nombre;
            editar[0].calle_numero = n.calle_numero;
            editar[0].horario_apertura = n.horario_apertura;
            editar[0].horario_cierre = n.horario_cierre;
            editar[0].id_barrio = n.id_barrio;
            editar[0].id_tipo_negocio = n.id_tipo_negocio;
            editar[0].telefono = n.telefono;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

    }
}
