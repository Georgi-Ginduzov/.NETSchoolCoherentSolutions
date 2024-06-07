using BookCollection.Contracts;
using BookCollection.Entities;
using System.Xml.Serialization;

namespace BookCollection.Repositories
{
    internal class XMLRepository<T> : IRepository<T>
    {
        protected virtual string _filePath { get; set; } = "C:\\Users\\Asus\\source\\repos\\.NETSchoolCoherentSolutions\\Task5\\BookCollection\\Data\\Catalog.xml";
        // Iterate through the folder to find the file by the name of the catalog,
        // Make it private const

        public XMLRepository()
        {
        }

        public T Get()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            T result = default;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
                {
                    result = (T)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during deserialization: " + ex.Message);
            }

            return result;
        }

        public bool Save(T entry)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    serializer.Serialize(writer, entry);
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
