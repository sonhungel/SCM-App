using System.Collections.Generic;

namespace SCMApp.Constants
{
    public static class CommonConstants
    {
        public const string ImportPageViewName = "ImportPageView";
        public const string InventoryPageViewName = "InventoryPageView";
        public const string OrdersPageViewName = "OrdersPageView";
        public const string OverviewPageViewName = "OverviewPageView";
        public const string PartnersPageViewName = "PartnersPageView";
        public const string ProfitPageViewName = "ProfitPageView";
        public const string RevenuePageViewName = "RevenuePageView";
        public const string StockPageViewName = "StockPageView";
        public const string HRMPageViewName = "HumanResourceManagementView";

        // Function name
        public const string ImportFunctionName = "Nhập hàng";
        public const string InventoryFunctionName = "Tồn kho";
        public const string OrdersFunctionName = "Đơn hàng";
        public const string OverviewFunctionName = "Tổng quan";
        public const string PartnersFunctionName = "Đối tác";
        public const string ProfitFunctionName = "Tài chính";
        public const string RevenueFunctionName = "Doanh thu";
        public const string StockFunctionName = "Hàng hoá";
        public const string HRMFunctionName = "Quản lý nhân sự";

        // Title

        public const string EditUser = "Chỉnh sửa thông tin người dùng";
        public const string UserProfile = "Thông tin người dùng";

        // User Role
        public static readonly List<string> UserRole = new List<string>() { "Quản lý", "Nhân viên" };

        // Profit

        public const string TurnoverInWeek = "Dòng tiền trong tuần";
        public const string TurnoverInMonth = "Dòng tiền trong tháng";

        public static readonly string[] BarLabelsByWeek = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };
        public static readonly string[] BarLabelsByMonth = { "Tuần 1", "Tuần 2", "Tuần 3", "Tuần 4", "Tuần 5" };


        public static readonly char[] Numberic = { '0', '1', '2', '3','4', '5', '6', '7', '8', '9' };

        public const string RED = "1";
        public const string YELLOW = "2";
        public const string BlUE = "3";
    }
}
