using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public Child(int i = 0, int momI = 0, string first = "", string date = "1/1/2017", bool special = false)
        {
            //id = i;
            //MotherID = momI;
            //FirstName = first;
            //specialNeeds = specialNeeds;
            //birthDay = DateTime.Parse(date);
        }
        public int? id { set; get; }
        public int? MotherID { set; get; }
        public string FirstName { set; get; }
        public DateTime birthDay { set; get; }
        public bool specialNeeds { set; get; }
        public string detailsSpecialNeeds { set; get; }
        public override string ToString()
        {
            return ("child id:  " + id.ToString() + '\n' +
                "name: " + FirstName + '\n' +
                "birth day: " + birthDay);
        }
    }
}
