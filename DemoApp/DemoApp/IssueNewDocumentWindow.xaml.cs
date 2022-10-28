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
    /// Логика взаимодействия для IssueNewDocumentWindow.xaml
    /// </summary>
    public partial class IssueNewDocumentWindow : Window
    {

        private IssuedDocuments issuedDocuments = new IssuedDocuments();

        public IssueNewDocumentWindow()
        {
            InitializeComponent();
            DataContext = issuedDocuments;
        }

        private void ToNewEventsBackButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrderWindow eventsAddEditWindow = new CreateNewOrderWindow();
            eventsAddEditWindow.Show();
            Close();
        }

        private void IssueNewDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (issuedDocuments.OrderName == null)
                errors.AppendLine("Введите название нового приказа");
            if (issuedDocuments.DateOfOrderOutcoming == null)
                errors.Append("Введите дату выхода");
            if (issuedDocuments.Sign != true)
                errors.Append("Введите наличие подписи 'true'");
            if (issuedDocuments.Role == null)
                errors.AppendLine("Введите содержание приказа");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (issuedDocuments.OrderName != null && issuedDocuments.DateOfOrderOutcoming != null || issuedDocuments.Sign != false || issuedDocuments.Role != null)
                StudyingPracticeEntities.GetContext().IssuedDocuments.Add(issuedDocuments);
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

        private void MakePdfDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            List<IssuedDocuments> tables;
            using (StudyingPracticeEntities studyingPracticeEntities = new StudyingPracticeEntities())
            {
                tables = studyingPracticeEntities.IssuedDocuments.ToList().OrderBy(g => g.Id).ToList();
                var entryTypes = tables
                        .GroupBy(s => s.OrderName);         ///Разделение таблиц по названиям приказов

                var app = new Word.Application();
                Word.Document document = app.Documents.Add();

                int i = 0;
                foreach (var group in entryTypes)
                {
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range.Text = $"Номер приказа {i + 1}";
                    paragraph.set_Style("Заголовок 1");
                    range.InsertParagraphAfter();
                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;
                    Word.Table newTable = document.Tables.Add(tableRange, group.Count() + 1, 5);
                    newTable.Borders.InsideLineStyle = newTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    newTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellRange;          ///Заполнение оглавлений таблицы
                    cellRange = newTable.Cell(1, 1).Range;
                    cellRange.Text = "Id";
                    cellRange = newTable.Cell(1, 2).Range;
                    cellRange.Text = "Название приказа";
                    cellRange = newTable.Cell(1, 3).Range;
                    cellRange.Text = "Дата издания";
                    cellRange = newTable.Cell(1, 4).Range;
                    cellRange.Text = "Наличие подписи";
                    cellRange = newTable.Cell(1, 5).Range;
                    cellRange.Text = "Должность";
                    newTable.Rows[1].Range.Bold = 1;
                    newTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    int k = 1;
                    foreach (var data in group)     ///Заполнение данных внутри таблиц
                    {
                        cellRange = newTable.Cell(k + 1, 1).Range;
                        cellRange.Text = Convert.ToString(data.Id);
                        cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = newTable.Cell(k + 1, 2).Range;
                        cellRange.Text = data.OrderName;
                        cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = newTable.Cell(k + 1, 3).Range;
                        cellRange.Text = Convert.ToString(data.DateOfOrderOutcoming);
                        cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = newTable.Cell(k + 1, 4).Range;
                        cellRange.Text = Convert.ToString(data.Sign);
                        cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = newTable.Cell(k + 1, 5).Range;
                        cellRange.Text = data.Role;
                        cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        k++;
                    }

                    Word.Paragraph newParagraph = document.Paragraphs.Add();
                    Word.Range countEmployeeRange = newParagraph.Range;
                    countEmployeeRange.Font.Color = Word.WdColor.wdColorBlue;
                    countEmployeeRange.InsertParagraphAfter();

                    document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                    app.Visible = true;
                    document.SaveAs2(@"C:\StudyingPracticeWork\DemoApptFile.docx");
                    document.SaveAs2(@"C:\StudyingPracticeWork\DemoAppFile.pdf", Word.WdExportFormat.wdExportFormatPDF);
                    i++;
                }
            }
        }
    }
}
