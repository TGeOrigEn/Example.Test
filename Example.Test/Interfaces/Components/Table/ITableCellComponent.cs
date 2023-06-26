using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.Table
{
    public interface ITableCellComponent : IApplicationComponent
    {
        bool HasCheckBox();

        bool HasCheck();

        string GetValue();

        bool IsCheck();

        void Click();
    }
}
