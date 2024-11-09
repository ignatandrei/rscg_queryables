
using FluentAssertions;

namespace rscg_queryables_test;
[TestClass]
public class TestIQueryable
{
    [TestMethod]
    public void TestOrderBy()
    {
        var p = new ListOfPersons();
        var arr = p.QueryPersons().OrderBy("fIrstName").ToArray();
        arr.Should().BeInAscendingOrder(it => it.FirstName);
        arr = arr.OrderByDescending("fIrstName").ToArray();
        arr.Should().BeInDescendingOrder(it => it.FirstName);
    }
    [TestMethod]
    public void TestThenBy()
    {
        var p = new ListOfPersons();
        var arrOK = p.QueryPersons()
            .OrderBy(it => it.FirstName)
            .ThenBy(it => it.LastName)
            .ToArray();
        var arr = p.QueryPersons()
            .OrderBy("fIrstName")
            .ThenBy("LastName")
            .ToArray();

        arrOK.Should().ContainInConsecutiveOrder(arr);

        arr = p.QueryPersons()
            .OrderBy("fIrstName")
            .ThenByDescending("LastName")
            .ToArray();

        arrOK.Should().NotContainInConsecutiveOrder(arr);
    }


}
