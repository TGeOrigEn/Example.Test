using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Implementations.Components.TreeView;
using Tdms.Api.Components.Interfaces.Components.TreeView;

namespace Tdms.Api.Components.Implementations.Components.Main
{
    public class Body : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Тело приложения");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsNavigationPage'][class*='x-panel x-fit-item']:not([class*='x-hidden-offsets'])";

        private const string _TREE_VIEW_SELECTOR = "div[id^='treeview'][class^='x-tree-view x-fit-item']";

        public ITreeViewComponent TreeView { get; protected set; }

        public PreviewPanel PreviewPanel { get; protected set; }

        public ViewPanel ViewPanel { get; protected set; }

        public ToolBar ToolBar { get; protected set; }
    
        protected Body()
        {
            var treeViewDescription = TreeViewComponent.DEFAULT_DESCRIPTION.With(new Selector(_TREE_VIEW_SELECTOR));

            TreeView = GetComponent<TreeViewComponent>().WithDescription(treeViewDescription).Perform();         

            PreviewPanel = GetComponent<PreviewPanel>().Perform();

            ViewPanel = GetComponent<ViewPanel>().Perform();

            ToolBar = GetComponent<ToolBar>().Perform();        
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
