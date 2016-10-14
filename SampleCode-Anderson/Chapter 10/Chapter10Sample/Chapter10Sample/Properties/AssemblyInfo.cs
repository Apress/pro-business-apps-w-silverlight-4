using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Chapter10Sample")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft Corp.")]
[assembly: AssemblyProduct("Chapter10Sample")]
[assembly: AssemblyCopyright("Copyright © Microsoft Corp. 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("en-US")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("852860fd-add9-4e08-9fe3-f215d0380fa7")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]


// Define a custom consolidated namespace
[assembly: XmlnsPrefix("http://schemas.yourbusinessurl.com/XAML", "vm")]
[assembly: XmlnsDefinition("http://schemas.yourbusinessurl.com/XAML", "Chapter10Sample.Models")]
[assembly: XmlnsDefinition("http://schemas.yourbusinessurl.com/XAML", "Chapter10Sample.Helpers")]