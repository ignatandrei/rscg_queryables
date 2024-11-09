using FluentAssertions;
using System.Collections.Generic;

namespace rscg_queryables_test;

[TestClass]
public class TestIEnumerable
{
    [TestMethod]
    public void TestOrderBy()
    {
        var p = new ListOfPersons();
        var arr = new List<Person>(p.ArrPersons()).OrderBy("fIrstName").ToArray();
        arr.Should().BeInAscendingOrder(it => it.FirstName);
        arr = arr.OrderByDescending("fIrstName").ToArray();
        arr.Should().BeInDescendingOrder(it => it.FirstName);
    }
    [TestMethod]
    public void TestThenBy()
    {
        var p = new ListOfPersons();
        var arrOK = new List<Person>(p.ArrPersons())
            .OrderBy(it=>it.FirstName).ThenBy(it=>it.LastName)
            .ToArray();
        var arr = new List<Person>(p.ArrPersons())
            .OrderBy("fIrstName")
            .ThenBy("LastName")
            .ToArray();
        
        arrOK.Should().ContainInConsecutiveOrder(arr);
        arr = new List<Person>(p.ArrPersons())
            .OrderBy("fIrstName")
            .ThenByDescending("LastName")
            .ToArray();

        arrOK.Should().NotContainInConsecutiveOrder(arr);
    }
}