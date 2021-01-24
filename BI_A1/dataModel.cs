using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_A1
{
    class DataModel
    {
        public  string Country { set; get; }
        public  int Output { set; get; }

        public DataModel(string coun, int output)
        {
            this.Country = coun;
            this.Output = output;
        }
    }
}
