using System;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Task3_MemoryGame_MVVM.Data;
using Task3_MemoryGame_MVVM.GameElements;
using Task3_MemoryGame_MVVM.ViewModels;

namespace Task3_MemoryGame_MVVM.Views.GamePad
{
    /// <summary>
    /// Логика взаимодействия для GamePad.xaml
    /// </summary>
    public partial class GamePad : Window
    {
        public GamePad()
        {
            InitializeComponent();
            DataContext = new ViewModels.VM_GamePad();
            CreateGamePad();
        }


        private void CreateGamePad()
        {
            Grid myGrid = new Grid();

            myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            myGrid.VerticalAlignment = VerticalAlignment.Stretch;

            myGrid.ShowGridLines = true;

            for (int r = 0; r < ((VM_GamePad)DataContext).Rows; r++)
            {
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);
            }

            for (int c = 0; c < ((VM_GamePad)DataContext).Cols; c++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef);
            }

            for (int r = 0; r < ((VM_GamePad)DataContext).Rows; r++)
            {
                for (int c = 0; c < ((VM_GamePad)DataContext).Cols; c++)
                {
                    Card card = new Card(((VM_GamePad)DataContext).Cards[r, c]);

                    card.Click += (sender, args) =>
                    {
                        if (((VM_GamePad)DataContext).openCard == null)
                        {
                            ((VM_GamePad)DataContext).openCard = (sender as Card);
                        }
                        else
                        {
                            if (((VM_GamePad)DataContext).openCard.CardIndex == ((Card)sender).CardIndex)
                            {
                                MessageBox.Show("Правильно! Отличная работа!");
                                myGrid.Children.Remove((UIElement)sender);
                                myGrid.Children.Remove(((VM_GamePad)DataContext).openCard);
                            }
                            else
                            {
                                MessageBox.Show("Неправильно");
                            }

                            ((VM_GamePad)DataContext).openCard = null;

                        }
                          
                    };

                    Grid.SetColumn(card, c);
                    Grid.SetRow(card, r);

                    myGrid.Children.Add(card);
                }
            }

            this.Content = myGrid;
        }
    }
}
