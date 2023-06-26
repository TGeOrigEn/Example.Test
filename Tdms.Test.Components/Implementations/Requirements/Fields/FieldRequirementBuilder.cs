using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Field;
using Example.Test.Interfaces.Requirements.Fields;
using Tdms.Test.Components.Implementations.Components.Fields;

namespace Tdms.Test.Components.Implementations.Requirements.Fields
{
    public sealed class FieldRequirement<TComponent> : FieldRequirementBuilder<TComponent, FieldRequirement<TComponent>> where TComponent : IFieldComponent { }

    public sealed class FieldRequirement : FieldRequirementBuilder<FieldComponent, FieldRequirement> { }

    public abstract class FieldRequirementBuilder<TComponent, TBuilder> : ApplicationRequirementBuilder<TComponent, TBuilder>, IFieldRequirementBuilder<TComponent, TBuilder>
        where TBuilder : FieldRequirementBuilder<TComponent, TBuilder>
        where TComponent : IFieldComponent
    {
        public IOperationBuilder<TComponent, TBuilder> HasPlaceholder(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasPlaceholder(), flag, "Имеет заполнитель"));

        public IOperationBuilder<TComponent, TBuilder> HasLabel(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasLabel(), flag, "Имеет заголовок"));

        public IOperationBuilder<TComponent, TBuilder> ByPlaceholderEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetPlaceholder(), value, "Имеет заполнитель", ByStringContent));

        public IOperationBuilder<TComponent, TBuilder> ByLabelEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Имеет заголовок", ByStringContent));

        public IOperationBuilder<TComponent, TBuilder> ByPlaceholderContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetPlaceholder(), value, "Содержит заполнитель", ByStringContent));

        public IOperationBuilder<TComponent, TBuilder> ByLabelContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Содержит заголовок", ByStringContent));
    }
}
