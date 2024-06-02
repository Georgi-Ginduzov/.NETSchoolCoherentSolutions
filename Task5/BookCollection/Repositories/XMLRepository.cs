using BookCollection.Contracts;
using System.Xml.Serialization;

namespace BookCollection.Repositories
{
    internal class XMLRepository<T> : IRepository<T>
    {
        protected virtual string _filePath { get; set; } //= "...\\...\\...\\repos\\.NETSchoolCoherentSolutions\\Task5\\BookCollection\\Data";, Iterate through the folder to find the file by the name of the catalog

        public XMLRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<T> GetAll()
        {
            if (!File.Exists(_filePath) || new FileInfo(_filePath).Length <= 25)
            {
                return new List<T>();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
                {
                    return (List<T>)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during deserialization: " + ex.Message);
                return new List<T>();
            }
        }

        public bool SaveAll(IEnumerable<T> entries)
        {
            try
            {

                List<T> items = GetAll().ToList();

                foreach (var entry in entries)
                {
                    items.Add(entry);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    serializer.Serialize(writer, items);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during serialization: " + ex.Message);
                return false;
            }
        }
        
        public bool Save(T entry)
        {
            try
            {
                List<T> items = GetAll().ToList();
                items.Add(entry);
                
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                                
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    serializer.Serialize(writer, items);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during serialization: " + ex.Message);
                return false;
            }
        }

        
    }
}
