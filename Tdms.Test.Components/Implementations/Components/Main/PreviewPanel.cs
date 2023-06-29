using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class PreviewPanel : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель предварительного просмотра");

        private const string _DEFAULT_SELECTOR = "div[class='x-panel x-border-item x-box-item x-panel-default'] div[id^='tdms'][class='x-panel x-fit-item x-panel-default']";

        public FileViewPanel FileViewPanel { get; protected set; }

        public TabPanel TabPanel { get; protected set; }



        protected PreviewPanel()
        {
            FileViewPanel = GetComponent<FileViewPanel>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
