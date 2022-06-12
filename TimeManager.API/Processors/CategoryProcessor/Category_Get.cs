﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.CategoryProcessor.Interfaces;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Get : Processor, ICategory_Get
    {
        public Category_Get(DataContext context) : base(context) {}

        public async Task<ActionResult<Response<List<Category>>>> Get()
        {
            Response<List<Category>> response;
            try
            {
                var categories = await _context.Categories.ToListAsync();
                response = new Response<List<Category>>(categories);

                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<Category>>(ex, "Whoops, something went wrong");
                return response;
            }
        }
    }
}
