using EducationalPracticeBL.Model;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPracticeBL.Data
{
    public static class StatisticSerializer
    {
        public static bool Serialize(string path, List<ElectricityGeneration> statistic)
        {
            statistic = new List<ElectricityGeneration>()
            {
                new ElectricityGeneration(){Country = new Country() {Code = "USA", Name="United States", Region=new Region() {Name="America"}}, DataDictionary = new Dictionary<int, double>()}
            };
            var meh = CsvSerializer.SerializeToCsv<ElectricityGeneration>(statistic);
            return true;
        }

        public static ElectricityGeneration Deserialize()
        {
            return null;
        }
    }
}
