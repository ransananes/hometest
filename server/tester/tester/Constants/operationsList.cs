using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tester.Enum
{

    struct defaultOperations
    {
        public const string Add = "+";
        public const string Substract = "-";
        public const string Multiply = "*";
        public const string Divide = "/";
        public static readonly string[] availableOperations = { defaultOperations.Add, defaultOperations.Substract, defaultOperations.Multiply, defaultOperations.Divide};
        public static readonly string[] complexOperations = {defaultOperations.Multiply, defaultOperations.Divide};

    }

}