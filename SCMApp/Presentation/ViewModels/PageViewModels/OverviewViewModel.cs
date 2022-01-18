using LiveCharts;
using LiveCharts.Wpf;
using SCMApp.Constants;
using SCMApp.Helper;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Linq;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OverviewViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IProfitWebAPI _profitWebAPI;
        public OverviewViewModel(IProfitWebAPI profitWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _profitWebAPI = profitWebAPI;
            SeriesCollection = new SeriesCollection();
            BarLabels = new[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };

            Formatter = value => value.ToString("N");
        }
        public string NamePage => CommonConstants.OverviewPageViewName;

        public string FunctionName => CommonConstants.OverviewFunctionName;

        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        private int _profitInDay;
        public string ProfitInDay => MoneyHelper.IntToStandardMoneyStringWithTail(_profitInDay);

        private int _costInDay;
        public string CostInDay => MoneyHelper.IntToStandardMoneyStringWithTail(_costInDay);

        public int NumberOfUser
        {
            get;
            set;
        }

        private int _paidInMonth;
        public string PaidInMonth => MoneyHelper.IntToStandardMoneyStringWithTail(_paidInMonth);

        private int _spendingInMonth;
        public string SpendingInMonth => MoneyHelper.IntToStandardMoneyStringWithTail(_spendingInMonth);

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

        public Func<double, string> Formatter { get; set; }
        public bool IsLoaded { get; set; }

        public void Construct()
        {
            IsLoaded = true;
            // Get data for overview
            var result = _profitWebAPI.GetDailyReport(Token);
            var daily = result.daily;
            NumberOfUser = daily.user;
            CreateValueForChart(result.weekly);


            if (daily.paid.HasValue)
            {
                _profitInDay = daily.paid.Value;
            }
            if (daily.cost.HasValue)
            {
                _costInDay = daily.cost.Value;
            }

        }

        private void CreateValueForChart(WeeklyReportDTO weekly)
        {
            SeriesCollection.Clear();
            var Paidvalues = new ChartValues<double>();
            var datePaid = weekly.weeklyPaid.OrderBy(x => x.date).ToList();
            datePaid.ForEach(x =>
            {
                switch (x.date.Value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        {
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        {
                            if (Paidvalues.Count < 1)
                            {
                                Paidvalues.Add(0);
                            }
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        {
                            if (Paidvalues.Count < 2)
                            {
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                            }
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Thursday:
                        {
                            if (Paidvalues.Count < 3)
                            {
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                            }
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Friday:
                        {
                            if (Paidvalues.Count < 4)
                            {
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                            }
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Saturday:
                        {
                            if (Paidvalues.Count < 5)
                            {
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                            }
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Sunday:
                        {
                            if (Paidvalues.Count < 6)
                            {
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                                Paidvalues.Add(0);
                            }
                            if (x.paid.HasValue)
                            {
                                Paidvalues.Add(x.paid.Value);
                            }
                            else
                            {
                                Paidvalues.Add(0);
                            }
                        }
                        break;

                }
            }
            );
            for (int i = Paidvalues.Count; i < 7; i++)
            {
                Paidvalues.Add(0);
            }
            SeriesCollection.Add(
                new ColumnSeries()
                {
                    Title = "Thu",
                    Values = Paidvalues
                });

            var CostValue = new ChartValues<double>();

            var dateCost = weekly.weeklyCost.OrderBy(x => x.date).ToList();
            dateCost.ForEach(x =>
            {
                switch (x.date.Value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        {
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        {
                            if (CostValue.Count < 1)
                            {
                                CostValue.Add(0);
                            }
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        {
                            if (CostValue.Count < 2)
                            {
                                CostValue.Add(0);
                                CostValue.Add(0);
                            }
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Thursday:
                        {
                            if (CostValue.Count < 3)
                            {
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                            }
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Friday:
                        {
                            if (CostValue.Count < 4)
                            {
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                            }
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Saturday:
                        {
                            if (CostValue.Count < 5)
                            {
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                            }
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;
                    case DayOfWeek.Sunday:
                        {
                            if (CostValue.Count < 6)
                            {
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                                CostValue.Add(0);
                            }
                            if (x.cost.HasValue)
                            {
                                CostValue.Add(x.cost.Value);
                            }
                            else
                            {
                                CostValue.Add(0);
                            }
                        }
                        break;

                }
            }
            );
            for (int i = CostValue.Count; i < 7; i++)
            {
                CostValue.Add(0);
            }

            SeriesCollection.Add(new ColumnSeries()
            {
                Title = "Chi",
                Values = CostValue
            });

            OnPropertyChanged(nameof(SeriesCollection));
        }
    }
}
