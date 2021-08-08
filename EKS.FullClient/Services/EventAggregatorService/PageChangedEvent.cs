using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.Services.EventAggregatorService
{
    // Used for navigation - sends new page to main window to be displayed in frame
    class PageChangedEvent : PubSubEvent<Page>
    {
    }
}