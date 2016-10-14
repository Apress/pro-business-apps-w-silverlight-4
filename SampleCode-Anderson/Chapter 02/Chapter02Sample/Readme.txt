This project is used to demonstrate the recommended template modification that sets
the focus to the Silverlight control when the HTML page is loaded.  The UI simply
consists of a text block and a text box.  Note that the text box doesn't receive the 
focus when the application is loaded (despite the focus being assigned in the 
code-behind).  Clicking the application will do so (by giving the application the
focus such that the text box can be focused).

Now open up Chapter02SampleTestPage.html in the Web project and uncomment the
onLoad parameter (which will call a JavaScript method to set the focus to the
Silverlight application, as described on page 31).