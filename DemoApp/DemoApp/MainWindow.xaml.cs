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

namespace DemoApp
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

        private void EmployeeShowButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeShow employeeShow = new EmployeeShow();
            employeeShow.Show();
            Hide();
        }

        private void IssuedDocumentsShowButton_Click(object sender, RoutedEventArgs e)
        {
            IssuedDocumentsShow issuedDocumentsShow = new IssuedDocumentsShow();
            issuedDocumentsShow.Show();
            Hide();
        }

        private void EventsListShowButton_Click(object sender, RoutedEventArgs e)
        {
            EventShow eventShow = new EventShow();
            eventShow.Show();
            Hide();
        }

        private void CreateNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrderWindow createNewOrderWindow = new CreateNewOrderWindow();
            createNewOrderWindow.Show();
            Hide();
        }

        private void AppInstructionsButton_Click(object sender, RoutedEventArgs e)
        {
            AppInstructionsWindow appInstructionsWindow = new AppInstructionsWindow();
            appInstructionsWindow.Show();
            Hide();
        }
    }
}
