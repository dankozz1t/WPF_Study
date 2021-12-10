using System;
using System.Windows;
using System.Windows.Controls;
using Task3_MemoryGame_MVVM.Views.GamePad;

namespace Task3_MemoryGame_MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class GlobalMenu : Window
    {
        public GlobalMenu()
        {
            InitializeComponent();
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            GamePad play = new GamePad(Convert.ToInt32(RowsTextBlock.Text), Convert.ToInt32(ColumnsTextBlock.Text) );
            play.Show();
            this.Hide();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Slider_Columns_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColumnsTextBlock.Text = Convert.ToInt32((sender as Slider).Value).ToString();
        }

        private void Slider_Rows_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RowsTextBlock.Text = Convert.ToInt32((sender as Slider).Value).ToString();
        }

    }
}
