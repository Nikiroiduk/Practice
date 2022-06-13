using EducationalPracticeBL.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EducationalPracticeWPF.ViewModel
{
    internal class PieChartViewModel : ViewModel
    {
        public PieChartViewModel(ObservableCollection<ElectricityGeneration> electricityGenerations)
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

        

        #region ComboBoxData
        private List<int> _ComboBoxData;
        public List<int> ComboBoxData
        {
            get => ListData.Select(x => x.Year).Distinct().OrderBy(x => x).ToList();
            set => Set(ref _ComboBoxData, value);
        }
        #endregion

        #region ComboBoxSelected
        private int _ComboBoxSelected;
        public int ComboBoxSelected
        {
            get
            {
                return _ComboBoxSelected;
            }
            set
            {
                Set(ref _ComboBoxSelected, value);
                UpdatePieChart();
            }
        }
        #endregion

        #region PieChart
        private SeriesCollection _PieChart;
        public SeriesCollection PieChart
        {
            get => _PieChart;
            set => Set(ref _PieChart, value);
        }
        #endregion

        #region UpdatePieChart
        private void UpdatePieChart()
        {
            var meh = new SeriesCollection();

            var distinctValues = ListData.Select(p => p.Country.Name)
                                         .Distinct()
                                         .ToList();
            distinctValues.RemoveAt(0);

            foreach (var item in distinctValues)
            {
                var amount = (from x in ListData
                              where x.Year == ComboBoxSelected
                              where x.Country.Name == item
                              select x.Value).Sum();
                meh.Add(new PieSeries
                {
                    Title = item,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(amount) }
                });
            }
            PieChart = meh;
        }
        #endregion
    }
}
