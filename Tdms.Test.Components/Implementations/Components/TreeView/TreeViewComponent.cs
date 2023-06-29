using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.TreeView;

namespace Tdms.Api.Components.Implementations.Components.TreeView
{
    public class TreeViewComponent : ApplicationComponent, ITreeViewComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Дерево объектов");

        private const string _DEFAULT_SELECTOR = "div[id^='treeview'][class^='x-tree-view']";

        protected TreeViewComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentCollectionBuilder<TComponent> GetItems<TComponent>() where TComponent : ITreeViewItemComponent => GetComponents<TComponent>();

        public IWebComponentBuilder<TComponent> GetItem<TComponent>() where TComponent : ITreeViewItemComponent => GetComponent<TComponent>();

        public IWebComponentCollectionBuilder<ITreeViewItemComponent> GetItems() => GetComponents<ITreeViewItemComponent>(typeof(TreeViewItemComponent));

        public IWebComponentBuilder<ITreeViewItemComponent> GetItem() => GetComponent<ITreeViewItemComponent>(typeof(TreeViewItemComponent));
    }
}
