using System.Collections.Generic;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms.Internals;

namespace PushUpApp.Services
{
    internal class AcceleratorReader : IAcceleratorObservable, IAcceleratorReader
    {
        private readonly IList<IAcceleratorSubscriber> _subscribers;

        public AcceleratorReader(IDeviceMotion deviceMotion)
        {
            Position = new MotionVector();
            _subscribers = new List<IAcceleratorSubscriber>();
            RegisterAccelerometer(deviceMotion);
        }

        public void NotifySubscribers()
        {
            _subscribers.ForEach(x => x.Update(this, Position));
        }

        public void AddSubscriber(IAcceleratorSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(IAcceleratorSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public MotionVector Position { get; set; }

        private void RegisterAccelerometer(IDeviceMotion deviceMotion)
        {
            deviceMotion.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
            deviceMotion.SensorValueChanged += DeviceMotionOnSensorValueChanged;
        }

        private void DeviceMotionOnSensorValueChanged(object sender, SensorValueChangedEventArgs e)
        {
            if (e.SensorType == MotionSensorType.Accelerometer)
            {
                Position = (MotionVector) e.Value;
            }
            NotifySubscribers();
        }
    }

    public interface IAcceleratorReader
    {
        MotionVector Position { get; set; }
    }
}