using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { set; get; }
        public string AroundAddress { get; set; }//the address the mom wants the nanny to be close. if no special address -> mothers address
        private bool[] workDays = new bool[7]; //for each day if mother needs nanny
        public bool[] WorkDays { get; set; }
        private int[,] dailyWorkHours = new int[2, 6];//hours of every day that mother needs nanny
        public int[,] DailyWorkHours { get; set; }
        public double MaxDistance { get; set; }// the max distance between child and nanny
        public int IncomeLevel { get; set; }
        public Mother() {; }//default c-tor

        //public Mother(int _id, string _lastName, string _firstName, string _phoneNumber, string _address, string _aroundAddress, bool[] _workDays, int[,] _dailyWorkHours)
        //{
        //    ID = _id;
        //    LastName = _lastName;
        //    FirstName = _firstName;
        //    PhoneNumber = _phoneNumber;
        //    Address = _address;
        //    AroundAddress = _aroundAddress;
        //    for (int i = 0; i < 7; i++)
        //        workDays[i] = _workDays[i];
        //    for (int i = 0; i < 2; i++)
        //        for (int j = 0; j < 7; j++)
        //            dailyWorkHours[i, j] = _dailyWorkHours[i, j];
        //}
       
        public override string ToString()
        {
            return ID + " " + LastName + " " + FirstName + " " + PhoneNumber + " " + Address;
        }

    }
}
