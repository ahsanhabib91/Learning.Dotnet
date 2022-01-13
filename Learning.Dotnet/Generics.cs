using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.tutorialsteacher.com/csharp/constraints-in-generic-csharp

namespace Learning.Dotnet;
internal class Generics1<T> where T : class // only a reference type can be passed as an argument i.e. as T, not value type
{
    public T Data { get; set; }
}

internal class Generics2<T> where T : struct // non-nullable value types such as primitive data types int, char, bool, float, etc.
{
    public T Data { get; set; }
}

internal class Generics3<T> where T : class, new()
{
    public T Data { get; set; }
}

class Person 
{
    public string Username { get; set; }
}

