using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Menu;
using Tdms.Api.Components.Interfaces.Requirements.Menu;

namespace Tdms.Api.Components.Implementations.Requirements.Menu
{
    public sealed class MenuItemRequirement<TComponent> : MenuItemRequirementBuilder<TComponent, MenuItemRequirement<TComponent>> where TComponent : IMenuItemComponent { }

    public sealed class MenuItemRequirement : MenuItemRequirementBuilder<IMenuItemComponent, MenuItemRequirement> { }

    public abstract class MenuItemRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, IMenuRequirementBuilder<TComponent, TBuilder>
        where TBuilder : MenuItemRequirementBuilder<TComponent, TBuilder>
        where TComponent : IMenuItemComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));

        public IOperationBuilder<TComponent, TBuilder> HasCheckBox(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasCheckBox(), flag, "Имеет флаг"));

        public IOperationBuilder<TComponent, TBuilder> IsCheck(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsCheck(), flag, "Значение флага"));
    }
}
