using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class TabPanel : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель вкладок");

        private const string _DEFAULT_SELECTOR = "div[id^='tabpanel'][class='x-panel x-box-item x-panel-default']";

        public ITableComponent Table { get; protected set; }
    }
}
