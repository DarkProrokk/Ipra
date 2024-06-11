using IpraAspNet.Domain.Entities;

namespace IpraAspNet.Domain.Interfaces;

public interface IUserRepository: IBaseRepository<User>
{
    public new IQueryable<User> GetAll();
}