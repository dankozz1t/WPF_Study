using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Study
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

          
            //Button button = new Button();
            //button.Width = 100;
            //button.Height = 50;
            //button.Content = "Exit";
            //button.Background = Brushes.DarkSlateGray;
            //myWPF.Children.Add(button);
            //button.Click += btm1_Click;


            //ListBox1.Items.Add(new Student
            //{
            //    Name ="Алекс-Тейлор", 
            //    Bd = new DateTime(2003, 02, 12)
            //});

            //ListBox1.Items.Add(new Student
            //{
            //    Name = "Марк",
            //    Bd = new DateTime(2002, 08, 20)
            //});

            //List<Student> students = new List<Student>
            //{
            //    new Student { Name = "Alex", Bd = new DateTime(2003, 02, 12), Group = "P011"},
            //    new Student { Name = "MArk", Bd = new DateTime(2002, 06, 20), Group="P213" },
            //    new Student { Name = "Vlad", Bd = new DateTime(2000, 12, 6), Group="0007" }

            //};
            //dg1.ItemsSource = students;

        }


        private void btm1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELLO!!!");
        }


        //private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MessageBox.Show(ListBox1.SelectedItem.ToString());
        //}

        //private void b2_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    p1.IsOpen = true;
        //}


        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem tree = (TreeViewItem)sender;
            string[] vs = Directory.GetFiles(".");
            foreach (var item in vs)
            {
                tree.Items.Add(item);
            }
        }

        //private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        //{
        //    media.Source = new Uri(@"G:\ГЗагрузки\Intro2.avi");
        //}

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "sender: " + sender.ToString() + "\n";
            txt.Text += "source: " + e.Source.ToString() + "\n";
        }

    }


    public class Student
    {
        public string Name { get; set; }
        public DateTime Bd { get; set; } = DateTime.Now;

        public string Group { get; set; }


        public override string ToString()
        {
            return $"{Name} | {Bd.ToShortDateString()}";
        }
    }
}
