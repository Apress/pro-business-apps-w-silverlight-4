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
using System.Windows.Interactivity;

namespace Chapter10Sample.Behaviors
{
    public class ButtonClickTrigger : TriggerBase<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Click += new RoutedEventHandler(AssociatedObject_Click);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Click -= new RoutedEventHandler(AssociatedObject_Click);
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            InvokeActions(null);
        }
    }
}
