using Project_SAIUT.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_SAUIT.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string pass)
        {

            DataTable dt = Usuarios.GetUsuario(login, pass);

            if (dt != null && dt.Rows.Count > 0)
            {

                FormsAuthentication.SetAuthCookie(login, true);

                return RedirectToAction("Index", "Alumno");

            }
            else
            {

                ViewBag.Message = "Usuario o Contraseña Invalidos";

                return View();

            }

        } 

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}