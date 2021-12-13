using LiveCharts;
using LiveCharts.Wpf;
using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OverviewViewModel : ViewModelBase, IPageViewModel
    {
        public OverviewViewModel(IScreenManager screenManager) : base(screenManager)
        {
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Thu",
                    Values = new ChartValues<double> {5,10,15,20,25,30,35}
                }
            };

            SeriesCollection.Add(new ColumnSeries()
            {
                Title = "Chi",
                Values = new ChartValues<double> { 3, 7, 13, 19,21,27,34 }
            });

            BarLabels = new[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };

            Formatter = value => value.ToString("N");
        }
        public string NamePage => CommonConstants.OverviewPageViewName;

        public string FunctionName => CommonConstants.OverviewFunctionName;

        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double,string> Formatter { get; set; }

        public void Construct()
        {
        }
    }
}
