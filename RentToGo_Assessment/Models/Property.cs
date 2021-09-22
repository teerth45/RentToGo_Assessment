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
    class Property
    {
        public int Id { get; set; }

        public string PropertyName { get; set; }

        public int PropertyRent { get; set; }

        public int PropertyRoom { get; set; }

        public int PropertyBath { get; set; }

        public string PropertyAddress { get; set; }
    }
}