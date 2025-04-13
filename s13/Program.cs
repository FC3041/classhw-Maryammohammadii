using System;
using System.Collections.Generic;

interface IPerson<_Type> : IComparable<IPerson<_Type>>
{
    _Type Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string FullName { get; }
}


class PersonComparers
{
    public static PersonFirstNameComparer PersonFirstNameComparer = new PersonFirstNameComparer();
    public static PersonLastNameComparer PersonLastNameComparer = new PersonLastNameComparer();
    public static PersonIdComparer<int> PersonIdComparer = new PersonIdComparer<int>();
    public static PersonFullNameComparer PersonFullNameComparer = new PersonFullNameComparer();
}


class PersonIdComparer<_Type> : IComparer<IPerson<_Type>>
{
    public int Compare(IPerson<_Type> x, IPerson<_Type> y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("Arguments cannot be null");

        return Comparer<_Type>.Default.Compare(x.Id, y.Id);
    }
}


class PersonFullNameComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("Arguments cannot be null");

        return x.FullName.CompareTo(y.FullName);
    }
}


class PersonFirstNameComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("Arguments cannot be null");

        return x.FirstName.CompareTo(y.FirstName);
    }
}


class PersonLastNameComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("Arguments cannot be null");

        return x.LastName.CompareTo(y.LastName);
    }
}

class Student : IPerson<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public double GPA { get; set; }

    public int CompareTo(IPerson<int> other)
    {
        if (other == null)
            throw new ArgumentNullException("Other object cannot be null");

        return FirstName.CompareTo(other.FirstName);
    }

    public override string ToString() => $"{FullName}\t{GPA}\t{Id}";
}


class Teacher : IPerson<string>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public double Rating { get; set; }

    public int CompareTo(IPerson<string> other)
    {
        if (other == null)
            throw new ArgumentNullException("Other object cannot be null");

        return Id.CompareTo(other.Id);
    }

    public override string ToString() => $"{FullName}\t{Rating}\t{Id}";
}


class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Ali", LastName = "Reza", GPA = 3.5 },
            new Student { Id = 2, FirstName = "Sara", LastName = "Ahmadi", GPA = 3.8 },
            new Student { Id = 3, FirstName = "Zahra", LastName = "Karimi", GPA = 3.2 }
        };

        students.Sort(PersonComparers.PersonFirstNameComparer);
        foreach (var student in students)
            Console.WriteLine(student);

        students.Sort(PersonComparers.PersonIdComparer);
        foreach (var student in students)
            Console.WriteLine(student);
    }
}
