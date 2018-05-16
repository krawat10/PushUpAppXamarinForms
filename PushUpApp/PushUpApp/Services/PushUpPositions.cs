using System;
using System.Collections.Generic;
using System.Text;

namespace PushUpApp.Services
{
    public class PushUpPositions
    {
        public ThreeDimPosition Up { get; set; }
        public ThreeDimPosition Down { get; set; }

        public PushUpPositions()
        {
            Up = new ThreeDimPosition();
            Down = new ThreeDimPosition();
        }
    }
}
