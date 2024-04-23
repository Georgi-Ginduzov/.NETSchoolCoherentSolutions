namespace ArrayInputOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array's size: ");
            int orignialArraySize = int.Parse(Console.ReadLine());

            int[] originalArray = new int[orignialArraySize];

            for (int i = 0; i < orignialArraySize; i++)
            {
                originalArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("The original array is: ");
            for (int i = 0; i < orignialArraySize - 1; i++)
            {
                Console.Write(originalArray[i] + ", ");
            }
            Console.Write(originalArray[orignialArraySize - 1]);


            int[] uniqueNumbersArray = new int[orignialArraySize];
            int uniqueElementsCount = 0;

            for (int i = 0; i < orignialArraySize; i++)
            {
                bool isUnique = true;
                
                for (int j = 0; j < orignialArraySize; j++)
                {
                    if (originalArray[i] == uniqueNumbersArray[j])
                    {
                        isUnique = false;
                    }
                }

                if (isUnique)
                {
                    uniqueNumbersArray[uniqueElementsCount] = originalArray[i];
                    uniqueElementsCount++;
                }
            }

            Console.WriteLine("\n\nThe array with unique values is: ");
            for (int i = 0; i < uniqueElementsCount - 1; i++)
            {
                Console.Write(uniqueNumbersArray[i] + ", ");
            }
            Console.Write(uniqueNumbersArray[uniqueElementsCount - 1]);

        }
    }
}
