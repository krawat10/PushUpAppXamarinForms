using System.Collections.Generic;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms.Internals;

namespace PushUpApp.Services
{
    class AcceleratorReader : IAcceleratorObtainer
    {
        private readonly IList<IAcceleratorSubscriber> _subscribers;
        private readonly ThreeDimPosition _position;


        public AcceleratorReader(IDeviceMotion deviceMotion)
        {
            RegisterAccelerometer(deviceMotion);
            _subscribers = new List<IAcceleratorSubscriber>();
            _position = new ThreeDimPosition();
        }

        private void RegisterAccelerometer(IDeviceMotion deviceMotion)
        {
            deviceMotion.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Ui);
            deviceMotion.SensorValueChanged += DeviceMotionOnSensorValueChanged;
        }

        private void DeviceMotionOnSensorValueChanged(object sender, SensorValueChangedEventArgs e)
        {
            if (e.SensorType == MotionSensorType.Accelerometer)
            {
                _position.X = ((MotionVector) e.Value).X;
                _position.Y = ((MotionVector)e.Value).Y;
                _position.Z = ((MotionVector)e.Value).Z;
            }            

            NotifySubscribers();
        }

        public void NotifySubscribers()
        {
            _subscribers.ForEach(x => x.Update(this, _position));
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