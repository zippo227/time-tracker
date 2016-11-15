using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_tracker.Model
{
    class TaskModel
    {
        public string ID;
        public string Description { get; set; }
        public List<Tuple<DateTime, DateTime>> Times;

        public TaskModel(string description)
        {
            ID = Guid.NewGuid().ToString();
            Description = description;
            Times = new List<Tuple<DateTime, DateTime>>();
        }

        public string GetTimeString()
        {
            if(Times.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var time in Times)
                {
                    sb.Append($"{time.Item1}-{time.Item2}");
                }

                return sb.ToString();
            }
            else
            {
                return "No work yet";
            }
        }
    }
}
