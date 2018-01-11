using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public delegate bool someDelegate(Contract con);

    public interface IBL
    {
        void addNanny(Nanny nanny);
        void removeNanny(Nanny nanny);
        void updateNanny(Nanny nanny);
        void addMother(Mother m);
        void removeMother(Mother m);
        void updateMother(Mother m);
        void addChild(Child ch);
        void removeChild(Child ch);
        void updateChild(Child ch);
        void addContract(Contract ch);
        void removeContract(Contract ch);
        void updateContract(Contract ch);
        List<Nanny> getNannyList();
        List<Mother> getMotherList();
        List<Child> getChildList();
        List<Contract> getContractList();
        List<Nanny> fittingNanny(Mother m);
        List<Nanny> almostFittingNanny(Mother m);
        int degreeOfFittingNanny(Mother m, Nanny n);
        //List<Nanny> closeNannys(Mother mom);
        List<Child> nannylessChildren();
        List<Nanny> vaccationNannys();
        List<Contract> conditionContracts(someDelegate condition);
        int numConditionContracts(someDelegate condition);
        IEnumerable<IGrouping<int, Nanny>> ageGroup(bool ifOrdered, bool orderByMax);
        //IEnumerable<IGrouping<int, Contract>> distanceGroup(bool isOrdered);
    }
}
