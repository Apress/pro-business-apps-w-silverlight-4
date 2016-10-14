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
using System.Collections.Generic;

namespace Chapter03Sample
{
    public class Titles : List<string>
    {
        public Titles()
        {
            this.Add("Mr");
            this.Add("Mrs");
            this.Add("Ms");
            this.Add("Miss");
        }
    }
}
