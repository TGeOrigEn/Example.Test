﻿using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Field
{
    public interface IFieldComponent : IApplicationComponent
    {
        bool HasPlaceholder();

        bool HasLabel();

        bool IsReadOnly();

        string GetPlaceholder();

        string GetValue();

        string GetLabel();

        void SetValue(string value);

        void SendKeys(string keys);

        void Sumbit();

        void Clear();
    }
}
