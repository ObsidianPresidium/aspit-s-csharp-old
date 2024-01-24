namespace aspit_s_csharp;

public class PrintPattern
{
    void Repeat(string myString, int repetitions)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Console.Write(myString);
        }

        Console.WriteLine();
    }

    void Pattern(string myString, int[] times)
    {
        foreach (int repetitions in times)
        {
            Repeat(myString, repetitions);
        }
    }
    public void Main()
    {
        Pattern("abc", new int[] {4, 2, 1});
    }
}
