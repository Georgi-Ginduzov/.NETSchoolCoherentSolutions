using System.Text;

namespace WriteDuodecimalNumbersInRange
{
    internal class Program
    {
        
        static void PrintNumbers(int from, int to)
        {
            int operation = to < 0 ? -1 : 1;

            for (int i = from; i < to; i = i + operation)
            {
                string duoDecimalNumber = ConvertDecimalToDuodecimal(i);

                if (MatchesOfA(duoDecimalNumber) == 2)
                {
                    Console.Write(i + " ");
                }
            }
        }

        static string ConvertDecimalToDuodecimal(int number)
        {
            if (number < 0)
            {
                return "-" + ConvertDecimalToDuodecimal(-number);
            }
            else if (number < 10)
            {
                return number.ToString();
            }


            StringBuilder duodecimalNumber = new StringBuilder();

            while (number > 0)
            {
                int remainder = number % 12;

                switch (remainder)
                {
                    case 10:
                        duodecimalNumber.Insert(0, "A");
                        break;
                    case 11:
                        duodecimalNumber.Insert(0, "B");
                        break;
                    default:
                        duodecimalNumber.Insert(0, remainder);
                    break;
                }

                number /= 12;
            }

            return duodecimalNumber.ToString();
        }

        static int MatchesOfA(string number)
        {
            int matches = 0;

            foreach (char digit in number)
            {
                if (digit == 'A')
                {
                    matches++;
                }
            }

            return matches;
        }

        static void Main(string[] args)
        {
            Console.Write("Number a = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Number b = ");
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            PrintNumbers(a, b);
        }
    }
}
