using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components;
using Example.Test.Interfaces.Requirements;

namespace Tdms.Test.Components.Implementations.Requirements
{
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
