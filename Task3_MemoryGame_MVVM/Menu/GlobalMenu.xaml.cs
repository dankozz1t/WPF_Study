using System;
using System.Windows;
using System.Windows.Controls;
using MemoryGame.Data;
using MemoryGame.Views.GamePad;

namespace MemoryGame
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

        #region Button

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            if (DataBaseContext.GetInstance().Images.Count > 1)
            {
                int rows = Convert.ToInt32(RowsTextBlock.Text);
                int columns = Convert.ToInt32(ColumnsTextBlock.Text);

                while (rows * columns % 2 != 0) //Eсли сумма поля нечетная
                {
                    if ((columns + 1 * rows) % 2 == 0)
                        columns++;
                    else rows++;
                }

                GamePad play = new GamePad(rows, columns);

                this.Hide();
                play.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите картинки", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region SliderColumnsRows

        private void Slider_Columns_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColumnsTextBlock.Text = Convert.ToInt32((sender as Slider).Value).ToString();
        }

        private void Slider_Rows_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RowsTextBlock.Text = Convert.ToInt32((sender as Slider).Value).ToString();
        }

        #endregion

        private void CheckBox_Image_Checked(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\Resources\Images\" + (sender as CheckBox).Name + ".png";

            DataBaseContext.GetInstance().Images.Add(new Entities.Image() { FileName = path });
        }
    }
}
