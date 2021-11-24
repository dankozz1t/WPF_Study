using System;
using System.Collections.Generic;
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

    }


    public class Student
    {
        public string Name { get; set; }
        public DateTime Bd { get; set; } = DateTime.Now;


        public override string ToString()
        {
            return $"{Name} | {Bd.ToShortDateString()}";
        }
    }
}
