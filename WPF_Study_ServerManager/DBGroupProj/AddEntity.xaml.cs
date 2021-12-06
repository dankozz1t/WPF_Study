using System.Windows;

namespace WPF_Study_ServerManager.DBGroupProj.DataBase
{
    /// <summary>
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddEntity : Window
    {
        public string FirstName { get => StudentFirstName.Text; set => StudentFirstName.Text = value; }
        public string SecondName { get => StudentSecondName.Text; set => StudentSecondName.Text = value; }
        public string BonusField { get =>StudentBonusField.Text; set => StudentBonusField.Text = value; }

        public string BonusEntityText { set => BonusTextBlock.Text = value; }

        public AddEntity()
        {
            InitializeComponent();
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
