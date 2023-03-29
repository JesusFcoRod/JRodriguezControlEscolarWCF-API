using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnoService.svc o AlumnoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnoService : IAlumnoService
    {
        public ML.Result Add(ML.Alumno alumno)
        {
            ML.Result resultAdd = BL.Alumno.Add(alumno);

            if (resultAdd.Correct)
            {
                return resultAdd;
            }
            else
            {
                return null;
            }

        }

        public ML.Result Update(ML.Alumno alumno)
        {
            ML.Result resultUpdate = BL.Alumno.Update(alumno);

            if (resultUpdate.Correct)
            {
                return resultUpdate;
            }
            else
            {
                return null;
            }
        }

        public ML.Result Delete(int idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.idAlumno = idAlumno;

            ML.Result resultDelete = BL.Alumno.Delete(idAlumno);

            if (resultDelete.Correct)
            {
                return resultDelete;
            }
            else { return null; }

        }

        public ML.Result GetAll()
        {
            ML.Result resultAll = BL.Alumno.GetAll();

            if (resultAll.Correct)
            {
                return resultAll;
            }
            else
            {
                return null;
            }
        }

        public ML.Result GetById(int idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.idAlumno = idAlumno;

            ML.Result resultId = BL.Alumno.GetById(idAlumno);

            if (resultId.Correct)
            {
                return resultId;
            }
            else
            {
                return null;
            }

        }
    }
}
