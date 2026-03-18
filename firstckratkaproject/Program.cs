namespace FIrstCKratkaProjectt;
class  Program
{

    double CalculateAverage(int[] values)
    {
        double sum = 0;
        for(int i = 0; i < values.Length; i++)
            {
            sum += values[i];
            }
        return sum / values.Length;
    }

    double CalculateMax(int[] values)
    {
        Console.WriteLine("Calculating max value...");
        return values.Max();
    }

    double CalculateMin(int[] values)
    {
        Console.WriteLine("Calculating min value...");
        return values.Min();
    }
    
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
        Console.WriteLine("Choose a mode: ");
        Console.WriteLine("1) Classify the vector");
        Console.WriteLine("2) Teach the perceptron");
        Perceptron per = new Perceptron(0.2, 0.2);
        
        if (int.TryParse(Console.ReadLine(), out int choice) && choice == 1  || choice == 2)
            {
                switch (choice)
                {
                    case 1:
                        if (per.classify(vector))
                        {
                            Console.WriteLine("Perceptron activated!");
                        }
                        else
                        {
                            Console.WriteLine("Perceptron not activated!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please provide the correct answer: ");
                        if (int.TryParse(Console.ReadLine(), out int answer) && answer == 1 || answer == 0)
                        {
                            if (answer == 1)
                            {
                                per.learn(vector, true);
                            }
                            else
                            {
                                per.learn(vector, false);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please provide the correct answer.");
                        }
                        break;
                    default:
                        break;
                }
            }
        else
        {
            Console.WriteLine("Please choose a mode.");
        }
        
        
    }
}

class Perceptron
{
    private double[] weights = { 1, 1, 0, 1 };
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

    public void learn(int[] vector, bool prediction)
    {
        while (classify(vector) != prediction)
        {
            Console.WriteLine("Learning...");
            delta_rule(vector, prediction);
        }

        Console.WriteLine("The answer matched the perceptron's classification");
    }

    public void delta_rule(int[] vector, bool prediction)
    {
        double a = alpha;
        if (!prediction)
        {
            a *= -1;
        }

        Console.WriteLine("Old threshold: " + threshold);
        threshold -= beta;
        Console.WriteLine("New threshold: " + threshold + "\n");
        Console.WriteLine("Old weights:");
        Console.WriteLine(string.Join(", ", weights));

        for (int i = 0; i < vector.Length; i++)
        {
            weights[i] = weights[i] + a * vector.ElementAt(i);
        }
        
        Console.WriteLine("New weights:");
        Console.WriteLine(string.Join(", ", weights) + "\n");
    }
    
    
    
}