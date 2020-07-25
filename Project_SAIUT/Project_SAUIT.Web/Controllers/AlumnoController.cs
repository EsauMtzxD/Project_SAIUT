using Project_SAIUT.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_SAUIT.Web.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calificaciones()
        {

            ViewBag.items = ListCuatri();

            return View();
        }

        public List<SelectListItem> ListCuatri()
        {

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 1°", Value = "1" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 2°", Value = "2" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 3°", Value = "3" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 4°", Value = "4" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 5°", Value = "5" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 6°", Value = "6" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 7°", Value = "7" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 8°", Value = "8" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 9°", Value = "9", Selected = true });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 10°", Value = "10" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 11°", Value = "11" });

            lst.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            return lst;

        }

        public JsonResult GetCalificaciones(string Cuatri)
        {

            DataRow usr = Usuarios.GetUsuarioByUsr(User.Identity.Name).Rows[0];
            int cuatri = Convert.ToInt32(Cuatri);

            DataTable dt = Usuarios.GetCalificaciones(Convert.ToInt32(usr["Id"]), cuatri);

        }

    }
}