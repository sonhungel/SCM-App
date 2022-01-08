using LiveCharts;
using LiveCharts.Wpf;
using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OverviewViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IProfitWebAPI _profitWebAPI;
        private readonly IUserWebAPI _userWebAPI;
        private readonly IInventoryWebAPI _inventoryWebAPI;
        public OverviewViewModel(IProfitWebAPI profitWebAPI, IUserWebAPI userWebAPI, IInventoryWebAPI inventoryWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _profitWebAPI = profitWebAPI;
            _userWebAPI = userWebAPI;
            _inventoryWebAPI = inventoryWebAPI;
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

        public int ProfitInDay
        {
            get;
            set;
        }

        public int TurnoverInDay
        {
            get;
            set;
        }

        public int NumberOfUser
        {
            get;
            set;
        }

        public int ProfitInMonth
        {
            get;
            set;
        }

        public int TurnoverInMonth
        {
            get;
            set;
        }

        public int SpendingInMonth
        {
            get;
            set;
        }

        public int IncomeInMonth
        {
            get;
            set;
        }

        public int InventoryQuantity
        {
            get;
            set;
        }

        public int OutOfStockQuantity
        {
            get;
            set;
        }

        public int OutOfStockSoonQuantity
        {
            get;
            set;
        }

        public int DefectiveStockQuantity
        {
            get;
            set;
        }
            

        public Func<double,string> Formatter { get; set; }
        public bool IsLoaded { get; set; }

        public void Construct()
        {
            IsLoaded = true;
            // Get data for overview
        }
    }
}
