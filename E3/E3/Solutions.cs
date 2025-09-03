using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E3;

public class Animal
{
    public virtual string MakeSound()
    {
        return "Some generic animal sound";
    }

}

public class Dog : Animal
{
    public override string MakeSound()
    {
        return "Woof";
    }
}


public class MyPointClass
{
    public static void ChangeType2(ref MyPointType2 p) { p.X = 100; p.Y = 200; }
}
public struct MyPointType2
{
    public int X;
    public int Y;
}

public class MyPointType1
{
    public int X;
    public int Y;
}
public class Comparer<T> where T : IComparable<T>
{
    private T _first;
    private T _second;

    public Comparer(T first, T second)
    {
        _first = first;
        _second = second;
    }

    public T GetLarger()
    {
        return _first.CompareTo(_second) >= 0 ? _first : _second;
    }
}
public class Product : IComparable<Product>
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return this.Price.CompareTo(other.Price);
    }
}
public class ResourceManager : IDisposable
{
    public bool IsDisposed;
    public void Dispose()
    {
        IsDisposed = true;

    }
    
}
public class LinqProblems
{

    public static IEnumerable<int> FilterAndDouble(IEnumerable<int> numbers)
    {
        return numbers
            .Where(n => n % 2 == 0)
            .Where(n => n > 5)
            .Select(n => n * 2);

    }

    public static Dictionary<string, int> GetTotalAmountByCategory(List<Sale> sales)
    {
        return sales
            .GroupBy(s => s.Category)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(s => s.Amount)
            );
    }

}

public class  Sale{
    public String? Category;
    public int Amount;
}



public class Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException();
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static bool operator ==(Money a, Money b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Amount == b.Amount && a.Currency == b.Currency;
    }

    public static bool operator !=(Money a, Money b) => !(a == b);

    public override bool Equals(object obj) => Equals(obj as Money);

    public bool Equals(Money other)
    {
        if (other is null) return false;
        return Amount == other.Amount && Currency == other.Currency;
    }

    public override int GetHashCode() => HashCode.Combine(Amount, Currency);
}






