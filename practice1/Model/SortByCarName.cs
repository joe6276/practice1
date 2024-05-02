using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1.Model
{
    public class SortByCarName : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
           return x.Name.CompareTo(y.Name);
        }
    }
}
