using System.Collections.Generic;
using Task3_MemoryGame_MVVM.Entities;

namespace Task3_MemoryGame_MVVM.Data
{
    public class DBContext
    {
    
        private static DBContext _instance;
        private DBContext() { Seed(); }
        public static DBContext getInstance() => _instance ?? (_instance = new DBContext());

        public List<Image> Images { get; set; }

        public void Seed()
        {
            Images = new List<Image>
            {
                new Image{FileName = @""}, //Пустая карта

                //new Image{FileName = @"C:\Users\alexd\source\repos\WPF_Study\Task3_MemoryGame_MVVM\Resources\Image\crown-3-256.png"},
                //new Image{FileName = @"C:\Users\alexd\source\repos\WPF_Study\Task3_MemoryGame_MVVM\Resources\Image\discord-2-256.png"},
                //new Image{FileName = @"C:\Users\alexd\source\repos\WPF_Study\Task3_MemoryGame_MVVM\Resources\Image\hot-chocolate-256.png"},
                //new Image{FileName = @"C:\Users\alexd\source\repos\WPF_Study\Task3_MemoryGame_MVVM\Resources\Image\puzzle-4-256.png"},
                //new Image{FileName = @"C:\Users\alexd\source\repos\WPF_Study\Task3_MemoryGame_MVVM\Resources\Image\radioactive-256.png"}

                //new Image{FileName = @"..\..\Resources\Image\crown-3-256.png"},
                //new Image{FileName = @"..\..\Resources\Image\discord-2-256.png"},
                //new Image{FileName = @"..\..\Resources\Image\hot-chocolate-256.png"},
                //new Image{FileName = @"..\..\Resources\Image\puzzle-4-256.png"},
                //new Image{FileName = @"..\..\Resources\Image\radioactive-256.png"}
            };
        }
    }
}