﻿using System;
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



        }


        private void btm1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELLO!!!");
        }

        public class Student
        {
            public string Name { get; set; }
            public DateTime Bd { get; set; }


            public override string ToString()
            {
                return $"{Name} | {Bd.ToShortDateString()}";
            }
        }
    }
}