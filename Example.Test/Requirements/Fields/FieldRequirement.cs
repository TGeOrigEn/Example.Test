using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.Fields;

namespace Example.Test.Requirements.Fields
{
    public sealed class FieldRequirement<TComponent> : FieldRequirementBuilder<TComponent, FieldRequirement<TComponent>> where TComponent : FieldComponent { }

    public sealed class FieldRequirement : FieldRequirementBuilder<FieldComponent, FieldRequirement> { }

    public abstract class FieldRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : FieldRequirementBuilder<TComponent, TBuilder>
        where TComponent : FieldComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasLabel(bool flag = true) =>
           CreateBuilder(new Requirement<TComponent, bool>(component => component.HasLabel(), flag, "Имеет текст"));

        public override IOperationBuilder<TComponent, TBuilder> ByValueEquality(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetValue(), value, "Имеет значение"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLabelEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Имеет заголовок"));

        public override IOperationBuilder<TComponent, TBuilder> ByValueContent(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetValue(), value, "Содержит значение", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLabelContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Содержит заголовок", ByStringContent));
    }
}
