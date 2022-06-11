﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_Add : Processor
    {

        public Activity_Add(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<Activity>>>> Post(Activity activity)
        {
            Response<List<Activity>> response;
            try
            {
                _context.Activities.Add(activity);
                _context.SaveChanges();

                var activities = await _context.Activities.ToListAsync();
                response = new Response<List<Activity>>(activities);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<Activity>>(ex, "Whoops, Something went wrong");
                return response;
            }

        }
    }
}