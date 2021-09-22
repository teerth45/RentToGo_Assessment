using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentToGo_Assessment.Models
{
    class Customer
    {
        public string CustUsername { get; set; }

        public string CustName { get; set; }

        public int CustPhnNumber { get; set; }

        public string CustAddress { get; set; }

        public string CustPassword { get; set; }
    }
}