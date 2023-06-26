﻿using Empyrean.Core.Interfaces;

namespace Example.Test.Interfaces.Components.TreeView
{
    public interface ITreeViewComponent : IApplicationComponent
    {
        IWebComponentCollectionBuilder<TComponent> GetItems<TComponent>() where TComponent : ITreeViewItemComponent;

        IWebComponentBuilder<TComponent> GetItem<TComponent>() where TComponent : ITreeViewItemComponent;

        IWebComponentCollectionBuilder<ITreeViewItemComponent> GetItems();

        IWebComponentBuilder<ITreeViewItemComponent> GetItem();
    }
}