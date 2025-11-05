namespace RandomUserService.Core.Interfaces
{
    public interface IUserFetchScheduler
    {
        string Status { get; }

        void Start();

        void Pause();

        void Resume();
    }
}
