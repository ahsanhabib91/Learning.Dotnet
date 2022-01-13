using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dotnet;
/*
 * Delegate is a type defination for a Method/Function.
 * Delegate knows the input parameter and returned value type
 * All the functions which shares the same parameters, they fullfill contract of a Delegate
 * Higher Order Function: A function that returns a function
 */
public class Delegates
{
    public Delegates()
    {
        var heroes = new List<Hero>
        {
            new("Bruce", "Wayn", "Batman", false),
            new("Clerk", "Kant", "Superman", true),
            new(string.Empty, string.Empty, "Homelander", false),
            new(string.Empty, string.Empty, "Stormfront", true)
        };
        var result = Filter(heroes, h => string.IsNullOrEmpty(h.LastName));
        var resultWithYield = FilterWithYield(heroes, h => string.IsNullOrEmpty(h.LastName));
        var heroesWhoCanFly = string.Join(",", result);
        Console.WriteLine(heroesWhoCanFly);

        Console.WriteLine(
            string.Join(",", Filter(new[] { 1, 2, 3, 4, 5 }, n => n % 2 == 0))
            );
        Console.WriteLine(
            string.Join(",", FilterWithYield(new[] { 1, 2, 3, 4, 5 }, n => n % 2 == 0))
            );

        CalculateR(5);
        // MeasureTime(() => CountToInNearlyfinity());
        // MeasureTime(CountToInNearlyfinity);
        // MeasureTimeFunc(CalculateSomeResult);

        Action a = () => Console.WriteLine("Hello World from Aciton delegate"); // Action is returning void
        a();

        // Closures
        Func<int, int> calculator = CreateCalculator();
        Console.WriteLine($"calculator: {calculator(2)}");
    }

    Func<int, int> CreateCalculator()
    {
        const int factor = 5;
        return n => n * factor;
    }

    // Linq: Where
    IEnumerable<T> Filter<T>(IEnumerable<T> items, Filter<T> f)
    {
        var resultList = new List<T>();
        foreach (var item in items)
        {
            if (f(item))
            {
                resultList.Add(item);
            }
        }
        return resultList;
    }
    // Linq: Where
    IEnumerable<T> FilterWithYield<T>(IEnumerable<T> items, Func<T, bool> f) // Func is a builtin delegate
    {
        foreach (var item in items)
        {
            if (f(item))
            {
                yield return item;
            }
        }
    }
    void MeasureTime(Action a)
    {
        var watch = Stopwatch.StartNew();
        a();
        watch.Stop();
        Console.WriteLine($"Time Elapsed: {watch.Elapsed}");
    }
    int MeasureTimeFunc(Func<int> f)
    {
        var watch = Stopwatch.StartNew();
        var result = f();
        watch.Stop();
        Console.WriteLine($"Time Elapsed: {watch.Elapsed}, result: {result}");
        return result;
    }
    void CountToInNearlyfinity()
    {
        for (int i = 0; i < int.MaxValue; i++) ;
    }
    int CalculateSomeResult()
    {
        for (int i = 0; i < int.MaxValue; i++) ;
        return int.MaxValue;
    }

    int CalculateR(int n)
    {
        if (n == 0) return 1;

        var factor = 3;
        var result = factor * CalculateR(n - 1);
        Console.WriteLine($"CalculateR: n:{n}, result: {result}");
        return result;
    }
}

delegate bool Filter<T>(T h);
record Hero(string FirstName, string LastName, string HeroName, bool CanFly);
