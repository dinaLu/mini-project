using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi;

namespace BL
{

    class Bl_imp : IBL
    {

        string source;
        string dest;
        TravelType travelType;
        int distance = -1;
        private TimeSpan duration;

        DAL.IDAL dal = FactoryDal.getInstance();
        //someDelegate codition = new someDelegate(sum);

        public void addNanny(Nanny nanny)
        {
            TimeSpan age = DateTime.Now - nanny.BirthDate;
            if ((age.Days / 365) >= 18)
            {
                try
                {
                    dal.addNanny(nanny);
                }
                catch (Exception E)
                {
                    throw E;
                }
            }
            else
            {
                throw new Exception("nanny is too young!");
            }
        }
        public void removeNanny(Nanny nanny)
        {
            //find all the contract associated wuth this nanny
            var nannysCon = from n in getContractList()
                            where n.IdNanny == nanny.ID
                            select n;
            //delete all found contract 
            try
            {
                foreach (Contract c in nannysCon)
                {
                    removeContract(c);
                }
            }
            catch (Exception e) { throw e; }
            try
            {
                dal.removeNanny(nanny);
            }
            catch (Exception e) { throw e; }

        }
        public void updateNanny(Nanny nanny)
        {

            try { dal.updateNanny(nanny); }
            catch (Exception e) { throw e; };
        }
        public void addMother(Mother mom)
        {
            try { dal.addMother(mom); }
            catch (Exception e) { throw e; };
        }
        public void removeMother(Mother mom)
        {
            //find all mothers' children
            var momsChild = from c in getChildList()
                            where c.IdMother == mom.ID
                            select c;
            //delete all mothers' children
            try
            {
                foreach (Child ch in momsChild)
                    removeChild(ch);
            }
            catch (Exception e) { throw e; }

            try { dal.removeMother(mom); }
            catch (Exception e) { throw e; };
        }
        public void updateMother(Mother mom)
        {
            try { dal.updateMother(mom); }
            catch (Exception e) { throw e; };
        }
        public void addChild(Child ch)
        {
            //if mother is not in the list yet
            Mother m = getMotherList().Find(x => x.ID == ch.IdMother);
            if (m == null)
            {
                throw new Exception("child's mother doesn't exist in the system yet. add the mother first");
            }

            //if child is too young (under 3 month old)
            int years = DateTime.Now.Year - ch.DateOfBirth.Year;
            int months = DateTime.Now.Month - ch.DateOfBirth.Month;
            if ((years < 1 && months < 3) || (years == 1 && months<-9)/* || (DateTime.Now.Month - ch.DateOfBirth.Month == 3 && DateTime.Now.Day - ch.DateOfBirth.Day < 0)*/)
            {
                Exception e = new Exception("child is too young!");
                throw e;
            }
            try
            {
                dal.addChild(ch);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void removeChild(Child ch)
        {
            //find all the contracts with this child
            var childCon = from c in getContractList()
                           where c.IdChild == ch.ID
                           select c;
            try//remove all the contracts associated with the removed child
            {
                foreach (Contract con in childCon)
                    removeContract(con);
                dal.removeChild(ch);
            }
            catch (Exception e) { throw e; }

        }
        public void updateChild(Child ch)
        {
            try { dal.updateChild(ch); }
            catch (Exception e) { throw e; };
        }
        public void addContract(Contract con)
        {
            List<Contract> conList = getContractList();
            Nanny nanny = getNannyList().Find(x => x.ID == con.IdNanny);
            Child child = getChildList().Find(x => x.ID == con.IdChild);
            Mother mother = getMotherList().Find(x => x.ID == child.IdMother);
            if (nanny == null)
            {
                throw new Exception("nanny does not exist in the system");
            }
            if (child == null)
            {
                throw new Exception("child does not exist in the system");
            }
            if (mother == null)
            {
                throw new Exception("mother does not exist in the system");
            }

            //if nanny has max number of children already
            if (nanny.NumOfChildren == nanny.MaxChildren)
            {
                throw new Exception("nanny can not take any more children!");
            }

            //if child is too old or too young for nanny
            if (child.DateOfBirth.Month < nanny.MinAge || child.DateOfBirth.Month > nanny.MaxAge)
            {

                throw new Exception("nanny does not take children at this age!"); ;
            }


            //calculating salary
            if (!nanny.IfHourlyFee)
            {
                con.Salary = nanny.MonthlyFee;
            }
            else
            {
                con.Salary = sumWorkHoursPerMonth(nanny) * nanny.HourlyFee;
            }

            //discount if several siblings have this same nanny
            int numOfSiblings = (from c in conList
                                 where c.IdNanny == con.IdNanny //find contracts with the same nannys
                                 from ch in getChildList()
                                 where ch.ID == c.IdChild //find child who has the same nanny
                                 where ch.IdMother == child.IdMother //if child has also the same mother
                                 select c).Count();
            con.Salary -= con.Salary * numOfSiblings * 0.02;
            try { dal.addContract(con); }
            catch(Exception e) { throw e; }
        }

        public void removeContract(Contract con)
        {
            try { dal.removeContract(con); }
            catch (Exception e) { throw e; };
        }
        public void updateContract(Contract con)
        {
            try { dal.updateContract(con); }
            catch (Exception e) { throw e; };
        }
        public List<Nanny> getNannyList()
        {
            try { return dal.getNannyList(); }
            catch (Exception e) { throw e; };
        }
        public List<Mother> getMotherList()
        {
            try { return dal.getMotherList(); }
            catch (Exception e) { throw e; };
        }
        public List<Child> getChildList()
        {
            try { return dal.getChildList(); }
            catch (Exception e) { throw e; };
        }
        public List<Contract> getContractList()
        {
            try { return dal.getContractList(); }
            catch (Exception e) { throw e; };
        }
        //public /*static*/ int calculateDistance(string source, string dest)
        //{
        //    var drivingDirectionRequest = new DirectionsRequest
        //    {
        //        TravelMode = TravelMode.Walking,
        //        Origin = source,
        //        Destination = dest,
        //    };
        //    DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
        //    Route route = drivingDirections.Routes.First();
        //    Leg leg = route.Legs.First();
        //    return leg.Distance.Value;
        //}

        // return the nannys that fit prefectly in terms of days and work hours
        public List<Nanny> fittingNanny(Mother m)
        {
            var fitNanny = from n in getNannyList()
                           where fittingDaysAndHours(m, n)
                           select n;
            return fitNanny.ToList();

        }
        public bool fittingDaysAndHours(Mother m, Nanny n)
        {
            //check if work days match(nanny can work more than mother asks for)
            for (int i = 0; i < 7; i++)
            {
                if ((m.WorkDays[i] && !n.WorkDays[i]))
                {
                    return false;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (m.DailyWorkHours[0, i] < n.DailyWorkHours[0, i] || m.DailyWorkHours[1, i] > n.DailyWorkHours[1, i])
                    return false;
            }
            return true;
        }
        public List<Nanny> almostFittingNanny(Mother m)
        {
            List<Nanny> afNannyLst = null;
            int[] scoreArr = new int[getNannyList().Count()];
            for (int i = 0; i < getNannyList().Count(); i++) //adding scores of nannys at the same indexes as the nannys in the nannylist
                scoreArr[i] = degreeOfFittingNanny(m, getNannyList()[i]);
            for (int j = 0; j < 5; j++)
            {
                afNannyLst.Add(getNannyList()[Array.IndexOf(scoreArr, scoreArr.Min())]); //adding the nanny with the lowest score to afNannyList
                scoreArr[Array.IndexOf(scoreArr, scoreArr.Min())] = 1000;
            }
            return afNannyLst;
        }
        public int degreeOfFittingNanny(Mother m, Nanny n) //the less points, the better is the match
        {
            int score = 0;
            for (int i = 0; i < 7; i++)
            {
                if ((m.WorkDays[i] && !n.WorkDays[i])) //mismatch in workdays
                {
                    score += 3;
                }
            }
            for (int i = 0; i < 6; i++) //mismatch in workhours
            {
                if (m.DailyWorkHours[0, i] < n.DailyWorkHours[0, i])
                    score += n.DailyWorkHours[0, i] - m.DailyWorkHours[0, i];
                if (m.DailyWorkHours[1, i] > n.DailyWorkHours[1, i])
                    score += m.DailyWorkHours[1, i] - n.DailyWorkHours[1, i];
            }
            return score;

        }
        //public List<Nanny> closeNannys(Mother mom)
        //{
        //    var closeLst = from n in getNannyList()
        //                   where calculateDistance(mom.AroundAddress, n.Address) <= mom.MaxDistance
        //                   select n;
        //    return closeLst.ToList();
        //}
        public List<Child> nannylessChildren()
        {
            List<Child> nlessChildLst = null;
            foreach (Child c in getChildList())
            {
                if (getContractList().Find(x => x.IdChild == c.ID) == null)
                    nlessChildLst.Add(c);

            }
            return nlessChildLst;

        }
        public List<Nanny> vaccationNannys()
        {
            var vacNannyList = from n in getNannyList()
                               where n.OfficialVaccation
                               select n;
            return vacNannyList.ToList();
        }
        public List<Contract> conditionContracts(someDelegate del)
        {
            var condList = from c in getContractList()
                           where del(c)
                           select c;
            return condList.ToList();
        }
        public int numConditionContracts(someDelegate del)
        {
            try { return conditionContracts(del).Count(); }
            catch (Exception e) { throw e; };
        }

        //calculates the total work hours per month
        public int sumWorkHoursPerMonth(Nanny n)
        {
            int sum = 0;
            for (int i = 0; i < 6; i++)
            {
                sum += n.DailyWorkHours[i, 0];
                sum += n.DailyWorkHours[i, 1];
            }
            return sum * 4;
        }


        //nannys grouped by min/max age of the children they take
        public IEnumerable<IGrouping<int, Nanny>> ageGroup(bool isOrdered, bool minAge)
        {
            IEnumerable<IGrouping<int, Nanny>> nannyGroup = null;

            if (minAge)
            {
                nannyGroup = from n in getNannyList()
                             group n by n.MinAge;
            }
            else //maxAge
            {
                nannyGroup = from n in getNannyList()
                             group n by n.MaxAge;
            }
            if (isOrdered)
            {
                var orderedNannyGroup = from n in nannyGroup
                                        orderby n.Key
                                        select n;
                return orderedNannyGroup;
            }
            return nannyGroup;
        }







        //------------------------------------Google maps-------------------------------------

        //public IEnumerable<IGrouping<int, Contract>> distanceGroup(bool isOrdered) //ev. ändern, schon drinnen ordnen
        //{
        //    var contractGroup = from c in getContractList()
        //                        let child = getChildList().Find(x => x.ID == c.IdChild)
        //                        let source = getMotherList().Find(x => x.ID == child.IdMother).Address
        //                        let dest = getNannyList().Find(x => x.ID == c.IdNanny).Address
        //                        group c by tryDistance(this, EventArgs e) / 5;
        //    if(isOrdered)
        //    {
        //        var orderedContractGroup = from c in contractGroup
        //                                   orderby c.Key
        //                                   select c;
        //        return orderedContractGroup;
        //    }
        //    return contractGroup;
        //}

        //thread

        //private void tryDistance(object sender, EventArgs e)
        //{

        //    System.ComponentModel.BackgroundWorker work = new System.ComponentModel.BackgroundWorker();
        //    work.DoWork += W_DoWork;
        //    work.RunWorkerCompleted += W_RunWorkerCompleted;
        //    work.RunWorkerAsync();

        //}

        //private void W_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        return GoogleApiFunc.CalcDistance(source, dest, travelType);
        //        //duration = algo.GoogleApiFunc.CalcDuration(source, dest, travelType);
        //    }
        //    catch (Exception)
        //    {
        //        return -1;
        //    }
        //}
        //    private void W_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //    {
        //        if (distance != -1)
        //        {
        //            if (distance < 1000)
        //                distanceResult.Content = distance + " meters";
        //            else
        //                distanceResult.Content = distance / 1000.0 + " km";

        //            durationResult.Content = duration.ToString();
        //        }
        //        else
        //        {
        //            distanceResult.Content = "no result";
        //            durationResult.Content = "no result";
        //        }
        //    }


        //}
    }
}
