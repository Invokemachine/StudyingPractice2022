using Microsoft.Win32;
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
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace DemoApp
{
    /// <summary>
    /// Логика взаимодействия для CreateNewOrderWindow.xaml
    /// </summary>
    public partial class CreateNewOrderWindow : Window
    {
        private Order_ _currentOrder = new Order_();


        public CreateNewOrderWindow()
        {
            InitializeComponent();

            DataContext = _currentOrder;

        }
        private const int _sheetsCount = 6;
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentOrder.OrderName == null)
                errors.AppendLine("Введите название нового приказа");
            if (_currentOrder.CurrentDate == null)
                errors.Append("Введите текущую дату");
            if (_currentOrder.Role == null)
                errors.Append("Введите должность ответственного за проведение мероприятия");
            if (_currentOrder.Content_ == null)
                errors.AppendLine("Введите содержание приказа");
            if (_currentOrder.EventResponsible == null)
                errors.Append("Введите имя ответственного за исполнение");
            if (_currentOrder.PerformanceDate == null)
                errors.Append("Введите дату проведения");
            if (_currentOrder.Correspondent == null)
                errors.AppendLine("Введите имя корреспондента");
            if (_currentOrder.EventNumber <= 0)
                errors.AppendLine("Введите корректный номер события");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentOrder.OrderName != null && _currentOrder.CurrentDate != null || _currentOrder.Role != null || _currentOrder.Content_ != null && _currentOrder.EventResponsible != null || _currentOrder.PerformanceDate != null || _currentOrder.EventNumber >= 0)
                StudyingPracticeEntities.GetContext().Order_.Add(_currentOrder);
            try
            {
                StudyingPracticeEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация успешно добавлена!", "Окно оповещений");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AllListShowButton_Click(object sender, RoutedEventArgs e)
        {
            AllListsShowWindow allListsShowWindow = new AllListsShowWindow();
            allListsShowWindow.Show();
        }

        private void ToIssueDocuments_Click(object sender, RoutedEventArgs e)
        {
            IssueNewDocumentWindow issueNewDocumentWindow = new IssueNewDocumentWindow();
            issueNewDocumentWindow.Show();
            Hide();
        }
    }
}
