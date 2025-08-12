using System.Security.Cryptography;
using System.Text;
using MediTrack.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace MediTrack.Data
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly DataContext _db;
        public UserAuthRepository(DataContext db)
        {
            _db = db;
        }

        public void CreateHashPassword(string newPassword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(newPassword));
            }

        }


    }
}
