using MediTrack.Models;
namespace MediTrack.Data
{
    public interface IUserAuthRepository
    {
        Task<User> RegisterUser(User user, string password);
        Task<bool> IfUserExist(string email);

        Task<User> LoginUser(string email, string password);
        //Task<User> Logout();


    }
}
