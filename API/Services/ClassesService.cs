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

            using (SqlConnection conn = GetConnection())
            {
                await conn.OpenAsync();
                DbDataReader reader = await conn.ExecuteReaderAsync(query);
                while (reader.Read())
                {
                    ClassesModel model = new ClassesModel();
                    model.id = reader.GetInt32(reader.GetOrdinal("id"));
                    model.name = reader.GetString(reader.GetOrdinal("name"));
                    list.Add(model);
                }
                await conn.CloseAsync();
            }

            return list;
            
        }
    }
}
