using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Group1
{
    class Data
    {
        public int hour { set; get; }
        public int distance { set; get; }

        public override string ToString()
        {
            return hour.ToString() + ":" + distance.ToString();
        }
    }
}
