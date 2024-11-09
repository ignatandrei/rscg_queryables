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
    public void TestWhereSimple()
    {
        var p = new ListOfPersons();
        var arr = p.ArrPersons(); 
        Person[] personFound = arr.Where(Person_.Where("Age", rscg_queryablesCommon.WhereOperator.Equal, 55)).ToArray();
        personFound.Should().HaveCount(1); 
        
    }

}