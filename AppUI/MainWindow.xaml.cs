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
            List<string> lst1 = new List<string>();
            lst1 = SqliteDataAccess.RerurnTaskHeadersListGeneral("TaskSetName", "TasksSet");
            lst = SqliteDataAccess.RerurnTaskHeadersList();
            foreach (string s in lst)
            {
                ComboBox1.Items.Add(s);
            }
            foreach (string s in lst1)
            {
                //ComboBox2.Items.Add(s);
            }
        }

        void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();

        }
        private void TaskListTitle_Click(object sender, RoutedEventArgs e)
        {
            
            //Tasks.ItemsSource = SqliteDataAccess.LoadTasks().DefaultView;
        }
        private void TaskListHeader_Click(object sender, RoutedEventArgs e)
        {

            //Tasks.ItemsSource = SqliteDataAccess.LoadMainTasks().DefaultView;
        }
        private void TaskListDropdown_Click(object sender, RoutedEventArgs e)
        {
            //Tasks.ItemsSource = SqliteDataAccess.LoadMainTasks().DefaultView;
        }   
        
        private void ComboBox_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(ComboBox1.SelectedItem.ToString());
            //int selectedIndex = ComboBox1.SelectedIndex;

            Object selectedItem = ComboBox1.SelectedItem;
            string row = selectedItem.ToString();
            DataTable datatable = new DataTable();
            datatable = SqliteDataAccess.DisplaySelectedRow(row);

            Lista.DataContext = datatable.DefaultView;
        } 

        /*private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {           
            int selectedIndex = ComboBox1.SelectedIndex;
            Object selectedItem = ComboBox1.SelectedItem;
            string row = selectedItem.ToString();
            DataTable datatable = new DataTable();
            datatable = SqliteDataAccess.DisplaySelectedRow(row);
        }*/

        /*private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            //get selected object from combobox-dropdownmen
            //Object selectedItem = ComboBox2.SelectedItem;
            //get selected row to string
            /**if (selectedItem.ToString() == null)
            {

            }
            else
            {
                string TaskSetName = selectedItem.ToString();
                //build new datatable
                DataTable datatable = new DataTable();
                //load datadable with data from method
                datatable = SqliteDataAccess.DisplaySelectedRow(TaskSetName);
                //build class object
                TaskSet set1 = new TaskSet();
                //Import to it data from class method
                set1 = SqliteDataAccess.SelectedRowToTaskSetModel("*", "TasksSet", "TaskSetName", TaskSetName);
                //Null the list to avoid stacking.
                TaskLst.ItemsSource = null;
                //Display Id prop from the Object
                TaskLst.Items.Add(set1.TaskSetName);
                //Null datagridview
                Tasks.ItemsSource = null;
                //import querry results to dgv
                Tasks.ItemsSource = datatable.DefaultView;
        }
        }*/

        private void Lista_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {
            DataTable datatable = new DataTable();

            foreach (DataRowView drv in Lista.SelectedItems)
            {
                DataRow row = drv.Row;
                string item = row.ItemArray[0].ToString();
                
                datatable = SqliteDataAccess.DisplayTaskDescriptions(item);
            }

            DetailsList.DataContext = datatable.DefaultView;
        }

    }
}
