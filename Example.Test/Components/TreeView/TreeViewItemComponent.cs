using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;

namespace Example.Test.Components.TreeView
{
    public class TreeViewItemComponent : WebComponent
    {
        public enum ExpandVariant { DoubleClick, ClickOnExpandButton }

        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(DEFAULT_SELECTOR, "Элемент дерева объектов");

        private const string DEFAULT_SELECTOR = "table[id^='treeview'] tr[class*='x-grid-row']";

        private const string NAME_COMPONENT_SELECTOR = "span[class^='x-tree-node-text']";

        private const string EXPAND_BUTTON_SELECTOR = "div[class*='x-tree-elbow'][class*='plus']";

        private readonly IWebComponent _expandButtonComponent;

        private readonly IWebComponent _nameComponent;

        protected TreeViewItemComponent()
        {
            var nameComponentDescription = new Description(NAME_COMPONENT_SELECTOR, "Название элемента");

            _nameComponent = GetComponent()
                .WithDescription(nameComponentDescription)
                .Perform();

            var expandButtonDescription = new Description(EXPAND_BUTTON_SELECTOR, "Кнопка 'Развернуть/Свернуть'");

            _expandButtonComponent = GetComponent()
                .WithDescription(expandButtonDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public int GetLevel()
        {
            if (int.TryParse(Properties.GetAttribute("aria-level"), out var level)) return level;
            else throw new Exception($"Не удалось получить значение уровня из '{Hierarchy}'.");
        }

        public bool IsSelected() => Equals(Properties.GetAttribute("aria-expanded"), "true");

        public bool IsExpanded() => Equals(Properties.GetAttribute("aria-expanded"), "true");

        public bool IsExpandable() => _expandButtonComponent.Has(new WebComponentRequirement().IsAvalable(true).Perform(), TimeSpan.Zero);

        public string GetName() => _nameComponent.Properties.GetText();

        public void Click() => Actions.Click();

        public void Expand(ExpandVariant variant = ExpandVariant.DoubleClick)
        {
            if (variant == ExpandVariant.DoubleClick) Actions.DoubleClick();
            else _expandButtonComponent.Actions.Click();
        }
    }
}
