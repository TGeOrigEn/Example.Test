using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Window;

namespace Tdms.Api.Components.Interfaces.Requirements.Window
{
    public interface IMessageBoxRequirementBuilder<TComponent, TBuilder> : IWindowRequirementBuilder<TComponent, TBuilder>
        where TBuilder : IMessageBoxRequirementBuilder<TComponent, TBuilder>
        where TComponent : IMessageBoxComponent
    {
        IOperationBuilder<TComponent, TBuilder> ByMessageEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByMessageContent(string value);
    }
}
