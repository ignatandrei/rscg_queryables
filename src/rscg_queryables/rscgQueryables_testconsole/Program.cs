// See https://aka.ms/new-console-template for more information
using rscgQueryables_testconsole;


Console.WriteLine("Hello, World!");

var persons = new Person[]
{
    new Person { FirstName = "John", LastName = "Doe", Age = 25 },
    new Person { FirstName = "Ignat", LastName = "Andrei", Age = 55 },
};

var orderedExplicitly = persons.OrderBy(p => p.FirstName).ToArray();
var orderedImplicitly = persons.OrderBy("firStnaMe").ToArray();
var orderedImplicitly2 = persons.AsQueryable().OrderBy("fIrsTnAme").ToArray();
