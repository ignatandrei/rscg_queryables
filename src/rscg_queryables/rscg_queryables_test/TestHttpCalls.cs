
using FluentAssertions;

namespace rscg_queryables_test;

public record Search(string propertyName, rscg_queryablesCommon.WhereOperator operatorWhere, string value);
[TestClass]
public class TestHttpCalls
{
    [TestMethod]
    public void TestSame()
    {
        var p = new ListOfPersons();
        var arr = p.ArrPersons().AsQueryable();
        var searches = new List<Search>
        {
            new Search("FirstName", rscg_queryablesCommon.WhereOperator.Equal, "Ignat"),
            new Search("LastName", rscg_queryablesCommon.WhereOperator.Equal, "Andrei")
        };
        //composing searches
        foreach (var item in searches)
        {
            
            arr = arr.Where(Person_.Where_Expr(item.propertyName, item.operatorWhere, item.value));
        }
        var data=arr.ToArray();
        data.Should().HaveCount(1);
    }
}