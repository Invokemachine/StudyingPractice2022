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
    /// Логика взаимодействия для IssuedDocumentsShow.xaml
    /// </summary>
    public partial class IssuedDocumentsShow : Window
    {
        public IssuedDocumentsShow()
        {
            InitializeComponent();
            DataGridIssuedDocuments.ItemsSource = StudyingPracticeEntities.GetContext().IssuedDocuments.ToList();
        }

        public void UpdateIssuedDocumentsList()
        {
            var currentIssuedDocument = StudyingPracticeEntities.GetContext().IssuedDocuments.ToList();

            currentIssuedDocument = currentIssuedDocument.Where(p => p.OrderName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            DataGridIssuedDocuments.ItemsSource = currentIssuedDocument.OrderBy(p => p.OrderName).ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateIssuedDocumentsList();
        }
    }
}
