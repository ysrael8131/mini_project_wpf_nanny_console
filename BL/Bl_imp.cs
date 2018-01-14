using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
namespace BL
{
    public class Bl_imp : IBL
    {

        DAL.IDAL dal = DAL.FactoryDal.getDal();
        


        public void addChild(Child a)
        {
            dal.addChild(a);
        }
        /// <summary>
        /// func to insert contract
        /// </summary>
        /// <param name="a"></param>
        public void addContract(Contract a)
        {
            Child temp1 = dal.getChild(a.childID);
            Nanny temp2 = dal.getNanny(a.NannyID);
            //check the age child that more 3 months 
            if (DateTime.Compare(DateTime.Now.AddMonths(-3), temp1.birthDay) == -1)
            {
                throw new Exception("the age of the child is less than 3 month");
            }
            //Checks if children are in range
            if (DateTime.Now.AddMonths(-temp2.age_child_max) > temp1.birthDay
                && DateTime.Now.AddMonths(-temp2.age_child_min) < temp1.birthDay)
                throw new Exception("The child is not within the age range of the nanny");
            IEnumerable<Contract> con = dal.getListContracts();
            var contract = from item in con
                           where item.NannyID == a.NannyID
                           select item;
            //the number of contracts
            int sumcontract = contract.Count();
            //The number of children of the mother
            int sumChildsPerMother = contract.Count
                (

                    item => item.MotherID == temp1.MotherID
                );
            //Checks if there is an excess of children
            if (sumcontract + 1 > temp2.maxChilds)
            {
                throw new Exception("the nanny has the max of contracts");
            }
            //Calculation of salary
            switch (a.ContracPer)
            {
                case contracPer.perMonth:
                    a.salaryPerMonth = (1 - (sumChildsPerMother * 0.02)) * temp2.salaryPerMonth;
                    break;
                case contracPer.perHour:
                    TimeSpan time = new TimeSpan();
                    foreach (var item in temp2.work)
                    {
                        if (item.day_work)
                        {
                            time += (item.end - item.start);
                        }
                    }

                    a.salaryPerMonth = (temp2.salaryPerHour * (time.Hours + (time.Minutes / 60)) * 4) * ((1 - sumChildsPerMother) * 0.02);
                    break;
            }
            a.MotherID = temp1.MotherID;
            dal.addContract(a);

        }
        /// <summary>
        /// func to insert mothers
        /// </summary>
        /// <param name="a"></param>
        public void addMother(Mother a)
        {
            dal.addMother(a);
        }
        /// <summary>
        /// func to insert nannys 
        /// </summary>
        /// <param name="a"></param>
        public void addNanny(Nanny a)
        {
            //Check if age nanny is less than 18
            if (DateTime.Compare(DateTime.Now.AddYears(-18), a.birthDay) == -1)
                throw new Exception("Can not register a nanny under age 18");
            dal.addNanny(a);
        }
        /// <summary>
        /// remove child by id child
        /// </summary>
        /// <param name="id"></param>
        public void deleteChild(int? id)
        {
            List<Contract> temp = (dal.getListContracts().Where(item => item.childID == id)).ToList();
            if (temp.Count != 0)
                dal.deleteContract(temp[0].num_contract);                                            
            dal.deleteChild(id);


        }
        /// <summary>
        /// remove contrct by num of contract 
        /// </summary>
        /// <param name="numContract"></param>
        public void deleteContract(int numContract)
        {
            dal.deleteContract(numContract);
        }
        /// <summary>
        /// remove mother by id of mother
        /// </summary>
        /// <param name="id"></param>
        public void deleteMother(int id)
        {
            Mother temp = dal.getMother(id);
            dal.deleteMother(id);
            var childsPerMother = dal.getListChilds(temp);

            foreach (var item in childsPerMother)
            {
                deleteChild(item.id);
            }

        }

        /// <summary>
        /// remove nanny by id nanny
        /// </summary>
        /// <param name="id"></param>
        public void deleteNanny(int id)
        {
            List<Contract> temp = (dal.getListContracts().Where(item => item.NannyID == id)).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                dal.deleteContract(temp[i].num_contract);
            }

            dal.deleteNanny(id);
        }

        public Child getChild(int? id)
        {
            return dal.getChild(id);
        }

        public Mother getMother(int? id)
        {
            return dal.getMother(id);
        }
        public Contract getContract(int num_contract)
        {
            return dal.getContract(num_contract);
        }
        public Nanny getNanny(int? id)
        {
            return dal.getNanny(id);
        }

        public IEnumerable<Child> getListChilds(Mother a)
        {
            return dal.getListChilds(a);
        }

        public IEnumerable<Contract> getListContracts()
        {
            return dal.getListContracts();
        }

        public IEnumerable<Mother> getListMothers()
        {
            return dal.getListMothers();
        }

        public IEnumerable<Nanny> getListNannys()
        {
            return dal.getListNannys();
        }

        public IEnumerable<Child> getListChild2()
        {
            return dal.getListChild2();
        }


        public void updateChild(Child a)
        {
            dal.updateChild(a);
        }

        public void updateContract(Contract a)
        {
            dal.updateContract(a);
        }

        public void updateMother(Mother a)
        {
            dal.updateMother(a);
        }

