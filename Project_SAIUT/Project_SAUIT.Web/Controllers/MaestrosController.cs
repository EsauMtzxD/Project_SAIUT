using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_SAIUT.Entity;

namespace Project_SAUIT.Web.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Maestros
        public ActionResult Alumnos()
        {
            return View();
        }

        public ActionResult Calificaciones()
        {

            ViewBag.ListaGrupos = ListaGrupos();

            return View();

        }

        public static List<SelectListItem> ListaGrupos()
        {

            List<SelectListItem> lst = new List<SelectListItem>();

            DataTable dt = Grupo.ListadeGrupos();

            for(int i = 0; i < dt.Rows.Count; i++)
            {

                lst.Add(new SelectListItem { Text = dt.Rows[i]["Grupos"].ToString(), Value = dt.Rows[i]["Id"].ToString() });

            }

            lst.Insert(0, new SelectListItem { Text = "-- Seleccionar Grupo --", Value = "" });

            return lst;

        }

        public JsonResult GuardarCalificacion(int AlumnoId, decimal Calf)
        {

            string Materia = Maestros.GetMateria(User.Identity.Name.ToString());
            int Cuatri = Alumno.GetCuatri(AlumnoId);
            int Matricula = Alumno.GetMatricula(AlumnoId);
            string Maestro = Usuarios.GetMaestroByUsr(User.Identity.Name.ToString());

            int rowsAffected = Maestros.SubirCalificaciones(Materia, Cuatri, Matricula, Maestro, Calf);

            return Json(rowsAffected, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAlumnoById(int Id)
        {

            string Nombre = Usuarios.GetAlumnoById(Id);

            return Json(Nombre, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAlumnos(int GrupoId)
        {

            List<SelectListItem> lst = new List<SelectListItem>();

            DataTable dt = Usuarios.getAlumnosByGrupoId(GrupoId);

            for(int i = 0; i <dt.Rows.Count; i++)
            {

                lst.Add(new SelectListItem { Text = dt.Rows[i]["Nombre"].ToString(), Value = dt.Rows[i]["Id"].ToString() });

            }

            lst.Insert(0, new SelectListItem { Text = "-- Seleccionar Alumno --", Value = "" });

            return new JsonResult { Data = new SelectList(lst, "Value", "Text"), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpPost]
        public ActionResult Calificaciones(string usr)
        {

            return View();

        }

    }
}