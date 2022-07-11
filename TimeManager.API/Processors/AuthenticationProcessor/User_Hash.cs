using System.Security.Cryptography;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.AuthenticationProcessor
{
    public class User_Hash : Processor
    {
        public User_Hash(DataContext context) : base(context) { }
        public Tuple<byte[], byte[]> CreatePasswordHash(string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return new Tuple<byte[], byte[]>(passwordHash, passwordSalt);
        }

        public bool VerifyPasswordHash(string password, User user)
        {         
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }
    }
}
