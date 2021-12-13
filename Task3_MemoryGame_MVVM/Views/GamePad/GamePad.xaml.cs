using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MemoryGame.Entities;
using MemoryGame.ViewModels;
using MemoryGame.Views.GameElements;

namespace MemoryGame.Views.GamePad
{
    /// <summary>
    /// Логика взаимодействия для GamePad.xaml
    /// </summary>
    public partial class GamePad : Window
    {
        private int _attempts = 1;
        private readonly Label _timerLabel = new Label();

        public GamePad(int rows, int cols)
        {
            InitializeComponent();

            DataContext = new MemoryGame.ViewModels.VMGamePad(rows, cols);

            TimerStart();
            BuildGamePad();
        }

        #region Timer

        private readonly DispatcherTimer _dt = new DispatcherTimer();
        private readonly Stopwatch _sw = new Stopwatch();
        private string _currentTime = string.Empty;

        private void TimerStart()
        {
            _dt.Tick += new EventHandler(timer_Tick);
            _dt.Interval = new TimeSpan(0, 0, 0, 1);

            _sw.Start();
            _dt.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_sw.IsRunning)
            {
                TimeSpan ts = _sw.Elapsed;
                _currentTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                _timerLabel.Content = _currentTime;
            }
        }

        #endregion

        #region BuildZone

        private void BuildGamePad()
        {
            this.Background = new SolidColorBrush(Colors.RosyBrown);
            Grid mainGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            if (DataContext is VMGamePad viewGamePad)
            {
                RowDefinition topPanel = new RowDefinition { Height = new GridLength(60) };
                mainGrid.RowDefinitions.Add(topPanel);

                BuildTopTimerPanel(mainGrid, viewGamePad);

                for (int row = 0; row < viewGamePad.Rows; row++)
                {
                    mainGrid.RowDefinitions.Add(new RowDefinition());
                }

                for (int column = 0; column < viewGamePad.Columns; column++)
                {
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                for (int row = 0; row < viewGamePad.Rows; row++)
                {
                    for (int column = 0; column < viewGamePad.Columns; column++)
                    {
                        Card card = new Card(viewGamePad.Cards[row, column]);

                        card.Click += (sender, args) =>
                        {
                            (sender as Card).IsOpen = true;

                            if (viewGamePad.OpenCard == null) //Если открытой карты нет
                            {
                                viewGamePad.OpenCard = (sender as Card);
                            }
                            else
                            {
                                if (viewGamePad.OpenCard.CardIndex == (sender as Card).CardIndex) //Если открытые карты совпадают
                                {
                                    if (viewGamePad.OpenCard == (sender as Card)) //Если дабл клик по одной карте
                                        return;

                                    AutoClosingMessageBox.Show("Отличная работа!", "ПОПАЛ!", 400);

                                    mainGrid.Children.Remove((sender as UIElement));
                                    mainGrid.Children.Remove((viewGamePad.OpenCard as UIElement));

                                    if (mainGrid.Children.Count == 1) //Если больше карт на панели нет
                                    {
                                        _sw.Stop();
                                        BuildVictoryPanel();
                                    }
                                }
                                else
                                {
                                    AutoClosingMessageBox.Show("Попробуй еще!", "МИМО!", 400);

                                    (sender as Card).IsOpen = false;
                                    (DataContext as VMGamePad).OpenCard.IsOpen = false;
                                }

                                viewGamePad.OpenCard = null;
                                _attempts++;
                            }
                        };
                        Grid.SetColumn(card, column);
                        Grid.SetRow(card, row + 1);

                        mainGrid.Children.Add(card);
                    }
                }
            }
            this.Content = mainGrid;
        }

        private void BuildTopTimerPanel(Grid mainGrid, VMGamePad gamePad)
        {
            Grid topTimePanel = new Grid();
            topTimePanel.Background = new SolidColorBrush(Colors.RosyBrown);

            _timerLabel.FontSize = 40;
            _timerLabel.HorizontalAlignment = HorizontalAlignment.Center;
            _timerLabel.VerticalAlignment = VerticalAlignment.Center;
            _timerLabel.Content = "00:00";

            topTimePanel.Children.Add(_timerLabel);

            mainGrid.Children.Add(topTimePanel);
            Grid.SetRow(topTimePanel, 0);
            Grid.SetColumnSpan(topTimePanel, gamePad.Columns);
        }

        private void BuildVictoryPanel()
        {
            this.Background = new SolidColorBrush(Colors.RosyBrown);

            Grid gtidVictory = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 300,
                Width = 290,
                Background = new SolidColorBrush(Colors.PeachPuff)
            };

            RowDefinition rowsDefinition1 = new RowDefinition { Height = new GridLength(50) };
            gtidVictory.RowDefinitions.Add(rowsDefinition1);
            gtidVictory.RowDefinitions.Add(new RowDefinition());
            gtidVictory.RowDefinitions.Add(new RowDefinition());

            RowDefinition rowsDefinition4 = new RowDefinition { Height = GridLength.Auto };
            gtidVictory.RowDefinitions.Add(rowsDefinition4);

            TextBlock topTextVictory = new TextBlock
            {
                Text = "ПОБЕДА!",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 30,
                FontWeight = FontWeights.Bold
            };
            gtidVictory.Children.Add(topTextVictory);
            Grid.SetRow(topTextVictory, 0);

            TextBlock textCountAttempts = new TextBlock
            {
                Text = "Количество попыток:",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };

            TextBlock textAttempts = new TextBlock
            {
                Text = _attempts.ToString(),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };

            StackPanel stackForAttempts = new StackPanel();
            stackForAttempts.Children.Add(textCountAttempts);
            stackForAttempts.Children.Add(textAttempts);

            gtidVictory.Children.Add(stackForAttempts);
            Grid.SetRow(stackForAttempts, 1);

            TextBlock textCountTime = new TextBlock
            {
                Text = "Количество времени:",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };

            _attempts++;
            TextBlock textTime = new TextBlock
            {
                Text = _currentTime,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };

            StackPanel stackForTime = new StackPanel();
            stackForTime.Children.Add(textCountTime);
            stackForTime.Children.Add(textTime);

            gtidVictory.Children.Add(stackForTime);
            Grid.SetRow(stackForTime, 2);

            Button buttonBack = new Button
            {
                Content = "НАЗАД"
            };
            gtidVictory.Children.Add(buttonBack);
            Grid.SetRow(buttonBack, 3);

            buttonBack.Click += (sender2, args2) =>
            {
                GlobalMenu globalMenu = new GlobalMenu();
                globalMenu.Show();
                this.Close();
            };

            this.Content = gtidVictory;
        }

        #endregion

    }
}