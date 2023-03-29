using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result resultAdd = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ADDAlumno";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            resultAdd.Correct = true;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                resultAdd.Exception = ex;
                resultAdd.ErrorMessage = ex.Message;
                resultAdd.Correct = false;
            }
            return resultAdd;
        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result resultUpdate = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "[UpdateAlumno]";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("idAlumno", System.Data.SqlDbType.VarChar);
                        collection[0].Value = alumno.idAlumno;

                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            resultUpdate.Correct = true;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                resultUpdate.Correct = false;
                resultUpdate.Exception = ex;
                resultUpdate.ErrorMessage = ex.Message;
            }
            return resultUpdate;
        }

        public static ML.Result Delete(int idAlumno)
        {
            ML.Result resultDelete = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "[DeleteAlumno]";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = contex;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("idAlumno", System.Data.SqlDbType.VarChar);
                        collection[0].Value = idAlumno;


                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            resultDelete.Correct = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                resultDelete.Correct = false;
                resultDelete.Exception = ex;
                resultDelete.ErrorMessage = ex.Message;
            }
            return resultDelete;
        }

        public static ML.Result GetAll()
        {
            ML.Result resultAll = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "[GetAllAlumno]";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = contex;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        DataTable TablaAlumno = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(TablaAlumno);

                        if (TablaAlumno.Rows.Count > 0)
                        {
                            resultAll.Objects = new List<object>();
                            foreach (DataRow row in TablaAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();

                                alumno.idAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();

                                resultAll.Objects.Add(alumno);

                            }
                            resultAll.Correct = true;

                        }
                        else
                        {
                            resultAll.Correct = false;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                resultAll.Correct = false;
                resultAll.Exception = ex;
                resultAll.ErrorMessage = ex.Message;

            }
            return resultAll;
        }

        public static ML.Result GetById(int idAlumno)
        {
            ML.Result resultId = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "[GetByIdAlumno]";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = contex;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("idAlumno", System.Data.SqlDbType.Int);
                        collection[0].Value = idAlumno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        DataTable TablaAlumno = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(TablaAlumno);

                        if (TablaAlumno.Rows.Count > 0)
                        {
                            resultId.Object = new object();
                            DataRow row = TablaAlumno.Rows[0];

                            ML.Alumno alumno = new ML.Alumno();

                            alumno.idAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();

                            resultId.Object = alumno;

                            resultId.Correct = true;

                        }
                        else
                        {
                            resultId.Correct = false;
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                resultId.Correct = false;
                resultId.Exception = ex;
                resultId.ErrorMessage = ex.Message;
            }
            return resultId;

        }

    }
}

