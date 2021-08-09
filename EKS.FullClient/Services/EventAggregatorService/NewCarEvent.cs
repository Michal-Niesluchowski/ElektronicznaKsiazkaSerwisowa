using EKS.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Services.EventAggregatorService
{
    // Used to store new car data 
    public class NewCarEvent : PubSubEvent<Car>
    {
    }
}
