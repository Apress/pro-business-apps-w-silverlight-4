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
using System.Reflection;

namespace MyControlLibrary
{
    [TemplateVisualState(Name = StateInactive, GroupName = StateGroupCommon)]
    [TemplateVisualState(Name = StateActive, GroupName = StateGroupCommon)]
    [TemplateVisualState(Name = StateStatic, GroupName = StateGroupCommon)]
    [TemplatePart(Name = "Ellipse1", Type = typeof(Ellipse))]
    public class WaitIndicator : Control
    {
        #region Constants
        private const string StateActive = "Active";
        private const string StateInactive = "Inactive";
        private const string StateStatic = "Static";
        private const string StateGroupCommon = "CommonStates";
        #endregion

        public static readonly DependencyProperty IsBusyProperty =
           DependencyProperty.Register("IsBusy", typeof(bool), typeof(WaitIndicator), 
           new PropertyMetadata(false, new PropertyChangedCallback(IsBusyPropertyChanged)));

        public WaitIndicator()
        {
            this.DefaultStyleKey = typeof(WaitIndicator);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SetVisualState();
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        private static void IsBusyPropertyChanged(DependencyObject d,
                                                  DependencyPropertyChangedEventArgs e)
        {
            ((WaitIndicator)d).SetVisualState();
        }

        private void SetVisualState()
        {
            if (DesignerProperties.IsInDesignTool)
                VisualStateManager.GoToState(this, StateStatic, true);
            else
                VisualStateManager.GoToState(this, IsBusy ? StateActive : StateInactive, 
                                                true);
        }
    }
}
