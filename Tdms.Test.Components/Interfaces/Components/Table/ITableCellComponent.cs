namespace Tdms.Api.Components.Interfaces.Components.Table
{
    public interface ITableCellComponent : IApplicationComponent
    {
        bool HasCheckBox();

        bool HasState();

        bool IsCheck();

        string GetValue();

        int GetState();

        void DoubleClick();

        void Click();
    }
}
