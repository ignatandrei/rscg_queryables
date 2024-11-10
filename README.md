
# rscg_queryables

`rscg_queryables` is a Roslyn Code Generator designed to generate extension methods for sorting and filtering `IEnumerable` and `IQueryable` collections based on a given class.



## Sorting how the user wants in frontend  - description

Consider a scenario where we need to display a list of `Person` objects and allow the user to sort them by various properties. The user should have the ability to select the property and the sorting order.

```csharp
public class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}
```

When data is transmitted over HTTP, it is often in the form of a string object. To sort by first name in descending order, the query string should look like this:

```json
orderBy=FirstName&Asc=false
```

Then in the backend code we should parse the query string and apply the sorting logic.

```csharp
if(queryString.ContainsKey("orderBy"))
{
    string orderBy = queryString["orderBy"];
    bool asc = queryString["asc"] == "false" ? false: true;//default is true
    if(orderBy == "FirstName")
    {
        if(asc)
        {
            persons = persons.OrderBy(p => p.FirstName);
        }
        else
        {
            persons = persons.OrderByDescending(p => p.FirstName);
        }
    }
    //do the same for other properties : LastName, Age, FullName

}
```

## The solution

With rscg_queryables, you can do this in a more elegant way.

```csharp
if(queryString.ContainsKey("orderBy"))
{
    string orderBy = queryString["orderBy"];
    bool asc = queryString["asc"] == "false" ? false: true;//default is true
    persons = persons.OrderByAscDesc(orderBy, asc);
    //or you can do this, if you want to control 
    //if(asc)
    //{
    //    persons = persons.OrderBy(orderBy);
    //}
    //else
    //{
    //    persons = persons.OrderByDescending(orderBy);
    //}
}
```

This should be done for everything that implements IEnumerable or IQueryable.


## Other Roslyn Code Generators

See other RSCG at https://ignatandrei.github.io/RSCG_Examples/v2/docs/rscg-examples 

