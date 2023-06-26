namespace Example.Test.Interfaces.Components.TreeView
{
    public interface ITreeViewItemComponent : IApplicationComponent
    {
        enum ExpandVariant { DoubleClick, ClickOnExpandButton }

        bool IsExpandable();

        bool IsExpanded();

        string GetName();

        void Click();

        void Expand(ExpandVariant variant = ExpandVariant.DoubleClick);
    }
}
