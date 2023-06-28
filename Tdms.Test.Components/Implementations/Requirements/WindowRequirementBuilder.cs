using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Window;
using Tdms.Api.Components.Interfaces.Requirements.Window;

namespace Tdms.Api.Components.Implementations.Requirements
{
    public sealed class WindowRequirement<TComponent> : WindowRequirementBuilder<TComponent, WindowRequirement<TComponent>> where TComponent : IWindowComponent { }

    public sealed class WindowRequirement : WindowRequirementBuilder<IWindowComponent, WindowRequirement> { }

    public abstract class WindowRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, IWindowRequirementBuilder<TComponent, TBuilder>
        where TBuilder : WindowRequirementBuilder<TComponent, TBuilder>
        where TComponent : IWindowComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> ByTitleEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTitle(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTitleContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTitle(), value, "Содержит имя", ByStringContent));
    }
}
