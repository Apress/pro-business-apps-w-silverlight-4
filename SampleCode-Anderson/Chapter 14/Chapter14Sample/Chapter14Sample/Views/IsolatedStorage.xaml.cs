using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Chapter14Sample.Views
{
    public partial class IsolatedStorage : Page
    {
        public IsolatedStorage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void GetSettingButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the value of the setting whose name is in the SettingNameTextBox
            if (IsolatedStorageSettings.ApplicationSettings.Contains(SettingNameTextBox.Text))
                SettingValueTextBox.Text = IsolatedStorageSettings.ApplicationSettings[SettingNameTextBox.Text].ToString();
            else
                MessageBox.Show("Setting not found");
        }

        private void SaveSettingButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the setting with the given name and value
            IsolatedStorageSettings.ApplicationSettings[SettingNameTextBox.Text] = SettingValueTextBox.Text;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        private void DeleteSettingButton_Click(object sender, RoutedEventArgs e)
        {
            // Delete the setting with the given name
            IsolatedStorageSettings.ApplicationSettings.Remove(SettingNameTextBox.Text);
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        private void WriteFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Writes a file to isolated storage, with that file containing a
            // serialised collection
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                List<TempData> dict = new List<TempData>();

                dict.Add(new TempData() { ID = 1, Name = "Item 1" });
                dict.Add(new TempData() { ID = 2, Name = "Item 2" });
                dict.Add(new TempData() { ID = 3, Name = "Item 3" });
                dict.Add(new TempData() { ID = 4, Name = "Item 4" });
                dict.Add(new TempData() { ID = 5, Name = "Item 5" });

                using (IsolatedStorageFileStream fileStream = store.OpenFile("TestDataCollection.xml", FileMode.Create))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<TempData>));
                    serializer.WriteObject(fileStream, dict);
                }
            }
        }

        private void ReadFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Reads a collection from the file written in the Write File function
            // from isolated storage, by deserialising it
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = store.OpenFile("TestDataCollection.xml", FileMode.Open))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<TempData>));
                    List<TempData> dict = serializer.ReadObject(fileStream) as List<TempData>;

                    fileStream.Close();
                }
            }
        }

        private void QuotaButton_Click(object sender, RoutedEventArgs e)
        {
            // Displays the current isolated storage quota
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

            double quota = store.Quota / (1024f * 1024f);
            double used = store.UsedSize / (1024f * 1024f);
            double avail = store.AvailableFreeSpace / (1024f * 1024f);

            MessageBox.Show("Current quota: " + quota.ToString("0.00") + "mb\r\n" +
                            "Space used: " + used.ToString("0.00") + "mb\r\n" +
                            "Space available: " + avail.ToString("0.00") + "mb", "Chapter 14 Sample", MessageBoxButton.OK);

            store.Dispose();
        }

        private void IncreaseQuotaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Increase the isolated storage quota to 3mb
                IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
                bool increasePermitted = store.IncreaseQuotaTo(3 * 1024 * 1024);
                store.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not increase quota: " + ex.Message, "Chapter 14 Sample", MessageBoxButton.OK);
            }
        }
    }
}
