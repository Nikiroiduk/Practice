using EducationalPracticeBL.Data;
using System;
using System.IO;
using System.Reflection;

namespace EducationalPracticeCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            StatisticSerializer.Serialize(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), null);
        }
    }
}
