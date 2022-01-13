using System;
using System.Collections.Generic;

namespace Learning.Dotnet
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params
    public class Params
    {
        public Params()
        {
            // You can send a comma-separated list of arguments of the
            // specified type.
            UseParams(1, 2, 3, 4);
            UseParams2(1, 'a', "test");

            // A params parameter accepts zero or more arguments.
            // The following calling statement displays only a blank line.
            UseParams2();

            // An array argument can be passed, as long as the array
            // type matches the parameter type of the method being called.
            int[] myIntArray = { 5, 6, 7, 8, 9 };
            UseParams(myIntArray);

            object[] myObjArray = { 2, 'b', "test", "again" };
            UseParams2(myObjArray);

            // The following call causes a compiler error because the object
            // array cannot be converted into an integer array.
            //UseParams(myObjArray);

            // The following call does not cause an error, but the entire
            // integer array becomes the first element of the params array.
            UseParams2(myIntArray);
            
            
            DateTime from = DateTime.UtcNow.AddHours(-12);
            DateTime to = DateTime.UtcNow;
            KeyValuePair<string, object>[] parameterizedKeyValuePairs =
            {
                new KeyValuePair<string, object>("@GatewayId", "123"),
                new KeyValuePair<string, object>("@from", from.ToString("O")),
                new KeyValuePair<string, object>("@to", to.ToString("O"))
            };
            
            UseParams3(parameterizedKeyValuePairs);
        }
        
        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        
        public static void UseParams3(params KeyValuePair<string, object>[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine($"{parameter.Key}: {parameter.Value}");
            }
            Console.WriteLine();
        }
    }
}