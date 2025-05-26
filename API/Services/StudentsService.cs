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

            using (SqlConnection conn = GetConnection())
            {
                await conn.OpenAsync();
                DbDataReader reader = await conn.ExecuteReaderAsync(query);
                while (reader.Read())
                {
                    StudentsModel student = new StudentsModel();
                    student.id = reader.GetInt32(reader.GetOrdinal("id"));
                    student.ra = reader.GetInt32(reader.GetOrdinal("ra"));
                    student.name = reader.GetString(reader.GetOrdinal("name"));
                    student.degreeId = reader.GetInt32(reader.GetOrdinal("degreeId"));
                    student.classId = reader.GetInt32(reader.GetOrdinal("classId"));
                    list.Add(student);
                }
                await conn.CloseAsync();
            }

            return list;
        }

        public static async Task<List<StudentCompleteModel>> GetStudentsByFilter(int degreeId, int classId)
        {
            string query = "SELECT st.id, st.ra, st.name, st.degreeId, dg.name AS degreeName, st.classId, cl.name AS className FROM dbo.Students st JOIN dbo.Degrees dg ON dg.id = st.degreeId JOIN dbo.Classes cl ON cl.id = st.classId ";
            List<StudentCompleteModel> list = new List<StudentCompleteModel>();

            if (degreeId > 0 || classId > 0)
            {
                query += "WHERE ";
            }
            if (degreeId > 0)
            {
                query += "st.degreeId = " + degreeId.ToString();
            }
            if (classId > 0)
            {
                query += (degreeId > 0 ? " AND " : "") + "st.classId = " + classId.ToString();
            }
            query += " ORDER BY st.degreeId, st.classId, st.name";

            using (SqlConnection conn = GetConnection())
            {
                await conn.OpenAsync();
                DbDataReader reader = await conn.ExecuteReaderAsync(query);
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
                await conn.CloseAsync();
            }

            return list;
        }
    }
}
