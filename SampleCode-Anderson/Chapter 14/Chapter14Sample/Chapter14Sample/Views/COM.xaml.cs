using System;
using System.Runtime.InteropServices.Automation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Chapter14Sample.Views
{
    public partial class COM : Page
    {
        public COM()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void StartExeButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                using (dynamic shell = AutomationFactory.CreateObject("WScript.Shell"))
                {
                    shell.Run("calc.exe");
                }
            }
        }

        private void CreateEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                dynamic outlook = AutomationFactory.CreateObject("Outlook.Application");
                dynamic mailItem = outlook.CreateItem(0);
                mailItem.To = "christhecoder@gmail.com";
                mailItem.Subject = "Silverlight 4 FTW!";
                mailItem.HTMLBody = "<P>This email was created by Silverlight</P>";
                mailItem.Display();
            }
        }

        private void OpenWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                using (dynamic word = AutomationFactory.CreateObject("Word.Application"))
                {
                    dynamic document = word.Documents.Add();
                    document.Content = "This was inserted by Silverlight";
                    word.Visible = true;
                }
            }
        }

        private void OpenExcelButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                using (dynamic excel = AutomationFactory.CreateObject("Excel.Application"))
                {
                    dynamic workbook = excel.Workbooks.Add();
                    dynamic cell = workbook.ActiveSheet.Cells[1, 1];
                    cell.Value = "This was inserted by Silverlight";
                    excel.Visible = true;
                }
            }
        }
    }
}
