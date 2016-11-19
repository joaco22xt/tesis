using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctaDelivery.Models;
using System.Security.Cryptography;
using System.Web.Security;

namespace DoctaDelivery.Controllers
{
    public class RegistrarController : Controller
    {
        private DoctaDBDataContext db = new DoctaDBDataContext();

        // GET: /Usuario/

        public ActionResult Index()
        {
            var zona = from z in db.Zonas
                       select z;
            ViewBag.zonas = zona;

            var barrio = from b in db.Barrios
                         orderby b.nombre
                         select b;
            ViewBag.barrios = barrio;
            return View();
        }

        [AllowAnonymous, ValidateAntiForgeryToken, HttpPost]
        public ActionResult Logeo(string usuario1, string contrasenia, bool recordarme = false)
        {
            var consulta = from c in db.Usuarios
                           where c.usuario1 == usuario1
                           select c;

            var user = consulta.ToArray();

            var consulta2 = from c in db.Negocios
                            where c.usuario1 == usuario1
                            select c;
            var user2 = consulta2.ToArray();


            if (user.Length > 0)
            {
                string pass2 = encriptar(contrasenia);

                if (user[0].contrasenia == pass2 && user[0].usuario1 == usuario1)
                {
                    FormsAuthentication.SetAuthCookie(user[0].usuario1, recordarme);
                    return RedirectToAction("index", "Index");
                }
                else
                {
                    TempData["mensajeError"] = "Usuario i/o Contrañe Incorrecta";
                    return RedirectToAction("Index", "Index");
                }
            }
            else
            {
                if (user2.Length>0)
                {
                    string pass2 = encriptar(contrasenia);
                    if (user2[0].contrasenia == pass2 && user2[0].usuario1 == usuario1)
                    {
                        FormsAuthentication.SetAuthCookie(user2[0].usuario1, recordarme);
                        return RedirectToAction("index", "Index");
                    }
                    else
                    {
                        TempData["mensajeError"] = "Usuario i/o Contrañe Incorrecta";
                        return RedirectToAction("Index", "Index");
                    }

                }

                TempData["mensajeError"] = "Usuario i/o Contrañe Incorrecta";
                return RedirectToAction("Index", "Index");
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Index");
        }

        [HttpPost]
        public ActionResult RegistrarUser(Usuario u) 
        {
            var validu = from c in db.Usuarios
                         select c;
            var i = validu.ToArray();
            int j = 0;
            for (int e = 0; e < i.Length; e++)
            {           
                if (i[e].usuario1 == u.usuario1)
                {
                    j++;
                }
            }

            if (j == 0)
            {
                u.coins = 0;
                u.contrasenia = encriptar(u.contrasenia);
                u.avatar = "avatar-defoult.png";
                db.Usuarios.InsertOnSubmit(u);
                db.SubmitChanges();
                TempData["Logeado"] = "Usuario Registrado con Exito , Por favor Ingrese a su Cuenta";
                return RedirectToAction("index", "Index");
            }
            else
            {
                TempData["Error"] = "Nombre del Usuario ya registrado";
                return RedirectToAction("index", "Registrar");
            }
        }


        public string encriptar(string pw)
        {
            string salt = "asdsadSapkfmpakfmapkfmasdasdh";
            int iteraciones = 1500;
            SHA256 sha256 = SHA256.Create();
            string finalContra = pw + salt;
            byte[] bytesPassword = System.Text.Encoding.UTF8.GetBytes(finalContra);
            try
            {
                for (int i = 0; i <= iteraciones - 1; i++)
                {
                    bytesPassword = sha256.ComputeHash(bytesPassword);
                }
            }
            finally
            {
                sha256.Clear();
            }
            return BitConverter.ToString(bytesPassword).Replace("-", "");

        }
    }
}
