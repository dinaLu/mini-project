using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        private static IBL instance = null;
        public static IBL getInstance()
        {
            if(instance==null)
            {
                instance = new Bl_imp();
            
            }
            return instance;
        }
    }
}
