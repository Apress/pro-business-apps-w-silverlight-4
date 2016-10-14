using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace Chapter10Sample.Models
{
    public class AdvancedDataBindingSourceData
    {
        // Expose some data as a collection
        public List<string> People { get; set; }

        // Expose the same data in a PagedCollectionView
        public PagedCollectionView PeopleView { get; set; }

        public AgeEnum AgeBracket { get; set; }

        public AdvancedDataBindingSourceData()
        {
            People = new List<string>() { "Homer", "Marge", "Bart", "Lisa", "Maggie" };
            PeopleView = new PagedCollectionView(People);
        }
    }
}
