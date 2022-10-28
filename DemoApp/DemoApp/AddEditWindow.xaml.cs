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


namespace DemoApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private CommonEmployee _currentEmployee = new CommonEmployee();

        public AddEditWindow(CommonEmployee selectedCommonEmployee)
        {
            InitializeComponent();

            if (selectedCommonEmployee != null)
                _currentEmployee = selectedCommonEmployee;

            DataContext = _currentEmployee;
        }

        private void EmployeeBackButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeShow employeeShow = new EmployeeShow();
            employeeShow.Show();
            Hide();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();         ///Создание нового объекта класса StringBuilder для сохранения ошибки ввода
            if (string.IsNullOrWhiteSpace(_currentEmployee.Name))
                errors.AppendLine("Введите имя сотрудника");
            if (_currentEmployee.Role == null)
                errors.AppendLine("Выберите должность сотрудника");

            if (errors.Length > 0)      ///Если errors не пуст, исполнить отправку сообщения с содержимым errors, полученным в условиях выше
            {
                MessageBox.Show(errors.ToString()); 
                return;
            }

            if (_currentEmployee.Name != null && _currentEmployee.Role != null )
                StudyingPracticeEntities.GetContext().CommonEmployee.Add(_currentEmployee);
            try
            {
                StudyingPracticeEntities.GetContext().SaveChanges();
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Show();
                EmployeeShow employeeShow = new EmployeeShow();
                employeeShow.Show();
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
