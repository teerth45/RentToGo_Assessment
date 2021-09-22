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
    class Agent
    {
        public int Id { get; set; }

        public string AgentName { get; set; }

        public string AgentEmail { get; set; }

        public string AgentPhnNumber { get; set; }

        public string AgentOffice { get; set; }
    }
}