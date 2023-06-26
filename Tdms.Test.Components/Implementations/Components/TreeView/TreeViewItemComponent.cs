using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Tdms.Api.Components.Interfaces.Components.TreeView;
using static Tdms.Api.Components.Interfaces.Components.TreeView.ITreeViewItemComponent;

namespace Tdms.Api.Components.Implementations.Components.TreeView
{
    public class TreeViewItemComponent : ApplicationComponent, ITreeViewItemComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент дерева объектов");

        private const string _DEFAULT_SELECTOR = "table[id^='treeview'] tr[class*='x-grid-row']";

        private const string _EXPAND_BUTTON_SELECTOR = "div[class*='x-tree-elbow'][class*='plus']";

        private const string _NAME_SELECTOR = "span[class^='x-tree-node-text']";

        protected IWebComponent nameComponent;

        protected IWebComponent expandButton;

        protected TreeViewItemComponent()
        {
            var expandButtonDescription = new Description(_EXPAND_BUTTON_SELECTOR, "Кнопка 'Развернуть/Свернуть'");

            var nameDescription = new Description(_NAME_SELECTOR, "Название элемента");

            expandButton = GetComponent()
                .WithDescription(expandButtonDescription)
                .Perform();

            nameComponent = GetComponent()
                .WithDescription(nameDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual int GetLevel() => int.Parse(GetAttribute("aria-level", this));

        public virtual bool IsSelected() => GetAttribute("aria-selected", this).Equals("true");

        public virtual bool IsExpanded() => GetAttribute("aria-expanded", this).Equals("true");

        public virtual bool IsExpandable() => expandButton.IsAvalable();

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual void Click() => Actions.Click();

        public virtual void Expand(ExpandVariant variant = ExpandVariant.DoubleClick)
        {
            if (variant == ExpandVariant.DoubleClick) Actions.DoubleClick();
            else expandButton.Actions.Click();
        }
    }
}
