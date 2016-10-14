using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Chapter03Sample
{
    public class Person
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    // In practise, you'd generally implement the INotifyPropertyChanged interface
    // as discussed in chapter 7, so that updates to the properties via code
    // are propagated to the user interface

    //public class Person : INotifyPropertyChanged
    //{
    //    private string title = "";
    //    private string firstName = "";
    //    private string lastName = "";

    //    public string Title
    //    {
    //        get { return title; }
    //        set
    //        {
    //            if (title != value)
    //            {
    //                title = value;

    //                if (PropertyChanged != null)
    //                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
    //            }
    //        }
    //    }

    //    public string FirstName 
    //    {
    //        get { return firstName; }
    //        set 
    //        {
    //            if (firstName != value)
    //            {
    //                firstName = value;

    //                if (PropertyChanged != null)
    //                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
    //            }
    //        }
    //    }
        
    //    public string LastName
    //    {
    //        get { return lastName; }
    //        set
    //        {
    //            if (lastName != value)
    //            {
    //                lastName = value;

    //                if (PropertyChanged != null)
    //                    PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
    //            }
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //}
}
