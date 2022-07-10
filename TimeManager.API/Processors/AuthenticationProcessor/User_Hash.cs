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

        public bool VerifyPasswordHash(UserDTO data)
        {
            Tuple<byte[], byte[]> hash = CreatePasswordHash(data.Password);
            var user = _context.Users.FirstOrDefault(u => u.UserName == data.UserName);

            using (var hmac = new HMACSHA512(hash.Item2))
            {
                var computedHash = user.PasswordHash;
                return computedHash.SequenceEqual(hash.Item1);
            }
        }
    }
}
