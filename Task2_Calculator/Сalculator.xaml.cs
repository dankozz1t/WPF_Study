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

        private char symbol;
        private bool isFirst = true;

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
            TextBlockLast.Text = "";
        }

        private void Button_LT_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockFirst.Text.Length != 0)
                TextBlockFirst.Text = TextBlockFirst.Text.Remove(TextBlockFirst.Text.Length - 1);
        }

    

        #region Кнопки 0-9

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "0";
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "1";
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += "9";
        }

        #endregion


        #region Операторы

        private void Button_Dot_Click(object sender, RoutedEventArgs e)
        {
            TextBlockFirst.Text += ".";
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                first = Double.Parse(TextBlockFirst.Text);
                TextBlockFirst.Text += "+";
                symbol = '+';
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!", exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                first = Double.Parse(TextBlockFirst.Text);
                TextBlockFirst.Text += "-";
                symbol = '-';
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!", exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Multi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                first = Double.Parse(TextBlockFirst.Text);

                TextBlockFirst.Text += "*";
                symbol = '*';
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!", exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                first = Double.Parse(TextBlockFirst.Text);
                TextBlockFirst.Text += "/";
                symbol = '/';
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!", exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        public void Сount()
        {
            switch (symbol)
            {
                case '/':
                    TextBlockFirst.Text = (first / second).ToString();
                    break;
                case '*':
                    TextBlockFirst.Text = (first * second).ToString();
                    break;
                case '+':
                    TextBlockFirst.Text = (first + second).ToString();
                    break;
                case '-':
                    TextBlockFirst.Text = (first - second).ToString();
                    break;
            }

        }

        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                second = Double.Parse(TextBlockFirst.Text.Split(symbol)[1]);
                TextBlockLast.Text = TextBlockFirst.Text;
                Сount();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!", exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

   
    }
}
