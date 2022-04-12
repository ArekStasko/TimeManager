using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.DataAccess.models.activity
{
    public interface IActivity
    {
        public int Id { get; set; }
        public string ActName { get; set; }
        public string ActDesc { get; set; }
        public string Category { get; set; }
    }
}
