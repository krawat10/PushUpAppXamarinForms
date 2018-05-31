using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PushUpApp.Services
{
    public interface IAcceleratorObtainer
    {
        void NotifySubscribers();
        void AddSubscriber(IAcceleratorSubscriber subscriber);
        void RemoveSubscriber(IAcceleratorSubscriber subscriber);
    }
}
