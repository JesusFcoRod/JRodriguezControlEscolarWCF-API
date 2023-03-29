using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (idMateria != null)
            {
                materia.idMateria = idMateria.Value;
                ML.Result result = new ML.Result();

                try
                {
                    using (var client = new HttpClient())
                    {
                        string urlApi = ConfigurationManager.AppSettings["urlApi"];
                        client.BaseAddress = new Uri(urlApi);

                        var responseTask = client.GetAsync("Materia/GetById/" + idMateria);
                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            string usuarioCast = readTask.Result.Object.ToString();

                            ML.Materia resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(usuarioCast);
                            result.Object = resultItem;
                            result.Correct = true;

                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Exception = ex;
                    result.ErrorMessage = ex.Message;
                }
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;
                    return View(materia);
                }
                else
                {
                    ViewBag.Message = "Ocurrio algo al consultar la informacion del usuario" + result.ErrorMessage;
                    return View("Modal");
                }
            }
            else
            {
                return View(materia);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            using (var client = new HttpClient())
            {
                if (materia.idMateria == 0)
                {
                    string urlApi = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha registrado la materia";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "Se ha registrado la materia";
                        return PartialView("Modal");
                    }

                }
                else
                {
                    string urlApi = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Update",materia);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha actualizado la Materia";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha actualizado la materia";
                        return PartialView("Modal");
                    }

                }
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result();

            result.Objects = new List<object>();

            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Materia/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();

                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    materia.Materias = result.Objects;
                }


            }
            catch (Exception ex)
            {

            }
            return View(materia);
        }

        [HttpGet]
        public ActionResult Delete(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.idMateria = idMateria.Value;

            using (var client = new HttpClient())
            {
                string urlApi = ConfigurationManager.AppSettings["urlApi"];
                client.BaseAddress = new Uri(urlApi);

                var postTask = client.GetAsync("Materia/Delete/" + idMateria);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se ha eliminado la materia";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "No se ha eliminado la materia";
                    return PartialView("Modal");
                }
            }
        }
    }
}