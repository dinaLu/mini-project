using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace DAL
{
    public interface IDAL
    {
        void addNanny(BE.Nanny nanny);
        void removeNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny);
        void addMother(BE.Mother m);
        void removeMother(BE.Mother m);
        void updateMother(BE.Mother m);
        void addChild(BE.Child ch);
        void removeChild(BE.Child ch);
        void updateChild(BE.Child ch);
        void addContract(BE.Contract ch);
        void removeContract(BE.Contract ch);
        void updateContract(BE.Contract ch);
        List<BE.Nanny> getNannyList();
        List<BE.Mother> getMotherList();
        List<BE.Child> getChildList();
        List<BE.Contract> getContractList();
        

    }


}
