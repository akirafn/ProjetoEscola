using API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace API.Services
{
    public class DegreesService : BaseService
    {
        public static async Task<List<DegreesModel>> GetAll()
        {
            string query = "SELECT id, name FROM dbo.Degrees ORDER BY id;";
            List<DegreesModel> list = new List<DegreesModel>();

            using (SqlConnection conn = GetConnection())
            {
                await conn.OpenAsync();
                DbDataReader reader = await conn.ExecuteReaderAsync(query);
                while (reader.Read())
                {
                    DegreesModel model = new DegreesModel();
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
