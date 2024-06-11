using IpraAspNet.Domain.Entities;
using IpraAspNet.Domain.Interfaces;
using IpraAspNet.Application.Context;
using IpraAspNet.Infrastructure.Repositories;

namespace IpraAspNet.Application.Repositories;

public class UserRepository(IpraContext context): BaseRepository<User>(context, context.Users), IUserRepository
{
    
    public new IQueryable<User> GetAll() => context.Users;
}