using BookCollection.Contracts;

namespace BookCollection.Repositories
{
    internal class XMLCatalogRepository : XMLRepository<ICatalog>
    {
        public XMLCatalogRepository(string filePath) : base(filePath)
        {
        }

        protected override string _filePath { get; set; } = "C:\\\\Users\\\\Asus\\\\source\\\\repos\\\\.NETSchoolCoherentSolutions\\\\Task5\\\\BookCollection\\\\Catalog.xml\"";
    }
}
