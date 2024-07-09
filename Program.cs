namespace CSharp15._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] randomNumbers = GenerateRandomNumbers(10000);
            var (evenNumbers, oddNumbers) = SplitEvenOdd(randomNumbers);

            SaveNumbersToFile(evenNumbers, "evenNumbers.txt");
            SaveNumbersToFile(oddNumbers, "oddNumbers.txt");

            DisplayStatistics(randomNumbers, evenNumbers, oddNumbers);
        }

        static int[] GenerateRandomNumbers(int count)
        {
            Random random = new Random();
            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next();
            }

            return numbers;
        }

        static (int[] evenNumbers, int[] oddNumbers) SplitEvenOdd(int[] numbers)
        {
            int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            int[] oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

            return (evenNumbers, oddNumbers);
        }

        static void SaveNumbersToFile(int[] numbers, string filePath)
        {
            try
            {
                File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));
                Console.WriteLine($"Numbers successfully saved to {filePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to file {filePath}: {ex.Message}");
            }
        }

        static void DisplayStatistics(int[] allNumbers, int[] evenNumbers, int[] oddNumbers)
        {
            Console.WriteLine("Statistics:");
            Console.WriteLine($"Total numbers generated: {allNumbers.Length}");
            Console.WriteLine($"Even numbers count: {evenNumbers.Length}");
            Console.WriteLine($"Odd numbers count: {oddNumbers.Length}");
        }
    }
}
