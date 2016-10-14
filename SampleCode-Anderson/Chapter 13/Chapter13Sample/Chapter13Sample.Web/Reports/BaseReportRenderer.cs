using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace SilverlightLOBFramework.Reports
{
    public class BaseReportRenderer
    {
        #region Enumerations
        public enum PageOrientations
        {
            Portrait,
            Landscape
        }
        #endregion

        #region Constants
        private const string A4_PAGE_WIDTH = "21cm";
        private const string A4_PAGE_HEIGHT = "29.7cm";
        private const string DEFAULT_MARGIN = "0.5cm";
        #endregion

        #region Member Variables
        protected string pageWidth = A4_PAGE_WIDTH;
        protected string pageHeight = A4_PAGE_HEIGHT;
        protected string margins = DEFAULT_MARGIN;
        protected NameValueCollection parameters = null;
        protected PageOrientations pageOrientation = PageOrientations.Portrait;
        #endregion

        #region Public Properties
        public virtual string ReportPath
        {
            get { return ""; }
        }

        public virtual string ReportName
        {
            get { return "Report"; }
        }

        public virtual bool IsUserAccessAuthorised
        {
            get { return true; }
        }

        public virtual NameValueCollection Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public virtual string PageWidth
        {
            get { return pageWidth; }
            set { pageWidth = value; }
        }

        public virtual string PageHeight
        {
            get { return pageHeight; }
            set { pageHeight = value; }
        }

        public virtual string Margins
        {
            get { return margins; }
            set { margins = value; }
        }

        public virtual PageOrientations PageOrientation
        {
            get { return pageOrientation; }
            set
            {
                pageOrientation = value;

                // Flip page dimensions
                if (pageOrientation == PageOrientations.Portrait)
                {
                    pageWidth = A4_PAGE_WIDTH;
                    pageHeight = A4_PAGE_HEIGHT;
                }
                else
                {
                    pageWidth = A4_PAGE_HEIGHT;
                    pageHeight = A4_PAGE_WIDTH;
                }
            }
        }
        #endregion

        #region Public Functions
        public virtual LocalReport GetReport()
        {
            LocalReport report = new LocalReport();

            report.ReportPath = ReportPath;
            PopulateReportDataSources(report.DataSources);

            return report;
        }

        public virtual void PopulateReportDataSources(ReportDataSourceCollection dataSources)
        {
        }
        #endregion
    }
}