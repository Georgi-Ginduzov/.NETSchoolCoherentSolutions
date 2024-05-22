namespace SparceMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int columns = int.Parse(Console.ReadLine());

            SparseMatrix matrix = new SparseMatrix(rows, columns);

            Console.Write("Enter number of non-zero elements: ");
            int nonZeroCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < nonZeroCount; i++)
            {
                Console.WriteLine($"Enter details for non-zero element {i + 1}:");
                Console.Write("Row index: ");
                int rowIndex = int.Parse(Console.ReadLine());
                Console.Write("Column index: ");
                int columnIndex = int.Parse(Console.ReadLine());
                Console.Write("Value: ");
                long value = long.Parse(Console.ReadLine());

                matrix[rowIndex, columnIndex] = value;
            }

            Console.WriteLine("Matrix:");
            Console.WriteLine(matrix);

            Console.WriteLine("Non-zero elements:");
            foreach (var element in matrix.GetNonzeroElements())
            {
                Console.WriteLine($"({element.Item1}, {element.Item2}) -> {element.Item3}");
            }

            Console.Write("Enter a value to count its occurrences: ");
            long countValue = long.Parse(Console.ReadLine());
            int count = matrix.GetCount(countValue);
            Console.WriteLine($"The value {countValue} appears {count} times in the matrix.");
            
        }

    }
}
