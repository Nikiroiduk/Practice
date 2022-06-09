using EducationalPracticeBL.Data;

namespace EducationalPracticeCMD
{
    class Program
    {
        static void Main()
        {
            var test = ElectricityGenerationDataService.Load("C:/Users/Nikit/source/repos/Nikiroiduk/EducationalPractice/EducationalPracticeCMD/bin/Debug/EnergyStatistics.csv");
            ElectricityGenerationDataService.Save("C:/Users/Nikit/source/repos/Nikiroiduk/EducationalPractice/EducationalPracticeCMD/bin/Debug/EnergyStatisticsCreated.csv", test);
        }
    }
}
