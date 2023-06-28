using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;

namespace Tdms.Api.Components.Implementations.Components.Fields.Dropdown.List
{
    public class DropdownListComponent : ApplicationComponent, IDropdownListComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Выпадающий список");

        private const string _DEFAULT_SELECTOR = "div[id^='contentfilter'][id*='picker'][class*='x-boundlist x-boundlist-floating']:not([style*='display'])";

        protected DropdownListComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<IDropdownListItemComponent> GetItem() =>
            IWebComponent.Context.GetComponent<IDropdownListItemComponent>(typeof(DropdownListItemComponent));

        public IWebComponentCollectionBuilder<IDropdownListItemComponent> GetItems() =>
            IWebComponent.Context.GetComponents<IDropdownListItemComponent>(typeof(DropdownListItemComponent));
    }
}
