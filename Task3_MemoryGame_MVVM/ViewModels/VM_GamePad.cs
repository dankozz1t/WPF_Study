using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task3_MemoryGame_MVVM.Annotations;
using Task3_MemoryGame_MVVM.Data;
using Task3_MemoryGame_MVVM.GameElements;

namespace Task3_MemoryGame_MVVM.ViewModels
{
    public class VM_GamePad : INotifyPropertyChanged
    {
        public Card openCard { get; set; } = null;

        public int Rows { get; set; }
        public int Cols { get; set; }

        public int[,] Cards { get; set; }

        private void BuildGamePad()
        {
            Cards = new int[Rows, Cols];
            Random random = new Random();

            bool isPair = true;
            int curCard = 0;

            List<Entities.Image> images = DBContext.getInstance().Images;

            for (int row = 0; row < Rows; row++)
            {
                for (int colomn = 0; colomn < Cols; colomn++)
                {
                    if (isPair)
                    {
                        curCard = random.Next(images.Count - 1) + 1;
                        isPair = true;
                    }

                    Cards[row, colomn] = curCard;
                    isPair = !isPair;
                }
            }

            for (int i = 0; i < Rows * Cols; i++) //Перемешивает карточки
            {
                int r1 = random.Next(Rows); int r2 = random.Next(Rows);
                int c1 = random.Next(Cols); int c2 = random.Next(Cols);
                (Cards[r1, c1], Cards[r2, c2]) = (Cards[r2, c2], Cards[r1, c1]);
            }
        }

        public VM_GamePad(int rows, int columns)
        {
            Rows = rows;
            Cols = columns;
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