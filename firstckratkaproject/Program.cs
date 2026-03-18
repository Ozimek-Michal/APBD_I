namespace FIrstCKratkaProjectt;
class  Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi! ^^");
        Console.WriteLine("This is my first C# program");
        Console.WriteLine("This will be a simple perceptron implementation");
        Console.WriteLine("First, input a vector [4 dim]:");
        int[] vector = new int[4];
            
        for (int i = 0; i < vector.Length; i++)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                vector[i] = result;
            }
            else
            {
                Console.WriteLine("Please input a number :<");
                i--;
            }
        }
        Console.WriteLine(string.Join(", ", vector));
    }
}