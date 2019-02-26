using KnightsWatch.Presentation.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace KnightsWatch.Core.Behaviors
{
    public static class UpdateCollectionItemBehavior
    {
        public static UpdateCollectionItemDelegate GetUpdatedItems(TabControl obj)
        {
            if (obj == null) return null ;
            return (UpdateCollectionItemDelegate)obj.GetValue(UpdatedItemProperty);
        }

        public static void SetUpdatedItem(DependencyObject obj, UpdateCollectionItemDelegate value)
        {
            obj.SetValue(UpdatedItemProperty, value);
        }

        public static readonly DependencyProperty UpdatedItemProperty =
            DependencyProperty.RegisterAttached("UpdatedItem",
                typeof(UpdateCollectionItemDelegate),
                typeof(UpdateCollectionItemBehavior),
                new UIPropertyMetadata(null, OnCollectionItemUpdated));

        private static void OnCollectionItemUpdated(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var tabControl = obj as TabControl;
            if (tabControl == null)
                return;

            if (args.OldValue is UpdateCollectionItemDelegate)
                tabControl.SelectionChanged -= OnItemChanged;
            if (args.NewValue is UpdateCollectionItemDelegate)
                tabControl.SelectionChanged += OnItemChanged;


        }

        private static void OnItemChanged(object sender, RoutedEventArgs args)
        {
            var tabcontrol = args.OriginalSource as TabControl;

            var updated = GetUpdatedItems(tabcontrol);
            if (updated == null) return;
            updated(null);
        }
    }


    //public static class DoubleClickBehavior
    //{
    //    public static DoubleClickDelegate GetDoubleClick(DependencyObject dependencyObject)
    //    {
    //        return (DoubleClickDelegate)dependencyObject.GetValue(DoubleClickProperty);
    //    }

    //    public static readonly DependencyProperty DoubleClickProperty = DependencyProperty.RegisterAttached(typeof(DoubleClickDelgate), typeof(DoubleClickBehavior), new UIPropertyMetadata(null, OnDoubleClick));

    //    private static void OnDoubleClick(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    //    {
    //        var control = obj as Control;
    //        if (args.OldValue is DoubleClickDelegate)
    //            control.MouseDoubleClick -= OnDoubleClickSelected;
    //        if (args.NewValue is DoubleClickDelegate)
    //            control.MouseDoubleClick += OnDoubleClickSelected;
    //    }
    //}

}