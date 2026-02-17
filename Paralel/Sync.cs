namespace Paralel;

public class Sync : ICalc
{
    public long Calc(int[] arr)
    {
        return arr.Sum();
    }
}