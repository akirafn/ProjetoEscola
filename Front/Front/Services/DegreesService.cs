using Front.Models;
using System.Text.Json;

namespace Front.Services
{
    public class DegreesService : BaseService
    {
        public static async Task<List<DegreesModel>> GetAll()
        {
            List<DegreesModel> list = new List<DegreesModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(_apiurl + "Degrees/GetDegrees"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(apiResponse))
                    {
                        list = JsonSerializer.Deserialize<List<DegreesModel>>(apiResponse);
                    }
                }
            }
            return list;
        }
    }
}
