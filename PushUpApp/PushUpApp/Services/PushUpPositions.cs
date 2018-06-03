using System;
using System.Collections.Generic;
using System.Text;
using DeviceMotion.Plugin.Abstractions;

namespace PushUpApp.Services
{
    public class PushUpPositions
    {
        public MotionVector Up { get; set; }
        public MotionVector Down { get; set; }

        public PushUpPositions()
        {
            Up = new MotionVector();
            Down = new MotionVector();
        }
    }
}
