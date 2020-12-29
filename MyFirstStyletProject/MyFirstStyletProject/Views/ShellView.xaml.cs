using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MyFirstStyletProject.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            
            //Set Build Action as Resource
            Icon = new BitmapImage(new Uri(@"pack://application:,,,/Resources/icon.png"));
        }
    }
}
