using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Learning.Dotnet.LinqTutorial
{
    public class LinqTutorial
    {
        public int Count { get; set; }
        public LinqTutorial()
        {
            var result = GenerateNumbers(10);
            var even = true;
            if (even)
            {
                result = result.Where(n => n % 2 == 0);
            }
            result = result.Select(n => n * 3);
            
            Console.WriteLine($"Total Count:{result.Count()}");
            
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        IEnumerable<int> GenerateNumbers(int maxValue)
        {
            Console.WriteLine($"count: {Count++}");
            for (var i = 0; i < maxValue; i++)
            {
                yield return i;
            }
        }

        private void Testing()
        {
            var myFamilies = new List<MyFamily>();
            myFamilies.Add(new MyFamily()
            {
                Name = "F1",
                Parent = new[]
                {
                    new Parent() { FamilyName = "F11", FirstName = "P11" },
                    new Parent() { FamilyName = "F12", FirstName = "P12" }
                }
            });
            myFamilies.Add(new MyFamily()
            {
                Name = "F2",
                Parent = new[]
                {
                    new Parent() { FamilyName = "F21", FirstName = "P21" },
                    new Parent() { FamilyName = "F22", FirstName = "P22" }
                }
            });
            myFamilies.Add(new MyFamily()
            {
                Name = "F3",
                Parent = new[]
                {
                    new Parent() { FamilyName = "F31", FirstName = "P31" },
                    new Parent() { FamilyName = "F32", FirstName = "P32" }
                }
            });
            var query1 = from family in myFamilies
                where family.Name == "F3"
                select family;
            
            var query2 = query1.SelectMany(
                f => f.Parent.Where(p => p.FirstName == "P32"), (family, parent) => family
            );
            
            foreach (var myFamily in query2)
            {
                Console.WriteLine(JsonConvert.SerializeObject(myFamily));
            }
        }
    }
    
    class MyFamily
    {
        public String Name { get; set; }
        public Parent[] Parent { get; set; }
    }
    
    public class Parent
    {
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
    }
}