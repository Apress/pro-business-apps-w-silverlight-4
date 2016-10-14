This solution demonstrates the following concepts from Chapter 13:

- Creating a HtmlViewer control
- Using the LocalReport engine to generate reports (as PDFs) on the server
- Displaying the PDF report in the Silverlight application

NOTE: BaseReportHandler has the code to check if the user is authenticated
	  commented out.  Uncomment this out if users must be authenticated to view the
	  reports.

NOTE: The entity model uses the AdventureWorks2008 database, which you can download
from http://msftdbprodsamples.codeplex.com.  You will need to configure the
connection string (named 'AdventureWorks2008Entities') in the App.Config file
to point towards your database once you've installed it.