using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MonarchsProject.HttpHandler;
using MonarchsProject.Utility;


namespace MonarchsProject
{
    public static class Monarchs
    {
        public static async Task Main(string[] args)
        {
            //Making a call and getting the list
            var monarchs = await HttpRequestHelper.GetJsonKings(
                "https://gist.githubusercontent.com/christianpanton/10d65ccef9f29de3acd49d97ed423736/raw/b09563bc0c4b318132c7a738e679d4f984ef0048/kings",
                new HttpClient());

            //Calculating numbers of monarchs
            Console.WriteLine($"Total number of monarch extracted : {monarchs.Count} ");

            //Calculating longest reigning monarch
            var longestMonarch = monarchs.Select(m => new {m.Name, rule = Utils.CalculateYears(m.Years)})
                .OrderBy(o => o.rule).Last();
            Console.WriteLine($"Longest reigning monarch is {longestMonarch.Name} for {longestMonarch.rule} Years.");

            //Calculating longest reigning house
            var longestHouse = monarchs.Select(m => new {m.House, rule = Utils.CalculateYears(m.Years)})
                .GroupBy(g => g.House).Select(s => new {House = s.Key, Reign = s.Sum(x => x.rule)}).Last();
            Console.WriteLine(
                $"Longest reigning house is {longestHouse.House} and they have been reigning for {longestHouse.Reign} years.");

            //Calculating most common first name
            var mostCommonFirstName = monarchs.Select(m => new {firstname = Utils.ExtractFirstName(m.Name)})
                .GroupBy(g => g.firstname)
                .Select(s => new {name = s.Key, count = s.Count()})
                .OrderBy(o => o.count).Last();
            Console.WriteLine(
                $"Most common Firstname is {mostCommonFirstName.name} which was chosen by {mostCommonFirstName.count} monarchs.");
        }
    }
}