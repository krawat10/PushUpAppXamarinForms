using System.Collections.Generic;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms.Internals;

namespace PushUpApp.Services
{
    class AcceleratorReader : IAcceleratorReader
    {
        private readonly IDeviceMotion _deviceMotion;
        private readonly IList<IAcceleratorSubscriber> _subscribers;
        public IEnumerable<IAcceleratorSubscriber> Subscribers => _subscribers;

        public AcceleratorReader(IDeviceMotion deviceMotion)
        {
            _deviceMotion = deviceMotion;
            _deviceMotion.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
            _deviceMotion.SensorValueChanged += DeviceMotionOnSensorValueChanged;
            _subscribers = new List<IAcceleratorSubscriber>();
            Position = new ThreeDimPosition();
        }

        public ThreeDimPosition Position { get; set; }

        private void DeviceMotionOnSensorValueChanged(object sender, SensorValueChangedEventArgs e)
        {
            if (e.SensorType == MotionSensorType.Accelerometer)
            {
                Position.X = ((MotionVector) e.Value).X;
                Position.Y = ((MotionVector)e.Value).Y;
                Position.Z = ((MotionVector)e.Value).Z;
            }            

            NotifySubscribers();
        }

        public void NotifySubscribers()
        {
            _subscribers.ForEach(x => x.Update(Position));
        }

        public void AddSubscriber(IAcceleratorSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(IAcceleratorSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}