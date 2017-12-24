using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public Mother(int i = 0, string first = "", string last = "", int phone = 0, string add = "", string seaadd = "", bool elev = false)
        {
            id = i;
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
            Addres = add;
            SearchAddres = seaadd;
            elevators = elev;
        }
        public int id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int PhoneNumber { set; get; }
        public string Addres { set; get; }
        public string SearchAddres { set; get; }
        public bool elevators { set; get; }
        public int RangeOfKm { set; get; }
        public List<Work_information> list = new List<Work_information>();

        public override string ToString()
        {
            return ("mother id: " + id.ToString() + '\n' +
                "name: " + FirstName + "  " + LastName);
        }
    }
}
