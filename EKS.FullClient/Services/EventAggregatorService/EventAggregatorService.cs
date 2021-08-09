using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Services.EventAggregatorService
{
    public static class EventAggregatorService
    {
        private static IEventAggregator _eventAggregator = new EventAggregator();

        public static IEventAggregator GetInstance { get { return _eventAggregator; } }
    }
}
