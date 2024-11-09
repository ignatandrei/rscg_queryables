using Microsoft.CodeAnalysis;
using System;

namespace rscg_queryables
{

    internal class DataFromExposeClass
    {
        public string FullName { get; private set; }
        public INamedTypeSymbol type;
        //public int HowToIntercept;
        public string[] PropertiesGet;
        public DataFromExposeClass(INamedTypeSymbol type)
        {
            this.type = type;
            FullName=type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            PropertiesGet = type.GetMembers()
                .OfType<IPropertySymbol>()
                .Where(it=>it.GetMethod != null)
                .Select(it=>it.Name)
                .ToArray();

        }
    }
}
