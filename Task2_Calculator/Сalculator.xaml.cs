using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Task2_Calculator
{
    /// <summary>
    /// Логика взаимодействия для Сalculator.xaml
    /// </summary>
    public partial class Сalculator : Window
    {
        private string _expression = "";
        private string Expression { get => _expression; set { _expression = value; OnExpressionChange(); } }

        public Сalculator()
        {
            InitializeComponent();
            Closed += (s, e) => Application.Current.Shutdown(0);
        }

        private void OnExpressionChange()
        {
            TextBlockFirst.Text = Expression;
        }


        #region Кнопки 0-9

        private bool EvalRealNum()
        {
            int i = Expression.Length - 1;
            if (Expression.Length != 0 && Expression.Last() == '0')
            {
                for (; i >= 0; i--)
                {
                    if (Expression[i] == '.')
                        break;
                }
                if (i == -1) return false;
            }
            return true;
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            int i = Expression.Length - 1;
            if (Expression.Length != 0 && Expression.Last() == '0')
            {
                for (; i >= 0; i--)
                {
                    if (Regex.IsMatch(Expression[i].ToString(), @"[/*+-]"))
                        return;
                    if (Regex.IsMatch(Expression[i].ToString(), @"[1-9]") || Expression[i] == '.')
                        break;
                }
                if (i == -1) return;

            }
            Expression += '0';
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '1';
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '2';
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '3';
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '4';
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '5';
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '6';
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '7';
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '8';
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            if (EvalRealNum())
                Expression += '9';
        }

        #endregion


        #region Операторы CE, C, <, ., +, -, *, /

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {
            Expression = "";
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            Expression = "";
            TextBlockLast.Text = "";
        }

        private void Button_LT_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Length != 0)
                Expression = Expression.Remove(Expression.Length - 1);
        }

        private void Button_Dot_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Length != 0 && Regex.IsMatch(Expression.Last().ToString(), @"\d"))
                Expression += '.';
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Length != 0 && !Regex.IsMatch(Expression.Last().ToString(), @"[*/+-.]"))
                Expression += '+';
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Length == 0 || !Regex.IsMatch(Expression.Last().ToString(), @"[*/+-.]"))
                Expression += '-';
        }

        private void Button_Multi_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Length != 0 && !Regex.IsMatch(Expression.Last().ToString(), @"[*/+-.]"))
                Expression += '*';
        }

        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            if (Expression.Length != 0 && !Regex.IsMatch(Expression.Last().ToString(), @"[*/+-.]"))
                Expression += "/";
        }

        #endregion


        private void Button_Equals_Click(object sender, RoutedEventArgs e) // =
        {
            double result;
            try
            {
                result = Convert.ToDouble(new DataTable().Compute(TextBlockFirst.Text, null));
            }
            catch (Exception ex)
            {
                return;
            }
            TextBlockLast.Text = TextBlockFirst.Text;
            Expression = result.ToString();
            TextBlockFirst.Text = result.ToString();
        }

   
    }
}
