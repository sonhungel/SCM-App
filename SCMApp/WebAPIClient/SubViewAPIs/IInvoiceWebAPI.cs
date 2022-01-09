﻿using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IInvoiceWebAPI
    {
        void CreateInvoice();
        void DeleteInvoice();
        IList<Order> GetAllInvoice(string token);
    }
}