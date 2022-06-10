using EducationalPracticeBL.Model;
using EducationalPracticeWPF.Model.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EducationalPracticeWPF.ViewModel
{
    internal class FullTableViewModel : ViewModel
    {
        public FullTableViewModel(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            RemoveItem = new LambdaCommand(OnRemoveItem, CanRemoveItem);
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


        #region RemoveItem
        public ICommand RemoveItem { get; }

        private bool CanRemoveItem(object p) => true;
        private void OnRemoveItem(object p)
        {
            if (p != null)
                ListData.Remove(p as ElectricityGeneration);
        }
        #endregion
    }
}
