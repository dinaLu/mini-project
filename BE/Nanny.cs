using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny:IComparable
    {
      
        public int MinAge { get; set; } //in months
        public int MaxAge { get; set; } //in months
        private bool[] workDays = new bool[7];
        public bool[] WorkDays { get; set; }
        private int[,] dailyWorkHours = new int[6, 2];
        public int[,] DailyWorkHours { get; set; }
        public bool OfficialVaccation { get; set; }
        public string Recommendation { get; set; }
        public int NumOfContracts { get; set; }
        public bool IfHourlyFee { get; set; }
        public int NumOfChildren { get; set; }
        public int YearsOfExperience { get; set; }
        public int Floor { get; set; }
        public bool Elevator { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public DateTime BirthDate { get; set; }
        public int MaxChildren { get; set; }
        public int MonthlyFee { get; set; }
        public int HourlyFee { get; set; }
        public bool BackYard { get; set; }
        public bool Lunch { get; set; }
        public bool kosherFood { get; set; }
        public List<string> Languages { get; set; }
        public Nanny() {;}

        //public Nanny(int _id, string _lastName, string _firstName, DateTime _birthDate, string _phoneNumber, string _address, bool _elevator, int _floor, int _yearsOfExerience, int _maxChildren, int _minAge, int _maxAge, bool _ifHourlyFee, int _hourlyFee, int _monthlyFee, bool[] _workDays, int[,] _dailyWorkHours, bool _officialVaccation, string _recommendation)
        //{
        //    ID = _id;
        //    LastName = _lastName;
        //    FirstName = _firstName;
        //    BirthDate = _birthDate;
        //    PhoneNumber = _phoneNumber;
        //    Address = _address;
        //    Elevator = _elevator;
        //    Floor = _floor;
        //    YearsOfExperience = _yearsOfExerience;
        //    MaxChildren = _maxChildren;
        //    MinAge = _minAge;
        //    MaxAge = _maxAge;
        //    IfHourlyFee = _ifHourlyFee;
        //    MonthlyFee = _monthlyFee;
        //    WorkDays = _workDays;
        //    DailyWorkHours = _dailyWorkHours;
        //    OfficialVaccation = _officialVaccation;
        //    Recommendation = _recommendation;
            

        //}
        
       
        public override string ToString()
        {
            return FirstName + ' ' + LastName + ' ' + ID + ' ' + PhoneNumber + ' ' +Address;
        }

        public int CompareTo(object obj)
        {
            return NumOfChildren.CompareTo(obj);
        }
    }
}
