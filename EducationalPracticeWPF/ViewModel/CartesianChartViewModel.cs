using EducationalPracticeBL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Windows.Media;

namespace EducationalPracticeWPF.ViewModel
{
    internal class CartesianChartViewModel : ViewModel
    {
        public CartesianChartViewModel(ObservableCollection<ElectricityGeneration> electricityGenerations)
        {
            ListData = electricityGenerations;
            SelectCountries();
            YFormatter = value => $"{value} TW/h";
            Labels = new[] { "2000", "2001", "2002", 
                "2003", "2004", "2005", "2006", 
                "2007", "2008", "2009", "2010",
                "2011", "2012", "2013", "2014", 
                "2015", "2016", "2017", "2018", "2019" };
        }

        private void SelectCountries()
        {
            ListCountries = new ObservableCollection<Country>();
            var meh = ListData.Select(x => x.Country.Name).Distinct().ToList();
            meh.RemoveAt(0);
            foreach (var item in meh)
            {
                var tmp = ListData.Select(x => x.Country).Where(x => x.Name == item).FirstOrDefault();
                tmp.PropertyChanged += Tmp_PropertyChanged;
                ListCountries.Add(tmp);
            }
            ListCountries[1].isSelected = true;
        }

        private void Tmp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateChart();
        }

        #region Chart
        private SeriesCollection _Chart;
        public SeriesCollection Chart
        {
            get => _Chart;
            set => Set(ref _Chart, value);
        }
        #endregion

        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }

        #region UpdateChart
        private void UpdateChart()
        {
            Chart = new SeriesCollection();
            foreach (var item in ListCountries)
            {
                if (item.isSelected)
                {
                    var ChartValue = new ChartValues<ObservableValue>();
                    var ctr = ListData.Select(x => x).Where(x => x.Country.Name == item.Name);
                    foreach (var values in ctr)
                    {
                        ChartValue.Add(new ObservableValue(values.Value));
                    }
                    Chart.Add(new LineSeries
                    {
                        Title = item.Name,
                        Values = ChartValue,
                    });
                }
                else
                {
                    continue;
                }
            }
        }
        #endregion

        #region ListData
        private ObservableCollection<ElectricityGeneration> _ListData;
        public ObservableCollection<ElectricityGeneration> ListData
        {
            get => _ListData;
            set => Set(ref _ListData, value);
        }
        #endregion

        #region ListCountries
        private ObservableCollection<Country> _ListCountries;
        public ObservableCollection<Country> ListCountries
        {
            get => _ListCountries;
            set => Set(ref _ListCountries, value);
        }
        #endregion
    }
}
