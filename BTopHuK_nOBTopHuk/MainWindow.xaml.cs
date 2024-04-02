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

namespace BTopHuK_nOBTopHuk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List_Rasdlov.Items.Add(Grepg());
            List_Rasdlov.Items.Add(Grepg());
            List_Rasdlov.Items.Add(Grepg());
        }
        public Grid Grepg()
        {
            Grid Grepg = new Grid();
            Grepg.Height = 133;
            Grepg.Width = 216;

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(4, GridUnitType.Star);

            Grepg.ColumnDefinitions.Add(col1);
            Grepg.ColumnDefinitions.Add(col2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/images/icons/2.png", UriKind.Relative));
 

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "моя заметка";
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Top;
 
            Grid.SetColumn(textBlock, 1);

            Grepg.Children.Add(image);
            Grepg.Children.Add(textBlock);
            return Grepg;
        }
    }
}
