using System.Windows;
using System.Windows.Controls;
using WPF_Study_ServerManager.Entity;

namespace WPF_Study_ServerManager
{
    /// <summary>
    /// Логика взаимодействия для DBGroupWindow.xaml
    /// </summary>
    public partial class DBGroupWindow : Window
    {
        public void Notify(string msg)
        {
            MessageBox.Show(msg);
        }

        public DBGroupWindow()
        {
            DBContext.getInstance().Error += Notify;
            DBContext.getInstance().Notify += Notify;
            //DBContext.getInstance().Load();

            InitializeComponent();
        }

        #region Menu
        private void MenuItem_Seeding_Click(object sender, RoutedEventArgs e)
        {
            DBContext.getInstance().Seed();
        }

        private void MenuItem_Load_Click(object sender, RoutedEventArgs e)
        {
            DBContext.getInstance().Load();
            DataContext = DBContext.getInstance().Groups;
            this.groupDetails.DataContext = new Group();
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            DBContext.getInstance().Save();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            DBContext.getInstance().Save();
            this.Close();
        }

        #endregion

        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Groups.SelectedItem == null)
            {
                groupDetails.DataContext = new Group();
                return;
            }
            groupDetails.DataContext = Groups.SelectedItem;
        }
    }

}
