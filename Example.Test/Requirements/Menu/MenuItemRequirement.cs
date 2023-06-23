using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.Menu;

namespace Example.Test.Requirements.Menu
{
    public sealed class MenuItemRequirement<TComponent> : MenuItemRequirementBuilder<TComponent, MenuItemRequirement<TComponent>> where TComponent : MenuItemComponent { }

    public sealed class MenuItemRequirement : MenuItemRequirementBuilder<MenuItemComponent, MenuItemRequirement> { }

    public abstract class MenuItemRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : MenuItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : MenuItemComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
