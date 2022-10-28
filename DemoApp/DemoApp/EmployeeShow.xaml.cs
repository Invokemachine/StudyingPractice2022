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
using System.Windows.Navigation;
using DocumentFormat.OpenXml.ExtendedProperties;
using System.Data;

namespace DemoApp
{
    /// <summary>
    /// Логика взаимодействия для EmployeeShow.xaml
    /// </summary>
    public partial class EmployeeShow : Window
    {
        public EmployeeShow()
        {
            InitializeComponent();
            DataGridCommonEmployees.ItemsSource = StudyingPracticeEntities.GetContext().CommonEmployee.ToList();    ///Присвоение атрибуту элемента для вывода списка сотрудников таблицы CommonEmployee
        }

        public void UpdateEmployeesList()
        {
            var currentEmployeesName = StudyingPracticeEntities.GetContext().CommonEmployee.ToList();

            currentEmployeesName = currentEmployeesName.Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();       
            DataGridCommonEmployees.ItemsSource = currentEmployeesName.OrderBy(p=>p.Name).ToList();     ///Возврат имён сотрудников, совпавших с введённым значением в текстбокс 
        }

        private void EmployeeAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow(null);
            addEditWindow.Show();
            Close();
        }

        private void EmployeeDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var employeesForDeleting = DataGridCommonEmployees.SelectedItems.Cast<CommonEmployee>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить следующие {employeesForDeleting.Count} элементов?","Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    StudyingPracticeEntities.GetContext().CommonEmployee.RemoveRange(employeesForDeleting);
                    StudyingPracticeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!", "Окно оповещений");
                    DataGridCommonEmployees.ItemsSource = StudyingPracticeEntities.GetContext().CommonEmployee.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                StudyingPracticeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());        ///Обновление сущностей в GetContext и выполнение Reload (перезагрузки значения таблицы) для каждого элемента
                DataGridCommonEmployees.ItemsSource = StudyingPracticeEntities.GetContext().CommonEmployee.ToList();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEmployeesList();      ///Вызов метода обновления списка сотрудников по событию изменения текста внутри SearchTextBox
        }
    }
}
