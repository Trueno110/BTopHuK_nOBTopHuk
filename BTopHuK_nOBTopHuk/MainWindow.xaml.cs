using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
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
        int UserID = 1;
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ToDoList; Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
            conn.Open();
        }
        public Grid Grepg(String IdIcons, String Name)
        {
            Grid Grepg = new Grid();

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(4, GridUnitType.Star);

            Grepg.ColumnDefinitions.Add(col1);
            Grepg.ColumnDefinitions.Add(col2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/images/icons/" + IdIcons + ".png", UriKind.Relative));
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Height = 40;
            image.Width = 40;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = Name;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Top;
            textBlock.SetValue(Grid.ColumnProperty, 1);
            textBlock.FontSize = 20;

            Grepg.Children.Add(image);
            Grepg.Children.Add(textBlock);
            return Grepg;
        }

        private void Addor_Click(object sender, RoutedEventArgs e)
        {
            Razdel razdel = new Razdel();
            ChoiseToAdd choiseToAdd = new ChoiseToAdd(razdel);
            choiseToAdd.ShowDialog();
            List_Rasdlov.Items.Add(Grepg(razdel.IdIcon,razdel.Name));
            SqlCommand sqlCommand = new SqlCommand($"insert into Section values({UserID},'{razdel.Name}',{razdel.IdIcon},2);", conn);
            sqlCommand.ExecuteNonQuery();
        }

        private void List_Rasdlov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stac.Children.Clear();
            Stac.Children.Add(new Button() { Content = "Добавить" });
            string aw = ((TextBlock)((Grid)List_Rasdlov.SelectedItem).Children[1]).Text;
            SqlCommand sqlCommand = new SqlCommand($"Select description from Cases where Status = (Select Id from Section where Name = '{aw}')",conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            while (reader.Read())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = reader[0];
                checkBox.FontSize = 15;
                Stac.Children.Add(checkBox);

            }
            reader.Close();
        
        
        }
        private void Button_Click2(object sender, RoutedEventArgs e) 
        {
            AddCheckBox addCheckBox = new AddCheckBox();
            addCheckBox.ShowDialog();

        }
    }
}
