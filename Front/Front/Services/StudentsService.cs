using Front.Models;
using System.Text.Json;

namespace Front.Services
{
    public class StudentsService : BaseService
    {
        public static async Task<List<StudentCompleteModel>> GetStudentsByFilter(int degreeId, int classId)
        {
            List<StudentCompleteModel> list = new List<StudentCompleteModel>();
            string url = string.Format("{0}Students/GetStudentsByFilter/{1}/{2}", _apiurl, degreeId.ToString(), classId.ToString());
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(apiResponse))
                    {
                        list = JsonSerializer.Deserialize<List<StudentCompleteModel>>(apiResponse);
                    }
                }
            }

            return list;
        }
    }
}
