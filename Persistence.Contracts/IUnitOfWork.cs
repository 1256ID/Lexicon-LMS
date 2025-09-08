using LMS.Shared.DTOs;

namespace Persistence.Contracts;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task CompleteAsync();
}