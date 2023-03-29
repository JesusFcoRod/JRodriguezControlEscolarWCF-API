using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            AlumnoService.AlumnoServiceClient AlumnoService = new AlumnoService.AlumnoServiceClient();
            ML.Result result = AlumnoService.GetAll();

            alumno.Alumnos = result.Objects;
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? idAlumno) {

            ML.Alumno alumno = new ML.Alumno();

            if (idAlumno != null)
            {
                AlumnoService.AlumnoServiceClient alumnoServiceClient = new AlumnoService.AlumnoServiceClient();
                ML.Result result = alumnoServiceClient.GetById(idAlumno.Value);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    return View(alumno); 
                }
                else
                {
                    ViewBag.Message = "Ocurrio un problema al consultar la informacion";
                    return View("Modal");
                }
            }
            else
            {
                return View(alumno);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (alumno.idAlumno > 0)
            {
                AlumnoService.AlumnoServiceClient alumnoServiceClient = new AlumnoService.AlumnoServiceClient();
                result = alumnoServiceClient.Update(alumno);
                ViewBag.Message = "Se ha actualizado el registro";
            }
            else
            {
                AlumnoService.AlumnoServiceClient alumnoServiceClient = new AlumnoService.AlumnoServiceClient();
                result = alumnoServiceClient.Add(alumno);
                ViewBag.Message = "Se ha agregadao el nuevo el registro";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(int idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.idAlumno= idAlumno;

            AlumnoService.AlumnoServiceClient alumnoServiceClient = new AlumnoService.AlumnoServiceClient();
            ML.Result result = alumnoServiceClient.Delete(idAlumno);

            if (result.Correct)
            {
                ViewBag.Message = "Alumno Eliminado con exito";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Ocurrio un problema al eliminar el Alumno";
                return PartialView("Modal");
            }
        }
    }
}