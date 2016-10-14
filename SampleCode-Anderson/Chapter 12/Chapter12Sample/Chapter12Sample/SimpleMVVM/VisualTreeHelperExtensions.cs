using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Reflection;

namespace SimpleMVVM
{
    public static class VisualTreeHelperExtensions
    {
        public static IEnumerable<DependencyObject> GetChildren(this DependencyObject element)
        {
            int count = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < count; i++)
            {
                yield return VisualTreeHelper.GetChild(element, i);
            }
        }

        public static DependencyObject FindNamedChild(this DependencyObject element, string elementName)
        {
            var elementQueue = new Queue<DependencyObject>();
            elementQueue.Enqueue(element);
            var tmpName = element.GetValue(FrameworkElement.NameProperty) as String;
            if (tmpName==elementName)
            {
                return element;
            }
            while(elementQueue.Count>0)
            {
                var target = elementQueue.Dequeue();
                foreach (var child in target.GetChildren())
                {
                    var name = child.GetValue(FrameworkElement.NameProperty) as String;
                    if(name==elementName)
                    {
                        return child;
                    }
                    elementQueue.Enqueue(child);
                }

            }
            return null;
        }

        public static DependencyObject FindAncestorOfType(this DependencyObject element, Type locateType)
        {
            DependencyObject parent = element;

            do
            {
                parent = VisualTreeHelper.GetParent(parent);

                if (parent.GetType() == locateType)
                    return parent;
            } 
            while (parent != null);

            return null;
        }
    }
}
