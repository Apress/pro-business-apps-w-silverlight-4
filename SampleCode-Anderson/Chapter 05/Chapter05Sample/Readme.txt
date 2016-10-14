This solution demonstrates exposing data from the Web project to the Silverlight
project.  You will find an entity model defined in the 
Chapter05Sample.Web project, from which the services in the same project
will serve data up (although the client side code/XAML to consume this service has
not yet been implemented).

NOTE: The entity model uses the AdventureWorks2008 database, which you can download
from http://msftdbprodsamples.codeplex.com.  You will need to configure the
connection string (named 'AdventureWorks2008Entities') in the App.Config file
to point towards your database once you've installed it.

Features implemented include:

- Defining an entity model
- Exposing Product entities via the ProductsService domain service
- Exposing custom presentation model objects (ProductPM) via the ProductsService domain service
- Using the ModifiedDate field of the Product entity to maintain concurrency checks
- Specifying validation rules (both property and class level)
- Defining custom validation rules (both property and class level)
- Sharing logic across tiers