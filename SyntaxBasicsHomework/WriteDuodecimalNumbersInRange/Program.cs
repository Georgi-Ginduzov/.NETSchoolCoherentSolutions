namespace WriteDuodecimalNumbersInRange
{
    internal class Program
    {
        static int setValue(string value)
        {
            switch (value)
            {
                case "A":
                    return 10;
                case "B":
                    return 11;
                default:
                    int number = int.Parse(value);
                    
                    if (number < 0)
                    {
                        Console.WriteLine("Invalid input! Please enter a positive number.");
                        setValue(Console.ReadLine());                        
                    }
                    return number;
            }
        }

        static void NormalPrinting(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                Console.WriteLine(i + " ");
            }
        }

        static void ReversedPrinting(int from, int to)
        {
            for (int i = to; i <= from; i--)
            {
                Console.WriteLine(i + " ");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Number a = ");
            string input = Console.ReadLine();
            int a = setValue(input);

            Console.Write("Number b = ");
            input = Console.ReadLine();
            int b = setValue(Console.ReadLine());

            if (a > b)
            {
                NormalPrinting(a, b);
            }
            else
            {
                ReversedPrinting(a, b);
            }
        }
    }
}
