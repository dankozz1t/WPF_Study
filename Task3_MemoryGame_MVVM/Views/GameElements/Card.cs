using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Task3_MemoryGame_MVVM.Data;
using Task3_MemoryGame_MVVM.ViewModels;

namespace Task3_MemoryGame_MVVM.GameElements
{
    public class Card : Button
    {
        public int CardIndex { get; set; } = 0;
        public bool isOpen { get; set; } = false;

        public Card(int CardIndex):base()
        {
            this.CardIndex = CardIndex;

            Image img = new Image();
            img.Source = new BitmapImage(new Uri(DBContext.getInstance().Images[CardIndex].FileName));
            img.Margin = new Thickness(15);

            this.Content = img;

        }
    }
}