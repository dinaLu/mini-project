using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryDal
    {
        private static IDAL instance = null;
        public static IDAL getInstance()
        { 
            if (instance == null)
            {
                instance = new Dal_imp();
            }
            return instance;
      
        }
    }
}
