using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Fields.Dropdown.List;
using Tdms.Api.Components.Implementations.Components.Loading;
using Tdms.Api.Components.Implementations.Components.Menu;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;
using Tdms.Api.Components.Interfaces.Components.LoadIndicator;
using Tdms.Api.Components.Interfaces.Components.Menu;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class ApplicationComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Приложение");

        private const string _DEFAULT_SELECTOR = "body[id='ext-element-1']";

        public ApplicationHeaderComponent Header { get; }

        protected ApplicationComponent()
        {
            Header = GetComponent<ApplicationHeaderComponent>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<IDropdownListComponent> GetDropdownList() =>
            GetComponent<IDropdownListComponent>(typeof(DropdownListComponent));

        public IWebComponentBuilder<ILoadingComponent> GetLoading() =>
            GetComponent<ILoadingComponent>(typeof(LoadingComponent));

        public IWebComponentBuilder<IMenuComponent> GetMenu() =>
            GetComponent<IMenuComponent>(typeof(MenuComponent));
    }
}
