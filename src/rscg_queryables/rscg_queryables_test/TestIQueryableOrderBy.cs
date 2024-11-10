
using FluentAssertions;
using System.Linq.Expressions;

namespace rscg_queryables_test;
[TestClass]
public class TestIQueryableOrderBy
{
    [TestMethod]
    public void TestOrderByAscDesc()
    {
        var p = new ListOfPersons();
        var arr = p.QueryPersons().OrderByAscDesc("fIrstName",true).ToArray();
        arr.Should().BeInAscendingOrder(it => it.FirstName);

        arr = arr.OrderByAscDesc("fIrstName",false).ToArray();
        arr.Should().BeInDescendingOrder(it => it.FirstName);
    }

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
        
        Func<string,
        System.Linq.Expressions.Expression<Func<Person, bool>>> qFirstNameEquals=FirstName=> (a=>a.FirstName == FirstName);
        Func<int,
        System.Linq.Expressions.Expression<Func<Person, bool>>> qAgeEquals = Age => (a => a.Age == Age);


        var q1 = qFirstNameEquals("Andrei");
        var q2 = qAgeEquals(55);
        
        var parameter = Expression.Parameter(typeof(Person), "a");
        var combinedExpression = Expression.Lambda<Func<Person, bool>>(
            Expression.And(
                Expression.Invoke(q1, parameter),
                Expression.Invoke(q2, parameter)
            ),
            parameter
        );
        Func<Person,string, bool> a = (p,a) => p.FirstName == a;
        Func<Person,int, bool> b = (p,a) => p.Age == a;


        var q = p.QueryPersons().Where(it=>a(it,"Andrei") && b(it,55) ).ToArray();
        arrOK.Should().NotContainInConsecutiveOrder(arr);
    }
    
    


}
