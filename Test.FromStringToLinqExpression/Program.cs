using System.Linq.Dynamic.Core;

public class MyObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ForCheckingValue { get; set; }
}

public class Program
{
    public static string ReplaceValueWithPropertyName(string conditionString, string propertyName)
    {
        string replacedString = conditionString.Replace("value", propertyName);
        return replacedString;
    }

    public static IQueryable<T> FilterList<T>(IQueryable<T> list, string conditionString)
    {
        var filteredList = list.Where(conditionString);
        return filteredList;
    }

    public static void Main()
    {
        IQueryable<MyObject> myList = new List<MyObject>
        {
            new MyObject { Id = 1, Name = "Object 1", ForCheckingValue = 5 },
            new MyObject { Id = 2, Name = "Object 2", ForCheckingValue = 10 },
            new MyObject { Id = 3, Name = "Object 3", ForCheckingValue = 7 },
            new MyObject { Id = 4, Name = "Object 4", ForCheckingValue = 3 }
        }.AsQueryable();

        string conditionString = "value > 1 && value < 10";

        string replacedString = ReplaceValueWithPropertyName(conditionString, "ForCheckingValue");

        List<MyObject> filteredList = FilterList(myList, replacedString).ToList();

        foreach (var item in filteredList)
        {
            Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, ForCheckingValue: {item.ForCheckingValue}");
        }
    }
}