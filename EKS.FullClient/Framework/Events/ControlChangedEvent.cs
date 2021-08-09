using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EKS.FullClient.Framework.Events
{
    // Element of EventAggregator pattern. Used for navigation between user controls
    public class ControlChangedEvent : PubSubEvent<UserControl>
    {
    }
}