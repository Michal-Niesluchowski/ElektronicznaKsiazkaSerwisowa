using EKS.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.Events
{
    // Used to store new car data 
    class NewCarEvent : PubSubEvent<Car>
    {
    }
}
