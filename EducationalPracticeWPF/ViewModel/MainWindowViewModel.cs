using EducationalPracticeBL.Data;
using EducationalPracticeBL.Model;
using EducationalPracticeWPF.Model.Command;
using EducationalPracticeWPF.Service;
using EducationalPracticeWPF.View;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using EducationalPracticeWPF.View.Exercises;
using System.Collections.ObjectModel;

namespace EducationalPracticeWPF.ViewModel
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly DialogVisitor Visitor = new();

        public MainWindowViewModel()
        {
            #region Commands
            OpenFileCommand       = new LambdaCommand(OnOpenFileCommand, CanOpenFileCommand);
            SaveFileCommand       = new LambdaCommand(OnSaveFileCommand, CanSaveFileCommand);
            PrintFileCommand      = new LambdaCommand(OnPrintFileCommand, CanPrintFileCommand);
            FullTableView         = new LambdaCommand(OnFullTableView, CanFullTableView);
            Exercise1Command      = new LambdaCommand(OnExercise1Command, CanExercise1Command);
            Exercise2Command      = new LambdaCommand(OnExercise2Command, CanExercise2Command);
            Exercise3Command      = new LambdaCommand(OnExercise3Command, CanExercise3Command);
            PrintResultCommand    = new LambdaCommand(OnPrintResultCommand, CanPrintResultCommand);
            PieChartCommand       = new LambdaCommand(OnPieChartCommand, CanPieChartCommand);
            CartesianChartCommand = new LambdaCommand(OnCartesianChartCommand, CanCartesianChartCommand);
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

        private bool CanSaveFileCommand(object p) => ListData != null;
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


        #region Exercise1Command
        public ICommand Exercise1Command { get; }

        private bool CanExercise1Command(object p) => ListData != null;
        private void OnExercise1Command(object p)
        {
            var pg = new Exercise1();
            pg.DataContext = ExerciseService.Exercise1(ListData);
            ActivePage = pg;
        }
        #endregion

        #region Exercise2Command
        public ICommand Exercise2Command { get; }

        private bool CanExercise2Command(object p) => ListData != null;
        private void OnExercise2Command(object p)
        {
            var pg = new Exercise2();
            pg.DataContext = ExerciseService.Exercise2(ListData);
            ActivePage = pg;
        }
        #endregion

        #region Exercise3Command
        public ICommand Exercise3Command { get; }

        private bool CanExercise3Command(object p) => ListData != null;
        private void OnExercise3Command(object p)
        {
            var pg = new Exercise3();
            pg.DataContext = ExerciseService.Exercise3(ListData);
            ActivePage = pg;
        }
        #endregion

        #region PrintResultCommand
        public ICommand PrintResultCommand { get; }

        private bool CanPrintResultCommand(object p) => ListData != null;
        private void OnPrintResultCommand(object p)
        {
            PrintDialog printDialog = new();
            var result = $"Exercise 1\n" +
                $"This query displays the country that produced the most electricity in 2015\n";
            var tmp = ExerciseService.Exercise1(ListData);
            foreach (var item in tmp)
            {
                result += $"{item.Country.Code}\t{item.Country.Name}\t{item.Year}\t{item.Value}\tTW/h\n";
            }
            result += $"\nExercise 2\n";
            tmp = ExerciseService.Exercise2(ListData);
            foreach (var item in tmp)
            {
                result += $"{item.Country.Code}\t{item.Country.Name}\t{item.Year}\t{item.Value}\tTW/h\n";
            }
            result += $"\nExercise 3\n";
            tmp = ExerciseService.Exercise3(ListData);
            foreach (var item in tmp)
            {
                result += $"{item.Country.Code}\t{item.Country.Name}\t{item.Year}\t{item.Value}\tTW/h\n";
            }
            FlowDocument doc = new FlowDocument(new Paragraph(new Run(result)));
            doc.Name = "CSV_print";
            IDocumentPaginatorSource idpSource = doc;
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }
        #endregion

        #region PrintFileCommand
        public ICommand PrintFileCommand { get; }

        private bool CanPrintFileCommand(object p) => ListData != null;
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

        private bool CanFullTableView(object p) => ListData != null;
        private void OnFullTableView(object p)
        {
            var vm = new FullTableViewModel(ListData);
            var pg = new FullTable();
            pg.DataContext = vm;
            ActivePage = pg;
        }
        #endregion

        #region PieChartCommand
        public ICommand PieChartCommand { get; }

        private bool CanPieChartCommand(object p) => ListData != null;
        private void OnPieChartCommand(object p)
        {
            var vm = new PieChartViewModel(ListData);
            var pg = new PieChart();
            pg.DataContext = vm;
            ActivePage = pg;
        }
        #endregion

        #region CartesianChartCommand
        public ICommand CartesianChartCommand { get; }

        private bool CanCartesianChartCommand(object p) => ListData != null;
        private void OnCartesianChartCommand(object p)
        {
            var vm = new CartesianChartViewModel(ListData);
            var pg = new CartesianChart();
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
        private ObservableCollection<ElectricityGeneration> _ListData = null;
        public ObservableCollection<ElectricityGeneration> ListData
        {
            get => _ListData;
            set => Set(ref _ListData, value);
        }
        #endregion
    }
}
