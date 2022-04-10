using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tester.Models.Operations
{
    class Multiply : Operation
    {
        public override int calculate(int x, int y)
        {
            return x * y;
        }
    }
}