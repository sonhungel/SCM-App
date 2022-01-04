using LiveCharts;
using LiveCharts.Wpf;
using SCMApp.Constants;
using SCMApp.Constants.Enum;
using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class ProfitViewModel : ViewModelBase, IPageViewModel
    {
        public ProfitViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            SeriesCollectionCartesianChart = new SeriesCollection()
            {
                new LineSeries()
                {
                    Title = "Doanh thu",
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
        }
        public string NamePage => CommonConstants.ProfitPageViewName;

        public string FunctionName => CommonConstants.ProfitFunctionName;

        public List<TimeFilterEnum> ListFilter { get; set; }

        public TimeFilterEnum SelectedFilter { get; set; }

        //CartesianChart
        public SeriesCollection SeriesCollectionCartesianChart { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> FormatterCartesianChart { get; set; }

        //PieChart

        public SeriesCollection SeriesCollectionPieChart { get; set; }

        public Func<ChartPoint, string> FormatterPieChart { get; set; }

        public void Construct()
        {
        }
    }
}
