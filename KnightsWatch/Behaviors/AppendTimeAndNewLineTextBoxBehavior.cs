using System;
using System.Windows;
using System.Windows.Controls;

namespace KnightsWatch.Core.Behaviors
{
    public static class NewLineTextBoxBehavior
    {
        public static bool GetNewLine(DependencyObject obj)
        {
            return (bool)obj.GetValue(NewLineProperty);
        }
        public static void SetNewLine(DependencyObject obj, bool value)
        {
            obj.SetValue(NewLineProperty, value);
        }

        public static readonly DependencyProperty NewLineProperty =
                DependencyProperty.RegisterAttached("NewLine", typeof(bool), 
                    typeof(NewLineTextBoxBehavior), new PropertyMetadata(false, OnFocus));

        private static void OnFocus(object sender, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = (TextBox)sender;
            bool hasFocus = (bool)(args.NewValue);

            if (hasFocus)
                textBox.GotFocus += TextBox_GotFocus;
            else
                textBox.GotFocus -= TextBox_GotFocus;
        }

        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            
            textBox.Text = textBox.Text + "(Local) " + DateTime.Now + " (UTC) " + DateTime.UtcNow +"\n";
            textBox.CaretIndex = textBox.Text.Length;

            
        }
    }



}