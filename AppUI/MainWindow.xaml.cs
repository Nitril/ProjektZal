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
        /// <summary> 
        /// Initialize an instance of all accesible synth
        /// </summary>        
        public static SpeechSynthesizer synth = new SpeechSynthesizer();


        /// <summary> 
        /// Initialize main window and load MainWindow_Loaded event
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            
        }
        /// <summary> 
        /// Initial window loadrf with available list of meals in drop down menu
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> mealsList = new List<string>();

            mealsList = SqliteDataAccess.RerurnTaskHeadersList();

            foreach (string s in mealsList)
            {
                MealsSelect.Items.Add(s);
            }
        }
        /// <summary> 
        /// Event handler which is updating list of available tasks whenever selection from available meals in drop down is changed. It loads proper meal task list to list view.
        /// </summary>
        private void MealsSelect_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {
            Object selectedItem = MealsSelect.SelectedItem;
            string row = selectedItem.ToString();
            DataTable datatable = new DataTable();
            //query database
            datatable = SqliteDataAccess.DisplaySelectedRow(row);
            //display to list view
            MealTaskList.DataContext = datatable.DefaultView;
        }
        /// <summary> 
        /// Event handler which is updating displayed description of selected task whenver listview value selected is changed. It loads proper meals task list to list view.
        /// Event handling also synthesizer function by autoreading whatever is being transfered to the final window.
        /// </summary>
        private async void MealTaskList_SelectionChanged_Click(object sender, SelectionChangedEventArgs e)
        {
            DataTable datatable = new DataTable();

            foreach (DataRowView drv in MealTaskList.SelectedItems)
            {
                DataRow row = drv.Row;
                string item = row.ItemArray[0].ToString();
                //query database to load task descriptions
                datatable = SqliteDataAccess.DisplayTaskDescriptions(item);
            }
            //Prepare the string to be read
            string read = SqliteDataAccess.convertDataTableToString(datatable);

            //Make sure that previous synth tasks are cancelled
            synth.SpeakAsyncCancelAll();

            //As polish speech libraries are implemented externaly, and depend on proper installation so the synth function is adjusted to this situation.
            try
            {
                //Select polish voice
                synth.SelectVoice("Microsoft Paulina Desktop");
            }
            catch (Exception exc)
            {
                //Mask Exception in case "Paulina" voice is missing, to allow text to be spoken with default english.
            }

            ///Technical method for querrying for installed and available system voicess
            //var a = synth.GetInstalledVoices();

            Prompt prompt = new Prompt(read);

            await Task.Run(() => synth.SpeakAsync(prompt));
            //display to list view
            MealDetailTaskList.DataContext = datatable.DefaultView;
        }

    }
}
