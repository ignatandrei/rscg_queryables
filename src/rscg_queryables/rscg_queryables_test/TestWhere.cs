using FluentAssertions;
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
    public void TestOrderBy()
    {
        var p = new ListOfPersons();
        var arr = p.ArrPersons(); 
        Person[] personFound = arr.Where(ExtensionsWhere_rscg_queryables_test_Person.Person_Where("Age", rscg_queryablesCommon.WhereOperator.Equal, 55)).ToArray();
        personFound.Should().HaveCount(1); 
    }
}