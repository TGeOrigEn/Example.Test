using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components;

namespace Example.Test.Requirements
{
    public sealed class LoadIndicatorRequirement<TComponent> : LoadIndicatorRequirementBuilder<TComponent, LoadIndicatorRequirement<TComponent>> where TComponent : LoadIndicatorComponent { }

    public sealed class LoadIndicatorRequirement : LoadIndicatorRequirementBuilder<LoadIndicatorComponent, LoadIndicatorRequirement> { }

    public abstract class LoadIndicatorRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : LoadIndicatorRequirementBuilder<TComponent, TBuilder>
        where TComponent : LoadIndicatorComponent
    {
        public override IOperationBuilder<TComponent, TBuilder> ByTextEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetText(), value, "Имеет текст"));

        public override IOperationBuilder<TComponent, TBuilder> ByTextContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetText(), value, "Содержит текст", ByStringContent));
    }
}
