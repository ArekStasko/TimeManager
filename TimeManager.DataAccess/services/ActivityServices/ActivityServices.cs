﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.DataAccess.data.Activity;

namespace TimeManager.DataAccess.services.ActivityServices
{
    public class ActivityServices : IActivityServices
    {
        private Activity db = new Activity();

        public IEnumerable<Activity> GetActivities()
        {
            
        }
    }
}
