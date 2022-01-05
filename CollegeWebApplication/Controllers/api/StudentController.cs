using CollegeWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeWebApplication.Controllers.api
{
    public class StudentController : ApiController
    {
        string connectionString = "Data Source=DESKTOP-0MT6QTG;Initial Catalog=CollegeDb;Integrated Security=True;Pooling=False";

        List<Student> studentList = new List<Student>();


        // GET: api/Student
        public IHttpActionResult Get()
        {
            List<Student> returnGet = AllStudentIn(studentList, connectionString);

            return Ok(new { returnGet });
        }

        private static List<Student> AllStudentIn(List<Student> studentList, string stringConnection)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Stuedent";
                    SqlCommand commend = new SqlCommand(query, connection);
                    SqlDataReader reader = commend.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            studentList.Add(new Student(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4),
                            reader.GetInt32(5)));
                            //return $"{reader.GetString(1)} , {reader.GetString(2)} , {reader.GetDateTime(3)}, {reader.GetString(4)} ,{reader.GetInt32(5)}";
                            //Console.WriteLine($"{reader.GetString(1)} , {reader.GetString(2)} , {reader.GetString(3)},{reader.GetInt32(4)}");
                        }


                    }
                    connection.Close();
                    return studentList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            List<Student> getById = GetById(studentList, connectionString, id);
            return Ok(new { getById });
        }

        private static List<Student> GetById(List<Student> studentList, string stringConnection, int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {

                connection.Open();
                string query = $@"SELECT * FROM Stuedent Where Id = {id}";
                SqlCommand commend = new SqlCommand(query, connection);
                SqlDataReader reader = commend.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        studentList.Add(new Student(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4),
                        reader.GetInt32(5)));

                    }


                }
                connection.Close();
                return studentList;
            }
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student student)
        {

            int postMat = PostMethod(student, connectionString);
            return Ok(new { postMat });

        }


        private static int PostMethod(Student student, string stringConnection)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                string query = $@"INSERT INTO Student(fName , lName , dateOfBirth , email , yearsOfStudies) values('{student.Fname}','{student.LName}',{student.DateOfBirth},'{student.Email}', {student.YearsOfStudies})";
                SqlCommand commend = new SqlCommand(query, connection);
                int rowEffected = commend.ExecuteNonQuery();
                connection.Close();
                return rowEffected;
            }
        }



        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody] Student student)
        {
            int putMat = PutMethodAdd(student, connectionString);
            return Ok(new { putMat });
        }


        private static int PutMethodAdd(Student student, string stringConnection)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                string sqlQuery = $@"UPDATE Student SET fName = '{student.Fname}', dateOfBirth = '{student.DateOfBirth}', email = '{student.Email}', yearsOfStudies = {student.YearsOfStudies}";
                SqlCommand commend = new SqlCommand(sqlQuery, connection);
                int rowEffected = commend.ExecuteNonQuery();
                return rowEffected;
                connection.Close();
            }

        }

        // DELETE: api/Student/5
        //public IHttpActionResult Delete(int id)
        //{
        //    int deleteMet = DeleteFun(id, connectionString);
        //    return Ok(new { deleteMet });
        //}

        //private static List<Student> DeleteFun(int id, string stringConnection)
        //{
        //    using (SqlConnection connection = new SqlConnection(stringConnection))
        //    {
        //        connection.Open();
        //        string query = $@"DELETE FROM Student WHERE Id = {id}";
        //        SqlCommand commend = new SqlCommand(query, connection);
        //        int delete = commend.ExecuteNonQuery();
        //        connection.Close();

        //        return studentList;
        //    }
        //}
    }
}
