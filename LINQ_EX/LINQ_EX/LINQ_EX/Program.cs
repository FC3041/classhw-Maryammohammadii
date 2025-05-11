namespace LINQ_EX;

enum LifeExpectancyType {AtBirth, At60}
enum DataGender { Male, Female, Both}
class Data
{
    public Data(LifeExpectancyType leType, int year, string territory, string country, DataGender dg, double value)
    {
        LEType = leType;
        Year = year;
        Territory = territory;
        Country = country;
        DataGender = dg;
        Value = value;
    }

    public LifeExpectancyType LEType {get; }
    public int Year {get; }
    public string Terrirtory {get;}
    public string Country {get;}
    public DataGender DataGender {get;}
    public double Value {get;}
    public string Territory { get; }

    public override string ToString() =>
        $"{Country},{Year},{LEType},{DataGender},{Value}";

    public static Data Parse(string line)
    {
        var toks = line.Split(',').Select(t => t.Trim('"')).ToArray();        
        LifeExpectancyType leType = toks[0].Contains("60") ? 
                LifeExpectancyType.At60 :
                LifeExpectancyType.AtBirth;
        int year = int.Parse(toks[1]);
        string territory = toks[2].ToLower();
        string country = toks[3].ToLower();
        DataGender dg = toks[4].Contains("Both") ?
            DataGender.Both :
            (
                toks[4].Contains("Male") ? 
                    DataGender.Male :
                    DataGender.Female
            );
        double value = double.Parse(toks[5]);
        return new Data(leType, year, territory, country, dg, value);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var data = File.ReadAllLines("data.csv")
        .Skip(1)
        .Select(line => {
            var parts = line.Split(',');
            return new Data(
                leType: parts[0].Contains("60") ? LifeExpectancyType.At60 : LifeExpectancyType.AtBirth,
                year: int.Parse(parts[1]),
                territory: parts[2],
                country: parts[3],
                dg: parts[4].Contains("Both") ? DataGender.Both : 
                   (parts[4].Contains("Male") ? DataGender.Male : DataGender.Female),
                value: double.Parse(parts[5])
            );
        })
        .ToList();

        //Query 1
        Console.WriteLine("Query 1");
        var query1 = data
            .Where(d => d.Country.Contains("Iran"))
            .Where(d => d.LEType.ToString().Contains("Birth"))
            .Where(d => d.DataGender.ToString().Contains("Both"))
            .OrderBy(d => d.Value)
            .ToList();
            query1.ForEach(item => Console.WriteLine(item));
        Console.WriteLine();

        //Query 2
        Console.WriteLine("Query 2");
            var dif = query1.Max(d => d.Value) - query1.Min(d => d.Value);
            Console.WriteLine($"{dif}");
        //
        //
        Console.WriteLine();

        //Query 3
        Console.WriteLine("Query 3");
        var query3 = data
            .Where(d => d.DataGender == DataGender.Both) 
            .Where(d => d.LEType == LifeExpectancyType.AtBirth)  
            .GroupBy(d => d.Country)
            .Select(g => new {
                Country = g.Key,
                Min = g.Min(d => d.Value),  
                Max = g.Max(d => d.Value),  
                Diff = g.Max(d => d.Value) - g.Min(d => d.Value)  
            })
            .OrderByDescending(x => x.Diff)  
            .ToList();

        query3.ForEach(x => Console.WriteLine($"{x.Country}: Min={x.Min}, Max={x.Max}, Difference={x.Diff}"));
        Console.WriteLine();

        //Query 4
        Console.WriteLine("Query 4");
        var males = data.Where(d => d.LEType == LifeExpectancyType.AtBirth && d.DataGender == DataGender.Male);
        var females = data.Where(d => d.LEType == LifeExpectancyType.AtBirth && d.DataGender == DataGender.Female);

        males.Join(females,
            m => m.Country + m.Year,
            f => f.Country + f.Year,
            (m, f) => new { m.Country, m.Year, Male = m.Value, Female = f.Value })
            .GroupBy(x => x.Country)
            .Select(g => g.OrderByDescending(x => x.Female - x.Male).First())
            .OrderByDescending(x => x.Female - x.Male)
            .Select((x, i) => $"{i+1}. {x.Country} ({x.Year}): Male={x.Male}, Female={x.Female}, Diff={x.Female - x.Male}")
            .ToList()
            .ForEach(Console.WriteLine);
        
        //
        //
        Console.WriteLine();

    }
}
