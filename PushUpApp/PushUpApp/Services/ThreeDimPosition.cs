﻿namespace PushUpApp.Services
{
    public class ThreeDimPosition
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public ThreeDimPosition()
        {

        }

        public ThreeDimPosition(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}