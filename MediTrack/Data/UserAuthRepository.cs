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
         //public Task<IActionResult> Register (User user , string password)
         //{
            
         //}


    }
}
