using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using Microsoft.Reporting.WebForms;

namespace SilverlightLOBFramework.Reports
{
    public class BaseReportHandler : IHttpHandler
    {
        #region Public Functions
        public void ProcessRequest(HttpContext context)
        {
            Request = context.Request;
            Response = context.Response;

            User = HttpContext.Current.User;

            // Uncomment this if users must be authenticated to view the reports
            //if (User == null || !User.Identity.IsAuthenticated)
            //{
            //    Response.StatusCode = 403; // Forbidden
            //    Response.Write("Invalid security credentials supplied!");
            //    Response.End();
            //    return;
            //}

            ReportRenderers = new Dictionary<string, Type>();
            RegisterRenderers(ReportRenderers);

            BaseReportRenderer renderer = GetRenderer();
            renderer.Parameters = Request.QueryString;

            if (renderer != null)
            {
                if (renderer.IsUserAccessAuthorised)
                {
                    LocalReport report = renderer.GetReport();
                    report.EnableHyperlinks = true;

                    RenderToResponseAsPDF(report);
                }
                else
                {
                    Response.StatusCode = 403; // Forbidden
                    Response.Write("Permission to access this report has been denied");
                    Response.End();
                    return;
                }
            }
            else
            {
                Response.Write("Report renderer not found!");
            }
        }
        #endregion

        #region Private Functions
        protected virtual void RegisterRenderers(Dictionary<string, Type> reportRenderers)
        {
        }

        protected virtual BaseReportRenderer GetRenderer()
        {
            BaseReportRenderer renderer = null;

            if (ReportRenderers.ContainsKey(ParamReportName))
            {
                // Use reflection to create an instance of the renderer class
                Type rendererType = ReportRenderers[ParamReportName];
                renderer = Activator.CreateInstance(rendererType) as BaseReportRenderer;
            }

            return renderer;
        }

        protected void RenderToResponseAsPDF(LocalReport report)
        {
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            string deviceInfo = null;

            //Render the report
            renderedBytes = report.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            //Clear the response stream and write the bytes to the output stream
            string reportFileName = ParamReportName.Replace(" ", "") + ".pdf";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "inline;filename=" + reportFileName);
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
        #endregion

        #region Private Properties
        protected Dictionary<string, Type> ReportRenderers { get; set; }
        protected HttpRequest Request { get; private set; }
        protected HttpResponse Response { get; private set; }
        protected IPrincipal User { get; private set; }

        protected string ParamReportName
        {
            get
            {
                string paramValue = "";
                const string paramName = "ReportName";

                if (Request.QueryString[paramName] != null)
                    paramValue = Request.QueryString[paramName];

                return paramValue;
            }
        }

        protected bool ParamDownload
        {
            get
            {
                bool paramValue = false;
                const string paramName = "Download";

                if (Request.QueryString[paramName] != null)
                    bool.TryParse(Request.QueryString[paramName], out paramValue);

                return paramValue;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
        #endregion
    }
}
