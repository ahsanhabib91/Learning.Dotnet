using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dotnet
{
    public class TypeSystem
    {
        public TypeSystem()
        {
            var myName = "Habib";
            myName.ToUpper();
            Console.WriteLine(myName);

            // Boxing
            object o = 42;
            if (o is 42)
            {
                Console.WriteLine("Same!");
            }
            // Unboxing
            var n = (int)o;

            dynamic myDynamic = 45;
            myDynamic = "Ahsan";

            int n1 = 11;
            int n2 = n1;
            n2 = 15;
            Console.WriteLine($"n1: {n1}, n2: {n2}");
        }
    }
}
