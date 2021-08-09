using EKS.BackEnd.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.Events
{
    // // Element of EventAggregator pattern. Used to store data of new car
    public class NewCarEvent : PubSubEvent<Car>
    {
    }
}
