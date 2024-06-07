namespace BookCollection.Entities
{
    public class Author
    {
        private const int _nameMaxLiterals = 200;
        private string _firstName;
        private string _lastName;
        //private DateTime _birthDate;

        public Author(){}

        public Author(string firstName, string lastName, DateTime? birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = (DateTime)birthDate;
        }

        public string FirstName 
        {
            get => _firstName;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length == 0)
                {
                    throw new ArgumentException("Author's first name cannot be null, empty or whitespace");
                }

                if (value.Length <= _nameMaxLiterals)
                {
                    _firstName = value;
                }
            }
        }
        public string LastName 
        {
            get => _lastName;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length == 0)
                {
                    throw new ArgumentException("Author's last name cannot be null, empty or whitespace");
                }

                if (value.Length <= _nameMaxLiterals)
                {
                    _lastName = value;
                }
            }
        }
        public DateTime BirthDate { get; set; }

        public override bool Equals(object obj)
            => obj is Author other ? FirstName == other.FirstName && LastName == other.LastName && BirthDate == other.BirthDate : false;

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, BirthDate);
        }
    }
}
