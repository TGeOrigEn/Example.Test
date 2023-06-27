using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components;
using Tdms.Api.Components.Interfaces.Requirements;

namespace Tdms.Api.Components.Implementations.Requirements
{
    public sealed class ApplicationRequirement<TComponent> : ApplicationRequirementBuilder<TComponent, ApplicationRequirement<TComponent>> where TComponent : IApplicationComponent { }

    public sealed class ApplicationRequirement : ApplicationRequirementBuilder<IApplicationComponent, ApplicationRequirement> { }

    public abstract class ApplicationRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>, IApplicationRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ApplicationRequirementBuilder<TComponent, TBuilder>
        where TComponent : IApplicationComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasReference(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasReference(), flag, "Имеет ссылку"));

        public virtual IOperationBuilder<TComponent, TBuilder> HasTip(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasTip(), flag, "Имеет подсказку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByReferenceEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetReference(), value, "Имеет ссылку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTipEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTip(), value, "Имеет подсказку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByReferenceContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetReference(), value, "Содержит ссылку", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTipContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTip(), value, "Содержит подсказку", ByStringContent));
    }
}
