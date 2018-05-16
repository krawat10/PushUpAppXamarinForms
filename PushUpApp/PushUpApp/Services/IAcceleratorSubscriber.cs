namespace PushUpApp.Services
{
    public interface IAcceleratorSubscriber
    {
        void Update(ThreeDimPosition position);
    }
}