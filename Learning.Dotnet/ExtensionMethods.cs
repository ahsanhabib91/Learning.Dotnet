using System;

namespace Learning.Dotnet
{
    public class ExtensionMethods
    {
        public ExtensionMethods()
        {
            var demo = "this is my message";
            demo.PrintToConsole();
        }
    }
    
    public static class Extensions
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }
}