using System.Windows;
using System.Windows.Controls;

namespace HotelApp
{
    public partial class NumericUpDown : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0, OnValueChanged));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown), new PropertyMetadata(int.MinValue));

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }


        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown), new PropertyMetadata(int.MaxValue));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public NumericUpDown()
        {
            InitializeComponent();
            //Value = MinValue;
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < MaxValue)
            {
                Value++;
            }
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > MinValue) // Предполагаем, что минимальное значение 0
            {
                Value--;
            }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as NumericUpDown;
            control?.ValueChanged?.Invoke(control, new RoutedPropertyChangedEventArgs<int>((int)e.OldValue, (int)e.NewValue));
        }

        public event RoutedPropertyChangedEventHandler<int> ValueChanged;
    }
}