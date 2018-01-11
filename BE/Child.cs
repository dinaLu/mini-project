using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int IdMother { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SpecialNeeds { get; set; }
        public bool IsSpecialNeed { get; set; }
        public string Allergies { get; set; }
        public bool pottyTrained { get; set; }
        public Child() {; }


        //public Child(int _id, int _idMother, string _name, DateTime _dateOfBirth, bool _isSpecialNeeds, string _specialNeeds = "")
        //{
        //    ID = _id;
        //    IdMother = _idMother;
        //    Name = _name;
        //    DateOfBirth = _dateOfBirth;
        //    IsSpecialNeed = _isSpecialNeeds;
        //    SpecialNeeds = _specialNeeds;
        //}


        public override string ToString()
        {
            return ID + " " +IdMother + " " + Name + " " + DateOfBirth + " " + IsSpecialNeed + " " + SpecialNeeds;
        }

    }
}
