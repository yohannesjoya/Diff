

namespace Backend.Contracts;

public interface IUnitOfWork : IDisposable
    {


    IUserRepository UserRepository { get; }
    IOtpRepository OtpRepository { get; }


    Task Save();
    
}
