using EducationalPracticeBL.Data;
using EducationalPracticeBL.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPracticeWPF.ViewModel
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            ListData = ElectricityGenerationDataService.Load("C:/Users/Nikit/source/repos/Nikiroiduk/EducationalPractice/EducationalPracticeCMD/bin/Debug/EnergyStatistics.csv");
            UpdateIncomePieChart();
        }


        #region ListData
        private List<ElectricityGeneration> _ListData;
        public List<ElectricityGeneration> ListData
        {
            get => _ListData;
            set => Set(ref _ListData, value);
        }
        #endregion

        #region IncomePieChart
        private SeriesCollection _IncomePieChart;
        public SeriesCollection IncomePieChart
        {
            get => _IncomePieChart;
            set => Set(ref _IncomePieChart, value);
        }
        #endregion

        #region UpdateIncomePieChart
        private void UpdateIncomePieChart()
        {
            var meh = new SeriesCollection();

            var distinctValues = ListData.Select(p => p.Country.Name)
                                         .Distinct()
                                         .ToList();

            foreach (var item in distinctValues)
            {
                var amount = (from x in ListData
                              where x.Country.Name == item
                              select x.Value).Sum();
                meh.Add(new PieSeries
                {
                    Title = item,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(amount) }
                });
            }

            IncomePieChart = meh;
        }
        #endregion
    }
}
