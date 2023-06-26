namespace Example.Test.Interfaces.Components.Window
{
    public interface IWindowComponent : IApplicationComponent
    {
        string GetTitle();

        void Maximize();

        void Cancel();

        void Close();

        void Apply();

        void Ok();
    }
}
