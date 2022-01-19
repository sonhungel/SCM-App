using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCMApp.Constants.Enum
{
    public enum TimeFilterEnum
    {
        [Display(Name = "Lọc theo Tuần")]
        Week,

        [Display(Name = "Lọc theo Tháng")]
        Month,
    }
}
