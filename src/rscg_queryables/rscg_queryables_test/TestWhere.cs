using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rscg_queryables_test;

[TestClass]
public class TestWhere
{
    [TestMethod] 
    public void TestWhereSimpleArr()
    {
        var p = new ListOfPersons();
        var arr = p.ArrPersons(); 
        Person[] personFound = arr.Where(Person_.Where("Age", rscg_queryablesCommon.WhereOperator.Equal, 55)).ToArray();
        personFound.Should().HaveCount(1); 
        
    }
    [TestMethod]
    public void TestWhereSimpleIQueryable()
    {
        var p = new ListOfPersons();
        var arr = p.QueryPersons();
        IQueryable<Person> personFoundQ = arr.Where(Person_.Where_Expr("Age", rscg_queryablesCommon.WhereOperator.Equal, 55));
        Person[] personFound  = personFoundQ.ToArray();
        personFound.Should().HaveCount(1);

    }
    [TestMethod]
    public void TestWhereSimpleData()
    {
        var p = new ListOfPersons();
        var arr = p.QueryPersons();
        IQueryable<Person> personFoundQ = arr.Where("Age", rscg_queryablesCommon.WhereOperator.Equal, 55);
        Person[] personFound = personFoundQ.ToArray();
        personFound.Should().HaveCount(1);

    }



}