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
    [DefaultTrigger(typeof(Button), typeof(ButtonClickTrigger))]
    public class SubmitChangesAction : TargetedTriggerAction<DomainDataSource>
    {
        protected override void Invoke(object parameter)
        {
            Target.SubmitChanges();
        }
    }
}
