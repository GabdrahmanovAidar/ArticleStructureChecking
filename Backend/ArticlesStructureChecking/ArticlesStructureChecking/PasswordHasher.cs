using ArticlesStructureChecking.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace ArticlesStructureChecking
{
    public class PasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password)
        {
            user.HashPassword(password);

            return user.PasswordHash;
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            var isCorrectPassword = user.CheckPassword(hashedPassword, providedPassword);

            return isCorrectPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
