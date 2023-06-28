using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Requirements;
using Tdms.Api.Components.Interfaces.Components;
using Tdms.Api.Components.Interfaces.Components.Search;

namespace Tdms.Api.Components.Implementations.Components.Search
{
    public class SearchComponent : ApplicationComponent, ISearchComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Меню");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsSearch'][class^='x-field search-field']";

        private const string _INPUT_SELECTOR = "input";

        protected IApplicationComponent advancedButton;

        protected IApplicationComponent searchButton;

        protected IApplicationComponent clearButton;

        protected IWebComponent inputComponent;

        protected SearchComponent()
        {
            var applicationRequirement = new ApplicationRequirement<ApplicationComponent>();

            var advancedRequirement = applicationRequirement.HasTip().And().ByTipEquality("Расширенный поиск").Perform();
            var searchRequirement = applicationRequirement.HasTip().And().ByTipEquality("Искать").Perform();
            var clearRequirement = applicationRequirement.HasTip().And().ByTipEquality("Очистить").Perform();

            advancedButton = GetComponent<ApplicationComponent>().WithRequirement(advancedRequirement).Perform();
            searchButton = GetComponent<ApplicationComponent>().WithRequirement(searchRequirement).Perform();
            clearButton = GetComponent<ApplicationComponent>().WithRequirement(clearRequirement).Perform();

            var inputDescription = new Description(_INPUT_SELECTOR, "Ввод для поиска");

            inputComponent = GetComponent().WithDescription(inputDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void Clear() => clearButton.Actions.Click();

        public void Remove() => clearButton.Actions.Click();

        public void Search() => searchButton.Actions.Click();

        public void SendKeys(string keys) => inputComponent.Actions.SendKeys(keys);

        public void SetValue(string value) => inputComponent.Actions.SetValue(value);

        public void AdvancedSearch() => advancedButton.Actions.Click();
    }
}
