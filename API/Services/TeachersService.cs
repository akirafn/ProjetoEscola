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
            using (SqlConnection conn = GetConnection())
            {
                await conn.OpenAsync();
                DbDataReader reader = await conn.ExecuteReaderAsync(query);
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

                foreach(RelationshipModel teacher in list)
                {
                    query = string.Format("SELECT tc.degreeId, dg.name AS degreeName, tc.classId, cl.name AS className FROM dbo.RelationshipTeacherClass tc JOIN dbo.Degrees dg ON dg.id = tc.degreeId JOIN dbo.Classes cl ON cl.id = tc.classId WHERE tc.teacherId = {0}", teacher.id.ToString());
                    DbDataReader classReader = await conn.ExecuteReaderAsync(query);
                    while (classReader.Read())
                    {
                        TeacherClassModel model = new TeacherClassModel();
                        model.degreeId = classReader.GetInt32(classReader.GetOrdinal("degreeId"));
                        model.degreeName = classReader.GetString(classReader.GetOrdinal("degreeName"));
                        model.classId = classReader.GetInt32(classReader.GetOrdinal("classId"));
                        model.className = classReader.GetString(classReader.GetOrdinal("className"));
                        teacher.classes.Add(model);
                    }
                }

                await conn.CloseAsync();
            }
            return list;
        }

        public static async Task<List<RelationshipModel>> GetByFilter(int degreeId, int classId)
        {
            string query = string.Empty;
            List<RelationshipModel> list = new List<RelationshipModel>();

            if (degreeId > 0)
            {
                query = string.Format("tc.degreeId = {0}{1}", degreeId.ToString(), (classId > 0 ? " AND " : string.Empty));
            }
            if (classId > 0) {
                query = string.Format("{0}tc.classId = {1}", query, classId.ToString());
            }
            if (!string.IsNullOrEmpty(query)) {
                query = string.Format("WHERE EXISTS (SELECT 1 FROM dbo.RelationshipTeacherClass tc WHERE tc.teacherId = te.id AND {0}) ", query);
            }
            query = string.Format("SELECT mt.id, tm.teacherId, te.name AS teacherName, tm.matterId, mt.name AS matterName FROM dbo.Teachers te JOIN dbo.RelationshipTeacherMatter tm ON tm.teacherId = te.id JOIN dbo.Matters mt ON mt.id = tm.matterId {0} ORDER BY te.name", query);
            using (SqlConnection conn = GetConnection())
            {
                await conn.OpenAsync();
                DbDataReader reader = await conn.ExecuteReaderAsync(query);
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

                foreach (RelationshipModel teacher in list)
                {
                    query = string.Empty;
                    if (degreeId > 0)
                        query = string.Format(" AND tc.degreeId = {0}", degreeId.ToString());
                    if (classId > 0)
                        query = string.Format("{0} AND tc.classId = {1}", query, classId.ToString());
                    query = string.Format("SELECT tc.degreeId, dg.name AS degreeName, tc.classId, cl.name AS className FROM dbo.RelationshipTeacherClass tc JOIN dbo.Degrees dg ON dg.id = tc.degreeId JOIN dbo.Classes cl ON cl.id = tc.classId WHERE tc.teacherId = {0}{1}", teacher.id.ToString(), query);
                    DbDataReader classReader = await conn.ExecuteReaderAsync(query);
                    while (classReader.Read())
                    {
                        TeacherClassModel model = new TeacherClassModel();
                        model.degreeId = classReader.GetInt32(classReader.GetOrdinal("degreeId"));
                        model.degreeName = classReader.GetString(classReader.GetOrdinal("degreeName"));
                        model.classId = classReader.GetInt32(classReader.GetOrdinal("classId"));
                        model.className = classReader.GetString(classReader.GetOrdinal("className"));
                        teacher.classes.Add(model);
                    }
                }

                await conn.CloseAsync();
            }
            return list;
        }
    }
}
