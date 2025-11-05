namespace RandomUserService.Core.Interfaces
{
    public interface IScheduler
    {
        string Status { get; }

        void Start();

        void Pause();

        void Resume();
    }
}
