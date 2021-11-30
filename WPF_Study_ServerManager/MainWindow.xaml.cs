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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Study_ServerManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void themeDark_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary themeDictionary = new ResourceDictionary();
            themeDictionary.Source = new Uri("DarkTheme.xaml", UriKind.Relative);
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
        }

        private void themeLight_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary themeDictionary = new ResourceDictionary();
            themeDictionary.Source = new Uri("LightTheme.xaml", UriKind.Relative);
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
        }
    }
}
