using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Media;

namespace SilverlightLOBFramework.Controls.Layout
{
    public partial class HtmlViewer : UserControl, IDisposable
    {
        #region Member Variables
        private HtmlElement divElement = null;
        private HtmlElement iframeElement = null;
        private string url = null;
        private WebBrowser webBrowser = null;
        #endregion

        #region Constants
        private const string loadingHTML =
            "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
            "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
                "<head />" +
                "<body>" +
                    "<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: small; font-weight: bold; color: Navy; width: 100%; text-align: center; vertical-align: middle; top: 50%; position: absolute;\">" +
                        "Please wait - loading..." +
                    "</div>" +
                "</body>" +
            "</html>"; 
        #endregion

        #region Events
        /// <summary>
        /// Raised when the specified page has loaded.  Note that this
        /// event is not raised when the content is a PDF file
        /// </summary>
        public event EventHandler ContentLoadComplete;
        #endregion

        #region Constructor
        public HtmlViewer()
        {
            this.Loaded += new RoutedEventHandler(HtmlViewer_Loaded);
            this.LayoutUpdated += new EventHandler(HtmlViewer_LayoutUpdated);
        }
        #endregion

        #region Public Properties
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                Navigate(url);
            }
        } 
        #endregion

        #region Event Handlers
        private void HtmlViewer_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.IsRunningOutOfBrowser)
            {
                EnsureWindowlessModeOn();
                CreateIFrame();
                PositionIFrame();
            }
            else
            {
                webBrowser = new WebBrowser();
                webBrowser.LoadCompleted += webBrowser_LoadCompleted;
                this.Content = webBrowser;
            }
        }

        private void webBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (ContentLoadComplete != null)
                ContentLoadComplete(this, new EventArgs());
        }

        private void HtmlViewer_LayoutUpdated(object sender, EventArgs e)
        {
            if (!Application.Current.IsRunningOutOfBrowser)
                PositionIFrame();
        }

        private void iframeElement_PageLoaded(object sender, HtmlEventArgs e)
        {
            // NOTE: This event is never called for PDF files
            if (ContentLoadComplete != null)
                ContentLoadComplete(this, new EventArgs());
        }
        #endregion

        #region Private Functions
        private void EnsureWindowlessModeOn()
        {
            // Throw an exception if windowless mode isn't on, as the iframe
            // will be hidden behind the Silverlight plugin if it is
            HtmlElement silverlightObject = HtmlPage.Plugin;
            bool isWindowless = false;

            foreach (HtmlElement param in silverlightObject.Children)
            {
                if (param.TagName == "param")
                {
                    string name = param.GetAttribute("name");
                    string value = param.GetAttribute("value");

                    if (name == "Windowless")
                    {
                        isWindowless = Convert.ToBoolean(value);
                        break;
                    }
                }
            }

            if (!isWindowless)
                throw new Exception("The Silverlight plugin must be in windowless mode to use this control");
        }

        private void CreateIFrame()
        {
            // Create an iframe in the underlying aspx page to host
            // the given html content
            divElement = HtmlPage.Document.CreateElement("div");
            divElement.Id = "HtmlFrameDiv";
            divElement.SetStyleAttribute("position", "absolute");
            divElement.SetStyleAttribute("z-index", "99");

            iframeElement = HtmlPage.Document.CreateElement("iframe");
            iframeElement.Id = "HtmlFrame";
            iframeElement.SetAttribute("scrolling", "no");
            iframeElement.SetAttribute("frameborder", "0");
            iframeElement.AttachEvent("onload", new EventHandler<HtmlEventArgs>(iframeElement_PageLoaded));
            
            HtmlElement formElement = HtmlPage.Document.GetElementsByTagName("form")[0] as HtmlElement;
            formElement.AppendChild(divElement);

            divElement.AppendChild(iframeElement);

            // Add some HTML to the iframe before requesting the document
            // to indicate that it is loading
            HtmlWindow contentWindow = iframeElement.GetProperty("contentWindow") as HtmlWindow;
            HtmlDocument document = contentWindow.GetProperty("document") as HtmlDocument;
            
            // Write the html to display to the document
            document.Invoke("open", null);

            document.Invoke("write", loadingHTML);

            document.Invoke("close", null);
            
            if (url != null && url.Length != 0)
                contentWindow.Navigate(new Uri(url));
        }

        private void PositionIFrame()
        {
            // Fill the area of this control with the iframe
            if (iframeElement != null && this.ActualHeight != 0)
            {
                GeneralTransform gt = this.TransformToVisual(Application.Current.RootVisual);
                Point pos = gt.Transform(new Point(0, 0));
                divElement.SetStyleAttribute("left", pos.X.ToString() + "px");
                divElement.SetStyleAttribute("top", pos.Y.ToString() + "px");
                divElement.SetStyleAttribute("width", this.ActualWidth.ToString() + "px");
                divElement.SetStyleAttribute("height", this.ActualHeight.ToString() + "px");

                iframeElement.SetStyleAttribute("width", this.ActualWidth.ToString() + "px");
                iframeElement.SetStyleAttribute("height", this.ActualHeight.ToString() + "px");
            }
        }

        private void DestroyIFrame()
        {
            // Remove the iframe from the underlying aspx page
            if (divElement != null)
            {
                divElement.Parent.RemoveChild(divElement);
                divElement = null;
                iframeElement = null;
            }
        }

        private void Navigate(string url)
        {
            if (Application.Current.IsRunningOutOfBrowser)
            {
                if (webBrowser != null)
                {
                    webBrowser.Navigate(new Uri(url));
                }
            }
            else
            {
                if (iframeElement != null)
                {
                    HtmlWindow contentWindow = iframeElement.GetProperty("contentWindow") as HtmlWindow;
                    contentWindow.AttachEvent("onload", new EventHandler<HtmlEventArgs>(iframeElement_PageLoaded));
                    contentWindow.Navigate(new Uri(url));
                }
            }
        }
        #endregion

        #region Public Functions
        public void Dispose()
        {
            DestroyIFrame();
        } 
        #endregion
    }
}
