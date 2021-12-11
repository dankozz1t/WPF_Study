﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Task3_MemoryGame_MVVM.Annotations;
using Task3_MemoryGame_MVVM.Data;

namespace Task3_MemoryGame_MVVM.GameElements
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
                    Source = new BitmapImage(new Uri(DBContext.getInstance().Images[CardIndex].FileName)),
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