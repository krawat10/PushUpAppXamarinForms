namespace PushUpApp.Services
{
    public interface IAcceleratorSubscriber
    {
        void Update(IAcceleratorObtainer sender, object arg);
    }
}