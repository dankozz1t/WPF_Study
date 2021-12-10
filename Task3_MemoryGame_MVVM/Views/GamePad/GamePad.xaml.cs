using System;
using System.Windows;
using System.Windows.Controls;
using Task3_MemoryGame_MVVM.GameElements;
using Task3_MemoryGame_MVVM.ViewModels;

namespace Task3_MemoryGame_MVVM.Views.GamePad
{
    /// <summary>
    /// Логика взаимодействия для GamePad.xaml
    /// </summary>
    public partial class GamePad : Window
    {
        public GamePad(int rows, int cols)
        {
            InitializeComponent();

            DataContext = new ViewModels.VM_GamePad(rows, cols);
            CreateGamePad();
        }


        private void CreateGamePad()
        {
            Grid myGrid = new Grid();

            myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            myGrid.VerticalAlignment = VerticalAlignment.Stretch;

            myGrid.ShowGridLines = true;

            if (DataContext is VM_GamePad viewGamePad)
            {
                for (int r = 0; r < viewGamePad.Rows; r++)
                {
                    RowDefinition rowDef = new RowDefinition();
                    myGrid.RowDefinitions.Add(rowDef);
                }

                for (int c = 0; c < viewGamePad.Cols; c++)
                {
                    ColumnDefinition colDef = new ColumnDefinition();
                    myGrid.ColumnDefinitions.Add(colDef);
                }

                for (int row = 0; row < viewGamePad.Rows; row++)
                {
                    for (int column = 0; column < viewGamePad.Cols; column++)
                    {
                        Card card = new Card(viewGamePad.Cards[row, column]);

                        card.Click += (sender, args) =>
                        {
                            (sender as Card).IsOpen = true;

                            if (viewGamePad.openCard == null)
                            {
                                viewGamePad.openCard = (sender as Card);
                            }
                            else
                            {
                                if (viewGamePad.openCard.CardIndex == (sender as Card).CardIndex)
                                {
                                    MessageBox.Show("Good memory");
                                    myGrid.Children.Remove((sender as UIElement));
                                    myGrid.Children.Remove((viewGamePad.openCard as UIElement));
                                }
                                else
                                {
                                    MessageBox.Show("Bed");
                                    (sender as Card).IsOpen = false;
                                    (DataContext as VM_GamePad).openCard.IsOpen = false;
                                }

                                viewGamePad.openCard = null;
                            }
                        };

                        Grid.SetColumn(card, column);
                        Grid.SetRow(card, row);

                        myGrid.Children.Add(card);
                    }
                }
            }
            this.Content = myGrid;
        }
    }
}
