using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MemoryGame.Annotations;
using MemoryGame.Data;
using MemoryGame.Views.GameElements;

namespace Task3_MemoryGame_MVVM.ViewModels
{
    public class VMGamePad : INotifyPropertyChanged
    {
        public Card OpenCard { get; set; } = null;

        public int Rows { get; set; }
        public int Columns { get; set; }

        public int[,] Cards { get; set; }

        private static readonly Random Random = new Random();

        public VMGamePad(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            BuildGamePad();
        }

        private void BuildGamePad()
        {
            Cards = new int[Rows, Columns];
            
            bool isPair = true;
            int indexCurrentCard = 0;

            List<MemoryGame.Entities.Image> images = DataBaseContext.GetInstance().Images;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (isPair)
                    {
                        indexCurrentCard = Random.Next(images.Count - 1) + 1;
                        isPair = true;
                    }

                    Cards[row, column] = indexCurrentCard;
                    isPair = !isPair;
                }
            }

            RandomMovedCards();
        }

        private void RandomMovedCards()
        {
            for (int i = 0; i < Rows * Columns; i++) //Перемешивает карточки
            {
                int rowR1 = Random.Next(Rows); int rowR2 = Random.Next(Rows);
                int columnR1 = Random.Next(Columns); int columnR2 = Random.Next(Columns);
                (Cards[rowR1, columnR1], Cards[rowR2, columnR2]) = (Cards[rowR2, columnR2], Cards[rowR1, columnR1]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}