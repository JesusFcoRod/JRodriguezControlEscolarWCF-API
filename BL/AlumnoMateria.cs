using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public ML.Result MateriasAsignadasGetByIdAlumno(int idAlumno)
        {
            ML.Result resutl = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.MateriasAsignadasGetByIdAlumno(idAlumno);



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
    }
}
