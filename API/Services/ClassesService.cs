using API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace API.Services
{
    public class ClassesService : BaseService
    {
        public static async Task<List<ClassesModel>> GetAll()
        {
            string query = "SELECT id, name FROM dbo.Classes ORDER BY id;";
            List<ClassesModel> list = new List<ClassesModel>();
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
                            ClassesModel model = new ClassesModel();
                            model.id = reader.GetInt32(reader.GetOrdinal("id"));
                            model.name = reader.GetString(reader.GetOrdinal("name"));
                            list.Add(model);
                        }
                    }
                }
            }
            finally
            {
                if(reader != null)
                    await reader.CloseAsync();
                if (conn != null)
                    await conn.CloseAsync();
            }

            return list;
            
        }
    }
}
