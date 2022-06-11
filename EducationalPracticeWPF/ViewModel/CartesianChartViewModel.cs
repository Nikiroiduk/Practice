using EducationalPracticeBL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPracticeWPF.ViewModel
{
    internal class CartesianChartViewModel : ViewModel
    {
        public CartesianChartViewModel(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            ListData = electricityGenerations;
        }

        #region ListData
        private ObservableCollection<ElectricityGeneration> _ListData;
        public ObservableCollection<ElectricityGeneration> ListData
        {
            get => _ListData;
            set => Set(ref _ListData, value);
        }
        #endregion
    }
}
