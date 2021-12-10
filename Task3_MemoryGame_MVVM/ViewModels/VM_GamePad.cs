using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Task3_MemoryGame_MVVM.Annotations;
using Task3_MemoryGame_MVVM.Data;
using Task3_MemoryGame_MVVM.GameElements;

namespace Task3_MemoryGame_MVVM.ViewModels
{
    public class VM_GamePad : INotifyPropertyChanged
    {
        public Card openCard { get; set; } = null;

        public int Rows { get; set; } = 5;
        public int Cols { get; set; } = 8;

        public int[,] Cards { get; set; }

        private void BuildGamePad()
        {
            Cards = new int[Rows, Cols];
            Random rnd = new Random();

            bool isPair = true;
            int curCard = 0;

            List<Entities.Image> lst = DBContext.getInstance().Images;

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (isPair)
                    {
                        curCard = rnd.Next(lst.Count - 1) + 1;
                        isPair = true;
                    }

                    Cards[r, c] = curCard;
                    isPair = !isPair;
                }
            }

            for (int toRand = 0; toRand < Rows * Cols; toRand++)
            {
                int r1 = rnd.Next(Rows); int r2 = rnd.Next(Rows);
                int c1 = rnd.Next(Cols); int c2 = rnd.Next(Cols);
                (Cards[r1, c1], Cards[r2, c2]) = (Cards[r2, c2], Cards[r1, c1]);
            }

        }

        public VM_GamePad()
        {
            BuildGamePad();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}