using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Test.Components.Buttons;
using Example.Test.Requirements.Buttons;

namespace Example.Test.Components.TreeView
{
    public class TreeViewComponent : WebComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Меню");

        private const string _DEFAULT_SELECTOR = "div[id^='treeview'][class^='x-tree-view']";

        private readonly ButtonComponent _expandButton;

        protected TreeViewComponent()
        {
            var expandButton = new ButtonRequirement();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<TreeViewComponent> GetItem() => GetComponent<TreeViewComponent>();

        public IWebComponentCollectionBuilder<TreeViewComponent> GetItems() => GetComponents<TreeViewComponent>();
    }
}
