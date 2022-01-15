﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.Event_Delegate
{
    public delegate void ReloadAfterCloseSubViewDelgate(bool isReloadCurrentPageView);
    public class ReloadAfterCloseSubView
    {
        public static ReloadAfterCloseSubViewDelgate Instance;

        public static ReloadAfterCloseSubViewDelgate ReloadMainUser;
    }
}
