using API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace API.Services
{
    public class TeachersService : BaseService
    {
        public static async Task<List<RelationshipModel>> GetAll()
        {
            string query = "SELECT tm.id, tm.teacherId, te.name AS teacherName, tm.matterId, mt.name AS matterName FROM dbo.Teachers te JOIN dbo.RelationshipTeacherMatter tm ON tm.teacherId = te.id JOIN dbo.Matters mt ON mt.id = tm.matterId ORDER BY te.name";
            List<RelationshipModel> list = new List<RelationshipModel>();
            SqlConnection conn = null;
            SqlDataReader reader = null;

            try
            {
                using(conn = GetConnection())
                {
                    await conn.OpenAsync();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        reader = await cmd.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            RelationshipModel model = new RelationshipModel();
                            model.id = reader.GetInt32(reader.GetOrdinal("id"));
                            model.teacherId = reader.GetInt32(reader.GetOrdinal("teacherId"));
                            model.teacherName = reader.GetString(reader.GetOrdinal("teacherName"));
                            model.matterId = reader.GetInt32(reader.GetOrdinal("matterId"));
                            model.matterName = reader.GetString(reader.GetOrdinal("matterName"));
                            model.classes = new List<TeacherClassModel>();
                            list.Add(model);
                        }
                    }

                    foreach (RelationshipModel teacher in list)
                    {
                        query = "SELECT tc.degreeId, dg.name AS degreeName, tc.classId, cl.name AS className FROM dbo.RelationshipTeacherClass tc JOIN dbo.Degrees dg ON dg.id = tc.degreeId JOIN dbo.Classes cl ON cl.id = tc.classId WHERE tc.teacherId = @TeacherId";
                        await reader.CloseAsync();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@TeacherId", System.Data.SqlDbType.Int).Value = teacher.teacherId;
                            reader = await cmd.ExecuteReaderAsync();
                            while (reader.Read())
                            {
                                TeacherClassModel model = new TeacherClassModel();
                                model.degreeId = reader.GetInt32(reader.GetOrdinal("degreeId"));
                                model.degreeName = reader.GetString(reader.GetOrdinal("degreeName"));
                                model.classId = reader.GetInt32(reader.GetOrdinal("classId"));
                                model.className = reader.GetString(reader.GetOrdinal("className"));
                                teacher.classes.Add(model);
                            }  
                        }
                    }
                }
            }
            finally
            {
                if(reader != null)
                    await reader.CloseAsync();
                if(conn != null)
                    await conn.CloseAsync();
            }


            return list;
        }

        public static async Task<List<RelationshipModel>> GetByFilter(int degreeId, int classId)
        {
            string query = string.Empty;
            List<RelationshipModel> list = new List<RelationshipModel>();
            SqlConnection conn = null;
            SqlDataReader reader = null;

            if (degreeId > 0)
            {
                query = string.Format("tc.degreeId = @DegreeId{0}", (classId > 0 ? " AND " : string.Empty));
            }
            if (classId > 0) {
                query = string.Format("{0}tc.classId = @ClassId", query);
            }
            if (!string.IsNullOrEmpty(query)) {
                query = string.Format("WHERE EXISTS (SELECT 1 FROM dbo.RelationshipTeacherClass tc WHERE tc.teacherId = te.id AND {0}) ", query);
            }
            query = string.Format("SELECT mt.id, tm.teacherId, te.name AS teacherName, tm.matterId, mt.name AS matterName FROM dbo.Teachers te JOIN dbo.RelationshipTeacherMatter tm ON tm.teacherId = te.id JOIN dbo.Matters mt ON mt.id = tm.matterId {0} ORDER BY te.name", query);
            try
            {
                using(conn = GetConnection())
                {
                    await conn.OpenAsync();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@DegreeId", System.Data.SqlDbType.Int).Value = degreeId;
                        cmd.Parameters.Add("@ClassID", System.Data.SqlDbType.Int).Value = classId;

                        reader = await cmd.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            RelationshipModel model = new RelationshipModel();
                            model.id = reader.GetInt32(reader.GetOrdinal("id"));
                            model.teacherId = reader.GetInt32(reader.GetOrdinal("teacherId"));
                            model.teacherName = reader.GetString(reader.GetOrdinal("teacherName"));
                            model.matterId = reader.GetInt32(reader.GetOrdinal("matterId"));
                            model.matterName = reader.GetString(reader.GetOrdinal("matterName"));
                            model.classes = new List<TeacherClassModel>();
                            list.Add(model);
                        }
                    }

                    foreach(RelationshipModel teacher in list)
                    {
                        await reader.CloseAsync();
                        query = string.Empty;
                        if (degreeId > 0)
                            query = " AND tc.degreeId = @DegreeId";
                        if (classId > 0)
                            query = string.Format("{0} AND tc.classId = @ClassId", query);
                        query = string.Format("SELECT tc.degreeId, dg.name AS degreeName, tc.classId, cl.name AS className FROM dbo.RelationshipTeacherClass tc JOIN dbo.Degrees dg ON dg.id = tc.degreeId JOIN dbo.Classes cl ON cl.id = tc.classId WHERE tc.teacherId = {0}{1}", teacher.id.ToString(), query);
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@DegreeId", System.Data.SqlDbType.Int).Value = degreeId;
                            cmd.Parameters.Add("@ClassId", System.Data.SqlDbType.Int).Value = classId;
                            
                            reader = await cmd.ExecuteReaderAsync();
                            while (reader.Read())
                            {
                                TeacherClassModel model = new TeacherClassModel();
                                model.degreeId = reader.GetInt32(reader.GetOrdinal("degreeId"));
                                model.degreeName = reader.GetString(reader.GetOrdinal("degreeName"));
                                model.classId = reader.GetInt32(reader.GetOrdinal("classId"));
                                model.className = reader.GetString(reader.GetOrdinal("className"));
                                teacher.classes.Add(model);
                            }
                        }
                    }
                }
            }
            finally
            {
                if(reader != null)
                    await reader.CloseAsync();
                if(conn != null)
                    await conn.CloseAsync();
            }
            
            return list;
        }
    }
}
