using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Task3_MemoryGame_MVVM.Entities;
using Task3_MemoryGame_MVVM.GameElements;
using Task3_MemoryGame_MVVM.ViewModels;
using System.Windows.Threading;

namespace Task3_MemoryGame_MVVM.Views.GamePad
{
    /// <summary>
    /// Логика взаимодействия для GamePad.xaml
    /// </summary>
    public partial class GamePad : Window
    {
        private int attempts = 0;

        private Label timerLabel = new Label();

        private DispatcherTimer dt = new DispatcherTimer();
        private Stopwatch sw = new Stopwatch();
        private string currentTime = string.Empty;

        public GamePad(int rows, int cols)
        {
            InitializeComponent();

            DataContext = new ViewModels.VM_GamePad(rows, cols);
            CreateGamePad();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                timerLabel.Content = currentTime;
            }
        }

        private void CreateGamePad()
        {
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 1);

            sw.Start();
            dt.Start();

            Grid myGrid = new Grid();
            myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            myGrid.VerticalAlignment = VerticalAlignment.Stretch;

            //myGrid.ShowGridLines = true;

            if (DataContext is VM_GamePad viewGamePad)
            {
                RowDefinition topPanel = new RowDefinition();
                topPanel.Height = new GridLength(60);
                myGrid.RowDefinitions.Add(topPanel);

                Grid topTimePanel = new Grid();
                topTimePanel.Background = new SolidColorBrush(Colors.RosyBrown);

                timerLabel.FontSize = 40;
                timerLabel.HorizontalAlignment = HorizontalAlignment.Center;
                timerLabel.VerticalAlignment = VerticalAlignment.Center;
                timerLabel.Content = "00:00";

                topTimePanel.Children.Add(timerLabel);

                myGrid.Children.Add(topTimePanel);
                Grid.SetRow(topTimePanel, 0);
                Grid.SetColumnSpan(topTimePanel, 2);

                for (int r = 0; r < viewGamePad.Rows; r++)
                {
                    myGrid.RowDefinitions.Add(new RowDefinition());
                }

                for (int c = 0; c < viewGamePad.Cols; c++)
                {
                    myGrid.ColumnDefinitions.Add(new ColumnDefinition());
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
                                    if(viewGamePad.openCard == (sender as Card))
                                        return;

                                    AutoClosingMessageBox.Show("Отличная работа!", "ПОПАЛ!", 400);

                                    myGrid.Children.Remove((sender as UIElement));
                                    myGrid.Children.Remove((viewGamePad.openCard as UIElement));

                                    if (myGrid.Children.Count == 1)
                                    {
                                        //------------------------------------------------------
                                        sw.Stop();

                                        Grid gtidVictory = new Grid();
                                        this.Background = new SolidColorBrush(Colors.RosyBrown);
                                        gtidVictory.HorizontalAlignment = HorizontalAlignment.Center;
                                        gtidVictory.VerticalAlignment = VerticalAlignment.Center;
                                        gtidVictory.Height = 300;
                                        gtidVictory.Width = 290;
                                        gtidVictory.Background = new SolidColorBrush(Colors.PeachPuff);

                                        RowDefinition rowsDefinition1 = new RowDefinition();
                                        rowsDefinition1.Height = new GridLength(50);
                                        gtidVictory.RowDefinitions.Add(rowsDefinition1);
                                        gtidVictory.RowDefinitions.Add(new RowDefinition());
                                        gtidVictory.RowDefinitions.Add(new RowDefinition());
                                        RowDefinition rowsDefinition4 = new RowDefinition();
                                        rowsDefinition4.Height = GridLength.Auto;
                                        gtidVictory.RowDefinitions.Add(rowsDefinition4);

                                        TextBlock topTextVictory = new TextBlock();
                                        topTextVictory.Text = "ПОБЕДА!";
                                        topTextVictory.HorizontalAlignment = HorizontalAlignment.Center;
                                        topTextVictory.FontSize = 30;
                                        topTextVictory.FontWeight = FontWeights.Bold;
                                        gtidVictory.Children.Add(topTextVictory);
                                        Grid.SetRow(topTextVictory, 0);

                                        TextBlock textCountAttempts = new TextBlock();
                                        textCountAttempts.Text = "Количество попыток:";
                                        textCountAttempts.HorizontalAlignment = HorizontalAlignment.Center;
                                        textCountAttempts.FontSize = 20;
                                        textCountAttempts.FontWeight = FontWeights.Bold;

                                        attempts++;
                                        TextBlock textAttempts = new TextBlock();
                                        textAttempts.Text = attempts.ToString();
                                        textAttempts.HorizontalAlignment = HorizontalAlignment.Center;
                                        textAttempts.FontSize = 20;
                                        textAttempts.FontWeight = FontWeights.Bold;

                                        StackPanel stack = new StackPanel();
                                        stack.Children.Add(textCountAttempts);
                                        stack.Children.Add(textAttempts);

                                        gtidVictory.Children.Add(stack);
                                        Grid.SetRow(stack, 1);


                                        TextBlock textCountTime = new TextBlock();
                                        textCountTime.Text = "Количество времени:";
                                        textCountTime.HorizontalAlignment = HorizontalAlignment.Center;
                                        textCountTime.FontSize = 20;
                                        textCountTime.FontWeight = FontWeights.Bold;

                                        attempts++;
                                        TextBlock textTime = new TextBlock();
                                        textTime.Text = currentTime;
                                        textTime.HorizontalAlignment = HorizontalAlignment.Center;
                                        textTime.FontSize = 20;
                                        textTime.FontWeight = FontWeights.Bold;

                                        StackPanel stack2 = new StackPanel();
                                        stack2.Children.Add(textCountTime);
                                        stack2.Children.Add(textTime);

                                        gtidVictory.Children.Add(stack2);
                                        Grid.SetRow(stack2, 2);


                                        Button button = new Button();
                                        button.Content = "НАЗАД";
                                        gtidVictory.Children.Add(button);
                                        Grid.SetRow(button, 3);


                                        button.Click += (sender2, args2) =>
                                        {
                                            GlobalMenu globalMenu = new GlobalMenu();
                                            globalMenu.Show();
                                            this.Close();
                                        };


                                        this.Content = gtidVictory;
                                        //------------------------------------------------------
                                    }
                                }
                                else
                                {
                                    AutoClosingMessageBox.Show("Попробуй еще!", "МИМО!", 400);
                             
                                    (sender as Card).IsOpen = false;
                                    (DataContext as VM_GamePad).openCard.IsOpen = false;
                                }

                                viewGamePad.openCard = null;
                                attempts++;
                            }
                        };

                        Grid.SetColumn(card, column);
                        Grid.SetRow(card, row+1);

                        myGrid.Children.Add(card);
                    }
                }

            }
            this.Content = myGrid;
        }
    }
}
