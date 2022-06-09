using System.Collections.Generic;

namespace EducationalPracticeBL.Model
{
    public class ElectricityGeneration
    {
        public int Year { get; set; }
        public double Value { get; set; }
        //public Dictionary<int, double> DataDictionary { get; set; }
        public Country Country { get; set; }
    }
}
