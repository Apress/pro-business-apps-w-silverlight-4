using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MyControlLibrary
{
    [ContentProperty("Children")]
    public class GroupBox : ContentControl
    {
        public GroupBox()
        {
            DefaultStyleKey = typeof(GroupBox);
        }

        public static readonly DependencyProperty HeaderTextProperty =
            DependencyProperty.Register("HeaderText", typeof(string), 
                                        typeof(GroupBox), null);

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(ObservableCollection<UIElement>), 
             typeof(GroupBox), new PropertyMetadata(new ObservableCollection<UIElement>()));

        public ObservableCollection<UIElement> Children
        {
            get { return (ObservableCollection<UIElement>)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public static int GetContentArea(DependencyObject obj)
        {
            return (int)obj.GetValue(ContentAreaProperty);
        }

        public static void SetContentArea(DependencyObject obj, int value)
        {
            obj.SetValue(ContentAreaProperty, value);
        }

        public static readonly DependencyProperty ContentAreaProperty =
            DependencyProperty.RegisterAttached("ContentArea", typeof(int),
            typeof(GroupBox), new PropertyMetadata(ContentAreaPropertyChanged));


        private static void ContentAreaPropertyChanged(DependencyObject d,
                                                  DependencyPropertyChangedEventArgs e)
        {
            GroupBox groupBox = VisualTreeHelper.GetParent(d) as GroupBox;

            if (groupBox != null)
                groupBox.InvalidateMeasure();
        }

        internal static readonly DependencyProperty Content0Property =
            DependencyProperty.Register("Content0", typeof(FrameworkElement), typeof(GroupBox), null);

        internal static readonly DependencyProperty Content1Property =
            DependencyProperty.Register("Content1", typeof(FrameworkElement), typeof(GroupBox), null);

        internal static readonly DependencyProperty Content2Property =
            DependencyProperty.Register("Content2", typeof(FrameworkElement), typeof(GroupBox), null);

        internal static readonly DependencyProperty Content3Property =
            DependencyProperty.Register("Content3", typeof(FrameworkElement), typeof(GroupBox), null);

        internal FrameworkElement Content0
        {
            get { return (FrameworkElement)GetValue(Content0Property); }
            set { SetValue(Content0Property, value); }
        }

        internal FrameworkElement Content1
        {
            get { return (FrameworkElement)GetValue(Content1Property); }
            set { SetValue(Content1Property, value); }
        }

        internal FrameworkElement Content2
        {
            get { return (FrameworkElement)GetValue(Content2Property); }
            set { SetValue(Content2Property, value); }
        }

        internal FrameworkElement Content3
        {
            get { return (FrameworkElement)GetValue(Content3Property); }
            set { SetValue(Content3Property, value); }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (FrameworkElement child in Children)
            {
                int area = GroupBox.GetContentArea(child);

                switch (area)
                {
                    case 0:
                        Content0 = child;
                        break;
                    case 1:
                        Content1 = child;
                        break;
                    case 2:
                        Content2 = child;
                        break;
                    case 3:
                        Content3 = child;
                        break;
                }
            }

            return base.MeasureOverride(availableSize);
        }
    }
}
