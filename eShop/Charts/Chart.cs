using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Charts
{
    public class Chart
    {
        public int red {get;set;}
        public int yellow { get; set; }
        public int green { get; set; }

        public Chart(int _do, int _vang, int _xanh)
        {
            red = _do;
            yellow = _vang;
            green = _xanh;
        }

    }
}
