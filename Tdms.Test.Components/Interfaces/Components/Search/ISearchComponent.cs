namespace Tdms.Api.Components.Interfaces.Components.Search
{
    public interface ISearchComponent : IApplicationComponent
    {
        void SetValue(string value);

        void SendKeys(string keys);

        void Clear();

        void Search();

        void Remove();

        void AdvancedSearch();
    }
}
