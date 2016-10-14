using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Chapter14Sample
{
    public partial class Files : Page
    {
        public Files()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void imageBorder_Drop(object sender, DragEventArgs e)
        {
            // Code to open/read the dropped files goes here
            FileInfo[] files = e.Data.GetData(DataFormats.FileDrop) as FileInfo[];

            if (files.Length != 0)
            {
                // Ensure that the file is an image (by validating the extension)
                string[] validExtensions = new string[] { ".jpg", ".png" };

                // Note that you need a using directive to System.Linq for this line.
                // NOTE: Multiple files can be dropped on the application, we are 
                // displaying the first file only.
                if (validExtensions.Contains(files[0].Extension.ToLower()))
                {
                    try
                    {
                        // Open the file, read it into a BitmapImage object, and
                        // display it in the Image control. 
                        using (FileStream fileStream = files[0].OpenRead())
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.SetSource(fileStream);
                            fileStream.Close();

                            droppedImage.Source = bitmap;
                        }
                    }
                    catch { }                    
                }
            }

            // Reset the drag over state
            imageBorder.BorderBrush = new SolidColorBrush(Colors.Black);
            droppedImage.Opacity = 1;
        }

        private void imageBorder_DragEnter(object sender, DragEventArgs e)
        {
            imageBorder.BorderBrush = new SolidColorBrush(Colors.Red);
            droppedImage.Opacity = 0.7;
        }

        private void imageBorder_DragLeave(object sender, DragEventArgs e)
        {
            imageBorder.BorderBrush = new SolidColorBrush(Colors.Black);
            droppedImage.Opacity = 1;
        }
    }
}