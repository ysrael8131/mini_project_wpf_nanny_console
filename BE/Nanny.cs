using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        public Nanny(int i = 0, string first = "", string last = "", string birth = "1/1/2010",
          int phone = 0, string add = "", bool elev = false,
          int flo = 0, int exp = 0, int max = 0, int agemin = 0,
          int agemax = 0, bool per = false, double salhour = 0,
          double samonth = 0, bool vaca = false, string rec = null)
        {
            id = i;
            FirstName = first;
            LastName = last;
            birthDay = DateTime.Parse(birth);
            PhoneNumber = phone;
            addres = add;
            elevators = elev;
            floor = flo;
            years_of_experience = exp;
            maxChilds = max;
            age_child_min = agemin;
            age_child_max = agemax;
            per_hour_able = per;
            salaryPerHour = salhour;
            salaryPerMonth = samonth;
            vacation_kind = vaca;
            recommendation = rec;
        }
        public int id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime birthDay { set; get; }
        public int PhoneNumber { set; get; }
        public string addres { set; get; }
        public bool elevators { set; get; }
        public int floor { set; get; }
        public int years_of_experience { set; get; }
        public int maxChilds { set; get; }
        public int age_child_min { set; get; }
        public int age_child_max { set; get; }
        public bool per_hour_able { set; get; }
        public double salaryPerHour { set; get; }
        public double salaryPerMonth { set; get; }
        public bool vacation_kind { set; get; }
        public string recommendation { set; get; }

        public Work_information[] work = new Work_information[6];


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
