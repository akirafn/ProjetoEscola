using Front.Models;
using System.Text.Json;

namespace Front.Services
{
    public class TeachersService : BaseService
    {
        public static async Task<List<RelationshipModel>> GetTeachersByFilter(int degreeId, int classId)
        {
            List<RelationshipModel> list = new List<RelationshipModel>();
            string url = string.Format("{0}Teachers/GetTeachersByFilter/{1}/{2}", _apiurl, degreeId, classId);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(apiResponse))
                    {
                        list = JsonSerializer.Deserialize<List<RelationshipModel>>(apiResponse);
                    }
                }
            }

            return list;
        }
    }
}
