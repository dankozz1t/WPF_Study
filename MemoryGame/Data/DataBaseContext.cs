using System.Collections.Generic;
using MemoryGame.Entities;

namespace MemoryGame.Data
{
    /// <summary>
    ///  Единственная база данных изображений
    /// </summary>
    public class DataBaseContext
    {
        private static DataBaseContext _instance;
        public static DataBaseContext GetInstance() => _instance ?? (_instance = new DataBaseContext());

        public List<Image> Images { get; set; }

        public DataBaseContext()
        {
            Images = new List<Image>
            {
                new Image{FileName = @""}, //Пустая карта
            };
        }
    }
}