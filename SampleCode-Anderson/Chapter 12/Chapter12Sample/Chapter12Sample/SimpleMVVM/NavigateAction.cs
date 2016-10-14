using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Expression.Interactivity;
using System.Windows.Interactivity;

namespace SimpleMVVM
{
    /// <summary>
    /// This <see cref="TriggerAction{T}"/> will cause a named frame to 
    /// navigate to a new url in response to a
    ///  <see cref="Microsoft.Expression.Interactivity.TriggerBase">Trigger</see>
    ///  Obtained from: http://azurecoding.com/blogs/brownie/archive/2009/04/06/blend-behaviors-ftw.aspx
    /// </summary>
    public class NavigateAction : TriggerAction<UIElement>
    {
        /// <summary>
        /// The name of the frame which the <see cref="NavigateAction"/> will
        /// navigate.
        /// </summary>
        [Category("NavigateAction Properties"), Description("The element name of the Frame to navigate as a result of this TriggerAction")]
        public String TargetFrameName
        {
            get { return (String)GetValue(TargetFrameNameProperty); }
            set { SetValue(TargetFrameNameProperty, value); }
        }

        /// <summary>
        /// The Url to which the targe fram
        /// </summary>
        [Category("NavigationAction Properties"), Description("The relative Url to which the TargetFrame will be navigated.")]
        public String Url
        {
            get { return (String)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url",
                                        typeof(String),
                                        typeof(NavigateAction),
                                        new PropertyMetadata(UrlChanged));

        private static void UrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public static readonly DependencyProperty TargetFrameNameProperty =
            DependencyProperty.Register("Target Frame Name",
                                        typeof(String),
                                        typeof(NavigateAction),
                                        new PropertyMetadata
                                            (TargetFrameChanged));

        /// <summary>
        /// Has to be here because DependencyProperty.Register only has one signature.
        /// </summary>
        /// <param name="d">Who Cares</param>
        /// <param name="e">I don't.</param>
        private static void TargetFrameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        protected override void Invoke(object parameter)
        {
            // Heavily modified
            Frame frame = this.AssociatedObject.FindAncestorOfType(typeof(Frame)) as Frame;

            if (frame != null) 
                frame.Navigate(new Uri(Url, UriKind.Relative));
        }
    }
}
