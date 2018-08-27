using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chapter3
{
    public class SampleDataSource : DependencyObject
    {
        public SampleDataSource()
        {
            SampleDependencyProperty = 15;
        }

        public int SampleDependencyProperty
        {
            get { return (int)GetValue(SampleDependencyPropertyProperty); }
            set { SetValue(SampleDependencyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SampleDependencyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SampleDependencyPropertyProperty =
            DependencyProperty.Register(
                "SampleDependencyProperty", 
                typeof(int), 
                typeof(SampleDataSource), 
                new PropertyMetadata(
                    15,
                    propertyChangedCallback,
                    coerceValueCallback),
                validateValueCallback);

        private static bool validateValueCallback(object value)
        {
            return (int)value > 0;
        }

        private static object coerceValueCallback(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine($"{e.Property.Name} changed from {e.OldValue} to {e.NewValue}");
        }
    }
}
