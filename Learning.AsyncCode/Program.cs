const string fileLocation = "TextFile1.txt";

// var lines = File.ReadAllLines(fileLocation);
// foreach (var line in lines)
// {
//     Console.WriteLine(line);
// }


static async Task<int> GetDataFromNetworkAsync()
{
    // Simulate a network call
    await Task.Delay(150);

    return 45;
}
var networkResult = await GetDataFromNetworkAsync();
Console.WriteLine($"networkResult: {networkResult}");

Func<Task<int>> GetDataFromNetworkViaLambda = async () =>
{
    // Simulate a network call
    await Task.Delay(150);

    return 45;
};
var networkResultNetworkViaLambda = await GetDataFromNetworkViaLambda();
Console.WriteLine($"networkResultNetworkViaLambda: {networkResultNetworkViaLambda}");



// async Task ReadFile()
// {
//     // var lines = File.ReadAllLinesAsync(fileLocation).Result; // Blocks the CPU
//     var lines = await File.ReadAllLinesAsync(fileLocation);
//     foreach (var line in lines)
//     {
//         Console.WriteLine(line);
//     }
// }
// Console.WriteLine("Last command !!!!!!");
// await ReadFile();


// File.ReadAllLinesAsync(fileLocation)
//     .ContinueWith(t =>
//     {
//         if (t.IsFaulted)
//         {
//             Console.Error.WriteLine(t.Exception);
//         }
//         var lines = t.Result;
//         foreach (var line in lines)
//         {
//             Console.WriteLine(line);
//         }
//     });
// Console.WriteLine("Task Completed !!!!!!");
// Console.ReadKey();


// var fileReadTask = File.ReadAllLinesAsync(fileLocation);
// Console.WriteLine(fileReadTask.Status);
// Thread.Sleep(1);
// Console.WriteLine(fileReadTask.Status);
// fileReadTask.Wait(); // blocking
// var lines = fileReadTask.Result; // blocking
