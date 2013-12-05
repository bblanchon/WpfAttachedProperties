// Copyright © Benoit Blanchon 2013
// http://benoitblanchon.fr/
// MIT License
namespace WpfAttachedProperties
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    static class TextBoxHelpers
    {
        const string ALLOWED_CHARS = "0123456789ABCDEFabcdef";

        public static bool GetOnlyHexadecimal(TextBox obj)
        {
            return (bool)obj.GetValue(OnlyHexadecimalProperty);
        }

        public static void SetOnlyHexadecimal(TextBox obj, bool value)
        {
            obj.SetValue(OnlyHexadecimalProperty, value);
        }

        public static readonly DependencyProperty OnlyHexadecimalProperty =
            DependencyProperty.RegisterAttached("OnlyHexadecimal", typeof(bool), typeof(TextBoxHelpers), 
            new PropertyMetadata(false, OnOnlyHexadecimalPropertyChanged));

        static void OnOnlyHexadecimalPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;

            if( textBox == null)
                throw new InvalidOperationException("This property can only be applied to TextBox");

            var oldValue = (bool)e.OldValue;
            if (oldValue)
            {
                textBox.PreviewTextInput -= OnPreviewTextInput;

            }

            var newValue = (bool)e.NewValue;
            if (newValue)
            {
                textBox.PreviewTextInput += OnPreviewTextInput;

            }
        }

        static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        static bool IsTextAllowed(string text)
        {
            return text.All(ALLOWED_CHARS.Contains);
        }
    }
}
