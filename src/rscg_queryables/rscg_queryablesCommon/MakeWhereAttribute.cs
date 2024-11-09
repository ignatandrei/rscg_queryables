using System;

namespace rscg_queryablesCommon
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MakeWhereAttribute : Attribute
    {
        public WhereOperator WhereToGenerate = WhereOperator.None;
    }

}
