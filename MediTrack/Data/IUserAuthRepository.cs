using MediTrack.Models;
namespace MediTrack.Data
{
    public interface IUserAuthRepository
    {
        Task<User> Register(User user, string password);
        //Task<User> Login(string email, string password);
        //Task<User> Logout();


    }
}
