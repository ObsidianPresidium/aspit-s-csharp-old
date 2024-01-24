namespace aspit_s_csharp;

public class Factorial
{
    int FactorialThis(int number)
    {
        if (number == 0)
        {
            return 1;
        }

        int factorialNumber = 1;
        for (int i=1; i<number+1; i++)
        {
            factorialNumber = factorialNumber * i;
        }

        return factorialNumber;
    }

    public void Main()
    {
        int factorialInput = 6;
        int factorialResult = FactorialThis(factorialInput);
        Console.WriteLine($"{factorialInput}! = {factorialResult}");
    }
}