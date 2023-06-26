using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.TreeView;

namespace Tdms.Api.Components.Interfaces.Requirements.TreeView
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
