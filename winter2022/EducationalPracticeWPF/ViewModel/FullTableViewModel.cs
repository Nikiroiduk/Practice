using EducationalPracticeBL.Model;
using EducationalPracticeWPF.Model.Command;
using EducationalPracticeWPF.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EducationalPracticeWPF.ViewModel
{
    internal class FullTableViewModel : ViewModel
    {

        private readonly DialogVisitor Visitor = new();

        public FullTableViewModel(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            RemoveItem = new LambdaCommand(OnRemoveItem, CanRemoveItem);
            AddItem = new LambdaCommand(OnAddItem, CanAddItem);
            ChangeItem = new LambdaCommand(OnChangeItem, CanChangeItem);
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

        #region AddItem
        public ICommand AddItem { get; }

        private bool CanAddItem(object p) => true;
        private void OnAddItem(object p)
        {
            var tmp = p as ElectricityGeneration;
            ElectricityGeneration action = new() { Country = tmp.Country };
            action = Visitor.DynamicVisit(action) as ElectricityGeneration;
            if (action == null || action.Value <= 0)
                return;
            ListData.Add(action);
        }
        #endregion

        #region ChangeItem
        public ICommand ChangeItem { get; }

        private bool CanChangeItem(object p) => true;
        private void OnChangeItem(object p)
        {
            ElectricityGeneration action = p as ElectricityGeneration;
            action = Visitor.DynamicVisit(action) as ElectricityGeneration;
            if (action == null || action.Value <= 0)
                return;
        }
        #endregion
    }
}
