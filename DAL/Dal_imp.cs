using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dal_imp:IDAL
    {
        Exception e;
        DS.DataSource ds = new DS.DataSource();

        public void addNanny(Nanny nanny)
        {
            if(ds.nannyList.Contains(nanny))
            {
                throw new Exception("nanny already exist in the system");
            }
            ds.nannyList.Add(nanny);
        }
        public void removeNanny(Nanny nanny)
        {
            if (ds.nannyList.Contains(nanny))
            {
                ds.nannyList.Remove(nanny);
            }
            else
            {
                throw new Exception("nanny does not exist in the system");
            }
            
        }
        public void updateNanny(Nanny nanny)
        {
            Nanny n = ds.nannyList.Find(x => x.ID == nanny.ID);
            if (n == null)
                throw new Exception("nanny does not exist in the system");
            ds.nannyList.Remove(n);
            ds.nannyList.Add(nanny);
           
        }
        public void addMother(Mother mother)
        {
            Mother M = ds.motherList.Find(x => x.ID == mother.ID);
            if(M!=null)
            {
                throw new Exception("mother already exists in the system");
            }
            ds.motherList.Add(mother);
        }
        public void removeMother(Mother mother)
        {
            Mother M = ds.motherList.Find(x => x.ID == mother.ID);
            if (M == null)
            {
                throw new Exception("mother does not exist in the system");
            }
             ds.motherList.Remove(mother);
        
        }
        public void updateMother(Mother mother)
        {
            Mother M = ds.motherList.Find(x => x.ID == mother.ID);
            if (M == null)
            {
                throw new Exception("mother does not exist in the system");
            }
            ds.motherList.Remove(M);
            ds.motherList.Add(mother);
          
        }
        public void addChild(Child ch)
        {
            Child c = ds.childList.Find(x => x.ID == ch.ID);
            if(c!=null)
            {
                throw new Exception("child already exists in the system");
            }
            ds.childList.Add(ch);
        }
        public void removeChild(Child child)
        {
            Child c = ds.childList.Find(x => x.ID == child.ID);
            if (c == null)
            {
                throw new Exception("child does not exist in the system");
            }
            ds.childList.Remove(child);
           
        }
        public void updateChild(Child child)
        {
            Child c = ds.childList.Find(x => x.ID == child.ID);
            if (c == null)
            {
                throw new Exception("child does not exist in the system");
            }
            ds.childList.Remove(c);
            ds.childList.Add(child);

        }
        public void addContract(Contract contract)
        {
            if (ds.contractList.Contains(contract))
            {
                throw new Exception("contract already exists");
            }            
        }
        public void removeContract(Contract contract)
        {
            if (ds.contractList.Contains(contract))
            {
                ds.contractList.Remove(contract);
            }
            else
                throw new Exception("contract does not exist in the system");

        }
        public void updateContract(Contract con)
        {
            Contract c = ds.contractList.Find(x => x.ContractNumber == con.ContractNumber);
            if(c==null)
            {
                throw new Exception("contract does not exist in the system");
            }
            ds.contractList.Remove(c);
            ds.contractList.Add(con);
        }

        public List<Nanny> getNannyList()
        {
            return ds.nannyList;
        }
        public List<Mother> getMotherList()
        {
            return ds.motherList;
        }
        public List<Child> getChildList()
        {
            return ds.childList;
        }
        public List<Contract> getContractList()
        {
            return ds.contractList;
        }


    }
}
