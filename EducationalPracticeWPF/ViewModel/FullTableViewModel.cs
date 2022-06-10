using EducationalPracticeBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPracticeWPF.ViewModel
{
    internal class FullTableViewModel : ViewModel
    {
        public FullTableViewModel(List<ElectricityGeneration> electricityGenerations)
        {
            ListData = electricityGenerations;
        }

        #region ListData
        private List<ElectricityGeneration> _ListData = null;
        public List<ElectricityGeneration> ListData
        {
            get => _ListData;
            set => Set(ref _ListData, value);
        }
        #endregion
    }
}
