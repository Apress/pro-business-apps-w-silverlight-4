This solution demonstrates exposing summary product data from the Web project and 
consuming it in the Silverlight project.

NOTE: The entity model uses the AdventureWorks2008 database, which you can download
from http://msftdbprodsamples.codeplex.com.  You will need to configure the
connection string (named 'AdventureWorks2008Entities') in the App.Config file
to point towards your database once you've installed it.

Features implemented include:

- Consuming data using the DomainDataSource control (XAML-based approach)
- Filtering, sorting, grouping, and paging the summary list
- Implementing a summary list using the DataGrid control
- Implementing a summary list using a ListBox control (with a custom item data template)
- Drilling down on a record (note that this form is not completely implemented here)
- Using the BusyIndicator control

NOTE: The following topics covered in chapter 6 are not demonstrated in this example
solution - see the Chapter 12 example solution (which uses the MVVM design pattern)
where they will generally be used.  This example solution only uses the 
DomainDataSource control for retrieving data from the server.

- Consuming data using code-behind
- Using the ObservableCollection<T> object
- Using the PagedCollectionView object
- Defining a query on the client to be executed on the server-side