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
                            DegreesModel model = new DegreesModel();
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
