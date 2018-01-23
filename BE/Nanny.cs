using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        

        public Nanny()
          
        {
            birthDay = DateTime.Now.AddYears(-60);
            

            for (int j = 0; j < 6; j++)
            {
                work[j] = new Work_information();
           
            }
        }
        public int? id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime birthDay { set; get; }
        public string PhoneNumber { set; get; }
        public string addres { set; get; }
        public bool elevators { set; get; }
        public int? floor { set; get; }
        public int years_of_experience { set; get; }
        public int maxChilds { set; get; }
        public int age_child_min { set; get; }
        public int age_child_max { set; get; }
        public bool per_hour_able { set; get; }
        public double? salaryPerHour { set; get; }
        public double? salaryPerMonth { set; get; }
        public bool vacation_kind { set; get; }
        public string recommendation { set; get; }
        public double distance { set; get; }
        public Work_information[] work { set; get; }= new Work_information[6];



        public override string ToString()
        {
            return base.ToString();
        }

    }
}
