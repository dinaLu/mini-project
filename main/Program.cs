using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using BL;

namespace PL
{
    class Program
    {
        static BL.IBL bl = FactoryBL.getInstance();
        static void Main(string[] args)
        {
            Nanny nanny = new Nanny
            {
                ID = 517400283,
                FirstName = "elana",
                LastName = "felsental",
                BirthDate = new DateTime(1997, 01, 13),
                PhoneNumber = "0586601950",
                Address = "midbar sinai 13",
                Elevator = false,
                Floor = 0,
                YearsOfExperience = 9,
                NumOfChildren = 12,
                MinAge = 2,
                MaxAge = 4,
                IfHourlyFee = false,
                HourlyFee = 0,
                MonthlyFee = 5000,
                WorkDays = new bool[] { false, true, true, true, false, false },
                DailyWorkHours = new int[,] { {0, 0}, { 8, 16 }, {9,13 }, {6,12 }, {9,13 }, {9,16 } },
              
                
              
            };

            Nanny nanny2 = new Nanny
            {
                ID = 20656099,
                FirstName = "elana",
                LastName = "felsental",
                BirthDate = new DateTime(1998, 01, 13),
                PhoneNumber = "0586601950",
                Address = "midbar sinai 13",
                Elevator = false,
                Floor = 0,
                YearsOfExperience = 9,
                MaxChildren = 12,
                MinAge = 2,
                MaxAge = 4,
                IfHourlyFee = true,
                HourlyFee = 62,
                MonthlyFee = 0,
                WorkDays = new bool[] { false, true, true, true, false, false },
                DailyWorkHours = new int[,] { { 0, 0 }, { 8, 16 }, { 9, 13 }, { 6, 12 }, { 9, 13 }, { 9, 16 } },
            };
            Console.WriteLine(nanny.ToString());

            Mother mother = new Mother
            {
                ID = 341421261,
                FirstName = "chana",
                LastName = "gross",
                PhoneNumber = "055544432",
                Address = "jerusalem",
                WorkDays = new bool[] { false, true, true, true, false, false },
                DailyWorkHours = new int[,] { { 0, 0 }, { 8, 16 }, { 9, 13 }, { 6, 12 }, { 0, 0 }, { 0, 0 } },
             
            };
            Console.WriteLine(mother.ToString());

            Mother mother2 = new Mother
            {
                ID =677754321,
                FirstName = "chana",
                LastName = "gross",
                PhoneNumber = "055544432",
                Address = "jerusalem",
                AroundAddress="beit shemsh",
                WorkDays = new bool[] { false, true, true, true, false, false },
                DailyWorkHours = new int[,] { { 0, 0 }, { 8, 16 }, { 9, 13 }, { 6, 12 }, { 0, 0 }, { 0, 0 } },
             
            };
            Console.WriteLine(mother.ToString());

            Child child = new Child
            {
                ID = 4444444,
                IdMother = 341421261,
                Name = "tal",
                DateOfBirth = new DateTime(2014, 04, 3),
                IsSpecialNeed = true,

            };
            Console.WriteLine(child.ToString());
            Child child2 = new Child
            {
                ID = 676777,
                IdMother = 341421261,
                Name = "tal",
                DateOfBirth = new DateTime(1993, 04, 3),
                IsSpecialNeed = false,
               
            };
            Console.WriteLine(child.ToString());


            Contract contract = new Contract
            {
                IdNanny = 666666,
                IdChild = 7654098,
                FirstMeeting = false,
                Signed = true,
                //ByHourOrByMonth = "hour",
                //HourlyFee =65,
                //MonthlyFee = 98765,
                StartingDate = new DateTime(2017, 06, 23),
                EndingDate = new DateTime(2018, 08, 23),
            };
            Console.WriteLine(contract.ToString());

            Contract contract2 = new Contract
            {
                IdNanny = 20656099,
                IdChild = 4444444,
                FirstMeeting = false,
                Signed = true,
                //HourlyFee = 65,
                
                //MonthlyFee = 98765,
                StartingDate = new DateTime(2017, 06, 23),
                EndingDate = new DateTime(2018, 08, 23),
            };
            Console.WriteLine(contract.ToString());
            try
            {
                bl.addNanny(nanny);
                bl.addNanny(nanny2);
                bl.addMother(mother);
                bl.addMother(mother2);
                bl.addChild(child);
                bl.addChild(child2);
                bl.addContract(contract2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
            //Console.WriteLine(DataSource.nannyList.Count());
            //bl.deleteNanny(nanny);
            //Console.WriteLine(DataSource.NannyList.Count());

        }
    }
}