using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Components.Table;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Interfaces.Components.Buttons;
using Tdms.Api.Components.Interfaces.Components.Table;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class FileViewPanel : WebComponent
    {
        public static readonly IDescription DEAFULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель просмотра файлов");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsObjectFilesView'][class^='x-panel x-box-item']";

        private const string _TABLE_SELECTOR = "div[id^='grid'][class^='x-panel x-fit-item']";

        private const string _ADD_FILE_SELECTOR = "a[href='#add']";

        public IButtonComponent ShowTableButton { get; protected set; }

        public IWebComponent AddFileButton { get; protected set; }

        public ITableComponent Table { get; protected set; }

        protected FileViewPanel()
        {
            var buttonRequirement = new ButtonRequirement<ToolButtonComponent>();

            var a = buttonRequirement.ByTipEquality("Раскрыть панель").Perform();
            var b = buttonRequirement.ByTipEquality("Скрыть панель").Perform();
            var c = buttonRequirement.HasTip().Perform();

            var showTableRequirement = c.And(a.Or(b).Isolate());
            var tableDescription = TableComponent.DEFAULT_DESCRIPTION.With(new Selector(_TABLE_SELECTOR));
            var addFileDescription = new Description(_ADD_FILE_SELECTOR, "Кнопка 'Добавить...'");

            ShowTableButton = GetComponent<ToolButtonComponent>().WithRequirement(showTableRequirement).Perform();
            Table = GetComponent<TableComponent>().WithDescription(tableDescription).Perform();
            AddFileButton = GetComponent().WithDescription(addFileDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEAFULT_DESCRIPTION;
    }
}
