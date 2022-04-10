using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tester.Models
{
    public class OperationHandler
    {
        // handler for operation
        Operation operate;

        public OperationHandler(Operation operate)
        {
            this.operate = operate;
        }

        public int calculate(int a, int b)
        {
            return this.operate.calculate(a, b);
        }
    }
}