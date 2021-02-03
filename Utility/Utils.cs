using System;

namespace MonarchsProject.Utility
{
    internal static class Utils
    {
        public static int CalculateYears(string years)
        {
            var yr = years.Split('-');
            try
            {
                return yr.Length switch
                {
                    1 => 1,
                    2 when string.IsNullOrEmpty(yr[1]) => DateTime.Now.Year - int.Parse(yr[0]),
                    _ => int.Parse(yr[1]) - int.Parse(yr[0])
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Warning: Unable to parse the year value : " + years);
                return -1;
            }
        }

        public static string ExtractFirstName(string name)
        {
            var nameSplit = name.Split(' ');
            return nameSplit[0].ToUpper();
        }
    }
}