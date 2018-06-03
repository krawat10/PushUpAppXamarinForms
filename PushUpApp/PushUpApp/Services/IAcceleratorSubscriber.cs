namespace PushUpApp.Services
{
    public interface IAcceleratorSubscriber
    {
        void Update(IAcceleratorObservable sender, object arg);
    }
}