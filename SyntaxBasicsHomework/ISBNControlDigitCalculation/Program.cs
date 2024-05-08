namespace ISBNControlDigitCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first 9 digits of the ISBN: ");
            string firstNineISBNDigits = Console.ReadLine();
            int controlDigit = 0;
            int multiplicationFactor = 10;
            int digitsSum = 0;

            foreach (char symbol in firstNineISBNDigits)
            {
                int number = int.Parse(symbol.ToString());

                digitsSum += (number * multiplicationFactor);
                multiplicationFactor--;
            }


            int remainder = digitsSum % 11;



            controlDigit = (11 - remainder) % 11;
            
            Console.Write("Full ISBN --> ");
            
            if (controlDigit == 10)
            {
                Console.Write(firstNineISBNDigits + "X");
            }
            else
            {
                Console.Write(firstNineISBNDigits + controlDigit);
            }
        }
    }
}
