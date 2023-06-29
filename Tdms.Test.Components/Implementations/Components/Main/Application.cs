using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Fields.Dropdown.List;
using Tdms.Api.Components.Implementations.Components.Loading;
using Tdms.Api.Components.Implementations.Components.Menu;
using Tdms.Api.Components.Implementations.Components.Window;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;
using Tdms.Api.Components.Interfaces.Components.LoadIndicator;
using Tdms.Api.Components.Interfaces.Components.Menu;
using Tdms.Api.Components.Interfaces.Components.Window;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class Application : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Приложение");

        private const string _DEFAULT_SELECTOR = "body[id='ext-element-1']";

        public Header Header { get; protected set; }

        public Body Body { get; protected set; }

        protected Application()
        {
            Header = GetComponent<Header>().Perform();
            Body = GetComponent<Body>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<IDropdownListComponent> GetDropdownList() =>
            GetComponent<IDropdownListComponent>(typeof(DropdownListComponent));

        public IWebComponentBuilder<IMessageBoxComponent> GetMessageBox() =>
            GetComponent<IMessageBoxComponent>(typeof(MessageBoxComponent));

        public IWebComponentBuilder<ILoadingComponent> GetLoading() =>
            GetComponent<ILoadingComponent>(typeof(LoadingComponent));

        public IWebComponentBuilder<IWindowComponent> GetWindow() =>
            GetComponent<IWindowComponent>(typeof(WindowComponent));

        public IWebComponentBuilder<IMenuComponent> GetMenu() =>
            GetComponent<IMenuComponent>(typeof(MenuComponent));
    }
}
