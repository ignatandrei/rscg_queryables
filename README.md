# rscg_queryables

## The problem

When data comes over HTTP , it is often in the form of a string object. For example, to sort a list of Persons
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
 after first name descending we should send something like this

orderBy=FirstName&Asc=false

Then in the backend code we should parse the query string and apply the sorting logic.

```csharp
if(queryString.ContainsKey("orderBy"))
{
    var orderBy = queryString["orderBy"];
    var asc = queryString["asc"];
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
    bool asc = queryString["asc"] == "true" ? true : false;
    persons = persons.OrderByAscDesc(orderBy, asc);
    //or you can do this
    if(asc)
    {
        persons = persons.OrderBy(orderBy);
    }
    else
    {
        persons = persons.OrderByDescending(orderBy);
    }
}
```


