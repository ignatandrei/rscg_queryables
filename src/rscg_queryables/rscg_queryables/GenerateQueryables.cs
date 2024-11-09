using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace rscg_queryables
{
    [Generator]
    public class GenerateQueryables : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var classesToApplySortable = context.SyntaxProvider.ForAttributeWithMetadataName(
"rscg_queryablesCommon.MakeSortableAttribute",
IsAppliedOnMethod,
FindAttributeDataExposeClass
)
.Collect()
.SelectMany((data, _) => data.Distinct())
.Collect();
            context.RegisterSourceOutput(classesToApplySortable,
(spc, data) =>
ExecuteSort(spc, data));

        }

        private void ExecuteSort(SourceProductionContext spc, ImmutableArray<DataFromExposeClass?> dataFromExposeClasses)
        {
            var arr = dataFromExposeClasses.ToArray().Where(it=>it!=null).Select(it=>it!).ToArray();
            foreach (var classData in arr)
            {
                var c = new SortableTemplate(classData);
                var text = c.Render();
                spc.AddSource($"{classData.type.Name}_sortable.cs", text);
            }
        }

        private static bool IsAppliedOnMethod(
    SyntaxNode syntaxNode,
    CancellationToken cancellationToken)
        {
            var isOK = syntaxNode is ClassDeclarationSyntax;
            return isOK;

        }
        private static DataFromExposeClass? FindAttributeDataExposeClass(
    GeneratorAttributeSyntaxContext context,
    CancellationToken cancellationToken)
        {
           
            var data = context.TargetSymbol as INamedTypeSymbol;
            if(data != null)
            {
                return new DataFromExposeClass(data);
            }
            
            return null;
        }
    }
}
