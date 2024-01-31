using BlazorPOC_Net8Crud.Data;
using BlazorPOC_Net8Crud.IServices;
using BlazorPOC_Net8Crud.Model;
using BlazorPOC_Net8Crud.ViewModel;
using System.Security.Cryptography;

namespace BlazorPOC_Net8Crud.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        public UserService(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        private User FromUserRegisterModelToUserModel(UserVM userVM)
        {
            return new User
            {
                Email = userVM.Email,
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                Password = userVM.Password,
            };
        }
        private string HashPassword(string plainpassword)
        {



            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var rfcPassord = new Rfc2898DeriveBytes(plainpassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassord.GetBytes(20);

            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);

            return Convert.ToBase64String(passwordHash);
        }
        public async Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserVM userVM)
        {
            var isuserExist = _dbContext.User.Any(u => u.Email.ToLower() == userVM.Email.ToLower());
            if (isuserExist)
            {
                return (false, "Email Address Already Registered");
            }
            var NewUser = FromUserRegisterModelToUserModel(userVM);
            NewUser.Password = HashPassword(NewUser.Password);

            _dbContext.User.Add(NewUser);
            await _dbContext.SaveChangesAsync();

            return (true, "Success");
        }
       
    }
}
