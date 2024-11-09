using Microsoft.CodeAnalysis;
using System;

namespace rscg_queryables
{

    internal class DataFromExposeClass
    {
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public string FullNameToBeUsed { get { return FullName
                    .Replace("global::", "")
                    .Replace(".", "_")
                    ; } }

        private INamedTypeSymbol type;
        //public int HowToIntercept;
        public string[] PropertiesGet;
        public Tuple<string,string>[] PropertiesGetWithType;
        public Dictionary<string, string[]> PropertiesGetGroupedAfterType;

        public DataFromExposeClass(INamedTypeSymbol type)
        { 
            this.type = type;
            FullName=type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            Name = type.Name;
            var propsGet = type.GetMembers()
                .OfType<IPropertySymbol>()
                .Where(it => it.GetMethod != null)
                .ToArray();
            PropertiesGet = propsGet
                .Select(it=>it.Name)
                .ToArray();

            PropertiesGetWithType= propsGet
                .Select(it=>Tuple.Create(it.Name,it.GetMethod!.ReturnType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)))
                .ToArray();

            PropertiesGetGroupedAfterType= PropertiesGetWithType.GroupBy(it=>it.Item2).ToDictionary(it => it.Key, it => it.Select(it=>it.Item1).ToArray());
        
        }
    }
}
