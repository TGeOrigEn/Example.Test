namespace Example.Test.Interfaces.Components.Field
{
    public interface ICheckBoxFieldComponent : IApplicationComponent
    {
        bool HasLabel();

        bool IsReadOnly();

        bool GetValue();

        string GetLabel();

        void SetValue(string value);
    }
}
