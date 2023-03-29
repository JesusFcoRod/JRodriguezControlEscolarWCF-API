using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.addMateriasByIdAlumno(alumnoMateria.Alumno.idAlumno,alumnoMateria.Materia.idMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Exception= ex;
                result.ErrorMessage= ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result MateriasAsignadasGetByIdAlumno(int idAlumno)
        {
            ML.Result resutl = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.MateriasAsignadasGetByIdAlumno(idAlumno).ToList();

                    resutl.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.idMateria = item.idMateria;
                        materia.Nombre = item.Nombre;
                        materia.Costo = decimal.Parse(item.Costo.ToString());

                        resutl.Objects.Add(materia);

                    }
                    resutl.Correct = true;
                }

            }
            catch (Exception ex)
            {
                resutl.Correct = false;
                resutl.Exception = ex;
                resutl.ErrorMessage = ex.Message;
            }
            return resutl;

        }

        public static ML.Result MateriasNoAsignadasGetByIdAlumno(int idAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.MateriasNoAsignadasByIdAlumno(idAlumno).ToList();

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.idMateria = item.idMateria;
                        materia.Nombre = item.Nombre;
                        materia.Costo = decimal.Parse(item.Costo.ToString());

                        result.Objects.Add(materia);
                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.DeleteMateriaAsignada(idMateria);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;

        }
    }
}
