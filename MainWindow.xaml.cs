
using listofwork.Models;
using listofwork.servises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Win32;
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


namespace listofwork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\tododataList.json";
        private FileIOSservice _fileIOSservice;
        private BindingList<ToDoModel> _todoDataList;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOSservice = new FileIOSservice(PATH);
            try     {
               _todoDataList = _fileIOSservice.LoadData();
           }
                catch(Exception ex)
        {
         MessageBox.Show(ex.Message);
             Close();
           }

            dgWorkList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }
      
        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {   if( e.ListChangedType==ListChangedType.ItemAdded||e.ListChangedType==ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {

                try { 
                
                    _fileIOSservice.SaveData(sender);
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }

            }
          
        }
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            const string applicationName = "testProgram";
            const string pathRegistryKeyStartup =
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup =
                        Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.SetValue(
                    applicationName, "C:\\Users\\User\\source\\repos\\listofwork\\listofwork\\bin\\Debug\\listofwork.exe");
                    
            }
            //     const string pathRegistryKeyStartup =
            //                 "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            //     RegistryKey Key =
            //Registry.CurrentUser.OpenSubKey(
            //            pathRegistryKeyStartup,true);
            //     Key.SetValue("jsonf", "C:\\Windows\\System32\\tododataList.json");
            //     Key.SetValue("prf", "C:\\Users\\User\\source\\repos\\listofwork\\listofwork\\bin\\Debug\\listofwork.exe");
            //     Key.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const string applicationName = "testProgram";
            const string pathRegistryKeyStartup =
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup =
                        Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.DeleteValue(applicationName, false);
            }
            //        const string pathRegistryKeyStartup =
            //                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            //        RegistryKey key =
            //Registry.CurrentUser.OpenSubKey(
            //    pathRegistryKeyStartup);
            //        key.DeleteValue("jsonf", false);
            //        key.DeleteValue("prf", false);
            //        key.Close();
        }

        private void dgWorkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

    
                 