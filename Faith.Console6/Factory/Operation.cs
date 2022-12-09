using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Console6.Factory
{
    public abstract class Operation
    {
        public int numberA;
        public int numberB;
        public abstract int GetResult();
    }
    public class Addoperation : Operation
    {
        public override int GetResult()
        {
            return (this.numberA + this.numberB);
        }
    }
    public class SubOperation : Operation
    {
        public override int GetResult()
        {
            return (this.numberA - this.numberB);
        }
    }
    public class SampleFactory { 
        public static Operation CreateOperation(string opt) {
            Operation operation = null;
            switch (opt)
            {
                case "+":
                    operation = new Addoperation();
                    break;
                case "-":
                    operation = new SubOperation();
                    break;
                default:
                    break;
            }
            return operation;
        }

}
}
