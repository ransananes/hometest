using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tester.Enum;

namespace tester.Models
{
    public abstract class Operation
    {
        public abstract int calculate(int x, int y);
    }
}