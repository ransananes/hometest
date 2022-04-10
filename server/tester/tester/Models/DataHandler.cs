using System;
using tester.Enum;
using tester.Models.Operations;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace tester.Models
{
    public class DataHandler : Data
    {
        private int currentResult = 0;
        public string createFunction()
        {
            int currentOperation = 0;

            if (this.operations.Contains(defaultOperations.Multiply) || this.operations.Contains(defaultOperations.Divide)) checkForOrder();
            for (int i = 1; i < this.numbers.Count; i++)
            {
                // we have 2 numbers available to use
                if (this.currentResult == 0) this.currentResult += this.handleSimpleCalculation(this.numbers[i-1], this.operations[currentOperation], this.numbers[i]);
                else this.currentResult = this.handleSimpleCalculation(this.currentResult, this.operations[currentOperation], this.numbers[i]);
                currentOperation++;
            }
            string json = JsonConvert.SerializeObject(new Result {value = this.currentResult});
            return json;
        }


        public int handleSimpleCalculation(int x, String operation, int y)
        {
            int final_result = 0;
            OperationHandler handler;
            switch (operation)
            {
                case defaultOperations.Add:
                    handler = new OperationHandler(new Addition());
                    final_result = handler.calculate(x, y);
                    break;
                case defaultOperations.Substract:
                    handler = new OperationHandler(new Substract());
                    final_result = handler.calculate(x, y);
                    break;
                case defaultOperations.Divide:
                    handler = new OperationHandler(new Divide());
                    final_result = handler.calculate(x, y);
                    break;
                case defaultOperations.Multiply:
                    handler = new OperationHandler(new Multiply());
                    final_result = handler.calculate(x, y);
                    break;
                default:
                    break;
            }
            return final_result;
        }

        // do math order instead of normal order
        private void checkForOrder()
        {
            // j < numbers
            for (int j = 0; j < this.operations.Count; j++)
            {
                if (defaultOperations.complexOperations.Contains(this.operations[j]))
                {
                    this.currentResult += handleSimpleCalculation(this.numbers[j], this.operations[j], this.numbers[j + 1]);
                    String[] temp_operations = { this.operations[j] };
                    this.operations = this.operations.Except(temp_operations).ToList();

                    int[] temp_numbers = { this.numbers[j] };
                    this.numbers = this.numbers.Except(temp_numbers).ToList();
                }
            }
        }
    }
}