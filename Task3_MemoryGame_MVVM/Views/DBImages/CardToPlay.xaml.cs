using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Task3_MemoryGame_MVVM.Data;

namespace Task3_MemoryGame_MVVM.Views.DBImages
{
    /// <summary>
    /// Логика взаимодействия для CardToPlay.xaml
    /// </summary>
    public partial class CardToPlay : Window
    {
        public CardToPlay()
        {
            InitializeComponent();
            DataContext = DBContext.getInstance();
        }
    }
}
