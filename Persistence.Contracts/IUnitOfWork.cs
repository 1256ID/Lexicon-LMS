using LMS.Shared.DTOs;

namespace Persistence.Contracts;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }

    ICourseRepository CourseRepository { get; }
    Task CompleteAsync();
}