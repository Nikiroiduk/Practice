using EducationalPracticeBL.Data;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace EducationalPracticeCMD
{
    class Program
    {
        static void Main()
        {
            var test = ElectricityGenerationDataService.Load("C:/Users/Nikit/source/repos/Nikiroiduk/EducationalPractice/EducationalPracticeCMD/bin/Debug/EnergyStatistics.csv");
            //foreach (var item in test)  
            //{
            //    foreach (var key in item.DataDictionary.Keys)
            //    {
            //        Console.Write($"{item.Country.Name} {item.Country.Code} {key} {item.DataDictionary[key]}\n");
            //    }
            //}
            ElectricityGenerationDataService.Save("C:/Users/Nikit/source/repos/Nikiroiduk/EducationalPractice/EducationalPracticeCMD/bin/Debug/EnergyStatisticsCreated.csv", test);
        }
    }
}
