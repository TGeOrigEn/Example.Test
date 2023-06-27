using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.TreeView;
using Tdms.Api.Components.Interfaces.Requirements.TreeView;

namespace Tdms.Api.Components.Implementations.Requirements.TreeView
{
    public sealed class TreeViewItemRequirement<TComponent> : TreeViewItemRequirementBuilder<TComponent, TreeViewItemRequirement<TComponent>> where TComponent : ITreeViewItemComponent { }

    public sealed class TreeViewItemRequirement : TreeViewItemRequirementBuilder<ITreeViewItemComponent, TreeViewItemRequirement> { }

    public abstract class TreeViewItemRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, ITreeViewItemRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TreeViewItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITreeViewItemComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> IsExpandable(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsExpanded(), flag, "Разворачиваем"));

        public virtual IOperationBuilder<TComponent, TBuilder> IsExpanded(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsExpanded(), flag, "Развёрнут"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
