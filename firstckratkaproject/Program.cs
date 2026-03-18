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
        Perceptron per = new Perceptron(0.2, 0.2);
        if (per.classify(vector))
        {
            Console.WriteLine("Perceptron activated!");
        }
        else
        {
            Console.WriteLine("Perceptron not activated!");
        }
    }
}

class Perceptron
{
    private double[] weights = { 0.5, 0.2, 0.5, 1 };
    private double threshold = 4;
    private double alpha;
    private double beta;

    public Perceptron(double a, double b)
    {
        alpha = a;
        beta = b;
    }

    public bool classify(int[] vector)
    {
        double scalar = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            scalar += vector.ElementAt(i) * weights.ElementAt(i);
        }
        
        return scalar > threshold;
    }
}