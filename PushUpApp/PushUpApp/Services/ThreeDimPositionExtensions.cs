using System;

namespace PushUpApp.Services
{
    public static class ThreeDimPositionExtensions
    {
        public static ThreeDimPosition Deviation;

        static ThreeDimPositionExtensions()
        {
            Deviation = new ThreeDimPosition
            {
                X = 1,
                Y = 1,
                Z = 1
            };
        }

        public static bool IsSimilarPositionTo(this ThreeDimPosition positionOne, ThreeDimPosition positionTwo)
        {
            var isSimilarX = IsInRange(positionOne.X, positionTwo.X, Deviation.X);
            var isSimilarY = IsInRange(positionOne.Y, positionTwo.Y, Deviation.Y);
            var isSimilarZ = IsInRange(positionOne.Z, positionTwo.Z, Deviation.Z);

            return isSimilarX && isSimilarY && isSimilarZ;
        }

        private static bool IsInRange(double valueOne, double valueTwo, double deviation)
        {
            return Math.Abs(valueOne - valueTwo) < deviation;
        }
    }
}