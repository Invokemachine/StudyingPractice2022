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
    /// Логика взаимодействия для AllListsShowWindow.xaml
    /// </summary>
    public partial class AllListsShowWindow : Window
    {
        public AllListsShowWindow()
        {
            InitializeComponent();
            OrdersDataGrid.ItemsSource = StudyingPracticeEntities.GetContext().Order_.ToList();     ///Присвоение таблиц из базы для соответствующих им элементов DataGrid на странице
            CorrespondentDataGrid.ItemsSource = StudyingPracticeEntities.GetContext().OutgoingCorrespondent.ToList();
            SupervisorDataGrid.ItemsSource = StudyingPracticeEntities.GetContext().Supervisor.ToList();
        }
    }
}
