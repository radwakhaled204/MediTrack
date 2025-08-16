using System.Security.Cryptography;
using System.Text;
using MediTrack.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MediTrack.Data
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly DataContext _db;
        public UserAuthRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<User> RegisterUser(User user, string password)
        {
            CreateHashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.password_hash = passwordHash;
            user.password_salt = passwordSalt;
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }


        public async Task<User> LoginUser(string email, string password)
        {
            var user = await _db.users.FirstOrDefaultAsync(e => e.email == email);
            if (user == null || !VerifyPassword(password, user.password_hash, user.password_salt))
            {
                return null;

            }
            return user;

        }
        public void CreateHashPassword(string newPassword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(newPassword));
            }

        }
        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var returnedHash = hash.SequenceEqual(storedHash);
                return returnedHash;
            }
        }
        public async Task<bool> IfUserExist(string email)
        {
            return await _db.users.AnyAsync(u => u.email == email);
        }
        public async Task<string> ChangePasswordForUser(int userId ,string oldPasssword, string newPassword)
        {
            var user = await _db.users.FirstOrDefaultAsync(u => u.user_id == userId);
            if (user == null) return "User not found.";

            if (!VerifyPassword(oldPasssword , user.password_hash , user.password_salt)) 
                return "Old password is incorrect.";

            else
            {
                 CreateHashPassword(newPassword, out byte[] newHash, out byte[] newSalt);
                user.password_hash = newHash;   
                user.password_salt = newSalt;
                await _db.SaveChangesAsync();
            }
            return "Password Changed Successfully.";

        }
    }
}
