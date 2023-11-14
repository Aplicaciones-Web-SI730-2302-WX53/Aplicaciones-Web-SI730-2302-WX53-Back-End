using System.Diagnostics.CodeAnalysis;

namespace Domain;

public class MathDomain
{
    public int SumInt(int a, int b)
    {
        const int MAX_VALUE = 200;
        
        if (a > MAX_VALUE || b > MAX_VALUE) throw new ArgumentException("A or B grater than 200");
        
        return a + b  ;
    }
}