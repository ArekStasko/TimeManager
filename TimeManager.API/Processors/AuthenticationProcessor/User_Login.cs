using TimeManager.API.Data.Response;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.AuthenticationProcessor
{
    public class User_Login : Processor
    {
        public User_Login(DataContext context) : base(context) { }
        public Response<string> Login(UserDTO data)
        {
            Response<string> response;
            try
            {
                User_Hash userHash = new User_Hash(_context);

                if (userHash.VerifyPasswordHash(data))
                {

                    response = new Response<string>("dziala lol");
                    return response;
                }

                throw new Exception("User not found !");
            }
            catch (Exception ex)
            {
                response = new Response<string>(ex, "Whoops something went wrong");
                return response;
            }
        }
    }
}