        public void updateNanny(Nanny a)
        {
            dal.updateNanny(a);
        }
        /// <summary>
        /// Returns all the nannies according to the mother's constraints
        /// according to work hours
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<Nanny> requiredMother(Mother a)
        {
            IEnumerable<Child> child = dal.getListChilds(a);
            IEnumerable<Nanny> nannys = dal.getListNannys();
            Func<Nanny, Mother, bool> func1 = myFunc1;
            Func<Nanny, Mother, bool> func2 = myFunc2;
            var nan = from i in nannys
                      where func1(i, a)
                      select i;
            if (nan != null)
            {
                return nan;
            }
            nan = from i in nannys
                  where func2(i, a)
                  select i;
            return nan;
        }
        /// <summary>
        /// Returns all the children without a nanny
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Child> withoutNanny()
        {
            List<Child> temp = new List<Child>();
            IEnumerable<Child> childs = dal.getListChild2();
            var child = from item in childs
                        where helpFunc1(item.id)
                        select item;
            return temp.ToList();

        }
        /// <summary>
        /// Auxiliary function for the previous function
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool helpFunc1(int? id)
        {

            foreach (var item in dal.getListContracts())
            {
                if (item.childID == id)
                    return false;
            }
            return true;

        }
        /// <summary>
        /// Returns all caregivers who are vacationing by 'TAMT'
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Nanny> vacationKind()
        {
            return dal.getListNannys().Where
                (
                item => item.vacation_kind == true
                );
        }
        /// <summary>
        /// Function that returns a distance between 2 addresses
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
        /// <summary>
        /// A function that returns all caregivers in the desired range
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Nanny> rangeNanny(int id)
        {
            Mother temp = dal.getMother(id);
            IEnumerable<Nanny> nanny = dal.getListNannys();
            if (temp.SearchAddres != null)
            {
                var distance1 = from item in nanny
                                let distanceNanny = (CalculateDistance(item.addres, temp.SearchAddres)) / 1000
                                orderby distanceNanny
                                where distanceNanny <= temp.RangeOfKm
                                select item;
                return distance1;
            }
            var distance2 = from item in nanny
                            let distanceNanny = (CalculateDistance(item.addres, temp.Addres)) / 1000
                            orderby distanceNanny
                            where distanceNanny <= temp.RangeOfKm
                            select item;

            return distance2;


        }


        Func<Contract, bool> func = (item => item.contractSigne == true);


        public IEnumerable<Contract> allContractCondtion()
        {
            return dal.getListContracts().Where(func);
        }

        public int sumContrctCondtion()
        {
            return dal.getListContracts().Count(func);
        }
        /// <summary>
        /// All contracts to be completed
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<Contract> finishContract(int month)
        {
            return dal.getListContracts().Where
                (
                item => item.end.AddMonths(-month) == DateTime.Now
                );



        }
        static bool myFunc2(Nanny nan, Mother mom)
        {
            for (int i = 0; i < nan.work.Length; i++)
            {
                if (nan.work[i].start.Minutes - mom.arr[i].start.Minutes > 15 &&
                    mom.arr[i].end.Minutes - nan.work[i].end.Minutes > 15 )
                    return false;
            }
            return true;
        }
        static bool myFunc1(Nanny nan, Mother mom)
        {
            for (int i = 0; i < nan.work.Length; i++)
            {
                if (nan.work[i].day_work != mom.arr[i].day_work &&
                    mom.arr[i].start < nan.work[i].start &&
                    nan.work[i].end < mom.arr[i].end)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Create a group of nannies by key
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Nanny>> groupingNanny(bool b = false)
        {
            IEnumerable<Nanny> nanny = dal.getListNannys();
            Func<Nanny, bool, int> func = myFunc;
            var nannys = from item in nanny
                         let a = func(item, b)
                         group item by a;
            return nannys;
        }
        static int myFunc(Nanny nan, bool b)
        {
            if (b)
                return nan.age_child_max;
            return nan.age_child_min;
        }
        /// <summary>
        /// All nannies have an elevator in the building
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public IEnumerable<Nanny> accessibility(int floor)
        {
            return dal.getListNannys().Where
                (
                item => item.floor <= floor || item.elevators == true
                ).ToList();
        }
        /// <summary>
        /// Create a set of contracts by distance
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Contract>> groupingContract(bool b = false)
        {
            IEnumerable<Contract> con = dal.getListContracts();
            var contract = from item in con
                           let distance = CalculateDistance(dal.getNanny(item.NannyID).addres,
                           dal.getMother(item.MotherID).SearchAddres)
                           group item by ((distance / 1000) / 2) * 2;
            if (b == true)
            {
                var sortGroup = from item in contract
                                orderby item.Key
                                select item;
                return sortGroup;
            }
            return contract;
        }
        /// <summary>
        /// Calculate the full payment of the mother
        /// </summary>
        /// <param name="motherID"></param>
        /// <returns></returns>
        public double totalPay(int motherID)
        {
            double temp = 0;
            foreach (var item in dal.getListContracts())
            {
                if (item.MotherID == motherID)
                {
                    temp += item.salaryPerMonth;
                }
            }
            return temp;
        }

    }
}