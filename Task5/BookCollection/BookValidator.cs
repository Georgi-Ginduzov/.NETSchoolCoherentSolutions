using System.Collections;
using System.Text.RegularExpressions;

namespace BookCollection
{
    public static class BookValidator
    {
        private readonly static Regex _isbnFormat = new Regex(@"^(?:\d{3}-\d{1}-\d{2}-\d{6}-\d{1}|\d{13})$");
        
        public static string NormalizeIsbn(string isbn) => isbn.Replace("-", "");

        public static bool IsIsbnValid(string isbn) => _isbnFormat.IsMatch(isbn) ? false : true;

        public static bool IsStringValid(string str) => !string.IsNullOrWhiteSpace(str) && str.Length > 0;

        public static bool IsValidEnumerable(IEnumerable enumerable) => enumerable != null;
    }
}
