using Microsoft.Data.SqlClient;

namespace API.Services
{
    public abstract class BaseService
    {
        protected static SqlConnection GetConnection()
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string? connection = config.GetConnectionString("MainDB");

            return new SqlConnection(connection);
        }
    }
}
