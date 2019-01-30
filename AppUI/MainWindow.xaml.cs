using System;
using System.Collections.Generic;
using System.Data;
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


using AppLib;

namespace AppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Tasks.ItemsSource = SqliteDataAccess.LoadMainTasks().DefaultView;
            List<string> lst = new List<string>();
            lst = SqliteDataAccess.RerurnTaskHeadersList();
            foreach (string s in lst)
            {
                ComboBox1.Items.Add(s);
            }

        }

        void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();

        }
        private void TaskListTitle_Click(object sender, RoutedEventArgs e)
        {
            
            Tasks.ItemsSource = SqliteDataAccess.LoadTasks().DefaultView;
        }
        private void TaskListHeader_Click(object sender, RoutedEventArgs e)
        {

            Tasks.ItemsSource = SqliteDataAccess.LoadMainTasks().DefaultView;
        }
        private void TaskListDropdown_Click(object sender, RoutedEventArgs e)
        {
            Tasks.ItemsSource = SqliteDataAccess.LoadMainTasks().DefaultView;
        }       
        private void ComboBox_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {            
        } 
        private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {           
            int selectedIndex = ComboBox1.SelectedIndex;
            Object selectedItem = ComboBox1.SelectedItem;
            string row = selectedItem.ToString();
            DataTable datatable = new DataTable();
            datatable = SqliteDataAccess.DisplaySelectedRow(row);           
            Tasks.ItemsSource = null;          
            Tasks.ItemsSource = datatable.DefaultView;
        }
    }
}
