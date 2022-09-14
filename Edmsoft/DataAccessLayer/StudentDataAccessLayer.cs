using Edmsoft.Controllers;
using Edmsoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Edmsoft.DataAccessLayer
{
    public class StudentDataAccessLayer
    {
        string connectionString = ConnectionString.ConnectionName;

        public IEnumerable<StudentGrade> GetAllStudent()
        {
            List<StudentGrade> lstStudent = new List<StudentGrade>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "Select * from StudentGrade";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    StudentGrade student = new StudentGrade();
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.Nombre = rdr["Nombre"].ToString();
                    student.PrimerCorte = Convert.ToDecimal(rdr["PrimerCorte"].ToString());
                    student.SegundoCorte = Convert.ToDecimal(rdr["SegundoCorte"].ToString());
                    student.TercerCorte = Convert.ToDecimal(rdr["TercerCorte"].ToString());
                    student.Comentarios = rdr["Comentarios"].ToString();
                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }

        public void AddStudent(StudentGrade student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "Insert into StudentGrade (Nombre,PrimerCorte,SegundoCorte,TercerCorte,Comentarios,NotaFinal) values (@Nombre,@PrimerCorte,@SegundoCorte,@TercerCorte,@Comentarios,@NotaFinal);";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", student.Nombre);
                cmd.Parameters.AddWithValue("@PrimerCorte", student.PrimerCorte);
                cmd.Parameters.AddWithValue("@SegundoCorte", student.SegundoCorte);
                cmd.Parameters.AddWithValue("@TercerCorte", student.TercerCorte);
                cmd.Parameters.AddWithValue("@Comentarios", student.Comentarios);
                cmd.Parameters.AddWithValue("@NotaFinal", student.NotaFinal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(StudentGrade student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE StudentGrade SET Nombre = @Nombre, PrimerCorte = @PrimerCorte, SegundoCorte = @SegundoCorte, TercerCorte = @TercerCorte, Comentarios = @Comentarios, NotaFinal = @NotaFinal WHERE Id = " + student.Id;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Nombre", student.Nombre);
                cmd.Parameters.AddWithValue("@PrimerCorte", student.PrimerCorte);
                cmd.Parameters.AddWithValue("@SegundoCorte", student.SegundoCorte);
                cmd.Parameters.AddWithValue("@TercerCorte", student.TercerCorte);
                cmd.Parameters.AddWithValue("@Comentarios", student.Comentarios);
                cmd.Parameters.AddWithValue("@NotaFinal", student.NotaFinal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public StudentGrade GetStudentData(int? id)
        {
            StudentGrade student = new StudentGrade();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM StudentGrade WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.Nombre = rdr["Nombre"].ToString();
                    student.PrimerCorte = Convert.ToDecimal(rdr["PrimerCorte"].ToString());
                    student.SegundoCorte = Convert.ToDecimal(rdr["SegundoCorte"].ToString());
                    student.TercerCorte = Convert.ToDecimal(rdr["TercerCorte"].ToString());
                    student.Comentarios = rdr["Comentarios"].ToString();
                }
            }
            return student;
        }

        public void DeleteStudent(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "Delete From StudentGrade WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
