namespace WriteDuodecimalNumbersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number a = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Number b = ");
            int b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                string duodecimal = "";
                while (i > 0)
                {
                    int remainder = i % 12;
                    if (remainder == 10)
                        duodecimal = "A" + duodecimal;
                    else if (remainder == 11)
                        duodecimal = "B" + duodecimal;
                    else
                        duodecimal = remainder.ToString() + duodecimal;

                    i /= 12;
                }
                if (duodecimal.Count(c => c == 'A') == 2)
                {
                    int decimalNumber = 0;
                    int multiplier = 1;
                    for (int j = duodecimal.Length - 1; j >= 0; j--)
                    {
                        char digit = duodecimal[i];
                        if (digit == 'A')
                            decimalNumber += 10 * multiplier;
                        else if (digit == 'B')
                            decimalNumber += 11 * multiplier;
                        else
                            decimalNumber += int.Parse(digit.ToString()) * multiplier;

                        multiplier *= 12;
                    }



                    Console.WriteLine(decimalNumber);
                }
            }
        }
    }
}
