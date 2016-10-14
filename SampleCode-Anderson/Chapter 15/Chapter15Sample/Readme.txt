This solution demonstrates the following concepts from Chapter 15:

- Creating a custom preloader animation (note that as described in the book, this 
  may not work when the local machine is the host)

  NOTE: The following line has been commented out from App.xaml.cs, preventing the
		application from actually loading (so you can see the splash screen):

		this.InitializeRootVisual();

- Creating a class library that can be a "assembly cached" (the TestCachingLibrary
  project in this solution).