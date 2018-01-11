using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        static private int contractNumber=1234; //so?
        public int ContractNumber
        {
            get { return contractNumber; }
            set
            {
                contractNumber++;
            }
        }
        public DateTime EndingDate { set; get; }
        public DateTime StartingDate { get; set; }
        //public double HourlyFee { get; set; }
        public bool Signed { get; set; }
        public bool FirstMeeting { get; set; }
        public int IdNanny { get; set; }
        public int IdChild { get; set; }
        public double Salary { get; set; }
        public string motherPhone { get; set; }
        public string fatherPhone { get; set; }

        //public string ByHourOrByMonth { get; set; }
 
        public override string ToString()
        {
            return contractNumber.ToString() + ' ' + IdNanny + ' ' + IdChild;
        }
    }
}
