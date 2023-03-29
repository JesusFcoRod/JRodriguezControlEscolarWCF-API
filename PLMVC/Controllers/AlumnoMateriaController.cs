using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        public ActionResult AlumnoGetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAll();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }

        [HttpGet]
        public ActionResult MateriasAsignadasByAlumno(int idAlumno)
        {
            ML.Materia materia = new ML.Materia();
            ML.Alumno alumno = new ML.Alumno();

            Session["idAlumno"]= idAlumno;

            ML.Result result = BL.AlumnoMateria.MateriasAsignadasGetByIdAlumno(idAlumno);
            ML.Result resultAlumno = BL.Alumno.GetById(idAlumno);

            alumno = (ML.Alumno)resultAlumno.Object;
            materia.Alumno = alumno;

            materia.Materias = result.Objects;
            return View(materia);
        }

        [HttpGet]
        public ActionResult MateriasNoAsignadasByAlumno(ML.Alumno alumno)
        {
            int idAlumno = alumno.idAlumno;

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.idAlumno = idAlumno;

            ML.Result result = BL.AlumnoMateria.MateriasNoAsignadasGetByIdAlumno(idAlumno);

            if (result.Correct)
            {
                alumnoMateria.AlumnoMaterias = result.Objects;
                return View(alumnoMateria);
            }
            else
            {
                return View(alumnoMateria);
            }

        }

        [HttpPost]
        public ActionResult MateriasNoAsignadasByAlumno(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

            if (alumnoMateria.AlumnoMaterias != null)
            {
                alumnoMateria.Alumno = new ML.Alumno();
                int idAlumno = (int)(Session["idAlumno"]);

                alumnoMateria.Alumno.idAlumno = idAlumno;

                foreach (string idMateria in alumnoMateria.AlumnoMaterias)
                {
                    alumnoMateria.Materia = new ML.Materia();
                    alumnoMateria.Materia.idMateria = int.Parse(idMateria);
                    result = BL.AlumnoMateria.Add(alumnoMateria);
                }
                result.Correct = true;
                ViewBag.Message = "Materias agregadas con exito";

            }
            else
            {
                ViewBag.Message = "Error al agregar las materias seleccionadas";
            }
            return View("Modal");

        }

        [HttpGet]
        public ActionResult DeleteMateriaAsignada(int idMateria)
        {
            ML.Result result = BL.AlumnoMateria.Delete(idMateria);

            if (result.Correct)
            {
                ViewBag.Message = "Materia Eliminada";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Error al intentar eliminar la Materia";
                return PartialView("Modal");
            }
        }
    }
}