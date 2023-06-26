using Empyrean.Core.Interfaces;
using Example.Test.Interfaces.Components.Field;

namespace Example.Test.Interfaces.Components.Table
{
    public interface ITableFilterComponent : IFieldComponent
    {
        string GetPlaceholder();

        string GetValue();

        void Select(string value);
    }
}
