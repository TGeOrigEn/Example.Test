﻿using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Interfaces.Requirements.Menu
{
    public interface IMenuRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
    where TBuilder : IMenuRequirementBuilder<TComponent, TBuilder>
    where TComponent : IMenuItemComponent
    {
        IOperationBuilder<TComponent, TBuilder> HasCheckBox(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> IsCheck(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}
