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

        public static int Cuatri = 0;

        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calificaciones()
        {

            ViewBag.items = ListCuatri();

            ViewBag.c = "Cuatrimestre " + Convert.ToString(Cuatri);

            DataRow usr = Usuarios.GetUsuarioByUsr(User.Identity.Name).Rows[0];

            DataTable dt = Usuarios.GetCalificaciones(Convert.ToInt32(usr["login"]), Cuatri);

            Project_SAIUT.Entity.Calificaciones c = new Calificaciones();

            foreach(DataRow dr in dt.Rows)
            {

                c.maestro = dr["maestro"].ToString();
                c.materia = dr["materia"].ToString();
                c.calificaciones = Convert.ToDecimal(dr["calificacion"]);

            }

            return View(c);
        }

        public ActionResult GetCuatri(int cuatri)
        {
            Cuatri = cuatri;

            return RedirectToAction("Calificaciones", "Alumno");

        }

        public List<SelectListItem> ListCuatri()
        {

            List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem { Text = "-- Seleccionar --", Value = "" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 1°", Value = "1" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 2°", Value = "2" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 3°", Value = "3" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 4°", Value = "4" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 5°", Value = "5" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 6°", Value = "6" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 7°", Value = "7" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 8°", Value = "8" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 9°", Value = "9" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 10°", Value = "10" });
            lst.Add(new SelectListItem { Text = "CUATRIMESTRE 11°", Value = "11" });

            return lst;

        }

        public ActionResult Adeudo()
        {
            return View();
        }

    }
}