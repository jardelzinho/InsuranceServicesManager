using Mobile.Core.Models.User;
using System.Threading.Tasks;

namespace Mobile.Core.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string authToken);
    }
}
