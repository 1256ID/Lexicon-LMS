using LMS.Infractructure.Data;
using Persistence.Contracts;
using System.Runtime.CompilerServices;

namespace LMS.Infractructure.Repositories;
public class UnitOfWork
    (
        ApplicationDbContext context,
        IUserRepository userRepository
    ) 
        : IUnitOfWork
{
    public IUserRepository UserRepository => userRepository;
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}
