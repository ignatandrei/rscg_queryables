using rscg_queryablesCommon;

namespace rscgQueryables_testconsole;
[MakeSortable]
[MakeWhere]
public class Student
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int StartYear { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}
