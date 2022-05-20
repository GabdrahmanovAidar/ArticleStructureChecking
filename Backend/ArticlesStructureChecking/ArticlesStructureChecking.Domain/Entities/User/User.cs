using ArticlesStructureChecking.Domain.Enums;
using ArticlesStructureChecking.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace ArticlesStructureChecking.Domain.Entities.User
{
    public class User : IdentityUser<Guid>
    {
        protected User()
        {

        }
        public User(string username, string firstName, string middleName, string lastName, int statusId, string? phoneNumber = null, string? email = null)
        {
            UserName = username;
            NormalizedUserName = username;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            StatusId = statusId;
            CreatedAt = DateTime.UtcNow;
            PhoneNumberConfirmed = true;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string PasswordSalt { get; set; }
        public int StatusId { get; set; }
        public EUserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void SetPhoneConfirmed(bool confirmed)
        {
            PhoneNumberConfirmed = confirmed;
        }

        public void SetNewPassword(string password)
        {
            UpdatePassword(password);
        }

        public void HashPassword(string password)
        {
            if (!string.IsNullOrEmpty(PasswordSalt))
            {
                throw new BadRequestException("PasswordAllreadySet");
            }

            UpdatePassword(password);
        }

        public bool CheckPassword(string hashedPassword, string password)
        {
            return hashedPassword == GetHashedPassword(password);
        }

        private void UpdatePassword(string password)
        {
            var arrayLenght = 128 / 8;
            var salt = new byte[arrayLenght];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            PasswordSalt = Convert.ToBase64String(salt);
            PasswordHash = GetHashedPassword(password);
        }

        private string GetHashedPassword(string password)
        {
            using var hasher = new Rfc2898DeriveBytes(password, Convert.FromBase64String(PasswordSalt));
            return Convert.ToBase64String(hasher.GetBytes(256 / 8));
        }

        public void DeleteUser()
        {
            IsDeleted = true;
        }
    }
}
