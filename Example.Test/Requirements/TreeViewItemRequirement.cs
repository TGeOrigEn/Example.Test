using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.TreeView;

namespace Example.Test.Requirements
{
    public sealed class TreeViewItemRequirement<TComponent> : TreeViewItemRequirementBuilder<TComponent, TreeViewItemRequirement<TComponent>> where TComponent : TreeViewItemComponent { }

    public sealed class TreeViewItemRequirement : TreeViewItemRequirementBuilder<TreeViewItemComponent, TreeViewItemRequirement> { }

    public abstract class TreeViewItemRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TreeViewItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : TreeViewItemComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> IsExpandable(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsExpandable(), flag, "Разворачиваемый"));

        public override IOperationBuilder<TComponent, TBuilder> IsSelected(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsSelected(), flag, "Выделен"));

        public virtual IOperationBuilder<TComponent, TBuilder> IsExpanded(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsExpanded(), flag, "Развёрнут"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLevelEquality(int value) =>
            CreateBuilder(new Requirement<TComponent, int>(component => component.GetLevel(), value, "Имеет уровень"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
