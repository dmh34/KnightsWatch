using System.Windows;
using System.Windows.Controls;

namespace KnightsWatch.Core.Behaviors
{
    public static class TabItemLostFocusBehavior
    {
        public static bool TabItemLostFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(TabItemLostFocusProperty);
        }

        public static void SetTabItemLostFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(TabItemLostFocusProperty, value);
        }

        public static readonly DependencyProperty TabItemLostFocusProperty =
            DependencyProperty.RegisterAttached("TabItemLostFocus", typeof(bool),
                typeof(TabItemLostFocusBehavior), new UIPropertyMetadata(false, OnLostFocus));

        private static void OnLostFocus(object sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            TabItem tabItem = (TabItem)sender;
            bool hasLostFocus = (bool)(eventArgs.NewValue);
            var parent = tabItem.Parent as TabControl;

            if (hasLostFocus)
                parent.SelectionChanged += DoStuff;
            else
                parent.SelectionChanged -= DoStuff;
            var a = parent.Items;
            //var b = LogicalTreeHelper.GetChildren(a);


        }

        //Bad but will do for now
        private static void DoStuff(object sender, RoutedEventArgs args)
        {
            //TabItem tabItem = (TabItem)sender;
            //var data = tabItem.DataContext as MainWindowViewModel;
            //foreach (var item in data.AvailiblePersonnel)
            //{
            //    if (item.CallSign != null && !data.OnDutyPersonnel.Contains(item))
            //        data.OnDutyPersonnel.Add(item);
            //}

            //foreach (var item in data.OnDutyPersonnel)
            //{
            //    if (item.CallSign == null || item.CallSign == String.Empty)
            //        data.OnDutyPersonnel.Remove(item);
            //}


        }





    }
}
