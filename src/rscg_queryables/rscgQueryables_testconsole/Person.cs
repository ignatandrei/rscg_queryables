using rscg_queryablesCommon;

namespace rscgQueryables_testconsole;
[MakeSortable]
[MakeWhere]
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
