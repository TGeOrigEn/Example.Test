using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.TreeView;

namespace Example.Test.Interfaces.Requirements.TreeView
{
    public interface ITreeViewItemRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ITreeViewItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITreeViewItemComponent
    {
        IOperationBuilder<TComponent, TBuilder> IsExpandable(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> IsExpanded(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
