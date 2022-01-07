using LiveCharts;
using LiveCharts.Wpf;
using SCMApp.Constants;
using SCMApp.Constants.Enum;
using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class ProfitViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IProfitWebAPI _profitWebAPI;
        public ProfitViewModel(IProfitWebAPI profitWebAPI,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _profitWebAPI = profitWebAPI;
            FilterCommand = new RelayCommand(p => Filter());

            SeriesCollectionCartesianChart = new SeriesCollection()
            {
                new LineSeries()
                {
                    Title = "Lợi nhuận",
                    Values = new ChartValues<double> {20,5,19,4,25,55,35}
                }
            };

            BarLabels = new[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };

            FormatterCartesianChart = value => value.ToString("N");

            FormatterPieChart = value => string.Format("{0} ({1:P})", value.Y, value.Participation);

            SeriesCollectionPieChart = new SeriesCollection()
            {
                new PieSeries()
                {
                    Title = "Thu",
                    DataLabels = true,
                    Values = new ChartValues<double>{ 50},
                    LabelPoint = FormatterPieChart
                },
                new PieSeries()
                {
                    Title = "Chi",
                    DataLabels = true,
                    Values = new ChartValues<double>{ 30},
                    LabelPoint = FormatterPieChart
                }
            };
            ListFilter = new List<TimeFilterEnum>() { TimeFilterEnum.Week, TimeFilterEnum.Month, TimeFilterEnum.Year };

            SelectedFilter = TimeFilterEnum.Week;
            ProfitByFilterName = CommonConstants.TurnoverInWeek;
        }

        public ICommand FilterCommand { get; set; }

        public string NamePage => CommonConstants.ProfitPageViewName;

        public string FunctionName => CommonConstants.ProfitFunctionName;

        public List<TimeFilterEnum> ListFilter { get; set; }

        private TimeFilterEnum _selectedFilter { get; set; }
        public TimeFilterEnum SelectedFilter 
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;  
                OnPropertyChanged(nameof(SelectedFilter));
            }
        }

        public string ProfitByFilterName { get; set; }

        //CartesianChart
        public SeriesCollection SeriesCollectionCartesianChart { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> FormatterCartesianChart { get; set; }

        //PieChart

        public SeriesCollection SeriesCollectionPieChart { get; set; }

        public Func<ChartPoint, string> FormatterPieChart { get; set; }
        public bool IsLoaded { get; set; }

        public void Construct()
        {
            IsLoaded = true;
            OnPropertyChanged(nameof(SelectedFilter));
        }

        private void Filter()
        {
            if (_selectedFilter == TimeFilterEnum.Week)
            {
                ProfitByFilterName = CommonConstants.TurnoverInWeek;
                BarLabels = CommonConstants.BarLabelsByWeek;

                SeriesCollectionCartesianChart = new SeriesCollection()
                {
                    new LineSeries()
                    {
                        Title = "Lợi nhuận",
                        Values = new ChartValues<double> {20,5,19,4,25,55,35}
                    }
                };
                SeriesCollectionPieChart = new SeriesCollection()
                {
                    new PieSeries()
                    {
                        Title = "Thu",
                        DataLabels = true,
                        Values = new ChartValues<double>{ 20},
                        LabelPoint = FormatterPieChart
                    },
                    new PieSeries()
                    {
                        Title = "Chi",
                        DataLabels = true,
                        Values = new ChartValues<double>{ 60},
                        LabelPoint = FormatterPieChart
                    }
                };
            }
            else if (_selectedFilter == TimeFilterEnum.Month)
            {
                ProfitByFilterName = CommonConstants.TurnoverInMonth;
                BarLabels = CommonConstants.BarLabelsByMonth;
                SeriesCollectionCartesianChart = new SeriesCollection()
                {
                    new LineSeries()
                    {
                        Title = "Lợi nhuận",
                        Values = new ChartValues<double> {20,5,19,4}
                    }
                };

                SeriesCollectionPieChart = new SeriesCollection()
                {
                    new PieSeries()
                    {
                        Title = "Thu",
                        DataLabels = true,
                        Values = new ChartValues<double>{ 20},
                        LabelPoint = FormatterPieChart
                    },
                    new PieSeries()
                    {
                        Title = "Chi",
                        DataLabels = true,
                        Values = new ChartValues<double>{ 80},
                        LabelPoint = FormatterPieChart
                    }
                };
            }
            else
            {
                ProfitByFilterName = CommonConstants.TurnoverInYear;
                BarLabels = CommonConstants.BarLabelsByYear;
                SeriesCollectionCartesianChart = new SeriesCollection()
                {
                    new LineSeries()
                    {
                        Title = "Lợi nhuận",
                        Values = new ChartValues<double> {20,5,19,4,25,55,35,9,12,56,29,57}
                    }
                };

                SeriesCollectionPieChart = new SeriesCollection()
                {
                    new PieSeries()
                    {
                        Title = "Thu",
                        DataLabels = true,
                        Values = new ChartValues<double>{ 50},
                        LabelPoint = FormatterPieChart
                    },
                    new PieSeries()
                    {
                        Title = "Chi",
                        DataLabels = true,
                        Values = new ChartValues<double>{ 30},
                        LabelPoint = FormatterPieChart
                    }
                };
            }
            OnPropertyChanged(nameof(SeriesCollectionCartesianChart));
            OnPropertyChanged(nameof(BarLabels));
            OnPropertyChanged(nameof(SeriesCollectionPieChart));
            OnPropertyChanged(nameof(ProfitByFilterName));
        }
    }
}
