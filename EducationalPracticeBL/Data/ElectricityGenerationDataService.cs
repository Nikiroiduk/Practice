using EducationalPracticeBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EducationalPracticeBL.Data
{
    public static class ElectricityGenerationDataService
    {
        public static bool Save(string path, List<ElectricityGeneration> electricityGenerations)
        {
            if (electricityGenerations == null) return false;
            using (FileStream fileStream = File.Create(path))
            {
                foreach (var item in electricityGenerations)
                {
                    AddText(fileStream, $"{item.Country.Name},{item.Country.Code},{item.Year},{item.Value}");
                    //foreach (var key in item.DataDictionary.Keys)
                    //{
                    //    AddText(fileStream, $"{item.Country.Name},{item.Country.Code},{key},{item.DataDictionary[key]}");
                    //}
                }
            }
            return true;
        }

        public static string CreateCSVText(List<ElectricityGeneration> electricityGenerations)
        {
            var result = "";
            
            foreach (var item in electricityGenerations)
            {
                result += $"{item.Country.Name}\t{item.Country.Code}\t{item.Year}\t{item.Value}\tTW/h\n";
            }
            return result;
        }

        public static List<ElectricityGeneration> Load(string path)
        {
            List<ElectricityGeneration> result = new();
            UTF8Encoding temp = new(true);
            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] b = new byte[fileStream.Length];
                while(fileStream.Read(b, 0, b.Length) > 0){
                    var separators = new char[] { '\n', ',' };
                    var line = temp.GetString(b).Split(separators);
                    for (int i = 0; i < line.Length - 1; i+=4)
                    {
                        result.Add(new ElectricityGeneration
                        {
                            Country = new Country { Code = line[i + 1], Name = line[i] },
                            Year = Convert.ToInt32(line[i + 2]),
                            Value = Convert.ToDouble(line[i + 3])
                        });
                    }
                }
            }
            return result;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value + "\n");
            fs.Write(info, 0, info.Length);
        }
    }
}
