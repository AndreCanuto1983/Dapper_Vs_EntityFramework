using ProjectDapperVsEntityFramework.Application.Entities;

namespace ProjectDapperVsEntityFramework.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByEmail(string email);
        Task<IEnumerable<UserModel>> GetUsers();
    }
}
