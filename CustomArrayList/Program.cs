namespace ArrayList;
public class Program
{
    static void Main(string[] args)
    {
        var ar = new CustomArrayList(new int[] { 2, 5, 9, 4, 1 });
        foreach (var item in ar)
        {
            Console.Write(item + "\t");
        }
        Console.WriteLine();
        ar.SortFromMax();
        foreach (var item in ar)
        {
            Console.Write(item + "\t");
        }
        Console.WriteLine();
        ar.SortFromMin();
        foreach (var item in ar)
        {
            Console.Write(item + "\t");
        }
    }
}

