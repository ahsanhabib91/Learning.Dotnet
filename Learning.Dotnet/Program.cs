using System;
using System.Threading.Tasks;
using Learning.Dotnet.Configurations;

namespace Learning.Dotnet;

class Program
{
    static async Task Main(string[] args)
    {

        int? num = null;
        Console.WriteLine(num);

        // ExtensionMethods extensionMethods = new ExtensionMethods();

        // Params @params = new Params();

        // Configuration configuration = new Configuration(args);

        // var linqTutorial = new LinqTutorial.LinqTutorial();
        var linqQueries = new LinqTutorial.LinqQueries();
        return;

        //AutoMapperDemo demo = new AutoMapperDemo();
        
        // TypeSystem typeSystem = new TypeSystem();

        #region Generic
        Generics1<Person> g1 = new Generics1<Person>();
        //Generics1<int> g2 = new Generics<int>(); // compile-time error
        Generics1<string> g3 = new Generics1<string>();
        //Generics2<Person> g4 = new Generics2<Person>(); // compile-time error
        Generics2<int> g5 = new Generics2<int>(); // compile-time error
        Generics3<Person> g6 = new Generics3<Person>();
        #endregion

        #region Delegate
        Delegates delegates = new Delegates();
        MathOp add = Add;
        MathOp sub = Subtract;
        Console.WriteLine($"Delegates add: {add(45, 35)}, sub: {sub(45, 35)}");
        CalculateAndPrint(35, 25, Add);
        CalculateAndPrint(35, 25, Subtract);
        CalculateAndPrint(5, 5, (int x, int y) => x*y);
        CalculateAndPrint(7, 5, (x, y) => x*y); // compiler figures out the type of x and y through delegate defination
        CalculateAndPrint(25, 5, delegate (int x, int y) { return x/y; });
        CalculateAndPrintWithGeneric(45, 45, Add);
        CalculateAndPrintWithGeneric("A", "B", (x,y) => x+y);
        CalculateAndPrintWithGeneric(true, true, (x,y) => x && y);
        #endregion
        
    }

    // Delegate Lessons starts
    delegate int MathOp(int x, int y);
    delegate T Combine<T>(T a, T b);
    static void CalculateAndPrintWithGeneric<T>(T x, T y, Combine<T> f)
    {
        var result = f(x, y);
        Console.WriteLine($"Delegates CalculateAndPrintWithGeneric result: {result} ");
    }
    static void CalculateAndPrint(int x, int y, MathOp f) 
    {
        var result = f(x, y);
        Console.WriteLine($"Delegates CalculateAndPrint result: {result}");
    }
    static int Add(int x, int y)
    {
        return x + y;
    }
    static int Subtract(int a, int b)
    {
        return a - b;
    }
    // Delegate Lessons ends
}