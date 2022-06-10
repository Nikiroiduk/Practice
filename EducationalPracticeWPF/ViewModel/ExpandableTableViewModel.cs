using EducationalPracticeBL.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EducationalPracticeWPF.ViewModel
{
    internal class ExpandableTableViewModel : ViewModel
    {
        public ExpandableTableViewModel(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            ObservableCollectionData = electricityGenerations;
        }


        #region ObservableCollectionData
        private ObservableCollection<ElectricityGeneration> _ObservableCollectionData;

        public ObservableCollection<ElectricityGeneration> ObservableCollectionData
        {
            get => _ObservableCollectionData;
            set => Set(ref _ObservableCollectionData, value);
        }
        #endregion
    }
}
