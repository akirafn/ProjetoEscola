using FrontWeb.Models;
using System.Text.Json;

namespace FrontWeb.Services
{
    public class ClassesService : BaseService
    {
        public static async Task<List<ClassesModel>> GetAll()
        {
            List<ClassesModel> list = new List<ClassesModel>();
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage responseMessage = await client.GetAsync(_apiurl + "Classes/GetClasses"))
                {
                    string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(apiResponse))
                    {
                        list = JsonSerializer.Deserialize<List<ClassesModel>>(apiResponse);
                    }
                }
            }
            return list;
        }
    }
}
