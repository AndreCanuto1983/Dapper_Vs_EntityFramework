using ProjectDapperVsEntityFramework.Application.Entities;

namespace ProjectDapperVsEntityFramework.Application.Interfaces
{
    public interface IUserEfRepository
    {
        Task<UserModel> GetUserByEmail(string email);
        Task<IEnumerable<UserModel>> GetUsers();
    }
}
