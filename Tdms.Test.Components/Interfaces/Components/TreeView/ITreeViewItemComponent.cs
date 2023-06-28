namespace Tdms.Api.Components.Interfaces.Components.TreeView
{
    public interface ITreeViewItemComponent : IApplicationComponent
    {
        enum ExpandVariant { DoubleClick, ClickOnExpandButton }

        bool IsExpandable();

        bool IsExpanded();

        string GetName();

        void ContextClick();

        void Click();

        void Expand(ExpandVariant variant = ExpandVariant.DoubleClick);
    }
}
