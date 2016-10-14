using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Chapter11Sample
{
    public partial class FormField : UserControl
    {
        public FormField()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty FieldLabelProperty =
            DependencyProperty.Register("FieldLabel", typeof(string), typeof(FormField), null);

        public string FieldLabel
        {
            get { return (string)GetValue(FieldLabelProperty); }
            set { SetValue(FieldLabelProperty, value); }
        }

        public static readonly DependencyProperty FieldValueProperty =
            DependencyProperty.Register("FieldValue", typeof(string), typeof(FormField), null);

        public string FieldValue
        {
            get { return (string)GetValue(FieldValueProperty); }
            set { SetValue(FieldValueProperty, value); }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = 300;
            this.Height = 30;
        }  
    }
}
