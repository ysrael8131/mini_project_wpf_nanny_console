using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public DayOfWeek[] cc = new DayOfWeek[6];
        public Mother(int i = 0, string first = "", string last = "", string phone = "", string add = "", string seaadd = "", bool elev = false)
        {
            //id = i;
            //FirstName = first;
            //LastName = last;
            //PhoneNumber = phone;
            //Addres = add;
            //SearchAddres = seaadd;
            //elevators = elev;
            cc[0] = DayOfWeek.Sunday;
            cc[1] = DayOfWeek.Monday;
            cc[2] = DayOfWeek.Thursday;
            cc[3] = DayOfWeek.Wednesday;
            cc[4] = DayOfWeek.Tuesday;
            cc[5] = DayOfWeek.Friday;
            for (int j = 0; j < 6; j++)
            {
                arr[j] = new Work_information();
                arr[j].day = cc[j];
            }
        }
        public int? id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }
        public string Addres { set; get; }
        public string SearchAddres { set; get; }
        public bool elevators { set; get; }
        public int RangeOfKm { set; get; }
        public Work_information[] arr { get; set; } = new Work_information[6];
        
        
        public override string ToString()
        {
            return ("mother id: " + id.ToString() + '\n' +
                "name: " + FirstName + "  " + LastName 
                );
        }
    }
}
