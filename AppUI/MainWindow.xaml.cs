using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Speech.Synthesis;
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

        public static SpeechSynthesizer synth = new SpeechSynthesizer();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
           
    }
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> mealsList = new List<string>();

            mealsList = SqliteDataAccess.RerurnTaskHeadersList();

            foreach (string s in mealsList)
            {
                MealsSelect.Items.Add(s);
            }
            
        }
        
        private void MealsSelect_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {
            Object selectedItem = MealsSelect.SelectedItem;
            string row = selectedItem.ToString();
            DataTable datatable = new DataTable();
            datatable = SqliteDataAccess.DisplaySelectedRow(row);

            MealTaskList.DataContext = datatable.DefaultView;
        } 

        private async void MealTaskList_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {

            DataTable datatable = new DataTable();

            foreach (DataRowView drv in MealTaskList.SelectedItems)
            {
                DataRow row = drv.Row;
                string item = row.ItemArray[0].ToString();
                
                datatable = SqliteDataAccess.DisplayTaskDescriptions(item);
            }

            string read = SqliteDataAccess.convertDataTableToString(datatable);

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            
            //synth.SpeakAsyncCancelAll();


            Prompt prompt = new Prompt(read);

            await Task.Run(() =>  synth.SpeakAsync(prompt)); 

            MealDetailTaskList.DataContext = datatable.DefaultView;
         }


    }
}
