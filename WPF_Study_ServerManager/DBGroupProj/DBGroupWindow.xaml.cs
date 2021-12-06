using System;
using System.Windows;
using System.Windows.Controls;
using WPF_Study_ServerManager.DBGroupProj.DataBase;
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
            DBContext.getInstance().Load();

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
            this.Close();
        }

        private void MenuItem_Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить базу данных?", "Удалить базу данных",
                MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                DBContext.getInstance().Groups.Clear();
                DBContext.getInstance().Clear();
            }
        }

        #endregion

        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsListBox.SelectedItem == null)
            {
                groupDetails.DataContext = new Group();
                return;
            }
            groupDetails.DataContext = GroupsListBox.SelectedItem;
        }

        private void DataUpdate()
        {
            DBContext.getInstance().Clear();
            DBContext.getInstance().Save();
            DBContext.getInstance().Load();
            DataContext = DBContext.getInstance().Groups;
            this.groupDetails.DataContext = new Group();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

            Group group = new Group() { Name = "Новая группа" };
          
            DBContext.getInstance().Groups.Add(group);
            DataUpdate();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsListBox.SelectedItem != null)
            {
                DBContext.getInstance().Groups.RemoveAt(GroupsListBox.SelectedIndex);
                DataUpdate();
            }
        }

        private void Button_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsListBox.SelectedItem != null)
            {
                AddEntity addStudent = new AddEntity();
                addStudent.Title = "Добавление студента";
                addStudent.BonusEntityText = "Успеваемость:";

                if (addStudent.ShowDialog() == true)
                {
                    Student student = new Student() { FirstName = addStudent.FirstName, SecondName = addStudent.SecondName, Progress = Int32.Parse(addStudent.BonusField) };

                    DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students.Add(student);

                    DataUpdate();
                }
            }
        }

        private void Button_DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (groupDetails.ListBox.SelectedItem != null)
            {
                DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students.RemoveAt(groupDetails.ListBox.SelectedIndex);
                DataUpdate();
            }
        }

        private void Button_Teacher_Click(object sender, RoutedEventArgs e)
        {
            if (GroupsListBox.SelectedItem != null)
            {
                AddEntity addTeacher = new AddEntity();
                addTeacher.Title = "Добавление преподавателя";
                addTeacher.BonusEntityText = "Предмет:";

                if (DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Teacher != null)
                {
                    addTeacher.FirstName = DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Teacher.FirstName;
                    addTeacher.SecondName = DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Teacher.SecondName;
                    addTeacher.BonusField = DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Teacher.Item;
                }

                if (addTeacher.ShowDialog() == true)
                {
                    Teacher teacher = new Teacher()
                    {
                        FirstName = addTeacher.FirstName,
                        SecondName = addTeacher.SecondName,
                        Item = addTeacher.BonusField
                    };

                    DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Teacher = teacher;

                    DataUpdate();
                }
            }
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            if (groupDetails.ListBox.SelectedItem != null)
            {
                AddEntity addStudent = new AddEntity();
                addStudent.Title = "Добавление студента";
                addStudent.BonusEntityText = "Успеваемость:";

                var StudentNow = groupDetails.ListBox.SelectedIndex;
                if (DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students[StudentNow] != null)
                {
                    addStudent.FirstName = DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students[StudentNow].FirstName;
                    addStudent.SecondName = DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students[StudentNow].SecondName;
                    addStudent.BonusField = DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students[StudentNow].Progress.ToString();
                }

                if (addStudent.ShowDialog() == true)
                {
                    Student student = new Student()
                    {
                        FirstName = addStudent.FirstName,
                        SecondName = addStudent.SecondName,
                        Progress = Int32.Parse(addStudent.BonusField)
                    };

                    DBContext.getInstance().Groups[GroupsListBox.SelectedIndex].Students.Add(student);

                    DataUpdate();
                }
            }

        }
    }

}
