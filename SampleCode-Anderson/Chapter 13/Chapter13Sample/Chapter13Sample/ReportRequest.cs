using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Browser;
using SilverlightLOBFramework;

namespace SilverlightLOBFramework.Reporting
{
    public static class ReportRequest
    {
        #region Public Functions
        public static string GetReportUrl(IDictionary<string, string> parameters)
        {
            // Use the configuration of the web service to determine whether
            // to use https or not - if web service traffic is encrypted so
            // should the reports
            Uri uri = new Uri(Application.Current.Host.Source, "../Report.ashx");
            string url = uri.OriginalString;

            // Append the supplied parameters to the url
            url += "?";

            foreach (KeyValuePair<string, string> param in parameters)
            {
                if (!url.EndsWith("?"))
                    url += "&";

                url += param.Key + "=" + param.Value;
            }

            return url;
        }

        public static string GetReportUrl(string reportName)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportName", reportName);

            return GetReportUrl(parameters);
        }

        public static void OpenReportInNewWindow(IDictionary<string, string> parameters)
        {
            string url = GetReportUrl(parameters);

            // Open a new popup window and display the report
            HtmlPopupWindowOptions options = new HtmlPopupWindowOptions();
            options.Menubar = false;
            options.Scrollbars = false;
            options.Toolbar = false;
            options.Directories = false;
            options.Resizeable = true;
            options.Status = true;
            options.Width = 1000;
            options.Height = 700;

            HtmlPage.PopupWindow(new Uri(url), null, options);
        }
        #endregion
    }
}
