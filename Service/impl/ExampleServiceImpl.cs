using System;
using System.Threading.Tasks;
using MySqlConnector;

namespace VeXe.Service.Impl
{
    public class ExampleServiceImpl : ExampleService
    {
        
        public string getAbc(string xyz)
        {
            return "Hello " + xyz;
        }

        public async Task<string> getInDbTest(int id)
        {
            try
            {

                await using var connection = new MySqlConnection();
                await connection.OpenAsync();
                await using var command = new MySqlCommand("SELECT name FROM user where id = 1;", connection);
                await using var reader = await command.ExecuteReaderAsync();
                var value = "";
                while (await reader.ReadAsync())
                {
                    value = (string) reader.GetValue(0);
                }

                return value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}