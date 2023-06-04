using EducationalPracticeBL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPracticeWPF.Service
{
    public static class ExerciseService
    {
        public static List<ElectricityGeneration> Exercise1(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            var result = new List<ElectricityGeneration>();
            var tmp = electricityGenerations
                .Select(x => x)
                .Where(x => x.Year == 2015)
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Key)
                .FirstOrDefault() ?? Enumerable.Empty<ElectricityGeneration>();
            result = tmp.ToList();
            return result;
        }
        public static List<ElectricityGeneration> Exercise2(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            var tmp = electricityGenerations
                .Select(x => x)
                .Where(x => x.Year == 2015)
                .Where(x => x.Value >= 70)
                .ToList();
            return tmp;
        }
        public static List<ElectricityGeneration> Exercise3(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            var tmp = electricityGenerations
                .Select(x => x)
                .Where(x => x.Year == 2010)
                .Where(x => x.Value < 100)
                .ToList();
            return tmp;
        }
    }
}
