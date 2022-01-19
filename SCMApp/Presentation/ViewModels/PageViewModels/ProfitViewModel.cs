using LiveCharts;
using LiveCharts.Wpf;
using SCMApp.Constants;
using SCMApp.Constants.Enum;
using SCMApp.Helper;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Linq;
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

            SeriesCollectionCartesianChart = new SeriesCollection();

            BarLabels = new[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };

            FormatterCartesianChart = value => value.ToString("N");

            FormatterPieChart = value => string.Format("{0} ({1:P})", MoneyHelper.IntToStandardMoneyStringWithTail(value.Y), value.Participation);

            SeriesCollectionPieChart = new SeriesCollection();


            ListFilter = new List<TimeFilterEnum>() { TimeFilterEnum.Week, TimeFilterEnum.Month };
            _selectedFilter = TimeFilterEnum.Week;
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
            Filter();

            OnPropertyChanged(nameof(SelectedFilter));
        }

        private void Filter()
        {
            if (_selectedFilter == TimeFilterEnum.Week)
            {
                GetReportResponseDTO resultReport;
                using (new WaitCursorScope())
                {
                    resultReport = _profitWebAPI.GetDailyReport(Token);
                }

                SeriesCollectionCartesianChart.Clear();
                SeriesCollectionPieChart.Clear();
                var totalPaid = resultReport.weekly.weeklyPaid.Sum(x => x.paid);
                var totalCost = resultReport.weekly.weeklyCost.Sum(x => x.cost);
                ProfitByFilterName = CommonConstants.TurnoverInWeek;
                BarLabels = CommonConstants.BarLabelsByWeek;

                CreateValueForLineSeriesChartByWeek(resultReport.weekly);
                SeriesCollectionPieChart.Add(new PieSeries()
                {
                    Title = "Thu",
                    DataLabels = true,
                    Values = new ChartValues<double> { totalPaid.Value },
                    LabelPoint = FormatterPieChart
                });
                SeriesCollectionPieChart.Add(new PieSeries()
                {
                    Title = "Chi",
                    DataLabels = true,
                    Values = new ChartValues<double> { totalCost.Value },
                    LabelPoint = FormatterPieChart
                });
            }
            else
            {
                IList<IList<IList<MoreDetailDTO>>> resultReport;
                using (new WaitCursorScope())
                {
                    resultReport = _profitWebAPI.GetMonthlyReport(Token);
                }
                SeriesCollectionCartesianChart.Clear();
                SeriesCollectionPieChart.Clear();

                var MonthlyPaid = resultReport.ElementAt(0);
                var MonthlyCost = resultReport.ElementAt(1);
                var TotalMonthlyPaid = MonthlyPaid.Sum(x => 
                {
                    return x.Sum(x => x?.paid);

                });
                var TotalMonthlyCost = MonthlyCost.Sum(x =>
                {
                    return x.Sum(x => x?.cost);
                });

                ProfitByFilterName = CommonConstants.TurnoverInMonth;
                BarLabels = CommonConstants.BarLabelsByMonth;
                CreateValueForLineSeriesChartByMonth(MonthlyPaid, MonthlyCost);

                SeriesCollectionPieChart.Add(new PieSeries()
                {
                    Title = "Thu",
                    DataLabels = true,
                    Values = new ChartValues<double> { TotalMonthlyPaid.Value },
                    LabelPoint = FormatterPieChart
                });

                SeriesCollectionPieChart.Add(new PieSeries()
                {
                    Title = "Chi",
                    DataLabels = true,
                    Values = new ChartValues<double> { TotalMonthlyCost.Value },
                    LabelPoint = FormatterPieChart
                });
            }
            
            OnPropertyChanged(nameof(SeriesCollectionCartesianChart));
            OnPropertyChanged(nameof(BarLabels));
            OnPropertyChanged(nameof(SeriesCollectionPieChart));
            OnPropertyChanged(nameof(ProfitByFilterName));
        }
        private void CreateValueForLineSeriesChartByWeek(WeeklyReportDTO weeklyReportDTO)
        {
            var Paidvalues = new ChartValues<double>();
            var datePaid = weeklyReportDTO.weeklyPaid.OrderBy(x => x.date).ToList();
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
            SeriesCollectionCartesianChart.Add(
                new LineSeries()
                {
                    Title = "Doanh thu",
                    Values = Paidvalues
                });

            var CostValue = new ChartValues<double>();

            var dateCost = weeklyReportDTO.weeklyCost.OrderBy(x => x.date).ToList();
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

            SeriesCollectionCartesianChart.Add(new LineSeries()
            {
                Title = "Chi phi",
                Values = CostValue
            });

        }
        private void CreateValueForLineSeriesChartByMonth(IList<IList<MoreDetailDTO>> monthlyPaid, 
            IList<IList<MoreDetailDTO>> monthlyCost)
        {
            var monthlyPaidFilted = monthlyPaid.Select(x => x.ElementAt(0)).ToList();
            var monthlyCostFilted = monthlyCost.Select(x => x.ElementAt(0)).ToList();

            var Paidvalues = new ChartValues<double>();
            monthlyPaidFilted.ForEach(x =>
            {
                if(x == null)
                {
                    Paidvalues.Add(0);
                }    
                else if (x.paid.HasValue)
                {
                    Paidvalues.Add(x.paid.Value);
                }
            }
            );
            SeriesCollectionCartesianChart.Add(
                new LineSeries()
                {
                    Title = "Doanh thu",
                    Values = Paidvalues
                });

            var CostValues = new ChartValues<double>();
            monthlyCostFilted.ForEach(x =>
            {
                if (x == null)
                {
                    CostValues.Add(0);
                }
                else if (x.cost.HasValue)
                {
                    CostValues.Add(x.cost.Value);
                }
            }
            );
            SeriesCollectionCartesianChart.Add(
                new LineSeries()
                {
                    Title = "Chi phí",
                    Values = CostValues
                });
        }
    }
}
