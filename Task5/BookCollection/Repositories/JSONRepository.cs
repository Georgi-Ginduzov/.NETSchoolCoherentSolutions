using BookCollection.Contracts;
using System.Text.Json;

namespace BookCollection.Repositories
{
    public class JSONRepository<T> : IRepository<T>
    {
        protected readonly string _filePath = "C:\\Users\\Asus\\source\\repos\\.NETSchoolCoherentSolutions\\Task5\\BookCollection\\Data\\Authors\\";

        public JSONRepository()
        {
        }

        public T Get()
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(_filePath));
        }

        public bool Save(T item)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(item);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error during serialization: " + ex.Message);
                return false;
            }

            return true;
        }

        protected bool fileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
