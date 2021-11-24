using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_Calculator
{
    /// <summary>
    /// Логика взаимодействия для Сalculator.xaml
    /// </summary>
    public partial class Сalculator : Window
    {
        private double first;
        private double second;

        public Сalculator()
        {
            InitializeComponent();
        }

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text = "";
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text = "";
            TextBlockLast.Text = "0";
        }

        private void Button_LT_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockFirst.Text.Length != 0)
                TextBlockFirst.Text = TextBlockFirst.Text.Remove(TextBlockFirst.Text.Length - 1);
        }

        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!",exception.Message,MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
