using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Work_information
    {
        public TimeSpan start { set; get; }
        public TimeSpan end { set; get; }
        public bool day_work { set; get; }
        public DayOfWeek day { set; get; }
        public Work_information()
        {
            start = new TimeSpan();
            end = new TimeSpan();
        }
    } 
    
}
