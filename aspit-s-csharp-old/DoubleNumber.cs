namespace aspit_s_csharp;

public class DoubleNumber
{
    float DoubleThis(float myNumber)
    {
        float doubleNumber = myNumber * 2;
        return doubleNumber;
    }

    int DoubleThisInteger(int myNumber)
    {
        int doubleNumber = myNumber * 2;
        return doubleNumber;
    }

    public void Main()
    {
        Console.WriteLine(DoubleThis(1.5f));
        Console.WriteLine(DoubleThisInteger(3));
    }
}