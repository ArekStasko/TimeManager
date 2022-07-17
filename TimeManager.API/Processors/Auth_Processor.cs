using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors
{
    public class Auth_Processor : Processor
    {
        public Auth_Processor(DataContext context) : base(context) { }

        
    }
}
