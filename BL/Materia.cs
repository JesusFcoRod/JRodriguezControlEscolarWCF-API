using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        { 
            ML.Result result= new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.AddMateria(materia.Nombre,materia.Costo);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
                result.Correct = false;
            }
            return result;

        }

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.UpdateMateria(materia.idMateria,materia.Nombre,materia.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage= ex.Message;
                result.Exception = ex;
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
                    var query = contex.DeleteMateria(idMateria);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }

            }
            catch (Exception ex)
            {
                result.Exception= ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.GetAllMaterias().ToList();
                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.idMateria = item.idMateria;
                        materia.Nombre= item.Nombre;
                        materia.Costo = decimal.Parse(item.Costo.ToString());

                        result.Objects.Add(materia);
                    }

                    result.Correct = true;

                }

            }
            catch(Exception ex)
            {
                result.Exception = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities contex = new DL.ControlEscolarEntities())
                {
                    var query = contex.MateriaGetById(idMateria).FirstOrDefault();
                    ML.Materia materia = new ML.Materia();

                    materia.idMateria = query.idMateria;
                    materia.Nombre = query.Nombre;
                    materia.Costo = decimal.Parse(query.Costo.ToString());

                    result.Object = materia;
                    result.Correct= true;
                }

            }
            catch(Exception ex)
            {
                result.Exception = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
