using API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace API.Services
{
    public class StudentsService : BaseService
    {
        public static async Task<List<StudentsModel>> GetAll()
        {
            string query = "SELECT * FROM dbo.Students ORDER BY id;";
            List<StudentsModel> list = new List<StudentsModel>();
            SqlConnection conn = null;
            SqlDataReader reader = null;

            try
            {
                using (conn = GetConnection())
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        reader = await cmd.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            StudentsModel student = new StudentsModel();
                            student.id = reader.GetInt32(reader.GetOrdinal("id"));
                            student.name = reader.GetString(reader.GetOrdinal("name"));
                            student.ra = reader.GetInt32(reader.GetOrdinal("ra"));
                            student.degreeId = reader.GetInt32(reader.GetOrdinal("degreeId"));
                            student.classId = reader.GetInt32(reader.GetOrdinal("classId"));
                            list.Add(student);
                        }
                    }
                }
            }
            catch (SqlException ex) { }
            finally
            {
                if (reader != null)
                    await reader.CloseAsync();
                if(conn != null)
                    await conn.CloseAsync();
            }

            return list;
        }

        public static async Task<List<StudentCompleteModel>> GetStudentsByFilter(int degreeId, int classId)
        {
            string query = "SELECT st.id, st.ra, st.name, st.degreeId, dg.name AS degreeName, st.classId, cl.name AS className FROM dbo.Students st JOIN dbo.Degrees dg ON dg.id = st.degreeId JOIN dbo.Classes cl ON cl.id = st.classId ";
            List<StudentCompleteModel> list = new List<StudentCompleteModel>();
            SqlConnection conn = null;
            SqlDataReader reader = null;

            if (degreeId > 0 || classId > 0)
            {
                query += "WHERE ";
            }
            if (degreeId > 0)
            {
                query += "st.degreeId = @DegreeId";
            }
            if (classId > 0)
            {
                query += (degreeId > 0 ? " AND " : "") + "st.classId = @ClassId";
            }
            query += " ORDER BY st.degreeId, st.classId, st.name";

            try
            {
                using (conn = GetConnection())
                {
                    await conn.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.Add("@DegreeId", System.Data.SqlDbType.Int).Value = degreeId;
                        command.Parameters.Add("@ClassId", System.Data.SqlDbType.Int).Value = classId;
                        reader = await command.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            StudentCompleteModel student = new StudentCompleteModel();
                            student.id = reader.GetInt32(reader.GetOrdinal("id"));
                            student.ra = reader.GetInt32(reader.GetOrdinal("ra"));
                            student.name = reader.GetString(reader.GetOrdinal("name"));
                            student.degreeId = reader.GetInt32(reader.GetOrdinal("degreeId"));
                            student.degreeName = reader.GetString(reader.GetOrdinal("degreeName"));
                            student.classId = reader.GetInt32(reader.GetOrdinal("classId"));
                            student.className = reader.GetString(reader.GetOrdinal("className"));
                            list.Add(student);
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                if(reader != null)
                    await reader.CloseAsync();
                if(conn!= null)
                    await conn.CloseAsync();
            }

            return list;
        }

        public static async Task<int> InsertStudentData(StudentsModel model)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            string query = "INSERT INTO dbo.Students (name, ra, degreeId, classId) VALUES (@Name, @Ra, @DegreeId, @ClassId)";
            int result = 0;

            try
            {
                using (conn = GetConnection())
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Name", System.Data.SqlDbType.Text).Value = model.name;
                        cmd.Parameters.Add("@Ra", System.Data.SqlDbType.Int).Value = model.ra;
                        cmd.Parameters.Add("@DegreeId", System.Data.SqlDbType.Int).Value = model.degreeId;
                        cmd.Parameters.Add("@ClassId", System.Data.SqlDbType.Int).Value = model.classId;
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            finally
            {
                if(reader != null)
                    await reader.CloseAsync();
                if (conn!= null)
                    await conn.CloseAsync();
                result = -1;
            }

            return result;
        }

        public static async Task<int> UpdateStudentData(StudentsModel model)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            string query = "UPDATE dbo.Students SET name = @Name, ra = @Ra, degreeId = @DegreeId, classId = @ClassId WHERE id = @Id";
            int result = 0;

            try
            {
                using (conn = GetConnection())
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = model.id;
                        cmd.Parameters.Add("@Name", System.Data.SqlDbType.Text).Value = model.name;
                        cmd.Parameters.Add("@Ra", System.Data.SqlDbType.Int).Value = model.ra;
                        cmd.Parameters.Add("@DegreeId", System.Data.SqlDbType.Int).Value = model.degreeId;
                        cmd.Parameters.Add("@ClassId", System.Data.SqlDbType.Int).Value = model.classId;
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            finally
            {
                if (reader != null)
                    await reader.CloseAsync();
                if (conn != null)
                    await conn.CloseAsync();
                result = -1;
            }

            return result;
        }
    }
}
