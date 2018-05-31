using System;

namespace PushUpApp.Services
{
    class Vibrate : IVibrate
    {
        public Vibrate()
        {
            
        }

        public void Vibrate(int miliseconds)
        {
            try
            {
                // Use default vibration length
                Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}