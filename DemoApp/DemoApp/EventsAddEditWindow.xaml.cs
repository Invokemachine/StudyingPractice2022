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
    /// Логика взаимодействия для EventsAddEditWindow.xaml
    /// </summary>
    public partial class EventsAddEditWindow : Window
    {
        private Event_ _currentEvent = new Event_();

        public EventsAddEditWindow(Event_ selectedEvent_)
        {
            InitializeComponent();

            if(selectedEvent_ != null)
                _currentEvent = selectedEvent_;
            DataContext = _currentEvent;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentEvent.Name == null)
                errors.AppendLine("Введите название мероприятия");
            if (_currentEvent.Date == null)
                errors.Append("Введите дату");
            if (_currentEvent.Status == null)
                errors.Append("Введите статус мероприятия");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentEvent.Name != null && _currentEvent.Date != null || _currentEvent.Status != null)
                StudyingPracticeEntities.GetContext().Event_.Add(_currentEvent);
            try
            {
                StudyingPracticeEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация успешно добавлена!", "Окно оповещений");
                EventShow eventShow = new EventShow();
                eventShow.Show();
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void EventsBackButton_Click(object sender, RoutedEventArgs e)
        {
            EventShow eventShow = new EventShow();
            eventShow.Show();
            Close();
        }
    }
}
