using System;
using System.Threading;
using System.Threading.Tasks;
public class TPLDemo
{
    public static void Main()
    {
        Task<Double>[] taskArray = { Task<Double>.Factory.StartNew(() => Compute()),
                                     Task<Double>.Factory.StartNew(() => Compute()),
                                     Task<Double>.Factory.StartNew(() => Compute()),
                                      Task<Double>.Factory.StartNew(() => Compute())};
        var result = new Double[taskArray.Length];
        Double sum = 0;

        for (int i = 0; i < taskArray.Length; i++)
        {
            result[i] = taskArray[i].Result;
            Console.Write("{0} {1}", result[i],
                              i == taskArray.Length - 1 ? "= " : "+ ");
            sum += result[i];
        }
        Console.WriteLine("{0}", sum);
        Console.ReadKey();
    }
    private static Double Compute()
    {
        Double sum = 0;
        for (var value = 0; value <= 100; value++)
            sum += value;
        return sum;
    }
}