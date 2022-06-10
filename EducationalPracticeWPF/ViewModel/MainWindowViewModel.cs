using EducationalPracticeBL.Data;
using EducationalPracticeBL.Model;
using EducationalPracticeWPF.Model.Command;
using EducationalPracticeWPF.Service;
using EducationalPracticeWPF.View;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Printing;
using System.Windows.Documents;

namespace EducationalPracticeWPF.ViewModel
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            #region Commands
            OpenFileCommand = new LambdaCommand(OnOpenFileCommand, CanOpenFileCommand);
            SaveFileCommand = new LambdaCommand(OnSaveFileCommand, CanSaveFileCommand);
            PrintFileCommand = new LambdaCommand(OnPrintFileCommand, CanPrintFileCommand);
            FullTableView = new LambdaCommand(OnFullTableView, CanFullTableView);
            #endregion
            //UpdateIncomePieChart();
        }

        #region ActivePage
        private Page _ActivePage = new Default();

        public Page ActivePage
        {
            get => _ActivePage;
            set => Set(ref _ActivePage, value);
        }
        #endregion

        #region OpenFileCommand
        public ICommand OpenFileCommand { get; }

        private bool CanOpenFileCommand(object p) => true;
        private void OnOpenFileCommand(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.CheckFileExists)
                {
                    ListData = ElectricityGenerationDataService.Load(openFileDialog.FileName);
                }
            }
        }
        #endregion

        #region SaveFileCommand
        public ICommand SaveFileCommand { get; }

        private bool CanSaveFileCommand(object p) => true;
        private void OnSaveFileCommand(object p)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                ElectricityGenerationDataService.Save(saveFileDialog.FileName, ListData);
            }
        }
        #endregion

        #region PrintFileCommand
        public ICommand PrintFileCommand { get; }

        private bool CanPrintFileCommand(object p) => true;
        private void OnPrintFileCommand(object p)
        {
            PrintDialog printDialog = new();
            FlowDocument doc = new FlowDocument(new Paragraph(new Run(ElectricityGenerationDataService.CreateCSVText(ListData))));
            doc.Name = "CSV_print";
            IDocumentPaginatorSource idpSource = doc;
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }
        #endregion

        #region FullTableView
        public ICommand FullTableView { get; }

        private bool CanFullTableView(object p) => true;
        private void OnFullTableView(object p)
        {
            var vm = new FullTableViewModel(ListData);
            var pg = new FullTable();
            pg.DataContext = vm;
            ActivePage = pg;
        }
        #endregion

        #region SelectedPath
        private string _SelectedPath;

        public string SelectedPath
        {
            get => _SelectedPath;
            set => Set(ref _SelectedPath, value);
        }
        #endregion

        #region ListData
        private List<ElectricityGeneration> _ListData = null;
        public List<ElectricityGeneration> ListData
        {
            get => _ListData;
            set => Set(ref _ListData, value);
        }
        #endregion

        //#region IncomePieChart
        //private SeriesCollection _IncomePieChart;
        //public SeriesCollection IncomePieChart
        //{
        //    get => _IncomePieChart;
        //    set => Set(ref _IncomePieChart, value);
        //}
        //#endregion

        //#region UpdateIncomePieChart
        //private void UpdateIncomePieChart()
        //{
        //    var meh = new SeriesCollection();

        //    var distinctValues = ListData.Select(p => p.Country.Name)
        //                                 .Distinct()
        //                                 .ToList();

        //    foreach (var item in distinctValues)
        //    {
        //        var amount = (from x in ListData
        //                      where x.Country.Name == item
        //                      select x.Value).Sum();
        //        meh.Add(new PieSeries
        //        {
        //            Title = item,
        //            Values = new ChartValues<ObservableValue> { new ObservableValue(amount) }
        //        });
        //    }

        //    IncomePieChart = meh;
        //}
        //#endregion
    }
}
