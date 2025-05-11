using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private FileIOService _fileIOService;
        private readonly string PATH = $@"{Environment.CurrentDirectory}\toDoDataList.json";
        BindingList<ToDoModel> toDoDataList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);
            try
            {
                toDoDataList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка!", ex.Message);
                Close();
            }
           
            ToDoList.ItemsSource = toDoDataList;
            toDoDataList.ListChanged += ToDoDataList_ListChanged;
        }

        private void ToDoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemAdded)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Возникла ошибка!",ex.Message);
                    Close();    
                }
            }

           
        }
    }
}
