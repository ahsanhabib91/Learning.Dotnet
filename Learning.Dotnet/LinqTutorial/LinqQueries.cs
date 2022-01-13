using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Learning.Dotnet.LinqTutorial;

public class LinqQueries
{
    public CarData[]? Cars { get; set; }

    public LinqQueries()
    {
        var fileContent = File.ReadAllText("LinqTutorial/data.json");
        Cars = JsonSerializer.Deserialize<CarData[]>(fileContent);
        RunQueries();
    }

    void RunQueries()
    {
        var carsWithAtLeastFourDoors = Cars.Where(car => car.NumberOfDoors >= 4);
        var mazdaWithAtLeastFourDoors = Cars
            .Where(n => n.Make == "Mazda")
            .Where(car => car.NumberOfDoors >= 4);
            // PrintData(mazdaWithAtLeastFourDoors);
        
        // Cars.Where(car => car.Make.StartsWith("M"))
        //     .Select(car => $"{car.Make} {car.Model}")
        //     .ToList()
        //     .ForEach(car => Console.WriteLine(car));
        //
        // Cars.OrderByDescending(car => car.Hp)
        //     .Take(10)
        //     .Select(car => $"{car.Make} {car.Model}")
        //     .ToList()
        //     .ForEach(Console.WriteLine);
        //
        // Cars.GroupBy(car => car.Make)
        //     .ToList()
        //     .ForEach(car =>
        //     {
        //         foreach (var carData in car)
        //         {
        //             Console.WriteLine($"{car.Key}:{car.Count()}: {carData.Model}");
        //         }
        //     });
        //
        // Cars.Where(car => car.Year >= 1995)
        //     .GroupBy(car => car.Make)
        //     .Select(c => 
        //         new { c.Key, NumberOfModels = c.Count()}
        //     )
        //     .ToList()
        //     .ForEach(item => Console.WriteLine($"{item.Key}: {item.NumberOfModels}"));
        //
        // Cars.GroupBy(car => car.Make)
        //     .Select(c =>
        //         // new { c.Key, NumberOfModels = c.Where(car => car.Year >= 1995).Count()}
        //         new { CarMaker = c.Key, NumberOfModels = c.Count(car => car.Year >= 1995) }
        //     )
        //     .ToList()
        //     .ForEach(item => Console.WriteLine($"{item.CarMaker}: {item.NumberOfModels}"));

        // Display a list of Maker that have at least 2 models with >=400hp
        // Cars.Where(car => car.Hp >= 400)
        //     .GroupBy(car => car.Make)
        //     .Select(c => new { CarMaker = c.Key, NumberOfPowerfulCars = c.Count() })
        //     .Where(car => car.NumberOfPowerfulCars >= 2)
        //     .ToList()
        //     .ForEach(item => Console.WriteLine($"{item.CarMaker}: {item.NumberOfPowerfulCars}"));
        
        // Display the average hp per maker
        // Cars.GroupBy(car => car.Make)
        //     .Select(c => new { CarMaker = c.Key, AvgHp = c.Average(car => car.Hp) })
        //     .ToList()
        //     .ForEach(car => Console.WriteLine($"{car.CarMaker}: {car.AvgHp}"));
        
        //  How many Maker build cars with hp between 0..100, 101..200, 201..300, 301..400, 401..500
        Cars.GroupBy(car => car.Hp switch
            {
                <= 100 => "0..100",
                <= 200 => "101..200",
                <= 300 => "201..300",
                <= 400 => "301..400",
                _ => "401..500"
            })
            .Select(c => 
                new { HpCategory = c.Key, NumberOfMaker = c.Select(car => car.Make).Distinct().Count() })
            .ToList()
            .ForEach(car => Console.WriteLine($"{car.HpCategory}: {car.NumberOfMaker}"));

    }


    private void PrintData(IEnumerable<CarData> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine($"The car {car.Make},{car.Model} has {car.NumberOfDoors} doors");
        }
    }
}

public class CarData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("car_make")]
    public string Make { get; set; }
    [JsonPropertyName("car_models")]
    public string Model { get; set; }
    [JsonPropertyName("car_year")]
    public int Year { get; set; }
    [JsonPropertyName("number_of_doors")]
    public int NumberOfDoors { get; set; }
    [JsonPropertyName("hp")]
    public int Hp { get; set; }
}