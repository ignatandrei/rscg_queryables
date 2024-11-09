namespace rscg_queryables_test;

public class ListOfPersons
{
    static Person[] arrPersons = new Person[]
{
    new Person { FirstName = "John", LastName = "Doe", Age = 25 },
    new Person { FirstName = "Ignat", LastName = "Andrei", Age = 55 },
        new Person { FirstName = "Ignat", LastName = "Andreea", Age = 55 },

};
    public Person[] ArrPersons()
    {
        return arrPersons;

    }
    public IQueryable<Person> QueryPersons()
    {
        return arrPersons.AsQueryable();
    }
}