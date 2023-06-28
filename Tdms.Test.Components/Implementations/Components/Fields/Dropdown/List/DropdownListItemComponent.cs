using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Field.Dropdown.List;

namespace Tdms.Api.Components.Implementations.Components.Fields.Dropdown.List
{
    public class DropdownListItemComponent : ApplicationComponent, IDropdownListItemComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELCETOR, "Элемент выпадающего списка");

        private const string _DEFAULT_SELCETOR = "li";

        protected DropdownListItemComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public void Click() => Actions.Click();

        public string GetName() => Properties.GetText();
    }
}
