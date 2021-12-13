using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MemoryGame.Annotations;
using MemoryGame.Data;

namespace MemoryGame.Views.GameElements
{
    public class Card : Button, INotifyPropertyChanged
    {
        public int CardIndex { get; set; }

        private bool isOpen;
        public bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;
                Update();
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        private void Update()
        {
            if (isOpen)
            {
                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(DataBaseContext.GetInstance().Images[CardIndex].FileName, UriKind.Relative)),
                    Margin = new Thickness(15)
                };

                Content = img;
            }
            else
            {
                Content = null;
            }
        }

        public Card(int cardIndex) : base() => CardIndex = cardIndex;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}