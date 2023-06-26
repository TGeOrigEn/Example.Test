﻿using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Menu;

namespace Example.Test.Interfaces.Requirements.Menu
{
    public interface IMenuRequirementBuilder<TComponent, TBuilder> : IApplicationRequirementBuilder<TComponent, TBuilder>
    where TBuilder : IMenuRequirementBuilder<TComponent, TBuilder>
    where TComponent : IMenuComponent
    {
        IOperationBuilder<TComponent, TBuilder> HasCheckBox(bool flag = true);

        IOperationBuilder<TComponent, TBuilder> IsCheck(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value);

        IOperationBuilder<TComponent, TBuilder> ByNameContent(string value);
    }
}