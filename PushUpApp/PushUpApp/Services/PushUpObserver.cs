using System;
using DeviceMotion.Plugin.Abstractions;

namespace PushUpApp.Services
{
    class PushUpObserver : IAcceleratorSubscriber
    {
        private readonly PushUpPositions _pushUpPositions;
        public EventHandler<Position> OnPositionReached { get; set; }
        private bool _wasDownPosition;
        private bool _wasUpPosition;

        public PushUpObserver(PushUpPositions pushUpPositions)
        {
            _pushUpPositions = pushUpPositions;
        }

        public void Update(IAcceleratorObservable sender, object arg)
        {
            if (arg is MotionVector position)
            {
                if (position.IsSimilarPositionTo(_pushUpPositions.Up) && !_wasUpPosition)
                {
                    OnPositionReached(this, Position.Up);
                    _wasDownPosition = false;
                    _wasUpPosition = true;
                }
                if (position.IsSimilarPositionTo(_pushUpPositions.Down) && !_wasDownPosition)
                {
                    OnPositionReached(this, Position.Down);
                    _wasUpPosition = false;
                    _wasDownPosition = true;
                }
            }
        }
    }
}