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
    /// Логика взаимодействия для EventShow.xaml
    /// </summary>
    public partial class EventShow : Window
    {
        public EventShow()
        {
            InitializeComponent();
            DataGridEventShow.ItemsSource = StudyingPracticeEntities.GetContext().Event_.ToList();
        }

        public void UpdateEventsList()
        {
            var currentEventsName = StudyingPracticeEntities.GetContext().Event_.ToList();

            currentEventsName = currentEventsName.Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            DataGridEventShow.ItemsSource = currentEventsName.OrderBy(p => p.Name).ToList();
        }

        private void EventAddButton_Click(object sender, RoutedEventArgs e)
        {
            EventsAddEditWindow eventsAddEditWindow = new EventsAddEditWindow(null);
            eventsAddEditWindow.Show();
            Hide();
        }

        private void EventDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var eventsForDeleting = DataGridEventShow.SelectedItems.Cast<Event_>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {eventsForDeleting.Count} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    StudyingPracticeEntities.GetContext().Event_.RemoveRange(eventsForDeleting);
                    StudyingPracticeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!", "Окно оповещений");
                    DataGridEventShow.ItemsSource = StudyingPracticeEntities.GetContext().Event_.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EventsAddEditWindow eventsAddEditWindow = new EventsAddEditWindow((sender as Button).DataContext as Event_);
            eventsAddEditWindow.Show();
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEventsList();
        }
    }
}
