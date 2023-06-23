using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.Buttons;

namespace Example.Test.Requirements.Buttons
{
    public sealed class ButtonRequirement<TComponent> : ButtonRequirementBuilder<TComponent, ButtonRequirement<TComponent>> where TComponent : ButtonComponent { }

    public sealed class ButtonRequirement : ButtonRequirementBuilder<ButtonComponent, ButtonRequirement> { }

    public abstract class ButtonRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ButtonRequirementBuilder<TComponent, TBuilder>
        where TComponent : ButtonComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasText(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasText(), flag, "Имеет текст"));

        public virtual IOperationBuilder<TComponent, TBuilder> HasTip(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasTip(), flag, "Имеет подсказку"));

        public override IOperationBuilder<TComponent, TBuilder> ByTextEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetText(), value, "Имеет текст"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTipEquality(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetTip(), value, "Имеет подсказку"));

        public override IOperationBuilder<TComponent, TBuilder> ByTextContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetText(), value, "Содержит текст", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTipContent(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetTip(), value, "Содержит подсказку", ByStringContent));
    }
}
