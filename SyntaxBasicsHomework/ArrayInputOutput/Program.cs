namespace ArrayInputOutput
{
    internal class Program
    {
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.Write(array[array.Length - 1]);
        }

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
            PrintArray(originalArray);

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

            Array.Resize<int>(ref uniqueNumbersArray, uniqueElementsCount);
            Console.WriteLine("\n\nThe array with unique values is: ");
            PrintArray(uniqueNumbersArray);
        }
    }
}
