using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KnightsWatch.Behaviors
{
    public static class LostFocusBehavior
    {
        public static readonly DependencyProperty LostFocusProperty = DependencyProperty.RegisterAttached("LostFocus", typeof(bool), typeof(LostFocusBehavior), new UIPropertyMetadata(false, OnFocusLostChanged));
        public static bool DoStuff(DependencyObject obj)
        {
            return (bool)obj.GetValue(LostFocusProperty);
        }

        private static void OnFocusLostChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            ListView listView = (ListView)sender;
            bool FocusLost = (bool)args.NewValue;

            if (FocusLost)
                listView.LostFocus;
            else
                listView.LostFocus;


        }

        private static void 
    }
}
