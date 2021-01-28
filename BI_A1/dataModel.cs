/*===============================================================
 * fileName: dataModel.cs
 * Description: this file provide a simple class used as data model
 ===============================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_A1
{
    public class DataModel
    {
        public  string Name { set; get; }
        public  int Output { set; get; }

        public DataModel(string name, int output)
        {
            this.Name = name;
            this.Output = output;
        }
    }
}
