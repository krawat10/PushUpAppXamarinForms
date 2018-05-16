using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PushUpApp.Services
{
    public interface IAcceleratorReader
    {
        ThreeDimPosition Position { get; set; }
        IEnumerable<IAcceleratorSubscriber> Subscribers { get; }

        void NotifySubscribers();
        void AddSubscriber(IAcceleratorSubscriber subscriber);
        void RemoveSubscriber(IAcceleratorSubscriber subscriber);
    }
}
