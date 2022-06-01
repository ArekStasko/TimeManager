using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_Processor
    {
        protected readonly DataContext _context;

        public Activity_Processor(DataContext context)
        {
            _context = context;
        }
    }
}
