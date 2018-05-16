using System;

namespace PushUpApp.Services
{
    public interface IPushUpObservable : IAcceleratorSubscriber
    {
        EventHandler<Position> OnUpPositionReached { get; set; }
    }

    public enum Position { Down, Up }

    class PushUpObservable : IPushUpObservable
    {
        private readonly PushUpPositions _pushUpPositions;
        public EventHandler<Position> OnUpPositionReached { get; set; }
        private bool _wasDownPosition;
        private bool _wasUpPosition;

        public PushUpObservable(PushUpPositions pushUpPositions)
        {
            _pushUpPositions = pushUpPositions;
        }

        public void Update(ThreeDimPosition position)
        {
            if (position.IsSimilarPositionTo(_pushUpPositions.Up) && !_wasUpPosition)
            {
                OnUpPositionReached(this, Position.Up);
                _wasDownPosition = false;
                _wasUpPosition = true;
            }
            if (position.IsSimilarPositionTo(_pushUpPositions.Down) && !_wasDownPosition)
            {
                OnUpPositionReached(this, Position.Down);
                _wasUpPosition = false;
                _wasDownPosition = true;
            }
        }
    }
}